using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliHayderBase.Shared.DTOs.Request
{
    public class VerifyEmailRequestDto
    {
        public required string Email { get; set; }
        public required string Code { get; set; }
    }
}