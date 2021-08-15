using ResumeBuilder.Data.Models.CV;
using ResumeBuilder.DTO.Templates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Factories.Templates
{
    public interface ITemplatesFactory
    {
        Task<GetTeamplateResponseModel> GetAllTemplates(GetTemplateRequestModel model);
        Task<List<Header>> GetAllHeaders(GetTemplateRequestModel model);
        Task<List<Body>> GetAllBodies(GetTemplateRequestModel model);
        Task<List<Salutation>> GetAllSalutations(GetTemplateRequestModel model);
        Task<List<Footer>> GetAllFooters(GetTemplateRequestModel model);
    }
}
