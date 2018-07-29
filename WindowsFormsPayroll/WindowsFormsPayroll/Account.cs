using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsPayroll
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
            FillCombo();
        }
        MySqlConnection connection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=prodb;SslMode=none;");
        MySqlCommand command;
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Close();
            hm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string qry = "delete from login where UserName = '" + comboBox1.Text.Trim() + "'";
                command = new MySqlCommand(qry, connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Account deleted sucessfully...!");
                Home hm = new Home();
                this.Hide();
                hm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops: Something went wrong with the DB Connection Please try again\n\n" + ex.Message);
            }
        }

       void FillCombo()
        {
            connection.Open();
            string query = "select * from login";
            command = new MySqlCommand(query, connection);
            MySqlDataReader dtread;
            try
            {
                dtread = command.ExecuteReader();
                while (dtread.Read())
                {
                    string sName = dtread.GetString("UserName");
                    comboBox1.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "select * from login where UserName = '" + comboBox1.Text.Trim() + "'";
                command = new MySqlCommand(query, connection);
                MySqlDataReader dtread = command.ExecuteReader();
                if (dtread.Read())
                {
                    txtUserName.Text = (dtread["UserName"].ToString());
                    txtPass1.Text = (dtread["Password"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            connection.Close();

        }

        public bool Passwordmatch()
        {

            if (textBox2.Text.Trim() == txtPass2.Text.Trim())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text=="" || txtPass2.Text=="")
            {
                MessageBox.Show("Enter fields to Save");
                textBox1.Clear();
                textBox2.Clear();
                txtPass2.Clear();
            }
            else
            {
                string query1 = "update login set UserName='" + textBox1.Text + "',Password='" + textBox2.Text + "' where UserName='" + this.comboBox1.Text + "'";
                if (Passwordmatch() == true)
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("User Account updated sucessfully..!");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("error caught please contact the developers" + ex.Message);
                    }
                    connection.Close();
                    Home hm = new Home();
                    this.Hide();
                    hm.Show();
                }
                else if (Passwordmatch() == false)
                {
                    MessageBox.Show("Passwords Doesn't match");
                    textBox2.Clear();
                    txtPass2.Clear();
                }
            }
                
        }
    }
}
