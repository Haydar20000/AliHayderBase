using Microsoft.AspNetCore.Mvc;
using AliHayderBase.Web.Dtos.Request;
using AliHayderBase.Web.Core.Interface;
namespace AliHayderBase.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IExternalLoginRepository _externalLogin;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthRepository authRepository, IExternalLoginRepository externalLogin, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _externalLogin = externalLogin;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            var response = await _authRepository.RegisterAsync(model);
            return !response.IsSuccessful ? BadRequest(response) : Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var response = await _authRepository.LoginAsync(model);
            return !response.IsSuccessful ? Unauthorized(response) : Ok(response);
        }

        [HttpPost("validate")]
        public IActionResult Validate([FromBody] string token)
        {
            var response = _authRepository.ValidateToken(token);
            return !response.IsSuccessful ? Unauthorized(response) : Ok(response);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] string code)
        {
            var response = await _authRepository.LoginWithRefreshToken(code);
            return !response.IsSuccessful ? Unauthorized(response) : Ok(response);
        }

        [HttpPost("verifyEmail")]
        public async Task<IActionResult> VerifyEmailAsync([FromBody] VerifyEmailRequestDto verifyEmailRequest)
        {
            var response = await _authRepository.VerifyEmailAsync(verifyEmailRequest);
            return !response.IsSuccessful ? BadRequest(response) : Ok(response);
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordRequestDto forgotPasswordRequest)
        {
            var response = await _authRepository.ForgotPasswordAsync(forgotPasswordRequest);
            return !response.IsSuccessful ? BadRequest(response) : Ok(response);
        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordRequestDto resetPasswordRequestDto)
        {
            var response = await _authRepository.ResetPasswordAsync(resetPasswordRequestDto);
            return !response.IsSuccessful ? BadRequest(response) : Ok(response);
        }
        [HttpPost("resendEmailConfirmation")]
        public async Task<IActionResult> ResendEmailConfirmationAsync([FromBody] ResendEmailConfirmationRequestDto request)
        {
            var response = await _authRepository.ResendEmailConfirmation(request);
            return !response.IsSuccessful ? BadRequest(response) : Ok(response);
        }
        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequestDto request)
        {
            var response = await _externalLogin.GoogleLogin(request);
            return !response.IsSuccessful ? BadRequest(response) : Ok(response);
            //"http://10.0.2.2:5003",
        }
    }
}