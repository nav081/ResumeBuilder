using ResumeBuilder.Data.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResumeBuilder.Data.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAll();

        Task<User> Get(int id);
    }
}
