using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace login
{
    class MyConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(login.Properties.Resources.StringConection);
                connection.Open();
                return connection;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

    }
}
