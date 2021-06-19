using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ResumeBuilderAPI.Factories;
using System;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Filters
{
    public class AuthenticationFilter : IAsyncActionFilter
    {
        private readonly IAccountFactory _accountmanager;
        public AuthenticationFilter( IAccountFactory accountmanager)
        {
            _accountmanager = accountmanager;
        }
        public void OnActionExecutedAsync(ActionExecutedContext context)
        {
            
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var token = context.HttpContext.Request.Headers["Token"].ToString();
            var ipadress = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var user = await _accountmanager.GetByToken(token, ipadress);

            if (user is null)
            {
                context.Result = new RedirectToActionResult("NotAuthorized","Account",null);
                await context.Result.ExecuteResultAsync(context);
            }
            else {
                await next();
            }
        }
    }
}
