using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data.Models.Common;
using ResumeBuilder.Data.Services.Manager;
using ResumeBuilder.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResumeBuilder.Data.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly DatabaseContext _context;
        public TokenService(DatabaseContext context)
        {
            _context = context;
        }

        public List<Token> AllInActive(DateTime time)
        {
            var inactiveusers = _context.Users.Where(a => a.LastLogin < time).Select(a=>a.Id).ToList();
            return _context.Tokens.Where(x => inactiveusers.Contains(x.userid)).ToList();

        }

        public void Delete(string token)
        {
            var data= _context.Tokens.FirstOrDefault(a=>a.token== EncryptionHelper.Decrypt(token));
            if (!(data is null))
            {
                _context.Tokens.Remove(data);
                _context.SaveChanges();
            }
        }
    }
}
