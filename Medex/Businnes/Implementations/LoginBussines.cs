using Medex.Businnes.Interfaces;
using Medex.Configurations;
using Medex.Data.VO;
using Medex.Repository.Generic;
using Medex.Services;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Medex.Businnes.Implementations
{
    public class LoginBussines : ILoginBussines
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private IUserRepository _repository;
        private readonly ITokenService _tokenServices;

        public LoginBussines(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenServices)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenServices = tokenServices;
        }

        public TokenVO ValidateCredentials(UserVo userCredentials)
        {
            var user = _repository.ValidateCredencials(userCredentials);
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName)
            };
            var accessToken = _tokenServices.GenerateAccessToken(claims);
            var refreshToken = _tokenServices.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExperyTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }
    }
}
