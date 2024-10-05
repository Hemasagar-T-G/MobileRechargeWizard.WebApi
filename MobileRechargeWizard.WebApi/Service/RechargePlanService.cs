using MobileRechargeWizard.WebApi.Dto;
using MobileRechargeWizard.WebApi.Model;
using MobileRechargeWizard.WebApi.Service;
using MobileRechargeWizard.WebApi.Utilities.Enums;
using MongoDB.Driver;

namespace MobileRechargeWizard.WebApi.Services
{
    public class RechargePlanService : IRechargePlanService
    {
        private readonly IMongoCollection<RechargePlan> rechargePlansCollection;

        public RechargePlanService(IMongoCollection<RechargePlan> rechargePlansCollection)
        {
            this.rechargePlansCollection = rechargePlansCollection;
        }
        
        public async Task<ApiResponseDto<RechargePlan>> CreateRechargePlan(RechargePlanRequestDto request)
        {
            try
            {
                // This assumes PlanDetails are string representations of the enum values
                var planDetailsAsStrings = request.PlanDetails
                .Select(detail => ((PlanDetail)detail).ToString())
                .ToList();

                var rechargePlan = new RechargePlan
                {
                    PlanName = request.PlanName,
                    PlanDetails = planDetailsAsStrings,
                    Price = request.Price,
                    PlanValidity = request.PlanValidity 
                };

                // Assuming you're using an ID of type string for MongoDB
                await rechargePlansCollection.InsertOneAsync(rechargePlan);

                return new ApiResponseDto<RechargePlan>(rechargePlan, true, "Recharge plan created successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<RechargePlan>(null, false, "Failed to create recharge plan.", ex.Message);
            }
        }

        public async Task<ApiResponseDto<RechargePlan>> UpdateRechargePlanById(string id, RechargePlanRequestDto request)
        {
            try
            {
                var planDetailsAsStrings = request.PlanDetails
                .Select(detail => ((PlanDetail)detail).ToString())
                .ToList();
                var rechargePlan = new RechargePlan
                {
                    Id = id,
                    PlanName = request.PlanName,
                    PlanDetails = planDetailsAsStrings,
                    Price = request.Price,
                    PlanValidity = request.PlanValidity
                };

                var filter = Builders<RechargePlan>.Filter.Eq(r => r.Id, id);
                var updateResult = await rechargePlansCollection.ReplaceOneAsync(filter, rechargePlan);

                if (updateResult.MatchedCount == 0)
                {
                    return new ApiResponseDto<RechargePlan>(null, false, "Failed to update recharge plan.", "Plan not found.");
                }

                return new ApiResponseDto<RechargePlan>(rechargePlan, true, "Recharge plan updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<RechargePlan>(null, false, "Failed to update recharge plan.", ex.Message);
            }
        }
        
        public async Task<ApiResponseDto<RechargePlan>> GetRechargePlanById(string id)
        {
            var rechargePlan = await rechargePlansCollection.Find(r => r.Id == id).FirstOrDefaultAsync();

            if (rechargePlan == null)
            {
                return new ApiResponseDto<RechargePlan>(null, false, "Recharge plan not found.");
            }

            return new ApiResponseDto<RechargePlan>(rechargePlan, true, "Recharge plan retrieved successfully.");
        }

        public async Task<ApiResponseDto<List<RechargePlan>>> GetAllRechargePlan()
        {
            var rechargePlans = await rechargePlansCollection.Find(_ => true).ToListAsync();
            return new ApiResponseDto<List<RechargePlan>>(rechargePlans, true, "All recharge plans retrieved successfully.");
        }

        public async Task<ApiResponseDto<RechargePlan>> DeleteRechargePlanById(string id)
        {
            try
            {
                var result = await rechargePlansCollection.DeleteOneAsync(r => r.Id == id);

                if (result.DeletedCount == 0)
                {
                    return new ApiResponseDto<RechargePlan>(null, false, "Failed to delete recharge plan.", "Plan not found.");
                }

                return new ApiResponseDto<RechargePlan>(null, true, "Recharge plan deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<RechargePlan>(null, false, "Failed to delete recharge plan.", ex.Message);
            }
        }
    }
}
