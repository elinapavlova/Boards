using System.Threading.Tasks;
using Common.Result;
using Core.Authenticate.Dtos;

namespace Core.Authenticate
{
    public interface IAuthenticateService
    {
        Task<ResultContainer<UserLoginResponseDto>> Login(UserLoginRequestDto data);
        Task<ResultContainer<UserRegisterResponseDto>> Register(UserRegisterRequestDto data);
       // Task<ResultContainer<AccessTokenDto>> RefreshToken(string refreshToken, string userEmail);
    }
}