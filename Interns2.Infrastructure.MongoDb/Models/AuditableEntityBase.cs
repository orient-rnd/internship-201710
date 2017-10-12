using System;
using System.Collections.Generic;
using System.Text;

namespace Interns2.Infrastructure.MongoDb.Models
{
    public class AuditableEntityBase : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditableEntityBase"/> class.
        /// </summary>
        protected AuditableEntityBase()
        {
            CreatedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>
        /// The updated date.
        /// </value>
        public DateTime UpdatedDate { get; set; }

        public string SEODescription { get; set; }

        public string SEOKeyWords { get; set; }

        public string SEOTitle { get; set; }
    }
}
