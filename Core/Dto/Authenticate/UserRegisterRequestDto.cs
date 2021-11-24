using System.ComponentModel.DataAnnotations;

namespace Core.Dto.Authenticate
{
    public class UserRegisterRequestDto
    {
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}