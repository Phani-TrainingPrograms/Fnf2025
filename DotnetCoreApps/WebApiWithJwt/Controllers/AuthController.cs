using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApiWithJwt.Models;

namespace WebApiWithJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> mgr)
        {
            this._userManager = mgr;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginModel model)
        {
            //var name = await _userManager.FindByNameAsync(model.Username);
            //if(name == null || await _userManager.CheckPasswordAsync(name, model.Password) == false)
            //{
            //    Console.WriteLine("User is unauthorized");
            //    return Unauthorized();
            //}
            if(model.Username != "admin" || model.Password != "Password")
            {
                return Unauthorized();
            }
            //var userRoles = await _userManager.GetRolesAsync(name);
            var token = GenerateJwtToken(model.Username);
            Console.WriteLine(token);
            return Ok(new AuthResponse
            {
                Token = token,
                Expiration = DateTime.Now.AddMinutes(30),
                UserName = model.Username
            });
        }

        private string GenerateJwtToken(string name)
        {
            //var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, name.UserName),
            //    new Claim(ClaimTypes.NameIdentifier, name.Id),
            //};
             var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Program.Configuration["JwtSettings:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Program.Configuration["JwtSettings:ValidIssuer"],
                audience: Program.Configuration["JwtSettings:ValidAudience"],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
