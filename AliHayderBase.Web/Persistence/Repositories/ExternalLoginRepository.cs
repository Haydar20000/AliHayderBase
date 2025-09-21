
using AliHayderBase.Web.Core.Domain;
using AliHayderBase.Web.Core.Interface;
using AliHayderBase.Web.Dtos.Request;
using AliHayderBase.Web.Dtos.Response;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;

namespace AliHayderBase.Web.Persistence.Repositories
{
    public class ExternalLoginRepository : IExternalLoginRepository
    {
        //private GoogleJsonWebSignature.Payload? _googlePayload;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IJwtRepository _jwtRepository;

        public ExternalLoginRepository(IConfiguration configuration, UserManager<User> userManager, IJwtRepository jwtRepository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _jwtRepository = jwtRepository;
        }

        public async Task<AuthResponseDto> GoogleLogin(GoogleLoginRequestDto request)
        {
            var response = new AuthResponseDto();
            if (string.IsNullOrEmpty(request.idToken))
            {
                response.Errors.Add("Invalid Authentication");
                response.IsSuccessful = false;
                return response;
            }
            try
            {

                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new List<string>
            {
                _configuration["Google:ClientId"]??"",
                _configuration["Google:ANDROIDd"]??"",
                _configuration["Google:Web"]??""
            }
                };

                GoogleJsonWebSignature.Payload _googlePayload = await GoogleJsonWebSignature.ValidateAsync(request.idToken, settings);

                if (_googlePayload == null)
                {
                    response.Errors.Add("Invalid Authentication");
                    response.IsSuccessful = false;
                    return response;
                }
                var user = await _userManager.FindByEmailAsync(_googlePayload.Email);
                if (user == null)
                {
                    user = new User
                    {
                        UserName = _googlePayload.Email,
                        Email = _googlePayload.Email,
                        FirstName = _googlePayload.Name
                    };
                    var createResult = await _userManager.CreateAsync(user);
                    await _userManager.AddToRoleAsync(user, "Visitor");
                    if (!createResult.Succeeded)
                    {
                        foreach (var e in createResult.Errors)
                        {
                            response.Errors.Add(e.Description);
                        }
                        response.IsSuccessful = false;
                        return response;
                    }
                }
                var roles = await _userManager.GetRolesAsync(user);
                JwtRequestDto jwtRequest = new JwtRequestDto
                {
                    User = user,
                    Roles = roles
                };
                var jwtResponse = _jwtRepository.GenerateAccessToken(jwtRequest);
                if (!jwtResponse.IsSuccessful)
                {
                    response.IsSuccessful = false;
                    response.Errors.AddRange(jwtResponse.Errors);
                    return response;
                }
                var refreshToken = _jwtRepository.GenerateRefreshToken();
                if (!refreshToken.IsSuccessful)
                {
                    response.IsSuccessful = false;
                    response.Errors.AddRange(refreshToken.Errors);
                    return response;
                }
                user.RefreshToken = refreshToken.Token;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    response.IsSuccessful = false;
                    response.Errors.Add("Invalid Authentication");
                    return response;
                }

                response.AccessToken = jwtResponse.Token;
                response.RefreshToken = refreshToken.Token;
                response.IsSuccessful = true;
                response.Errors = ["Ok"];
                return response;
            }
            catch (System.Exception e)
            {
                var error = e.Message;
                response.IsSuccessful = false;
                response.Errors.Add(error);
                return response;
            }
        }
    }
}