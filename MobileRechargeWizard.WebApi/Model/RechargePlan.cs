using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MobileRechargeWizard.WebApi.Utilities.Enums;

namespace MobileRechargeWizard.WebApi.Model
{
    public class RechargePlan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }
        public string PlanName { get; set; }
        public List<string> PlanDetails { get; set; }
        public double Price { get; set; }
        public Validity PlanValidity { get; set; }
    }
}
