using ResumeBuilder.Data.Models.Common;
using ResumeBuilder.Data.Services.Manager;
using ResumeBuilder.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilder.Data.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private IRepositoryService<Token> _tokenRepository;
        public TokenService(IRepositoryService<Token> tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

       

        public async Task DeleteAsync(string token)
        {
            var data= _tokenRepository.Table.FirstOrDefault(a=>a.token== EncryptionHelper.Decrypt(token));
            if (!(data is null))
            {
                await _tokenRepository.DeleteAsync(data.Id);
            }
        }
    }
}
