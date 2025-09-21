using AliHayderBase.Web.Core.Domain;
using AliHayderBase.Web.Dtos.Request;


namespace AliHayderBase.Web.Dtos.Mappers
{
    public class AppMapper
    {
        public static User MapUserFromRegisterRequest(RegisterRequestDto request)
        {
            return new User
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
        }
        public static User MapUserFromAuthRequest(LoginRequestDto request)
        {
            return new User
            {
                Email = request.Email,
                UserName = request.Email,
            };
        }
    }
}