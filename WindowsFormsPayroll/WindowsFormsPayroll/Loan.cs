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
    public partial class Loan : Form
    {
        public Loan()
        {
            InitializeComponent();
            FillComboID();
        }
        ConnectServer s = new ConnectServer();
        MySqlCommand command;

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Attendance at = new Attendance();
            this.Hide();
            at.Show();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Drivers dri = new Drivers();
            this.Hide();
            dri.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Lobor lab = new Lobor();
            this.Hide();
            lab.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Final fin = new Final();
            this.Hide();
            fin.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Budget but = new Budget();
            this.Hide();
            but.Show();
        }

        void FillComboID()//this will fill comobox with existing ids
        {
            s.ConnOpen();
            string query = "select * from employee";
            command = new MySqlCommand(query, s.ConPass());
            MySqlDataReader dtread;
            try
            {
                dtread = command.ExecuteReader();
                while (dtread.Read())
                {
                    string sID = dtread.GetString("EmpID");
                    comboBox1.Items.Add(sID);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();
        }
        void FillComboSet()//fill name field when id match with database reading
        {
            try
            {
                s.ConnOpen();
                string query = "select * from employee where EmpID = '" + comboBox1.Text.Trim() + "'";
                command = new MySqlCommand(query, s.ConPass());
                MySqlDataReader dtread1 = command.ExecuteReader();
                if (dtread1.Read())
                {
                    textBox1.Text = (dtread1["Name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();
        }

        void FillComboType()//this will check and hide textbox according to user selection
        {
            try
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                if(comboBox2.Text == "Advance")
                {
                    textBox2.Enabled = true;
                    textBox3.Enabled = false;
                }
                else if(comboBox2.Text == "Loan")
                {
                    textBox2.Enabled = false;
                    textBox3.Enabled = true;
                }
                else if(comboBox2.Text=="Both")
                {
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillComboSet();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillComboType();
        }
        public string check;
        private void button7_Click(object sender, EventArgs e)//check availabilyty to choose wether to run insert or update query when clicked this button
        {
            try
                {
                    s.ConnOpen();
                    string query = "insert into loanadvance(Advance,Loan,Date,EmpID) values('" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + dateTimePicker1.Text.Trim() + "','" + comboBox1.Text.Trim() + "')";
                    MySqlCommand cmd = new MySqlCommand(query, s.ConPass());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data inserted sucessfully");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    dateTimePicker1.ResetText();
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    s.ConnClose();
                    dataGridView1.DataSource = GetList();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
            }

        private void button8_Click(object sender, EventArgs e)//reset everything when clicked
        {
            try
            {
                s.ConnOpen();
                string query = "select * from loanadvance where EmpID='"+comboBox1.Text+"'";
                command = new MySqlCommand(query, s.ConPass());
                MySqlDataReader dtread1 = command.ExecuteReader();
                if (dtread1.Read())
                {
                    check = (dtread1["EmpID"].ToString());
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();


            if (comboBox1.Text == check.ToString())
            {
                try
                {
                    s.ConnOpen();
                    string query = "update loanadvance set Advance='" + textBox2.Text + "',Loan='" + textBox3.Text + "',Date='" + dateTimePicker1.Text + "' where EmpID='"+comboBox1.Text+"'";
                    command = new MySqlCommand(query, s.ConPass());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Updated Sucessfully\n");
                    s.ConnClose();
                    dataGridView1.DataSource = GetList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oops: Something went wrong with the DB Connection Please try again\n\n" + ex.Message);
                }
            }
        }

        private void Loan_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetList();
        }//display datagrid when form loads

        private DataTable GetList()//get data in grid view from database
        {
            DataTable dt = new DataTable();
            string query = "Select e.EmpID,s.Name, e.Date, e.Advance, e.Loan From loanadvance e JOIN Employee s on e.EmpID = s.EmpID";
            try
            {
                s.ConnOpen();
                command = new MySqlCommand(query, s.ConPass());
                MySqlDataReader red = command.ExecuteReader();
                dt.Load(red);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();
            return dt;
        }
    }
}
