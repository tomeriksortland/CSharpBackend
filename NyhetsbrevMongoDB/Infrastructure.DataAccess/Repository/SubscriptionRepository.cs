using System.Threading.Tasks;
using Core.DomainModel;
using Core.DomainServices;
using MongoDB.Driver;

namespace Infrastructure.DataAccess
{
    
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private MongoClient dbClient = new MongoClient("mongodb://tomerik:<tomeriksortland>@testcluster-shard-00-00.srqwt.azure.mongodb.net:27017,testcluster-shard-00-01.srqwt.azure.mongodb.net:27017,testcluster-shard-00-02.srqwt.azure.mongodb.net:27017/<NewsletterDB>?ssl=true&replicaSet=atlas-11gv0r-shard-0&authSource=admin&retryWrites=true&w=majority");
        private string db = "NewsletterDB";

        public async Task<bool> Create(Subscription subscription)
        {
            var database = dbClient.GetDatabase(db);
            var collection = database.GetCollection<object>("Subscriptions");
            await collection.InsertOneAsync(subscription);
            return true;
        }

        

        public async Task<Subscription> ReadByEmail(string email)
        {
            //var database = dbClient.GetDatabase(db);
            //var collection = database.GetCollection<object>("Subscriptions");
            //var find = await collection.FindAsync(f=>f.Email == email);

            return null;
        }

        

        public async Task<bool> Update(Subscription subscription)
        {
            return false;
        }
    }
}
