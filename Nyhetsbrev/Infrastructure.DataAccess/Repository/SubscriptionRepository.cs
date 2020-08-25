using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
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

        

        public Task<Subscription> ReadByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        private DBModel MapToDB(Subscription subscription)
        {
            return new DBModel(subscription.Id.ToString(), subscription.Name, subscription.Email, subscription.Active, subscription.VerificationCode);
        }
    }
}
