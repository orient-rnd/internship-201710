using EFAndIdentity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAndIdentity.Models.Identity
{
    public class MyIdentityDbContext : JobContext
    {
        public MyIdentityDbContext() : base()
        {

        }
    }

    public class MyIdentityUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
    }

    public class MyIdentityRole : IdentityRole
    {
        public MyIdentityRole()
        {

        }

        public MyIdentityRole(string roleName, string description) : base(roleName)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}
