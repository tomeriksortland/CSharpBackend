using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsletterX.Core.Domain.Model;
using NewsletterX.Core.Domain.Serivce;

namespace NewsletterX.Infrastructure.API
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public Task<bool> Create(Subscription subscription)
        {
            //string connectionString = "";
            //var connection = new SqlConnection(ConnectionString)
            //connection.ExecuteAsync("INSERT INTO Registrations (Email, Code) VALUES (@Email, @Code)")
            return Task.FromResult(true);
        }

        public Task<Subscription> ReadByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
