﻿using System;
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
        DataTable myDataTable;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnAccess_Click(object sender, EventArgs e)
        {
            myLogin();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            FormRegistrar myFormRegistrar = new FormRegistrar();
            myFormRegistrar.ShowDialog();
        }

        private void myLogin()
        {
            string validUser = "select email, pwd from users where email = '{0}'and pwd='{1}'";
            validUser = string.Format(validUser, txtEmail.Text, txtPWD.Text);

            try
            {
                myDataTable = new DataTable();
                SqlCommand myCommand = new SqlCommand(validUser, MyConnection.GetConnection());
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand);

                myDataAdapter.Fill(myDataTable);

                if (myCommand.Connection.State == ConnectionState.Open)
                {
                    myCommand.Connection.Close();
                }

                if (myDataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Bien");
                }
                else
                {
                    MessageBox.Show("Error");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        
    }
}
