
using DATN.Models;
using DATN.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace DATN.Controllers
{
    [Authorize]
    [ApiController]

    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly IAuthoRepository _authRepo;
        private readonly IConfiguration _configuration;
        public LoginController(IAuthoRepository authRepo, IConfiguration configuration)
        {
            _configuration = configuration;
            _authRepo = authRepo;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]LoginModel model)
        {
            var user = _authRepo.Login(model.UserName, model.Password);
            if(user == null )
            {
                return BadRequest(new { message = "UserName or Password khong chinh xac" });
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Secret").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenstring = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role,
                Token = tokenstring
            });
        }
      
    }
}
