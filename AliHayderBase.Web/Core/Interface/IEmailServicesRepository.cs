using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliHayderBase.Web.Dtos.Request;
using AliHayderBase.Web.Dtos.Response;

namespace AliHayderBase.Web.Core.Interface
{
    public interface IEmailServicesRepository
    {
        Task<SystemResponseDto> SendEmailAsync(EmailRequestDto request);

        Task<SystemResponseDto> ConfirmEmailTemp(EmailRequestDto request);
    }
}