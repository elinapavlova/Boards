using System.ComponentModel.DataAnnotations;

namespace Boards.Auth.Core.Dto.Authenticate
{
    public class UserLoginRequestDto
    {
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}