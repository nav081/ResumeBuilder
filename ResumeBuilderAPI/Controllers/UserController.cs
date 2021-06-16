using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeBuilderAPI.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        //test

    }
}
