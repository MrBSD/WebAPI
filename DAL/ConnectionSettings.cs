using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ConnectionSettings
    {
        public string ConnectionString { get; set; }
        public int ConnectTimeout { get; set; }
    }
}
