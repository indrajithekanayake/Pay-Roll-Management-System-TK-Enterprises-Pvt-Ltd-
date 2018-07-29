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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        ConnectServer s = new ConnectServer();
       
        public bool CheckAdminPassword()//return bool values
            {//hard coded for admin password
                if (txtAdmin.Text.Trim()== "isuru@1997" || txtAdmin.Text.Trim() == "sewmal@1995")
                {
                    return true;//if true grant
                }
                else
                {
                    return false;//if false reject
                }
            }
            
        public bool Passwordmatch()//check for password match
            {
                
                if (txtPass.Text.Trim() == txtPass1.Text.Trim())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        private void btnSign_Click(object sender, EventArgs e)//grant to database if everithing is fine
        {

            if (Passwordmatch() == true && CheckAdminPassword() == true)
            {
                try
                {

                    s.ConnOpen();
                    string query = "insert into login (UserName,Password,Designation) values('" + txtUser.Text.Trim() + "','" + txtPass.Text.Trim() + "','" + comDes.Text.Trim() + "')";
                    MySqlCommand cmd = new MySqlCommand(query,s.ConPass());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("You have successfully registered..!");
                    Login log = new Login();
                    this.Hide();
                    log.Show();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("error caught please contact the developers" + ex.Message);
                }
                s.ConnClose();
                txtUser.Clear();
                txtPass.Clear();
                txtPass1.Clear();
                comDes.ResetText();
                txtAdmin.Clear();
            }
            else if (Passwordmatch() == false && CheckAdminPassword() == false)
            {
                MessageBox.Show("Both Admin and Your Password are incorrect");
                txtPass.Clear();
                txtPass1.Clear();
                txtAdmin.Clear();
            }
            else if (CheckAdminPassword() == false)
            {
                MessageBox.Show("Admin password incorrect");
                txtAdmin.Clear();
            }
            else if (Passwordmatch() == false)
            {
                MessageBox.Show("Passwords Doesn't match");
                txtPass.Clear();
                txtPass1.Clear();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)//reset
        {
            txtUser.Clear();
            txtPass.Clear();
            txtPass1.Clear();
            comDes.ResetText();
            txtAdmin.Clear();
            
        }

        private void btnBack_Click(object sender, EventArgs e)//open login form
        {
            Login log = new Login();
            this.Hide();
            log.Show();
        }
    }
}
