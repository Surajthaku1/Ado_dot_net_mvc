using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Ado_dot_net_mvc.Models
{
    public class DbConfig
    {
        public SqlConnection sql { get; }
        public DbConfig()
        {
            string cnn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            sql = new SqlConnection(cnn);
        }
    }
}