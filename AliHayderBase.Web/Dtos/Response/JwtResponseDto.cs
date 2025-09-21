using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliHayderBase.Web.Dtos.Response
{
    public class JwtResponseDto
    {
        public bool IsSuccessful { get; set; } = true;
        public List<string> Errors { get; set; } = [];
        public string? Token { get; set; }
    }
}