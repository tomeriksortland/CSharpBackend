using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Model;
using Core.DomainModel;
using Core.DomainServices;
using Dapper;
using Infrastructure.DataAccess.Model;

namespace Infrastructure.DataAccess
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly string _connectionString;

        public SubscriptionRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString.ConnectionValue;
        }
        public async Task<bool> Create(Subscription subscription)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string insert = 
                "INSERT INTO Subscription (Id, Name, Email, Active, VerificationCode) VALUES (@Id, @Name, @Email, @Active, @VerificationCode)";
            var dbGameModel = MapToDB(subscription);
            var rowsAffected = await conn.ExecuteAsync(insert, dbGameModel);
            return rowsAffected == 1;
        }

        

        public async Task<Subscription> ReadByEmail(string email)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string select =
                "SELECT Id, Name, Email, Active, VerificationCode FROM Subscription WHERE Email = @Email";
            var result = await conn.QueryAsync<DbSubscriptionModel>(select, new {Email = email});
            var dbModel = result.SingleOrDefault();
            var mapToDomain = MapToDomain(dbModel);
            return mapToDomain;
        }

        

        public async Task<bool> Update(Subscription subscription)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string update = 
                "UPDATE Subscription SET Active=@Active WHERE Id=@Id";
            var dbSubscriptionModel = MapToDB(subscription);
            var rowsAffected = await conn.ExecuteAsync(update, dbSubscriptionModel);
            return rowsAffected == 1;
        }

        private DbSubscriptionModel MapToDB(Subscription subscription)
        {
            return new DbSubscriptionModel(subscription.Id.Value, subscription.Name, subscription.Email, subscription.Active, subscription.VerificationCode);
        }

        private Subscription MapToDomain(DbSubscriptionModel dbModel)
        {
            return new Subscription(dbModel.Name, dbModel.Email, dbModel.VerificationCode, dbModel.Id);
        }
    }
}
