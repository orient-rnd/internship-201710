using System;
using System.Collections.Generic;
using System.Text;
using Interns2.Infrastructure.MongoDb.Models;
using System.ComponentModel.DataAnnotations;

namespace Interns2.Domain.Domains
{
    public class Student : AuditableEntityBase, IAggregateRoot
    {
        [Required]
        
        public string FullName { get; set; }

        public List<Address> Address { get; set; } = new List<Domains.Address>();
    }
}
