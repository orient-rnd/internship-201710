using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

namespace IdentityCore.Controllers
{
    [Route("api/Films")]
    public class FilmsController : Controller
    {
        private readonly IHtmlLocalizer _localizer;

        public FilmsController(IHtmlLocalizer localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var t = _localizer["hello"];
            return Ok();
        }
    }
}