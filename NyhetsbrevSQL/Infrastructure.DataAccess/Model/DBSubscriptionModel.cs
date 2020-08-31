using System;

namespace DataAccess.Model
{
    public class DbSubscriptionModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string VerificationCode { get; set; }

        public DbSubscriptionModel(Guid id, string name, string email, bool active, string verificationCode)
        {
            Id = id;
            Name = name;
            Email = email;
            Active = active;
            VerificationCode = verificationCode;
        }

        public DbSubscriptionModel()
        {
            
        }
    }
}
