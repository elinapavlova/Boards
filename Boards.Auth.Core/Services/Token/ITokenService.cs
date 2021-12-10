using Boards.Auth.Core.Token;
using Boards.Auth.Database.Models.User;

namespace Boards.Auth.Core.Services.Token
{
    public interface ITokenService
    {
        AccessToken CreateAccessToken(UserModel user);
    }
}