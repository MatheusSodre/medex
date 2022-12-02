using Medex.Configurations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Medex.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private TokenConfiguration _configuration;
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret));
            var signinCredetials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var options = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_configuration.Minutes),
                signingCredentials: signinCredetials
                );
            string tokenstring = new JwtSecurityTokenHandler().WriteToken(options);
            return tokenstring;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret)),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken segurityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out segurityToken);
            var jwtSecurityToken = segurityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
                !jwtSecurityToken.Header.Alg.Equals(
                    SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCulture))
                throw new SecurityTokenException("Invalid Token");

            return principal;
        }
    }
}
