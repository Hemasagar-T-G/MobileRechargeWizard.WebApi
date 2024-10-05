using Microsoft.Extensions.Options;
using MobileRechargeWizard.WebApi.Model;
using MongoDB.Driver;

namespace MobileRechargeWizard.WebApi.Repository
{
    public class MobileRepository : IMobileRepository
    {
        private readonly IMongoCollection<Mobile> mobileCollection;

        public MobileRepository(IMongoCollection<Mobile> mobileCollection)
        {
            this.mobileCollection = mobileCollection;
        }

        public async Task CreateMobileData(Mobile mobile)
        {
            await mobileCollection.InsertOneAsync(mobile);
        }

        public async Task<List<Mobile>> GetAllMobileData()
        {
            return await mobileCollection.Find(m => true).ToListAsync();
        }

        public async Task<Mobile?> GetMobileDataById(string id)
        {
            return await mobileCollection.Find(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMobileData(string id, Mobile mobile)
        {
            var result = await mobileCollection.ReplaceOneAsync(m => m.Id == id, mobile);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteMobileDataById(string id)
        {
            var result = await mobileCollection.DeleteOneAsync(m => m.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
