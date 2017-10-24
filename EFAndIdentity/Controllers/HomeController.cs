using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFAndIdentity.Models;
using EFAndIdentity.Entities;
using Microsoft.AspNetCore.Identity;
using EFAndIdentity.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EFAndIdentity.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<MyIdentityUser> userManager;
        private RoleManager<MyIdentityRole> roleManager;

        public IActionResult Index()
        {
            //var db = new JobContext();
            //var newJob = new Job();
            //db.Job.Add(newJob);

            //var job = db.Job.FirstOrDefault(n => n.JobName == "abc");
            //job.Description = "dbcd";
            //db.SaveChanges();
            MyIdentityDbContext db = new MyIdentityDbContext();

            UserStore<MyIdentityUser> userStore = new UserStore<MyIdentityUser>(db);
            //userManager = new UserManager<MyIdentityUser>(userStore);

            RoleStore<MyIdentityRole> roleStore = new RoleStore<MyIdentityRole>(db);
            //roleManager = new RoleManager<MyIdentityRole>(roleStore);

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
