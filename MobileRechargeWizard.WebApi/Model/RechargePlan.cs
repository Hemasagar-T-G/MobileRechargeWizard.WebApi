namespace MobileRechargeWizard.WebApi.Model
{
    public class RechargePlan
    {
        public string Id { get; set; }
        public string PlanName { get; set; }
        public List<PlanDetail> PlanDetails { get; set; }
        public decimal Price { get; set; }
        public Validity PlanValidity { get; set; }
    }
}
