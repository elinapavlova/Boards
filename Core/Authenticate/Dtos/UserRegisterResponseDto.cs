using System;
using Core.Token;

namespace Core.Authenticate.Dtos
{
    public class UserRegisterResponseDto
    {
        public Guid? Id { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}