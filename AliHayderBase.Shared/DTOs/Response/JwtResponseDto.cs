using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliHayderBase.Shared.DTOs.Response
{
    public class JwtResponseDto
    {
        public bool IsSuccessful { get; set; } = true;
        public List<string> Errors { get; set; } = [];
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}