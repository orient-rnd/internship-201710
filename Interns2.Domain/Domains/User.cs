using Interns2.Infrastructure.MongoDb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Interns2.Domain.Domains
{
    public class User : AuditableEntityBase, IAggregateRoot
    {
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(20, MinimumLength = 5)]
        public string FullName { get; set; }

        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [Required(ErrorMessage = "User Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Passwork is required")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]", ErrorMessage = "Please enter Passwork correct")]
        public string PassWord { get; set; }

        public string Address { get; set; }
    }
}
