using System.ComponentModel.DataAnnotations;

namespace Bcrypt.DTOs;

public class SignUpRequestDTO
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
