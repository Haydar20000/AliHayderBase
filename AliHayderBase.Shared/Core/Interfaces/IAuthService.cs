using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliHayderBase.Shared.DTOs.Request;
using AliHayderBase.Shared.DTOs.Response;

namespace AliHayderBase.Shared.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginRequestDto request);

        Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto request);
    }
}