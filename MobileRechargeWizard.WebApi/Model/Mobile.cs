namespace MobileRechargeWizard.WebApi.Model
{
    public class Mobile
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string OwnerName { get; set; }
        public bool IsActive { get; set; }
        public RechargePlan CurrentPlan { get; set; }
        public DateTime RechargeDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
