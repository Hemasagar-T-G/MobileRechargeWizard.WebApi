using MobileRechargeWizard.WebApi.Model;
using MobileRechargeWizard.WebApi.Repository;
using MobileRechargeWizard.WebApi.Dto;
using MobileRechargeWizard.WebApi.Utilities.Enums;

namespace MobileRechargeWizard.WebApi.Service
{
    public class MobileService : IMobileService
    {
        private readonly IMobileRepository mobileRepository;
        private readonly IRechargePlanRepository rechargePlanRepository;

        public MobileService(IMobileRepository mobileRepository, IRechargePlanRepository rechargePlanRepository)
        {
            this.mobileRepository = mobileRepository;
            this.rechargePlanRepository = rechargePlanRepository;
        }

        public async Task<ApiResponseDto<Mobile>> CreateAsync(MobileRequestDto request)
        {
            try
            {
                var rechargePlan = await rechargePlanRepository.GetRechargePlanById(request.RechargePlan);

                if (rechargePlan == null)
                {
                    return new ApiResponseDto<Mobile>(null, false, "Recharge plan not found.", "NotFound");
                }

                DateTime expiryDate = CalculateExpiryDate(rechargePlan.PlanValidity);

                var mobile = new Mobile
                {
                    PhoneNumber = request.PhoneNumber,
                    OwnerName = request.OwnerName,
                    IsActive = request.IsActive,
                    RechargePlan = rechargePlan,
                    RechargeDate = DateTime.UtcNow,
                    ExpiryDate = expiryDate
                };

                await mobileRepository.CreateMobileData(mobile);
                return new ApiResponseDto<Mobile>(mobile, true, "Mobile created successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<Mobile>(null, false, "Failed to create mobile.", ex.Message);
            }
        }

        public async Task<ApiResponseDto<IEnumerable<Mobile>>> GetAllAsync()
        {
            try
            {
                var mobiles = await mobileRepository.GetAllMobileData();
                return new ApiResponseDto<IEnumerable<Mobile>>(mobiles, true, "Retrieved all mobiles successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<IEnumerable<Mobile>>(null, false, "Failed to retrieve mobiles.", ex.Message);
            }
        }

        public async Task<ApiResponseDto<Mobile>> GetByIdAsync(string id)
        {
            try
            {
                var mobile = await mobileRepository.GetMobileDataById(id);
                if (mobile == null)
                {
                    return new ApiResponseDto<Mobile>(null, false, "Mobile not found.", "NotFound");
                }
                return new ApiResponseDto<Mobile>(mobile, true, "Mobile retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<Mobile>(null, false, "Failed to retrieve mobile.", ex.Message);
            }
        }
        
        public async Task<ApiResponseDto<Mobile>> UpdateAsync(string id, MobileRequestDto request)
        {
            try
            {
                var rechargePlan = await rechargePlanRepository.GetRechargePlanById(request.RechargePlan);
                if (rechargePlan == null)
                {
                    return new ApiResponseDto<Mobile>(null, false, "Recharge plan not found.", "NotFound");
                }
                DateTime expiryDate = CalculateExpiryDate(rechargePlan.PlanValidity);

                var mobile = new Mobile
                {
                    PhoneNumber = request.PhoneNumber,
                    OwnerName = request.OwnerName,
                    IsActive = request.IsActive,
                    RechargePlan = rechargePlan,
                    RechargeDate = request.RechargeDate,
                    ExpiryDate = expiryDate
                };

                var result = await mobileRepository.UpdateMobileData(id, mobile);
                if (!result)
                {
                    return new ApiResponseDto<Mobile>(null, false, "Failed to update mobile.", "NotFound");
                }
                return new ApiResponseDto<Mobile>(mobile, true, "Mobile updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<Mobile>(null, false, "Failed to update mobile.", ex.Message);
            }

        }

        public async Task<ApiResponseDto<Mobile>> DeleteAsync(string id)
        {
            try
            {
                var result = await mobileRepository.DeleteMobileDataById(id);
                if (!result)
                {
                    return new ApiResponseDto<Mobile>(null, false, "Failed to delete mobile.", "NotFound");
                }
                return new ApiResponseDto<Mobile>(null, true, "Mobile deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<Mobile>(null, false, "Failed to delete mobile.", ex.Message);
            }
        }

        //==========UTILITY METHODS==========//
        private DateTime CalculateExpiryDate(Validity planValidity)
        {
            int validityDays = (int)planValidity;
            return DateTime.UtcNow.AddDays(validityDays);
        }
    }
}
