
using AliHayderBase.Shared.DTOs.Request;
using AliHayderBase.Shared.DTOs.Response;


namespace AliHayderBase.Web.Core.Interface
{
    public interface IExternalLoginRepository
    {
        Task<AuthResponseDto> GoogleLogin(GoogleLoginRequestDto request);
    }
}