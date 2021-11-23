using System.ComponentModel.DataAnnotations;

namespace Core.Authenticate.Dtos
{
    public class UserLoginRequestDto
    {
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}