using Microsoft.AspNetCore.Identity;

namespace AliHayderBase.Web.Core.Domain
{
    public class Role : IdentityRole
    {
        public string? Description { get; set; }
    }
}