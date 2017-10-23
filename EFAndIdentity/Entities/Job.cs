using System;
using System.Collections.Generic;

namespace EFAndIdentity.Entities
{
    public partial class Job
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public int? Applied { get; set; }
    }
}
