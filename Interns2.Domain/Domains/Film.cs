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
<<<<<<< HEAD
        [Required(ErrorMessage = "Film's title is required")]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(360)]
=======
        [Required(ErrorMessage ="Please fill Title")]
        [StringLength(100)]
        public string Title { get; set; }
        
>>>>>>> mR.Son
        public string Description { get; set; }

        public List<FilmType> Types { get; set; } = new List<FilmType>();

<<<<<<< HEAD
        public FilmType Type { get; set; }

        [Required(ErrorMessage = "Date of publishing is required")]
=======
>>>>>>> mR.Son
        public DateTime? DatePublish { get; set; }

        public string Producer { get; set; }

        [BsonRepresentation(BsonType.Int64, AllowTruncation = true)]
<<<<<<< HEAD
        [Range(1, 10, ErrorMessage = "Film's rate must be between 1 and 10")]
        public int Rate { get; set; }

        [Required(ErrorMessage = "Film's image is required")]
=======
        [Range(0,10,ErrorMessage ="Fill 0 to 10")]
        public int Rate { get; set; }

        [StringLength(300)]
>>>>>>> mR.Son
        public string Image { get; set; }
        
        public string LinkFilm { get; set; }

        [Required(ErrorMessage = "Film's link is required")]
        public string LinkFilm { get; set; } //luu link phim

        public List<string> Actors { get; set; } = new List<string>();

        public FilmStatus Status { get; set; }
    }
}