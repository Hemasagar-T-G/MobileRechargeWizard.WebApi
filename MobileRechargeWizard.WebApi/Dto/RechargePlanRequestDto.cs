using MobileRechargeWizard.WebApi.Utilities.Enums;

namespace MobileRechargeWizard.WebApi.Dto
{
    public class RechargePlanRequestDto
    {
        public string PlanName { get; set; }

        public List<int> PlanDetails { get; set; }

        public double Price { get; set; }

        public Validity PlanValidity { get; set; }
    }
}
