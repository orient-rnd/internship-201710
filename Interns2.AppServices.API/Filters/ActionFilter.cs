using Interns2.AppServices.API.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Interns2.Domain.Domains;

namespace Interns2.AppServices.API.Filters
{
    public class ActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
            else
            {
                //Regex regex = new Regex(@"[a-z0-9._%+-]+@hotmail.com");

                var v1 = context.ActionArguments["user"] as User;
                //code cua #Mr.Son--------------------------------------
                //var email = v1.Email;
                //Match m = regex.Match(email);
                //if (!m.Success)
                //{

                //    context.Result = new UnprocessableEntityObjectResult(context.ModelState);
                //}

                //code cua #Huy---------------------------------------------
                if (!v1.Email.Contains("hotmail.com"))
                {
                    context.Result = new UnprocessableEntityObjectResult(context.ModelState);
                }


            }

        }
    }
   
}
