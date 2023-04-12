using ApiTestProject.Dtos.UserDto;
using ApiTestProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ApiTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public static User user = new User();

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            CreatePasswordHash(userDto.password ,out byte[] passwordHash ,out byte[] passwordSalt);

            user.Name = userDto.Name;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }
        private string CreateToken(User user)
        {

            List<Claim> claims = new List<Claim>{

                new Claim(ClaimTypes.Name , user.Name)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            if(user.Name != userDto.Name)
            {
                return BadRequest("User not found");
            }
            if(!VerifyPasswordHash(userDto.password , user.PasswordHash , user.PasswordSalt))
            {
                return BadRequest("nope");
            }
            string token = CreateToken(user);
            return Ok(token);
        }

        private void CreatePasswordHash(string password , out byte[] passwordHash , out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password , byte[] passwordHash , byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
            return false;
        }
    }
}
