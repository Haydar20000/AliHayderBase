



using AliHayderBase.Shared.Models;

namespace AliHayderBase.Shared.DTOs.Request
{
  public class JwtRequestDto
  {
    public required User User { get; set; }
    public required IList<string> Roles { get; set; }
  }
}