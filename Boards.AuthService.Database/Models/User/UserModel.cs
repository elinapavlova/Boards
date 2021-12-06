using Boards.Common.Base;

namespace Boards.AuthService.Database.Models.User
{
    public class UserModel : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}