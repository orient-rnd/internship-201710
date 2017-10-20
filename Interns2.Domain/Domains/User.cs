using Interns2.Infrastructure.MongoDb.Models;
<<<<<<< HEAD
=======
using MongoDB.Bson.Serialization.Attributes;
>>>>>>> mR.Son
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Interns2.Domain.Domains
{
<<<<<<< HEAD
    public class User : AuditableEntityBase, IAggregateRoot
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!#%*?&])[A-Za-z\d$@$!#%*?&]{8,16}", ErrorMessage = "Password is invalid")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [MinLength(5)]
        [MaxLength(20)]
        public string Fullname { get; set; }

        public string Address { get; set; }

        public string AccessToken { get; set; } = Guid.NewGuid().ToString();

        public bool Subscription { get; set; }
    }
}
=======
    [BsonIgnoreExtraElements]
    public class User : AuditableEntityBase, IAggregateRoot
    {
        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}",ErrorMessage = "Why can you do that with Email?")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!#%*?&])[A-Za-z\d$@$!#%*?&]{8,16}", ErrorMessage = "Why can you do that with Password?")]
        public string Password { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 5,ErrorMessage ="Please Fill from 5 to 20 letters")]
        public string Fullname { get; set; }

        [StringLength(300)]
        public string Address { get; set; }
    }
}
>>>>>>> mR.Son
