﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Interns2.Domain.Users.Models
{
    [BsonIgnoreExtraElements]
    public class UserAppToken
    {
        public string UserId { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}