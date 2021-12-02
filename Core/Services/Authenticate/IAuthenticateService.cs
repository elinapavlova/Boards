using System.Threading.Tasks;
using Common.Result;
using Core.Dto.Authenticate;

namespace Core.Services.Authenticate
{
    public interface IAuthenticateService
    {
        Task<ResultContainer<UserLoginResponseDto>> Login(UserLoginRequestDto data);
        Task<ResultContainer<UserRegisterResponseDto>> Register(UserRegisterRequestDto data);
    }
}