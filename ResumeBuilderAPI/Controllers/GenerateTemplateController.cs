using Microsoft.AspNetCore.Mvc;
using ResumeBuilder.DTO.ResumeBuilder;
using ResumeBuilderAPI.Factories;
using ResumeBuilderAPI.Filters;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class GenerateTemplateController : ControllerBase
    {
        #region Fields
        private readonly IResumeBuilderFactory _cvBuilderService;
        #endregion

        #region Constructor
        public GenerateTemplateController(IResumeBuilderFactory cvBuilderService)
        {
            _cvBuilderService = cvBuilderService;
        }
        #endregion

        #region Methods

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
