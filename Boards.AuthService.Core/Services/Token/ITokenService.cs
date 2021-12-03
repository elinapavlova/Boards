using Boards.AuthService.Core.Token;
using Boards.AuthService.Database.Models.User;

namespace Boards.AuthService.Core.Services.Token
{
    public interface ITokenService
    {
        AccessToken CreateAccessToken(UserModel user);
    }
}