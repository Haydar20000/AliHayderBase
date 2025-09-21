

using AliHayderBase.Shared.DTOs.Request;
using AliHayderBase.Shared.DTOs.Response;
using AliHayderBase.Shared.Models;



namespace AliHayderBase.Web.Core.Interface
{
    public interface IAuthRepository : IRepository<User>
    {
        Task<SystemResponseDto> RegisterAsync(RegisterRequestDto request);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
        Task<SystemResponseDto> VerifyEmailAsync(VerifyEmailRequestDto request);
        Task<SystemResponseDto> ForgotPasswordAsync(ForgotPasswordRequestDto request);
        Task<SystemResponseDto> ResetPasswordAsync(ResetPasswordRequestDto request);
        Task<SystemResponseDto> ResendEmailConfirmation(ResendEmailConfirmationRequestDto request);
        Task<JwtResponseDto> LoginWithRefreshToken(string refreshToken);
        JwtResponseDto ValidateToken(string Token);
    }
}
