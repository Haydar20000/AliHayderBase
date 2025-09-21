using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliHayderBase.Shared.DTOs.Request;

namespace AliHayderBase.Web.Client.Services
{
    public class AuthService
    {
        private RegisterRequestDto registerRequestDto;
        private readonly HttpClient _http;
        public AuthService(HttpClient http)
        {
            _http = http;
        }

        //public async Task<Auth>
    }
}