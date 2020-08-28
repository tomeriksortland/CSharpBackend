using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Model
{
    public class ViewModel
    {
        public string Name { get; }
        public string Email { get; }
        public string VerificationCode { get; }

        public ViewModel()
        {
            
        }

        public ViewModel(string name, string email, string verificationCode)
        {
            Name = name;
            Email = email;
            VerificationCode = verificationCode;
        }

        public ViewModel(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
