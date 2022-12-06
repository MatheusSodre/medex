using Medex.Data;
using Medex.Data.VO;
using Medex.Models;
using Medex.Repository.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Medex.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SistemaTarefasDBContex _dbContext;

        public UserRepository(SistemaTarefasDBContex dbContext)
        {
            _dbContext = dbContext;
        }

        public UserModel ValidateCredencials(UserVo user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _dbContext.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        public UserModel RefreshUserInfo(UserModel user)
        {
            if (_dbContext.Users.Any(u => u.Id.Equals(user.Id))) return null;
            var result = _dbContext.Users.SingleOrDefault(x => x.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _dbContext.Entry(result).CurrentValues.SetValues(user);
                    _dbContext.SaveChanges();
                    return user;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        private object ComputeHash(string input , SHA256CryptoServiceProvider algorithm)
        {
            Byte[] InputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] HashedBytes = algorithm.ComputeHash(InputBytes);
            return BitConverter.ToString(HashedBytes);
        }
    }
}
