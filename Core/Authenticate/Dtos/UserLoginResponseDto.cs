using System;
using Core.Token;

namespace Core.Authenticate.Dtos
{
    public class UserLoginResponseDto
    {
        public Guid? Id { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}