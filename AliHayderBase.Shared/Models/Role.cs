using Microsoft.AspNetCore.Identity;

namespace AliHayderBase.Shared.Models
{
    public class Role : IdentityRole
    {
        public string? Description { get; set; }
    }
}