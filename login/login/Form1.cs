using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnAccess_Click(object sender, EventArgs e)
        {
            //string validUser = "select * from users where email = '{0}'and pwd='{0}'";
            //validUser = string.Format(validUser, txtEmail.Text, txtPWD.Text);

            //SqlDataReader myReader = null; 

            //SqlCommand myCommand = new SqlCommand(validUser, MyConnection.GetConnection());

            //myReader = myCommand.ExecuteReader();

            //while(myReader.Read())
            //{
            //    if (txtEmail.Text == myReader["email"].ToString() && txtPWD.Text == myReader["pwd"].ToString())
            //    {
            //        MessageBox.Show("Correcto");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Incorrecto");
            //    }
            //}

            DataTable myDataTable = new DataTable();
            SqlCommand myCommand = new SqlCommand("select * from users", MyConnection.GetConnection());
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand);

            myDataAdapter.Fill(myDataTable);

            if(myCommand.Connection.State == ConnectionState.Open)
            {
                myCommand.Connection.Close();
            }

            dataGridView1.DataSource = myDataTable;

          
  
        }
    }
}
