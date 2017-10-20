using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using Interns2.Infrastructure.MongoDb.Models;
using Intern2.Infrastructure.Identity.MongoDb;

namespace Interns2.Domain.Users.Models
{
    [BsonIgnoreExtraElements]
    public class Role : IdentityRole<string>, IAggregateRoot
    {
        /// <summary>
        /// Permissions
        /// </summary>
        public IEnumerable<string> Permissions { get; set; }
    }
}