using Medex.Data.VO;
using Medex.Models;

namespace Medex.Businnes.Interfaces
{
    public interface ILoginBussines
    {
        TokenVO ValidateCredentials(UserVo user);

    }
}
