using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data.Models.CV;
using ResumeBuilder.Data.Services.Manager;
using ResumeBuilder.DTO.Templates;
using ResumeBuilder.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Factories.Templates
{
    public class TemplatesFactory : ITemplatesFactory
    {
        #region Field
        private readonly IRepositoryService<Template> _templateRepository;
        private readonly IRepositoryService<Header> _headerRepository;
        private readonly IRepositoryService<Footer> _footerRepository;
        private readonly IRepositoryService<Salutation> _salutaionRepository;
        private readonly IRepositoryService<Body> _bodyRepository;
        #endregion

        #region Constructor
        public TemplatesFactory(IRepositoryService<Template> templateRepository,
            IRepositoryService<Header> headerRepository,
            IRepositoryService<Footer> footerRepository,
            IRepositoryService<Salutation> salutaionRepository,
            IRepositoryService<Body> bodyRepository)
        {
            _templateRepository = templateRepository;
            _headerRepository = headerRepository;
            _footerRepository = footerRepository;
            _salutaionRepository = salutaionRepository;
            _bodyRepository = bodyRepository;
        }
        #endregion

        #region Methods
        public async Task<GetTeamplateResponseModel> GetAllTemplates(GetTemplateRequestModel model)
        {
            var response = new GetTeamplateResponseModel();
            var data =await _templateRepository.Table
                .Include(a=>a.Body)
                .Include(a => a.Header)
                .Include(a => a.Salutation)
                .Include(a => a.Footer)
                .ToListAsync();
            response.Templates = MapMultiple(data);
            return response;
        }

        public async Task<List<Body>> GetAllBodies(GetTemplateRequestModel model)
        {
            return await _bodyRepository.GetAllAsync();
        }
        public async Task<List<Header>> GetAllHeaders(GetTemplateRequestModel model)
        {
            return await _headerRepository.GetAllAsync();
        }
        public async Task<List<Footer>> GetAllFooters(GetTemplateRequestModel model)
        {
            return await _footerRepository.GetAllAsync();
        }
        public async Task<List<Salutation>> GetAllSalutations(GetTemplateRequestModel model)
        {
            return await _salutaionRepository.GetAllAsync();
        }

        private TemplateModel Map(Template template)
        {
            var response = new TemplateModel();
            response.TemplateId = template.Id;
            response.BodyId = template.BodyId;
            response.CreatedBy = template.CreatedBy;
            response.FooterId = template.FooterId;
            response.HeaderId = template.HeaderId;
            response.SalutaionId = template.SalutaionId;
            response.HTML = "";
            var htmls = new List<KeyValuePair<int, string>>();
            htmls.Add(new KeyValuePair<int, string>((int)template.HeaderHeirarchy,template?.Header?.HTML));
            htmls.Add(new KeyValuePair<int, string>((int)template.BodyHeirarchy, template?.Body?.HTML));
            htmls.Add(new KeyValuePair<int, string>((int)template.SalutaionHeirarchy, template?.Salutation?.HTML));
            foreach (var item in htmls.OrderBy(a=>a.Key))
            {
                response.HTML = response.HTML + item.Value;
            }
            response.HTML = response.HTML + template?.Footer?.HTML;
            return response;
        }

        private List<TemplateModel> MapMultiple(List<Template> data)
        {
            var response = new List<TemplateModel>();
            data.ForEach((item) =>
            {
                response.Add(Map(item));
            });
            return response;
        }
        #endregion
    }
}
