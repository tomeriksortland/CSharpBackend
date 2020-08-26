using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Model
{
    public class DomainModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string VerificationCode { get; set; }

        public DomainModel(Guid id, string name, string email, bool active, string verificationCode)
        {
            Id = id;
            Name = name;
            Email = email;
            Active = active;
            VerificationCode = verificationCode;
        }

        public DomainModel()
        {
            
        }
    }
}
