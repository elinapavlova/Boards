using System.Threading.Tasks;
using Boards.AuthService.Core.Dto.Authenticate;
using Boards.Common.Result;

namespace Boards.AuthService.Core.Services.Authenticate
{
    public interface IAuthenticateService
    {
        Task<ResultContainer<UserLoginResponseDto>> Login(UserLoginRequestDto data);
        Task<ResultContainer<UserRegisterResponseDto>> Register(UserRegisterRequestDto data);
    }
}