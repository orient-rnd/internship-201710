using Interns2.Infrastructure.MongoDb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Interns2.Domain.Domains
{
    public class User : AuditableEntityBase, IAggregateRoot
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [MinLength(5)]
        [MaxLength(20)]
        public string Fullname { get; set; }

        public string Address { get; set; }
    }
}
