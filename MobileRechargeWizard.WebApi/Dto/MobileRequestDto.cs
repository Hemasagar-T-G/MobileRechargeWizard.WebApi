namespace MobileRechargeWizard.WebApi.Dto
{
    public class MobileRequestDto
    {
        public string PhoneNumber { get; set; } = null!;
        public string OwnerName { get; set; } = null!;
        public bool IsActive { get; set; }
        public string RechargePlan { get; set; } = null!;
        public DateTime RechargeDate { get; set; } = DateTime.UtcNow;
    }
}
