using Bcrypt.DTOs;
using Bcrypt.Models;
using Bcrypt.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bcrypt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private static readonly List<User> _users = new List<User>();


        [HttpPost("SignUp")]
        public ActionResult SignUp([FromBody] SignUpRequestDTO signUpRequestDTO)
        {
            try
            {
                if (_users.Any(x => x.Username.ToLower() == signUpRequestDTO.Username.ToLower()))
                    return BadRequest("User Already Exists");

                var salt = EncryptionService.GenerateSalt();
                var passwordHashed = EncryptionService.HashPassword(signUpRequestDTO.Password, salt);

                _users.Add(new User()
                {
                    Id = Guid.NewGuid(),
                    Name = signUpRequestDTO.Name,
                    PasswordHashed = passwordHashed,
                    Salt = salt,
                    Username = signUpRequestDTO.Username
                });

                return Ok("User Created!");
            }   
            catch 
            {
                return BadRequest();
            }
        }

        [HttpPost("SignIn")]
        public ActionResult SignIn([FromBody] SignInRequestDTO signInRequestDTO)
        {
            try
            {
                var user = _users.FirstOrDefault(x => x.Username == signInRequestDTO.Username);

                if (user is null)
                {
                    return BadRequest("Sign In Failed!");
                }

                var passwordHashed = EncryptionService.HashPassword(signInRequestDTO.Password, user.Salt);

                if (passwordHashed != user.PasswordHashed)
                {
                    return BadRequest("Sign In Failed!");
                }             

                return Ok($"Welcome, {user.Name}");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}