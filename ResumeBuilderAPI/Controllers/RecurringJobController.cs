using Microsoft.AspNetCore.Mvc;
using ResumeBuilderAPI.Factories;

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
        public void RemoveInactiveToken()
        {
            _account.RemoveInactive();
        }
    }
}
