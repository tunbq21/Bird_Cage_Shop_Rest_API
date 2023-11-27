using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.User;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BirdCageShop.Presentation.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/login")]
    public class LoginController : ControllerBase { 
        private ILoginService _loginService;
        private IConfiguration _configuration;
        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
             _loginService = loginService;
            _configuration = configuration;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<LoginViewModel> Authenticate(LoginRequestModel loginRequest)
        {
            try
            {
                var user = _loginService.Authenticate(loginRequest);

                if (user == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserID", user.UserId.ToString()),
                        new Claim("UserName", user.Username),
                        new Claim("Email", user.Email),
                       
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);


                    user.Token = new JwtSecurityTokenHandler().WriteToken(token);
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
           
               
        }
    }
}
