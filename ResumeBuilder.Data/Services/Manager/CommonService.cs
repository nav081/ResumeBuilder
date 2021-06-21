using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data.Models.Common;
using ResumeBuilder.Data.Models.User;
using ResumeBuilder.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilder.Data.Services.Manager
{
    public class CommonService : ICommonService
    {
        private IRepositoryService<User> _userRepository; 
        private IRepositoryService<Token> _tokenRepository;

        public CommonService(IRepositoryService<User> userRepository, IRepositoryService<Token> tokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<string> GenerateToken(int userid, string ipaddress)
        {
            var guid = Guid.NewGuid().ToString();
            await _tokenRepository.InsertAsync(new Token
            {
                token = guid,
                userid = userid,
                IPAdress = ipaddress,
                CreatedOn = DateTime.Now
            });
            return EncryptionHelper.Encrypt(guid);
        }

        public async Task<User> GetUserByToken(string token,string ipaddress)
        {
            try
            {
                var tokeninfo = await _tokenRepository.Table.FirstOrDefaultAsync(a => a.token == DecryptToken(token) && a.IPAdress == ipaddress);                
                if (tokeninfo is null)
                    return default(User);
                var user = await _userRepository.Table.FirstOrDefaultAsync(a => a.Id == tokeninfo.userid);
                if (user is null)
                    return default(User);
                user.LastLogin = DateTime.Now;
                await _userRepository.UpdateAsync(user);
                return user;
            }
            catch (Exception)
            {

                return default(User);
            }
            

        }

        public async Task<User> GetUserByToken(string token)
        {
            var tokeninfo = await _tokenRepository.Table.FirstOrDefaultAsync(a => a.token == DecryptToken(token));
            if (tokeninfo is null)
                return default(User);
            var user = await _userRepository.Table.FirstOrDefaultAsync(a => a.Id == tokeninfo.userid);
            if (user is null)
                return default(User);
            return user;

        }

        public async Task<List<Token>> AllInActive(DateTime time)
        {
            var inactiveusers =await _userRepository.Table.Where(a => a.LastLogin < time).Select(a => a.Id).ToListAsync();
            return await _tokenRepository.Table.Where(x => inactiveusers.Contains(x.userid)).ToListAsync();

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
