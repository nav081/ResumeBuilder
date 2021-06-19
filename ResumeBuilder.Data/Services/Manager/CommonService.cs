using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data.Models.User;
using ResumeBuilder.Utilities;
using System;
using System.Threading.Tasks;

namespace ResumeBuilder.Data.Services.Manager
{
    public class CommonService : ICommonService
    {
        private readonly DatabaseContext _context;

        public CommonService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateToken(int userid, string ipaddress)
        {
            var guid = Guid.NewGuid().ToString();
            _context.Tokens.Add(new Models.Common.Token
            {
                token = guid,
                userid = userid,
                IPAdress = ipaddress,
                CreatedOn = DateTime.Now
            });
            await _context.SaveChangesAsync();
            return EncryptionHelper.Encrypt(guid);
        }

        public async Task<User> GetUserByToken(string token,string ipaddress)
        {
            try
            {
                var tokeninfo = await _context.Tokens.FirstOrDefaultAsync(a => a.token == DecryptToken(token) && a.IPAdress == ipaddress);
                if (tokeninfo is null)
                    return default(User);
                var user = await _context.Users.FirstOrDefaultAsync(a => a.Id == tokeninfo.userid);
                if (user is null)
                    return default(User);
                return user;
            }
            catch (Exception)
            {

                return default(User);
            }
            

        }

        public async Task<User> GetUserByToken(string token)
        {
            var tokeninfo = await _context.Tokens.FirstOrDefaultAsync(a => a.token == DecryptToken(token));
            if (tokeninfo is null)
                return default(User);
            var user = await _context.Users.FirstOrDefaultAsync(a => a.Id == tokeninfo.userid);
            if (user is null)
                return default(User);
            return user;

        }

        private string DecryptToken(string token) {
            try
            {
                return EncryptionHelper.Decrypt(token);
            }
            catch (Exception)
            {
                return token;
            }
        }
    }
}
