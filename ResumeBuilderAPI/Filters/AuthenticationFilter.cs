using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ResumeBuilderAPI.Factories;
using System;

namespace ResumeBuilderAPI.Filters
{
    public class AuthenticationFilter : IActionFilter
    {
        private readonly IAccountFactory _accountmanager;
        public AuthenticationFilter( IAccountFactory accountmanager)
        {
            _accountmanager = accountmanager;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers["Token"].ToString();
            var ipadress= context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var user = _accountmanager.GetByToken(token, ipadress).Result;
            if (user is null)
            {
                context.Result = new RedirectToRouteResult("api/NotAuthorized");
            }

        }
    }
}
