using Microsoft.Extensions.Options;
using MobileRechargeWizard.WebApi.Model;
using MongoDB.Driver;

namespace MobileRechargeWizard.WebApi.Repository
{
    public class RechargePlanRepository : IRechargePlanRepository
    {
        private readonly IMongoCollection<RechargePlan> rechargePlanCollection;

        public async Task CreateRechargePlan(RechargePlan rechargePlan)
        {
            await rechargePlanCollection.InsertOneAsync(rechargePlan);
        }

        public RechargePlanRepository(IMongoCollection<RechargePlan> rechargePlanCollection)
        {
            this.rechargePlanCollection = rechargePlanCollection;
        }

        public async Task<IEnumerable<RechargePlan>> GetAllRechargePlan()
        {
            return await rechargePlanCollection.Find(r => true).ToListAsync();
        }

        public async Task<RechargePlan?> GetRechargePlanById(string id)
        {
            return await rechargePlanCollection.Find(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateRechargePlanById(string id, RechargePlan rechargePlan)
        {
            var result = await rechargePlanCollection.ReplaceOneAsync(r => r.Id == id, rechargePlan);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteRechargePlanById(string id)
        {
            var result = await rechargePlanCollection.DeleteOneAsync(r => r.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
