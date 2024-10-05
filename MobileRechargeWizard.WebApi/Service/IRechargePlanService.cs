using MobileRechargeWizard.WebApi.Dto;
using MobileRechargeWizard.WebApi.Model;

namespace MobileRechargeWizard.WebApi.Service
{
    public interface IRechargePlanService
    {
        Task<ApiResponseDto<RechargePlan>> CreateRechargePlan(RechargePlanRequestDto request);

        Task<ApiResponseDto<RechargePlan>> UpdateRechargePlanById(string id, RechargePlanRequestDto request);

        Task<ApiResponseDto<RechargePlan>> GetRechargePlanById(string id);

        Task<ApiResponseDto<List<RechargePlan>>> GetAllRechargePlan();

        Task<ApiResponseDto<RechargePlan>> DeleteRechargePlanById(string id);
    }
}
