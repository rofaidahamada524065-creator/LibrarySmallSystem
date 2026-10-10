using LibrarySmallSystem.DTOs.UserDTOs;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.UnitOfWorkk;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibrarySmallSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUnitOfWork _repo;
        private readonly IConfiguration _confegar;
        public AuthController(IUnitOfWork repo, IConfiguration confegar,IPasswordHasher<User> passwordHasher)
        {
            _repo = repo;
            _confegar = _confegar;
            _passwordHasher = passwordHasher;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(Login dto)
        {
            var user = _repo.user.GetByUserNameAsync(dto.UserName);
            if (user == null||user.PasswordHash!=dto.Password)
            {
                return Unauthorized("Invalide userName or Password");
            }
            var token = GenerateToken(user);
            return Ok();
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confegar["Jwt:Key"]));
            var credetials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var clims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,user.Role)

            };

            var token = new JwtSecurityToken
                (
                issuer: _confegar["Jwt:Issuer"],
                audience: _confegar["Jwt:Audience"],
                claims: clims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_confegar["Jwt:DurationInMinutes"])),
                signingCredentials:credetials



                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register(Registration dto)
        {
            var x = _repo.user.GetByUserNameAsync(dto.UserName);
            if (x != null)
            {
                return BadRequest("UserName already exists");
            }
            var user = new User
            {
                UserName = dto.UserName,
                Role = "Member"
            };
            user.PasswordHash = _passwordHasher.HashPassword
                (
                user,
                dto.Password

                );

            _repo.user.AddAsync(user);
            _repo.save();
            return Ok(new
            {
                Message = "User registered successfully",
                user.Id,
                user.UserName,
                user.Role

            } );






        }
    }
}
