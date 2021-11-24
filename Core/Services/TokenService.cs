using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common.Base;
using Common.Options;
using Core.Token;
using Database.Models.User;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey;

        public TokenService 
        (
            AppOptions appOptions
        )
        {
            _secretKey = appOptions.Secret;
        }

        public AccessToken CreateAccessToken(UserModel user)
        {
            var accessToken = BuildAccessToken(user);
            return accessToken;
        }

        private AccessToken BuildAccessToken(BaseModel user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var accessTokenExpiration = DateTime.UtcNow.AddDays(365);

            var securityToken = new JwtSecurityToken
            (
                claims : GetClaims(user),
                expires : accessTokenExpiration,
                notBefore : DateTime.UtcNow,
                signingCredentials : 
                    new SigningCredentials
                        (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );
            
            var accessToken = handler.WriteToken(securityToken);

            return new AccessToken(accessToken, accessTokenExpiration.Ticks);
        }

        private static IEnumerable<Claim> GetClaims(BaseModel user)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, user.Id.ToString())
            };

            return claims;
        }
    }
}