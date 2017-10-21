using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interns2.AppServices.API.Filters
{
    public class ExceptionFilter: ExceptionFilterAttribute
    {        
        public override void OnException(ExceptionContext context)
        {           
            var result = new ViewResult { ViewName = "Error" };
            result.ViewData = new ViewDataDictionary(null, context.ModelState);
            result.ViewData.Add("Exception", context.Exception);
            // TODO: Pass additional detailed data via ViewData
            context.Result = result;
        }
    }
  
}
