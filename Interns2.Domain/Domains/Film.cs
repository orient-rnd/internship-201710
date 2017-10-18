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
        [Required(ErrorMessage = "Film's title is required")]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(360)]
        public string Description { get; set; }

        public List<FilmType> Types { get; set; } = new List<FilmType>();

        public FilmType Type { get; set; }

        [Required(ErrorMessage = "Date of publishing is required")]
        public DateTime? DatePublish { get; set; }

        public string Producer { get; set; }

        [BsonRepresentation(BsonType.Int64, AllowTruncation = true)]
        [Range(1, 10, ErrorMessage = "Film's rate must be between 1 and 10")]
        public int Rate { get; set; }

        [Required(ErrorMessage = "Film's image is required")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Film's link is required")]
        public string LinkFilm { get; set; } //luu link phim

        public List<string> Actors { get; set; } = new List<string>();

        public FilmStatus Status { get; set; }

    }
}