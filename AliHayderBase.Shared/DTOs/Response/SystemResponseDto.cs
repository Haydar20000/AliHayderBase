

namespace AliHayderBase.Shared.DTOs.Response
{
    public class SystemResponseDto
    {
        public bool IsSuccessful { get; set; } = true;
        public IEnumerable<string> Errors { get; set; } = [];
    }
}