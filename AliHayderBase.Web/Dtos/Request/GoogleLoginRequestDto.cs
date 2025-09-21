using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliHayderBase.Web.Dtos.Request
{
    public class GoogleLoginRequestDto
    {
        public string idToken { get; set; } = string.Empty;
    }
}