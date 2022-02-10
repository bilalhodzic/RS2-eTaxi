using Model.Others;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IJwtGenerator
    {
        //Task<string> CreateToken(LoginModel user);
        string GenerateToken(LoginModel model, int id, bool VerifiedAccount);

    }
}
