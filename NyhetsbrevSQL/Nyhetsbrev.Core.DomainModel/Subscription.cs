using System;

namespace DomainModel
{
    public class Subscription
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string VerificationCode { get; set; }
        public bool Active { get; set; }
        public Guid? Id { get; set; }

        public Subscription()
        {
            
        }

        public Subscription(string name, string email, string verificationCode = null, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
            Email = email;
            VerificationCode = verificationCode ?? Guid.NewGuid().ToString();
        }
    }
}
