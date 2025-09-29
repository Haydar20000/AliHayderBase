using AliHayderBase.Shared.DTOs.Request;
using AliHayderBase.Shared.DTOs.Response;

namespace AliHayderBase.Shared.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);

        Task LogoutAsync();
        Task<bool> RefreshSessionAsync();
        // Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto request);
        void StartAutoRefresh();
        event Action? OnLogin;
        event Action? OnLogout;

    }
}