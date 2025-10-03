using AliHayderBase.Shared.DTOs.Request;
using AliHayderBase.Shared.DTOs.Response;
using Microsoft.AspNetCore.Components.Authorization;

namespace AliHayderBase.Shared.Core.Interfaces
{
    public interface IAuthService
    {
        // Auth Methods 
        // Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto request);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
        Task LogoutAsync();

        // Token 
        Task<bool> RefreshSessionAsync();
        void StartAutoRefresh();
        event Action? OnLogin;
        event Action? OnLogout;

        //AuthenticationState
        Task<AuthenticationState> GetAuthenticationStateAsync();
        bool IsInRole(string role);
        string? GetUserName();
        Task<(string? UserName, bool IsAdmin)> GetUserInfoAsync();

    }
}