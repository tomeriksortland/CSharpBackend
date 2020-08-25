using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.ViewModel
{
    public class ViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public ViewModel(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public ViewModel()
        {
            
        }
    }
}
