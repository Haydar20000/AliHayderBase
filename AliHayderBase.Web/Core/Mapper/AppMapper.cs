using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliHayderBase.Shared.DTOs.Request;
using AliHayderBase.Shared.Models;


namespace AliHayderBase.Web.Core.Mapper
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