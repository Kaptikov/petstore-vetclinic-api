using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Users;
using petstore_vetclinic_api.Services.AuthService;
using petstore_vetclinic_api.Services.CartService;
using petstore_vetclinic_api.Services.UserService;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

        private readonly IConfiguration _configuration;

        private readonly DataContext _context;

        public AuthController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            /*Console.WriteLine("Received UserDto data:");
            Console.WriteLine($"UserName: {request.UserName}");
            Console.WriteLine($"Password: {request.Password}");*/

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User newUser = new User
            {
                UserName = request.UserName,
                PasswordHash = passwordHash,
                RoleId = 3,
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user) 
        {
            var userWithRoles = _context.Users
              .Include(u => u.Roles)
              .FirstOrDefault(u => u.Id == user.Id);


            if (userWithRoles != null) {

                string roleName = userWithRoles.Roles.Name;
                List<Claim> claims = new List<Claim> { 
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, roleName),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: creds
                      );
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        [Authorize]
        [HttpGet("user")]
        public ActionResult<User> GetUser()
        {
            var userName = User.Identity.Name;

            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            return Ok(user);
        }
    }
}
