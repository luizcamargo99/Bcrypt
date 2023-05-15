using System.ComponentModel.DataAnnotations;

namespace Bcrypt.DTOs;

public class SignInRequestDTO
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
