using System;
using System.Collections.Generic;
using System.Text;

namespace Interns2.Infrastructure.MongoDb.Models
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        public string Id { get; set; }
    }
}