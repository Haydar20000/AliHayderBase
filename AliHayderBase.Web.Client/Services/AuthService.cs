
using System.Net.Http.Json;
using AliHayderBase.Shared.DTOs.Request;
using AliHayderBase.Shared.DTOs.Response;
using AliHayderBase.Web.Client.Core.Interface;

namespace AliHayderBase.Web.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto request)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", request);
            return await response.Content.ReadFromJsonAsync<AuthResponseDto>();
        }

        public async Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto request)
        {
            var response = await _http.PostAsJsonAsync("api/auth/register", request);
            return await response.Content.ReadFromJsonAsync<AuthResponseDto>();
        }
    }
}