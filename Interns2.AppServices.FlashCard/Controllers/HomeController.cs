using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interns2.AppServices.FlashCard.Models;
using Interns2.Domain.Domains;
using Microsoft.AspNetCore.Identity;
using Interns2.Infrastructure.MongoDb;
using Interns2.Domain.Users.Models;
using BomBiEn.Domain.Users.Services;

namespace Interns2.AppServices.FlashCard.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IUserService _userService;
        //private readonly IMongoDbWriteRepository _writeRepository;

        public HomeController(IMongoDbWriteRepository writeRepository)
        {
            //_writeRepository = writeRepository;
            //_userService = userService;
        }

        public IActionResult Index()
        {
            //var user = new Domain.Users.Models.User();
            //user.Email = 
            //_userService.SignUpAsync(user, "123456aA@");
            return View();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            //if (!ModelState.IsValid)
            //{
            //    return new UnprocessableEntityObjectResult(ModelState);
            //}
            user.Id = Guid.NewGuid().ToString();
            //_writeRepository.Create(user);
            return Ok();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
