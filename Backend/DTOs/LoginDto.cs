using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
