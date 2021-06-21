using System.Threading.Tasks;

namespace ResumeBuilder.Data.Services.TokenService
{
    public interface ITokenService
    {
        Task DeleteAsync(string token);

    }
}
