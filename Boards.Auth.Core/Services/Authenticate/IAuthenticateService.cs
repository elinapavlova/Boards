using System.Threading.Tasks;
using Boards.Auth.Common.Result;
using Boards.Auth.Core.Dto.Authenticate;

namespace Boards.Auth.Core.Services.Authenticate
{
    public interface IAuthenticateService
    {
        Task<ResultContainer<UserLoginResponseDto>> Login(UserLoginRequestDto data);
        Task<ResultContainer<UserRegisterResponseDto>> Register(UserRegisterRequestDto data);
    }
}