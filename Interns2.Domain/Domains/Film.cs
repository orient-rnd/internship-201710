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
        private string title;

        public string GetTitle()
        {
            return title;
        }

        public void SetTitle(string value)
        {
            title = value;
        }

        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [StringLength(360)]
        [Required]
        public string Description { get; set; }

        [Required]
        public List<FilmType> Types { get; set; } = new List<FilmType>();

        public FilmType Type { get; set; }
        

        public DateTime? DatePublish { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        public string Producer { get; set; }

        [Range(0, 10)]
        [BsonRepresentation(BsonType.Int64, AllowTruncation = true)]
        public int Rate { get; set; }

        public string Image { get; set; }

        [Required]
        public string LinkFilm { get; set; }

        public List<string> Actors { get; set; } = new List<string>();

        public FilmStatus Status { get; set; }
    }
}