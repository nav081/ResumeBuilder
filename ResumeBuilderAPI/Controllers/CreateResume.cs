using Microsoft.AspNetCore.Mvc;
using ResumeBuilder.Utilities.Models;
using ResumeBuilderAPI.Factories;
using ResumeBuilderAPI.Filters;

namespace ResumeBuilderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class CreateResume : ControllerBase
    {
        #region Fields
        private readonly IResumeBuilderFactory _cvBuilderService;
        #endregion

        #region Constructor
        public CreateResume(IResumeBuilderFactory cvBuilderService)
        {
            _cvBuilderService = cvBuilderService;
        }
        #endregion

        #region Methods
        [Route("CreateResume")]
        [HttpPost]
        public IActionResult GetCV(ResumeResponseModel model)
        {
            return Ok();
        }
        #endregion
    }
}
