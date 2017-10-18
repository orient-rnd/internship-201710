using Interns2.Infrastructure.MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interns2.Domain.Domains
{
    public class User : AuditableEntityBase, IAggregateRoot
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Fullname { get; set; }

        public string Address { get; set; }
    }
}
