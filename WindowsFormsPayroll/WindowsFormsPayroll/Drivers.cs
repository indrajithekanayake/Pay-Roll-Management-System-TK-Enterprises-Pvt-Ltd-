using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsPayroll
{
    public partial class Drivers : Form
    {
        public Drivers()
        {
            InitializeComponent();
            FillComboID();
            dataGridView1.DataSource = GetList();
        }
        ConnectServer s = new ConnectServer();
        MySqlCommand command;
        MySqlDataReader dtread;

        void FillComboID()//fill como box empid
        {

            string query = "select * from employee where (Designation='Driver'|| Designation ='Helper Driver')";
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
        }
        private void button1_Click(object sender, EventArgs e)//open form attendance
        {
            Attendance at = new Attendance();
            this.Hide();
            at.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)//open form loan
        {
            Loan ln = new Loan();
            this.Hide();
            ln.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)//open form laour
        {
            Lobor lab = new Lobor();
            this.Hide();
            lab.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)//open form final
        {
            Final fin = new Final();
            this.Hide();
            fin.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)//open form salary details
        {
            Budget but = new Budget();
            this.Hide();
            but.Show();
        }

        private void btnHome_Click_1(object sender, EventArgs e)//open form home
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }

        private DataTable GetList()//function that gets salary details to grid view
        {
            DataTable dt = new DataTable();
            string qry = "Select s.EmpID,e.Name, e.Basic,s.NoPay,l.Allow,s.OTPay,s.EPF8,s.EPF12,s.ETF3,s.ProductIns,s.TravelIns,a.Advance,a.Loan,s.Final from Salary s JOIN Employee e on s.EmpID = e.EmpID JOIN Attendance l on l.EmpID = e.EmpID Join loanadvance a on a.EmpID = e.EmpID where(Designation='Driver'|| Designation ='Helper Driver')";
            try
            {
                s.ConnOpen();
                command = new MySqlCommand(qry, s.ConPass());
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//get and display salary details when id is selected
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
                    MessageBox.Show("No Data found..!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops: Something went wrong with the DB Connection Please try again\n\n" + ex.Message);
            }
            s.ConnClose();
            //dataGridView1.DataSource = GetList();
        }

        private void button8_Click(object sender, EventArgs e)//reset
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
                Bitmap bm = new Bitmap(this.dataGridView1.Width = 1200, this.dataGridView1.Height = 500);
                dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width = 1200, this.dataGridView1.Height = 500));
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
