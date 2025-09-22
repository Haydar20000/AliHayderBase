
using AliHayderBase.Shared.DTOs.Request;
using AliHayderBase.Shared.DTOs.Response;

namespace AliHayderBase.Web.Client.Core.Interface
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginRequestDto request);

        Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto request);
    }
}