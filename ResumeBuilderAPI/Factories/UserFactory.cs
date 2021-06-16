using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data.Models.User;
using ResumeBuilder.Data.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Factories
{
    public class UserFactory : IUserFactory
    {
        #region Fields
        private readonly IUserService _userService;
        #endregion


        #region Contructor
        public UserFactory(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Methods
        public async Task<List<User>> GetAll()
        {
            return await _userService.GetAll();
        }

        public async Task<User> Get(int id)
        {
            return await _userService.Get(id);
        }
        #endregion
    }
}
