using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using MySql.Data.MySqlClient;

namespace WindowsFormsPayroll
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignUp up = new SignUp();
            this.Hide();
            up.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            comLog.ResetText();
            txtUser.Clear();
            txtPass.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ConnectServer sr = new ConnectServer();
            try
            {
                string qry = "select * from login where Designation='" +comLog.Text.Trim()+ "' and UserName='" + txtUser.Text.Trim() + "' and Password='" +txtPass.Text.Trim()+ "'";
                MySqlDataAdapter adp = new MySqlDataAdapter(qry, sr.ConPass());
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Access Granted..!\n\n Welcome" + " " +txtUser.Text.Trim()+ " " + "to the System");
                    this.Hide();
                    Home hom = new Home();
                    hom.Show();
                }
                else
                {
                    MessageBox.Show("Access Denied..\n Please Try Again..!");
                }
                comLog.ResetText();
                txtPass.Clear();
                txtUser.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops: Something went wrong with the DB Connection Please try again\n" + ex.Message);
            }
            sr.ConnClose();
        }
    }
}
