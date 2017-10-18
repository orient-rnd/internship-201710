using Interns2.Domain.Enum;
using Interns2.Infrastructure.MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interns2.Domain.Domains
{
    public class Film : AuditableEntityBase, IAggregateRoot
    {
        public string FilmName { get; set; }

        public string Description { get; set; }

        public List<FilmType> Types { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public int Rate { get; set; }

        public string Image { get; set; }

        public List<string> Actors { get; set; }

        public FilmStatus Status { get; set; }
    }
}
