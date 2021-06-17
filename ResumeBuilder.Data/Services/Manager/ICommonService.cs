using ResumeBuilder.Data.Models.User;
using System.Threading.Tasks;

namespace ResumeBuilder.Data.Services.Manager
{
    public interface ICommonService
    {
        Task<User> GetUserByToken(string token,string ipadress);
        Task<string> GenerateToken(int userid, string ipaddress);
    }
}
