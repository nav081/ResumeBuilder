using Microsoft.Extensions.Localization;
using ResumeBuilder.Data.Models.CV;
using ResumeBuilder.Data.Services.Manager;
using ResumeBuilder.DTO.ResumeBuilder;
using ResumeBuilder.Utilities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Factories
{
    public class ResumeBuilderFactory : IResumeBuilderFactory
    {
        #region Fields
        private readonly ICommonService _commonService;
        private readonly IRepositoryService<Template> _templaterepository;
        private readonly IRepositoryService<Body> _template_bodyrepository;
        private readonly IRepositoryService<Header> _template_headerrepository;
        private readonly IRepositoryService<Footer> _template_footerrepository;
        private readonly IRepositoryService<Salutation> _template_salutaionrepository;
        private readonly IStringLocalizer<ResumeBuilderFactory> _localizer;
        #endregion

        #region Constructor
        public ResumeBuilderFactory( ICommonService commonService,IRepositoryService<Template> templaterepository,
        IRepositoryService<Body> template_bodyrepository,
        IRepositoryService<Header> template_headerrepository,
        IRepositoryService<Footer> template_footerrepository,
        IRepositoryService<Salutation> template_salutaionrepository,
        IStringLocalizer<ResumeBuilderFactory> localizer
            )
        {
            _commonService = commonService;
            _templaterepository = templaterepository;
            _template_bodyrepository = template_bodyrepository;
            _template_footerrepository = template_footerrepository;
            _template_headerrepository = template_headerrepository;
            _template_salutaionrepository = template_salutaionrepository;
            _localizer = localizer;
        }
        #endregion

        #region Method
        public async Task<string> CreateBody(CreateBody model, string token)
        {
            var user=await _commonService.GetUserByToken(token);
            if (user is null)
                return _localizer["InvalidToken"];

            await _template_bodyrepository.InsertAsync(new Body
            {
                Type = model.Type,
                HTML = model.HTML,
                CreatedOn = DateTime.Now,
                Popularity = 0,
                CreatedBy =user.Id
            });
            return _localizer["Added"];
        }

        public async Task<string> CreateFooter(CreateFooter model, string token)
        {
            var user = await _commonService.GetUserByToken(token);
            if (user is null)
                return _localizer["InvalidToken"];

            await _template_footerrepository.InsertAsync(new Footer
            {
                Type = model.Type,
                HTML = model.HTML,
                CreatedOn = DateTime.Now,
                Popularity = 0,
                CreatedBy = user.Id
            });
            return _localizer["Added"];
        }

        public async Task<string> CreateHeader(CreateHeader model, string token)
        {
            var user = await _commonService.GetUserByToken(token);
            if (user is null)
                return _localizer["InvalidToken"];

            await _template_headerrepository.InsertAsync(new Header
            {
                Type = model.Type,
                HTML = model.HTML,
                CreatedOn = DateTime.Now,
                Popularity = 0,
                CreatedBy = user.Id
            });
            return _localizer["Added"];

        }

        public async Task<string> CreateSalutaion(CreateSalutation model, string token)
        {
            var user = await _commonService.GetUserByToken(token);
            if (user is null)
                return _localizer["InvalidToken"];

            await _template_salutaionrepository.InsertAsync(new Salutation
            {
                Type = model.Type,
                HTML = model.HTML,
                CreatedOn = DateTime.Now,
                Popularity = 0,
                CreatedBy = user.Id
            });
            return _localizer["Added"];
        }

        public async Task<string> CreateTemplate(CreateTemplate model, string token)
        {
            var user = await _commonService.GetUserByToken(token);
            if (user is null)
                return _localizer["InvalidToken"];

            var request = new Template
            {
                Type = model.Type,
                HeaderId = model.HeaderId,
                HeaderHeirarchy = model.HeaderHeirarchy,
                SalutaionId = model.SalutaionId,
                SalutaionHeirarchy = model.SalutaionHeirarchy,
                BodyId = model.BodyId,
                BodyHeirarchy=model.BodyHeirarchy,
                FooterId = model.FooterId,
                FooterHeirarchy=model.FooterHeirarchy,
                CreatedOn = DateTime.Now,
                Popularity = 0,
                CreatedBy = user.Id
            };
            var body = await _template_bodyrepository.GetAsync(model.BodyId);
            if (body is null) return _localizer["NoBodyFound"];
            var header = await _template_headerrepository.GetAsync(model.HeaderId);
            if (header is null) return _localizer["NoHeaderFound"];
            var footer = await _template_footerrepository.GetAsync(model.FooterId);
            if (footer is null) return _localizer["NoFooterFound"];
            var salutaion = await _template_salutaionrepository.GetAsync(model.SalutaionId);
            if (salutaion is null) return _localizer["NoSalutaionFound"];
            request.Body = body;
            request.Header = header;
            request.Footer = footer;
            request.Salutation = salutaion;
            await _templaterepository.InsertAsync(request);
            return _localizer["Added"];
        }

        public Stream GenerateCV()
        {
            return CVBuilder.Htmltopdf("");
        }

        #endregion
    }
}
