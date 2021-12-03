using System;
using Boards.AuthService.Core.Token;

namespace Boards.AuthService.Core.Dto.Authenticate
{
    public class UserLoginResponseDto
    {
        public Guid? Id { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}