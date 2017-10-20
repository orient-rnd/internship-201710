using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interns2.AppServices.FlashCard.Models;
using Interns2.AppServices.FlashCard.Services;
using Interns2.Domain.Domains;

namespace Interns2.AppServices.FlashCard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService UserService)
        {
            _userService = UserService;
        }

        public IActionResult Index()
        {
            var user = new User();
            user.Email = "nguyenhuuloc304@gmail.com";
            user.Password = "123456aA@";
            _userService.SignUpAsync(user, user.Password);
            return View();
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
