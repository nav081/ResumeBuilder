using Microsoft.AspNetCore.Mvc;
using ResumeBuilder.DTO.ResumeBuilder;
using ResumeBuilder.DTO.Templates;
using ResumeBuilderAPI.Factories;
using ResumeBuilderAPI.Factories.Templates;
using ResumeBuilderAPI.Filters;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class TemplateController : ControllerBase
    {
        #region Fields
        private readonly IResumeBuilderFactory _cvBuilderService;
        private readonly ITemplatesFactory _templatesFactory;
        #endregion

        #region Constructor
        public TemplateController(IResumeBuilderFactory cvBuilderService, ITemplatesFactory templatesFactory)
        {
            _cvBuilderService = cvBuilderService;
            _templatesFactory = templatesFactory;
        }
        #endregion

        #region Methods
        [Route("GetTemplates")]
        [HttpGet]
        public async Task<IActionResult> GetTemplate()
        {
            var request = new GetTemplateRequestModel();
            return Ok(await _templatesFactory.GetAllTemplates(request));
        }

        [Route("GetBodies")]
        [HttpGet]
        public async Task<IActionResult> GetBodies()
        {
            var request = new GetTemplateRequestModel();
            return Ok(await _templatesFactory.GetAllBodies(request));
        }

        [Route("GetHeaders")]
        [HttpGet]
        public async Task<IActionResult> GetHeaders()
        {
            var request = new GetTemplateRequestModel();
            return Ok(await _templatesFactory.GetAllHeaders(request));
        }

        [Route("GetSalutaions")]
        [HttpGet]
        public async Task<IActionResult> GetSalutaions()
        {
            var request = new GetTemplateRequestModel();
            return Ok(await _templatesFactory.GetAllSalutations(request));
        }
        [Route("GetFooters")]
        [HttpGet]
        public async Task<IActionResult> GetFooters()
        {
            var request = new GetTemplateRequestModel();
            return Ok(await _templatesFactory.GetAllFooters(request));
        }

        [Route("CreateTemplate")]
        [HttpPost]
        public async Task<IActionResult> CreateTemplate(CreateTemplate model)
        {
            var token = HttpContext.Request.Headers["Token"].ToString();
            return Ok(await _cvBuilderService.CreateTemplate(model, token));

        }

        [Route("CreateBody")]
        [HttpPost]
        public async Task<IActionResult> CreateBody(CreateBody model)
        {
            var token = HttpContext.Request.Headers["Token"].ToString();
            return Ok(await _cvBuilderService.CreateBody(model, token));

        }

        [Route("CreateHeader")]
        [HttpPost]
        public async Task<IActionResult> CreateHeader(CreateHeader model)
        {
            var token = HttpContext.Request.Headers["Token"].ToString();
            return Ok(await _cvBuilderService.CreateHeader(model, token));

        }

        [Route("CreateSalutation")]
        [HttpPost]
        public async Task<IActionResult> CreateSalutation(CreateSalutation model)
        {
            var token = HttpContext.Request.Headers["Token"].ToString();
            return Ok(await _cvBuilderService.CreateSalutaion(model, token));

        }

        [Route("CreateFooter")]
        [HttpPost]
        public async Task<IActionResult> CreateFooter(CreateFooter model)
        {
            var token = HttpContext.Request.Headers["Token"].ToString();            
            return Ok(await _cvBuilderService.CreateFooter(model, token));

        }

        #endregion
    }
}
