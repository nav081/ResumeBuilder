using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Utilities;
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
