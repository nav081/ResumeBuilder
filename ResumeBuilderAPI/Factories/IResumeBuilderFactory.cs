using System.IO;
using System.Threading.Tasks;
using ResumeBuilder.DTO.ResumeBuilder;

namespace ResumeBuilderAPI.Factories
{
    public interface IResumeBuilderFactory
    {
        Stream GenerateCV();
        Task<string> CreateTemplate(CreateTemplate model, string token);

        Task<string> CreateHeader(CreateHeader model, string token);

        Task<string> CreateSalutaion(CreateSalutation model, string token);

        Task<string> CreateBody(CreateBody model, string token);

        Task<string> CreateFooter(CreateFooter model, string token);
    }
}
