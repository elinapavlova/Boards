using System;
using Boards.Auth.Core.Token;

namespace Boards.Auth.Core.Dto.Authenticate
{
    public class UserLoginResponseDto
    {
        public Guid? Id { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}