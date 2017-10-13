using System;
using System.Collections.Generic;
using System.Text;

namespace Interns2.Infrastructure.MongoDb.Models
{
    public interface IAggregateRoot
    {
        string Id { get; set; }
    }
}
