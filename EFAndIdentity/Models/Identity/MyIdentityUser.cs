using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFAndIdentity.Models.Identity
{    
    public class MyIdentityUser : IdentityUser
    {
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }
    }

    public class MyIdentityDbContext : IdentityDbContext<MyIdentityUser, MyIdentityRole, string>
    {
        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options) : base(options)
        {
            //nothing here
        }

    }
}