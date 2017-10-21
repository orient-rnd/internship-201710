using Interns2.AppServices.API.Models;
using Interns2.Domain.Domains;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interns2.AppServices.API.Filters
{
    public class UsersRegisterFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // do something before the action executes
            var parameters = context.ActionArguments;
            var email = parameters["user"];

            var result = (User)email;

            if (!result.Email.Contains("hotmail.com"))
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}
