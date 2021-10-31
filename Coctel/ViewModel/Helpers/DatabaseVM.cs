using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coctel.ViewModel.Helpers
{
    class DBSQLServerUtils
    {
        public static SqlConnection GetDBConnection(string dataSource, string initialCatalog, string user, string password)
        {
            // Connection string = Data Source=DESKTOP-HVNP78O;Initial Catalog=CoctelDB;Persist Security Info=True;User ID=sa;Password=developing

            string connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};Persist Security Info=True;User ID={user};Password={password}";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
            {
                string dataSource = "DESKTOP-HVNP78O";
                string initialCatalog = "CoctelDB";
                string user = "sa";
                string password = "developing";
                return DBSQLServerUtils.GetDBConnection(dataSource, initialCatalog, user, password);
            }
    }
}

