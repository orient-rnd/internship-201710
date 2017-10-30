using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFAndIdentity.Models;
using EFAndIdentity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EFAndIdentity.Models.Identity;

namespace EFAndIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<MyIdentityUser> userManager;
        private readonly SignInManager<MyIdentityUser> loginManager;
        private readonly RoleManager<MyIdentityRole> roleManager;


        public HomeController(UserManager<MyIdentityUser> userManager,
           SignInManager<MyIdentityUser> loginManager,
           RoleManager<MyIdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.roleManager = roleManager;
        }


        public IActionResult Index()
        {
            //var db = new JobContext();
            //var newJob = new Job();
            //db.Job.Add(newJob);

            //var job = db.Job.FirstOrDefault(n => n.JobName == "abc");
            //job.Description = "dbcd";
            //db.SaveChanges();

            var user = new MyIdentityUser();
            user.Email = "nguyenhuuloc@gmail.com";
            user.FullName = "nguyenhuuloc";
            user.UserName = "nguyenhuuloc";
            user.PasswordHash = "123456aA@";

            this.userManager.CreateAsync(user);

            IdentityResult result = userManager.CreateAsync(user, "123456aA@").Result;
            if (result.Succeeded)
            {
                var t = 0;
            }

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
