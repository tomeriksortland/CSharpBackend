using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Models
{
    public partial class Categories
    {
        public override string ToString()
        {
            return "Navn: " + this.CategoryName;
        }
    }
}
