using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class UserLogin
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
