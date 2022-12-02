using Medex.Data.VO;
using Medex.Models;

namespace Medex.Repository.Generic
{
    public interface IUserRepository
    {
         UserModel ValidateCredencials(UserVo user);
        
         UserModel RefreshUserInfo(UserModel user);
    }
}
