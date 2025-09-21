
using AliHayderBase.Shared.DTOs.Request;
using AliHayderBase.Shared.DTOs.Response;


namespace AliHayderBase.Web.Core.Interface
{
    public interface IEmailServicesRepository
    {
        Task<SystemResponseDto> SendEmailAsync(EmailRequestDto request);

        Task<SystemResponseDto> ConfirmEmailTemp(EmailRequestDto request);
    }
}