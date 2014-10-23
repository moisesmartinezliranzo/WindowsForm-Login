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
    public partial class FormRegistrar : Form
    {
        
        public FormRegistrar()
        {
            InitializeComponent();
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            myNewUser();
        }

        private void myNewUser()
        {
            string createUser = "insert into users(nombre,apellido,email,pwd)values('{0}','{1}','{2}','{3}')";
            createUser = string.Format(createUser, txtNombre.Text, txtApellido.Text, txtEmail.Text, txtPWD.Text);

            try
            {
                SqlCommand myCommand = new SqlCommand(createUser,MyConnection.GetConnection());
                myCommand.ExecuteNonQuery();

                if(myCommand.Connection.State == ConnectionState.Open)
                {
                    myCommand.Connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
