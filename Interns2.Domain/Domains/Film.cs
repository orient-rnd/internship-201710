using Interns2.Domain.Enum;
using Interns2.Infrastructure.MongoDb.Models;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interns2.Domain.Domains
{
    //loai bo 1 so thu neu ko match dc
    [BsonIgnoreExtraElements]
    public class Film : AuditableEntityBase, IAggregateRoot
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<FilmType> Types { get; set; } = new List<FilmType>();

        public DateTime DatePublish { get; set; }

        public string Producer { get; set; }

        public int Rate { get; set; }

        public string Image { get; set; }

        public List<string> Actors { get; set; } = new List<string>();

        public FilmStatus Status { get; set; }

    }
}
