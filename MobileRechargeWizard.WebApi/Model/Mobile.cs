using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MobileRechargeWizard.WebApi.Model
{
    public class Mobile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string OwnerName { get; set; }
        public bool IsActive { get; set; }
        public RechargePlan RechargePlan { get; set; }
        public DateTime RechargeDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
