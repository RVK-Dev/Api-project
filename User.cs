using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    //User.cs is not in the Controllers folder, so its namespace should be WebApi (like UserLogin)
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
    

}
