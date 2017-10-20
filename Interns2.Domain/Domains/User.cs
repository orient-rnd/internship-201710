﻿using Interns2.Infrastructure.MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Interns2.Domain.Domains
{
    [BsonIgnoreExtraElements]
    public class User : AuditableEntityBase, IAggregateRoot
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@#$!%*?&])[A-Za-z\d#$@$!%*?&]{8,16}", ErrorMessage = "Password is not accepted")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [MinLength(5)]
        [MaxLength(20)]
        public string Fullname { get; set; }

        public string Address { get; set; }
    }
}
