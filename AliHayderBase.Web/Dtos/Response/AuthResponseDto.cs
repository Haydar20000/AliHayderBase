using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliHayderBase.Web.Dtos.Response
{
    public class AuthResponseDto
    {
          public bool IsSuccessful { get; set; } = true;
  public List<string> Errors { get; set; } = [];
  public string? AccessToken { get; set; }
  public string? RefreshToken { get; set; }
  public int Code { get; set; } = 0;
    }
}