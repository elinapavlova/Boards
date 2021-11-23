using Common.Token;

namespace Core.Token
{
    public class AccessToken : TokenModel
    {
        public AccessToken(string token, long expiration) : base(token, expiration)
        {
        }
    }
}