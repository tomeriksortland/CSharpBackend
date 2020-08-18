using System;
using System.Collections.Generic;
using System.Text;

namespace NumberPuzzleWeb.Core.DomainModel
{
    public class ConnectionString
    {
        public string Value { get;  }

        public ConnectionString(string value)
        {
            Value = value;
        }
    }
}
