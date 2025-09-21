

namespace AliHayderBase.Web.Dtos.Response
{
    public class SystemResponseDto
    {
        public bool IsSuccessful { get; set; } = true;
        public IEnumerable<string> Errors { get; set; } = [];
    }
}