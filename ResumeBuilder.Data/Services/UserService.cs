using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data.Models.User;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilder.Data.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly DatabaseContext _context;
        #endregion


        #region Contructor
        public UserService(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            var data = await _context.Users.FindAsync(id);
            if (data is null)
                return default(User);
            return data;
        }

        public async Task<User> Get(string username)
        {
            var data =await  _context.Users.Where(a => a.UserName == username).FirstOrDefaultAsync();
            if (data is null)
                data =await  _context.Users.FirstOrDefaultAsync(a => a.Email.ToLower() == username.ToLower());
            if (data is null)
                return default(User);
            return data;
        }
        #endregion
    }
}
