using System.Net.Mail;


namespace AliHayderBase.Web.Dtos.Request
{
  public class EmailRequestDto
  {
    public required List<MailAddress> Receptors { get; set; }
    public required string Subject { get; set; }
    public string? Body { get; set; }
    public required List<string> MessageVariables { get; set; }
  }
}