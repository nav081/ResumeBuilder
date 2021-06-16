using ResumeBuilder.Data.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Factories
{
    public interface IUserFactory
    {
        Task<List<User>> GetAll();

        Task<User> Get(int id);
    }
}
