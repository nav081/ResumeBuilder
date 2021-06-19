using ResumeBuilder.Data.Models.User;
using ResumeBuilder.DTO.Account;
using System.Net;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Factories
{
    public interface IAccountFactory
    {
        Task<UserStatusResponseModel> GetUserStatusBy(string Username, string Password);
        Task<LoginResponseModel> Login(string username, string Password,string ipaddress);
        Task<User> GetByToken(string token,string ipaddress);
        void Logout(string token);
    }
}
