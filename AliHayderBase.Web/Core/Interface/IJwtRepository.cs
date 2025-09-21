using AliHayderBase.Web.Dtos.Request;
using AliHayderBase.Web.Dtos.Response;

namespace AliHayderBase.Web.Core.Interface
{
    public interface IJwtRepository
    {
         JwtResponseDto GenerateAccessToken(JwtRequestDto request);
         JwtResponseDto GenerateRefreshToken();
         bool ReadJwtToken(string token);
    }
}