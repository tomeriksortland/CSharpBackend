using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Model
{
    public class ConnectionString
    {
        public string ConnectionValue;

        public ConnectionString(string connectionValue)
        {
            ConnectionValue = connectionValue;
        }
    }
}
