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
using System.Globalization;

namespace WindowsFormsPayroll
{
    public partial class Attendance : Form
    {
        public Attendance()
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

            
            private void button2_Click(object sender, EventArgs e)
            {
                Loan ln = new Loan();
                this.Hide();
                ln.Show();
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

        private void Attendance_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetList();
        }
        public DataTable GetList()//grid view function
        {
            DataTable dt = new DataTable();
            string query = "Select e.EmpID,s.Name, e.OTHours, e.Days, e.Allow From Attendance e JOIN Employee s on e.EmpID = s.EmpID";
            try
            {
                s.ConnOpen();
                MySqlCommand command = new MySqlCommand(query, s.ConPass());
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
        void FillComboID()//display Available employee ids in combobox list
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
                    comboBox1.Items.Add(dtread.GetString("EmpID"));
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();
            
        }
        
        public string checks1,checks2,x;
        public DateTime dt;
        private void btnGo_Click(object sender, EventArgs e)//1233
        {
            try
            {
                s.ConnOpen();
                string query = "select * from attendance where  (EmpID = '" + int.Parse(comboBox1.Text) + "')";
                command = new MySqlCommand(query, s.ConPass());
                MySqlDataReader dtread = command.ExecuteReader();
                if (dtread.Read())
                {
                    checks1 = (dtread["EmpID"].ToString());
                    checks2 = (dtread["Days"].ToString());
                    dt = DateTime.Parse(checks2);
                    x = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();
            

            if (x == dateTimePicker3.Text && checks1==comboBox1.Text)
            {
                MessageBox.Show("Record Already Exists in the DB");
            }
            else
            {
                try
                {
                    s.ConnOpen();
                    string query = "insert into Attendance(EmpID,Days,OTHours,Allow) values('" + comboBox1.Text.Trim() + "','" + dateTimePicker3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "')";
                    command = new MySqlCommand(query, s.ConPass());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data inserted sucessfully..");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
                s.ConnClose();
            }
            comboBox1.ResetText();
            dateTimePicker3.ResetText();
            textBox1.Clear();
            textBox2.Clear();
            dataGridView1.DataSource = GetList();


        }
        public string news;

        private void btnDown_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height=800);
                dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height=800));
                e.Graphics.DrawImage(bm, 10, 10);
                printPreviewDialog1.Show();
            }
            
            catch(Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//run query when item is selected from the list
        {
            s.ConnOpen();
            string query = "select * from employee where EmpID='" + comboBox1.Text + "'";
            command = new MySqlCommand(query, s.ConPass());
            MySqlDataReader dtread;
            try
            {
                dtread = command.ExecuteReader();
                while (dtread.Read())
                {
                   news = (dtread["Designation"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();
            //check for designation labour to disable text boxes
            if (news == "Labour")
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)//update existing details
        {
            try
            {
                s.ConnOpen();
                string query = "select * from attendance where  (EmpID = '" + int.Parse(comboBox1.Text) + "')";
                command = new MySqlCommand(query, s.ConPass());
                MySqlDataReader dtread = command.ExecuteReader();
                if (dtread.Read())
                {
                    checks1 = (dtread["EmpID"].ToString());
                    checks2 = (dtread["Days"].ToString());
                    dt = DateTime.Parse(checks2);
                    x = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();
            try
            {
                if(checks1==null && checks2==null)
                {
                    MessageBox.Show("There is no specific record please insert it first");       
                }
                else
                {
                   s.ConnOpen();
                    string query = "update attendance set OTHours='" + textBox1.Text + "',Allow='" + textBox2.Text + "' where EmpID='" + this.comboBox1.Text + "' && Days='" + this.dateTimePicker3.Text + "'";
                    command = new MySqlCommand(query, s.ConPass());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data updated sucessfully..");
                    comboBox1.ResetText();
                    dateTimePicker3.ResetText();
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();
            dataGridView1.DataSource = GetList();
        }
    }
}
