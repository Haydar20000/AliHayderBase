
using System.Net.Http.Json;
using AliHayderBase.Shared.Core.Interfaces;
using AliHayderBase.Shared.DTOs.Request;
using AliHayderBase.Shared.DTOs.Response;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

public class WebAuthService : IAuthService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _http;
    public event Action? OnLogin;
    public event Action? OnLogout;
    private readonly WebAuthProvider _authProvider;

    public WebAuthService(HttpClient http, ILocalStorageService localStorage, WebAuthProvider authProvider)
    {
        _http = http;
        _localStorage = localStorage;
        _authProvider = authProvider;
        //Console.WriteLine("WebAuthService constructed.");
    }

    private CancellationTokenSource? _cts;

    public void StartAutoRefresh()
    {
        _cts = new CancellationTokenSource();
        _ = RunAutoRefreshAsync(_cts.Token);
    }

    private async Task RunAutoRefreshAsync(CancellationToken token)
    {
        var timer = new PeriodicTimer(TimeSpan.FromMinutes(25));

        try
        {
            while (await timer.WaitForNextTickAsync(token))
            {
                await RefreshSessionAsync();
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Auto-refresh cancelled.");
        }
    }


    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
    {
        var feedback = new AuthResponseDto();

        try
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", request);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                feedback.Errors.Add(error);
                feedback.IsSuccessful = false;
                return feedback;
            }

            var result = await response.Content.ReadFromJsonAsync<AuthResponseDto>();

            if (result is null || string.IsNullOrEmpty(result.Token))
            {
                feedback.Errors.Add("Invalid response from server.");
                feedback.IsSuccessful = false;
                return feedback;
            }

            await _localStorage.SetItemAsync("token", result.Token);
            await _localStorage.SetItemAsync("refreshToken", result.RefreshToken);
            await _localStorage.SetItemAsync("username", result.Username);
            await _localStorage.SetItemAsync("roles", result.Roles);

            feedback = result;
        }
        catch (Exception ex)
        {
            feedback.Errors.Add("Exception: " + ex.Message);
            feedback.IsSuccessful = false;
        }
        OnLogin?.Invoke(); // 🔥 This triggers WebAuthProvider to update AuthenticationState
        return feedback;
    }

    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync("token");
        await _localStorage.RemoveItemAsync("username");
        await _localStorage.RemoveItemAsync("roles");
        _cts?.Cancel();
        OnLogout?.Invoke();
    }


    public async Task<bool> RefreshSessionAsync()
    {
        var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");
        if (string.IsNullOrEmpty(refreshToken))
            return false;

        var response = await _http.PostAsJsonAsync("api/auth/refresh", refreshToken);

        if (!response.IsSuccessStatusCode)
            return false;

        var jwtDto = await response.Content.ReadFromJsonAsync<JwtResponseDto>();
        if (jwtDto is null || !jwtDto.IsSuccessful || string.IsNullOrEmpty(jwtDto.Token))
            return false;

        await _localStorage.SetItemAsync("token", jwtDto.Token);
        await _localStorage.SetItemAsync("refreshToken", jwtDto.RefreshToken);

        OnLogin?.Invoke(); // Notify state change
        StartAutoRefresh();
        return true;

    }

    public async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return await _authProvider.GetAuthenticationStateAsync();
    }

    public bool IsInRole(string role)
    {
        var state = _authProvider.GetAuthenticationStateAsync().Result;
        var user = state.User;
        return user.Identity?.IsAuthenticated == true && user.IsInRole(role);
    }

    public string? GetUserName()
    {
        var state = _authProvider.GetAuthenticationStateAsync().Result;
        var user = state.User;
        return user.Identity?.IsAuthenticated == true ? user.Identity.Name : null;

    }

    public async Task<(string? UserName, bool IsAdmin)> GetUserInfoAsync()
    {
        var state = await GetAuthenticationStateAsync();
        var user = state.User;

        if (user.Identity?.IsAuthenticated == true)
        {
            var name = GetUserName();
            var isAdmin = IsInRole("AdminAli");
            return (name, isAdmin);
        }
        return (null, false);
    }


}


