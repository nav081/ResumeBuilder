using Microsoft.AspNetCore.Mvc;
using ResumeBuilderAPI.Factories;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecurringJobController : ControllerBase
    {
        private readonly IAccountFactory _account;

        public RecurringJobController(IAccountFactory account)
        {
            _account = account;
        }

        [Route("RemoveInactiveToken")]
        [HttpGet]
        public async Task RemoveInactiveToken()
        {
            await _account.RemoveInactive();
        }
    }
}
