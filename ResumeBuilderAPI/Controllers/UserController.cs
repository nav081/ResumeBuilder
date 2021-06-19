using Microsoft.AspNetCore.Mvc;
using ResumeBuilderAPI.Factories;
using ResumeBuilderAPI.Filters;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class UserController : ControllerBase
    {
        #region Fileds
        private readonly IUserFactory _userservice;
        #endregion

        #region Contructor
        public UserController(IUserFactory userservice)
        {
            _userservice = userservice;
        }
        #endregion

        #region Methods
        [Route("GetUser")]
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _userservice.Get(id));
        }
        #endregion

    }
}
