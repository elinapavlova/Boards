using Common.User;

namespace Core.Token
{
    public interface ITokenService
    {
        AccessToken CreateAccessToken(UserModel user);
    }
}