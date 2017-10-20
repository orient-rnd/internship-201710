using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Interns2.Infrastructure.MongoDb.Models;

namespace Interns2.Domain.Users.Models
{
    [BsonIgnoreExtraElements]
    public class UserPaymentProfile : AuditableEntityBase
    {
        public string UserId { get; set; }

        public string PaymentProvider { get; set; }

        public string PaymentMethodId { get; set; }

        public string PaymentMethodName
        {
            get
            {
                return PaymentMethodId?.Split('.').LastOrDefault();
            }
        }

        public string BankId { get; set; }

        public string BankName { get; set; }

        public string LastFourDigits { get; set; }

        public string ExpiryDate { get; set; }

        public bool IsCreditCard { get; set; }

        public string ExternalPaymentProfileId { get; set; }

        public string Logo
        {
            get
            {
                return $"https://BomBiEn0prod.blob.core.windows.net/payment-methods-logos/{PaymentMethodName.ToLower()}.png";
            }
        }

        public bool IsDefault { get; set; }
    }
}