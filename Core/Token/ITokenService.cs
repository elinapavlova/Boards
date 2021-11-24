using Database.Models.User;

namespace Core.Token
{
    public interface ITokenService
    {
        AccessToken CreateAccessToken(UserModel user);
    }
}