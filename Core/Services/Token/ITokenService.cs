using Core.Token;
using Database.Models.User;

namespace Core.Services.Token
{
    public interface ITokenService
    {
        AccessToken CreateAccessToken(UserModel user);
    }
}