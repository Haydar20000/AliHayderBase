

using AliHayderBase.Web.Core.Domain;

namespace AliHayderBase.Web.Dtos.Request
{
  public class JwtRequestDto
  {
    public required User User { get; set; }
    public required IList<string> Roles { get; set; }
  }
}