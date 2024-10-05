using MobileRechargeWizard.WebApi.Model;

namespace MobileRechargeWizard.WebApi.Repository
{
    public interface IMobileRepository
    {
        Task CreateMobileData(Mobile mobile);
        Task<List<Mobile>> GetAllMobileData();
        Task<Mobile?> GetMobileDataById(string id);
        Task<bool> UpdateMobileData(string id, Mobile mobile);
        Task<bool> DeleteMobileDataById(string id);
    }
}
