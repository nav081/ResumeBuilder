using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeBuilderAPI.Factories;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Fileds
        private readonly IAccountFactory _accountManager;
        private readonly IHttpContextAccessor _contextAccessor;
        #endregion

        #region Contructor
        public AccountController(IAccountFactory accountManager, IHttpContextAccessor context)
        {
            _accountManager = accountManager;
            _contextAccessor = context;
        }
        #endregion

        #region Methods
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(string username,string password)
        {
            var ipaddress=_contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return Ok(await _accountManager.Login(username,password,ipaddress));
        }

        [Route("GetInfo")]
        [HttpPost]
        public async Task<IActionResult> GetInfo(string token,string ipadress)
        {
            return Ok(await _accountManager.GetByToken(token,ipadress));
        }

        [Route("NotAuthorized")]
        [HttpGet]
        public IActionResult NotAuthorized()
        {
            return Unauthorized();
        }

        [Route("Logout")]
        [HttpPost]
        public async Task<IActionResult> Logout(string token)
        {
            try
            {
                await _accountManager.Logout(token);
                return Ok();
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }
        #endregion

    }
}
