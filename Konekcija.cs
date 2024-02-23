using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Data;

namespace WpfApp1
{
    class Konekcija
    {
        public SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder conSb = new SqlConnectionStringBuilder()
            {
                DataSource = @"DESKTOP-9NN1BSR\SQLEXPRESS",
                InitialCatalog = "Pivara",
                IntegratedSecurity = true
            };
            string kon = conSb.ToString();
            SqlConnection konekcija = new SqlConnection(kon);
            return konekcija;
        }
    }
}
