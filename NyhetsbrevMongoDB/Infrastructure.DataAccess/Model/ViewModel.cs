using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.ViewModel
{
    public class ViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string VerificationCode { get; set; }

        public ViewModel(string name, string email, string verificationCode = null)
        {
            Name = name;
            Email = email;
            VerificationCode = verificationCode;
        }

        public ViewModel()
        {
            
        }
    }
}
