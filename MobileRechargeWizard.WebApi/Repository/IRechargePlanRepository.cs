using MobileRechargeWizard.WebApi.Model;

namespace MobileRechargeWizard.WebApi.Repository
{
    public interface IRechargePlanRepository
    {
        Task CreateRechargePlan(RechargePlan rechargePlan);
        Task<IEnumerable<RechargePlan>> GetAllRechargePlan();
        Task<RechargePlan?> GetRechargePlanById(string id);
        Task<bool> UpdateRechargePlanById(string id, RechargePlan rechargePlan);
        Task<bool> DeleteRechargePlanById(string id);
    }
}
