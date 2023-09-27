using System.ComponentModel.DataAnnotations;

namespace uni_project.Core.Entity.AuthModel
{
    public class AuthUserPassModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
