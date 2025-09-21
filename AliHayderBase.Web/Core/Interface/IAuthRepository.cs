

using AliHayderBase.Web.Core.Domain;
using AliHayderBase.Web.Core.Interface;
using AliHayderBase.Web.Dtos.Request;
using AliHayderBase.Web.Dtos.Response;


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
