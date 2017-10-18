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
        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [StringLength(360)]
        [Required]
=======
        [Required]
        public string Title { get; set; }
        
>>>>>>> 427279d898440c57858ab52d279cc131fbca661b
        public string Description { get; set; }

        public List<FilmType> Types { get; set; } = new List<FilmType>();

<<<<<<< HEAD
        public FilmType Type { get; set; }
        

=======
>>>>>>> 427279d898440c57858ab52d279cc131fbca661b
        public DateTime? DatePublish { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        public string Producer { get; set; }

<<<<<<< HEAD
        [Range(0, 10)]
=======
        [BsonRepresentation(BsonType.Int64, AllowTruncation = true)]
>>>>>>> 427279d898440c57858ab52d279cc131fbca661b
        public int Rate { get; set; }

        public string Image { get; set; }

        public string LinkFilm { get; set; }

        public List<string> Actors { get; set; } = new List<string>();

        public FilmStatus Status { get; set; }
    }
}