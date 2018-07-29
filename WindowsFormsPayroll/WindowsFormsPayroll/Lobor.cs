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
    public partial class Lobor : Form
    {
        public Lobor()
        {
            InitializeComponent();
            FillComboID();
            dataGridView1.DataSource = GetList();
        }
        ConnectServer s = new ConnectServer();
        MySqlCommand command;
        MySqlDataReader dtread;

        void FillComboID()
        {

            string query = "select * from employee where Designation='Labour'";
            command = new MySqlCommand(query, s.ConPass());
            MySqlDataReader dtread;
            try
            {
                s.ConnOpen();
                dtread = command.ExecuteReader();
                while (dtread.Read())
                {
                    comboBox1.Items.Add(dtread.GetString("EmpID"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();
        }//fill combo empid
        private void btnHome_Click_1(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }//open home form
        private void button1_Click(object sender, EventArgs e)
        {
            Attendance at = new Attendance();
            this.Hide();
            at.Show();
        }//open attendance form
        private void button2_Click_1(object sender, EventArgs e)
        {
            Loan ln = new Loan();
            this.Hide();
            ln.Show();
        }// open loan form

        private void button3_Click_1(object sender, EventArgs e)
        {
            Drivers dri = new Drivers();
            this.Hide();
            dri.Show();
        }//open drivers form

        private void button5_Click_1(object sender, EventArgs e)
        {
            Final fin = new Final();
            this.Hide();
            fin.Show();
        }//open final form

        private void button6_Click_1(object sender, EventArgs e)
        {
            Budget but = new Budget();
            this.Hide();
            but.Show();
        }//open salary details form

        private DataTable GetList()
        {
            DataTable dt = new DataTable();
            string query = "Select s.EmpID,e.Name, e.Basic,s.NoPay,l.Allow,s.OTPay,s.EPF8,s.EPF12,s.ETF3,s.ProductIns,s.TravelIns,a.Advance,a.Loan,s.Final from Salary s JOIN Employee e on s.EmpID = e.EmpID JOIN Attendance l on l.EmpID = e.EmpID Join loanadvance a on a.EmpID = e.EmpID where (e.Designation='Labour')";
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
        }//grid view function

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                s.ConnOpen();
                string query = "select * from employee where  (EmpID = '" + int.Parse(comboBox1.Text.Trim()) + "')";
                command = new MySqlCommand(query, s.ConPass());
                dtread = command.ExecuteReader();
                if (dtread.Read())
                {
                    textBox1.Text = (dtread["Name"].ToString());
                }
                else
                {
                   MessageBox.Show("No Data found..!");
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops: Something went wrong with the DB Connection Please try again\n\n" + ex.Message);
            }
            s.ConnClose();
            // salary
            try
            {
                s.ConnOpen();
                string query = "select * from salary where  (EmpID = '" + int.Parse(comboBox1.Text.Trim()) + "')";
                command = new MySqlCommand(query, s.ConPass());
                dtread = command.ExecuteReader();
                if (dtread.Read())
                {
                    textBox2.Text = (dtread["Final"].ToString());
                }
                else
                {
                    comboBox1.ResetText();
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show("No Data found..!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops: Something went wrong with the DB Connection Please try again\n\n" + ex.Message);
            }
            s.ConnClose();
           
        }//display when id selected along with grid view

        private void button8_Click(object sender, EventArgs e)//reset everithing
        {
            comboBox1.ResetText();
            textBox1.Clear();
            textBox2.Clear();
            this.dataGridView1.DataSource = null;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(this.dataGridView1.Width=1200, this.dataGridView1.Height=500);
                dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width=1200, this.dataGridView1.Height=500));
                e.Graphics.DrawImage(bm, 10, 10);
                printPreviewDialog1.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }
    }
}
