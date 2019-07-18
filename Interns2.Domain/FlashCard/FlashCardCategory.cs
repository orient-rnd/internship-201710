using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using Interns2.Infrastructure.MongoDb.Models;

namespace Interns2.Domain.FlashCard
{
    [BsonIgnoreExtraElements]
    public class FlashCardCategory : AuditableEntityBase, IAggregateRoot
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public bool IsFaceAShowFirst { get; set; }

        public bool IsRandom { get; set; }

        public int DisplayOrder { get; set; }
    }
}