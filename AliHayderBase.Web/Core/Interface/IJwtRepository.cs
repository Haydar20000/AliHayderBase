using AliHayderBase.Shared.DTOs.Request;
using AliHayderBase.Shared.DTOs.Response;


namespace AliHayderBase.Web.Core.Interface
{
    public interface IJwtRepository
    {
        JwtResponseDto GenerateAccessToken(JwtRequestDto request);
        JwtResponseDto GenerateRefreshToken();
        bool ReadJwtToken(string token);
    }
}