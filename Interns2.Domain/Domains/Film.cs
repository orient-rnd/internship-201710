using Interns2.Domain.Enum;
using Interns2.Infrastructure.MongoDb.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Interns2.Domain.Domains
{
    [BsonIgnoreExtraElements]
    public class Film : AuditableEntityBase, IAggregateRoot
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(360)]
        public string Description { get; set; }

        public List<FilmType> Types { get; set; } = new List<FilmType>();

        [Required(ErrorMessage = "Date is required")]
        public DateTime DatePulish { get; set; }

        public string Producer { get; set; }

        [Range(1, 10, ErrorMessage = "Rate must be between 1 and 10")]
        [BsonRepresentation(BsonType.Int64, AllowTruncation = true)]
        public int Rate { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }

        public List<string> Actors { get; set; } = new List<string>();

        public FilmStatus Status { get; set; }

    }
}
