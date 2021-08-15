using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data.Models.User;
using ResumeBuilder.Data.Services.Manager;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResumeBuilder.Data.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private IRepositoryService<User> _userRepository;
        #endregion

        #region Contructor
        public UserService(IRepositoryService<User> userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Methods
        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> Get(int id)
        {
            var data = await _userRepository.GetAsync(id);
            if (data is null)
                return default(User);
            return data;
        }

        public async Task<User> Get(string username)
        {
            var data = await _userRepository.Table.FirstOrDefaultAsync(a => a.UserName == username);
            if (data is null)
                data = await _userRepository.Table.FirstOrDefaultAsync(a => a.Email.ToLower() == username.ToLower());
            if (data is null)
                return default(User);
            return data;
        }
        #endregion
    }
}
