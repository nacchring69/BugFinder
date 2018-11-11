using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BugFinder
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connectionString;
            connectionString = "server=localhost;database=advsoft;user id=root;password=;integrated security=true";

            MySqlConnection myOleDbConn = new MySqlConnection(connectionString);
            myOleDbConn.Open();
            
            String firstname = txtFname.Text;
            String lastname = txtLname.Text;
            String emails = txtEmail.Text;
            String pass = txtPassword.Text;

            // Format and execute SQL statement.[3
            String sql = String.Format("Insert Into user (fname, lname, email, password) Values({0}, '{1}', '{2}','{3}')", firstname, lastname, emails, pass);
            MySqlCommand cmd = new MySqlCommand(sql, myOleDbConn);
            try
            {
                MessageBox.Show("Added Successfully");
                cmd.ExecuteReader();
                myOleDbConn.Close();
            }
            catch
            {
                //Console.WriteLine("Bad input! Canceling request");
                MessageBox.Show("Not Connected");
                return;
            }
        }
    }
}
