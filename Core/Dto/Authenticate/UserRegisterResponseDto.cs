using System;
using Core.Token;

namespace Core.Dto.Authenticate
{
    public class UserRegisterResponseDto
    {
        public Guid? Id { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}