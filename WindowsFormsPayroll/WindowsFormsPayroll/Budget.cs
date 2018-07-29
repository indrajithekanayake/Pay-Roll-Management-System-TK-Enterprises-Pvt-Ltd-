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
    public partial class Budget : Form
    {
        public Budget()
        {
            InitializeComponent();
            FillComboID();
            SalID();
        }
        ConnectServer s = new ConnectServer();
        MySqlCommand command;
        MySqlDataReader dtread;

        private void button1_Click(object sender, EventArgs e)
        {
            Attendance at = new Attendance();
            this.Hide();
            at.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Loan ln = new Loan();
            this.Hide();
            ln.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Drivers dri = new Drivers();
            this.Hide();
            dri.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Lobor lab = new Lobor();
            this.Hide();
            lab.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Final fin = new Final();
            this.Hide();
            fin.Show();
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }

        void FillComboID()//fill combobox with available ids
        {
            string query = "select * from employee";
            command = new MySqlCommand(query, s.ConPass());
            MySqlDataReader dtread;
            try
            {
                s.ConnOpen();
                dtread = command.ExecuteReader();
                while (dtread.Read())
                {
                    comboBox2.Items.Add(dtread.GetString("EmpID"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();

        }
        
        private void button8_Click(object sender, EventArgs e)//reset everything
        {
            comboBox2.ResetText();
            textSalID.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
        }  
        private void button7_Click(object sender, EventArgs e)//update details when changes made
        {
                try
                {
                    s.ConnOpen();
                    string query = "update salary set Days='" + textBox4.Text + "',NoPay='" + textBox5.Text + "',ProductIns='" + textBox10.Text + "',TravelIns='" + textBox11.Text + "' where EmpID='"+comboBox2.Text+"'";
                    command = new MySqlCommand(query, s.ConPass());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Updated Sucessfully\n");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oops: Something went wrong with the DB Connection Please try again\n\n" + ex.Message);
                }
                s.ConnClose();
            s.ConnClose();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
        }

        private void button9_Click(object sender, EventArgs e)//insert when new employee is added to the DB to calculate his/her salary
        {
            try
            {
                    s.ConnOpen();
                    string query = "insert into salary (SalID,EmpID,Days,NoPay,OTPay,EPF8,EPF12,ETF3,ProductIns,TravelIns,Final) values('" + textSalID.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" +textBox5.Text+ "','" + textBox9.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text+ "','" + textBox10.Text + "','" + textBox11.Text+"','"+textBox12.Text+"')";
                    MySqlCommand cmd = new MySqlCommand(query, s.ConPass());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Salary details inserted \n to the database sucessfully..!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();
            comboBox2.ResetText();
            textSalID.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
        }

        void SalID()//genarate salary id automatically
        {
            try
            {
                s.ConnOpen();
                command = new MySqlCommand("select max(SalID) from salary", s.ConPass());
                int i = Convert.ToInt32(command.ExecuteScalar());
                s.ConnClose();
                i++;
                textSalID.Text = i.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            
        }
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//change details when id selection changes
        {
            try
            {
                s.ConnOpen();
                string query = "select * from employee where (EmpID = '" + int.Parse(comboBox2.Text) + "')";
                command = new MySqlCommand(query, s.ConPass());
                dtread = command.ExecuteReader();
                if (dtread.Read())
                {
                    textBox1.Text = (dtread["Designation"].ToString());
                    textBox2.Text = (dtread["Name"].ToString());

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
                string query = "select * from attendance where  (EmpID = '" + int.Parse(comboBox2.Text) + "')";
                command = new MySqlCommand(query, s.ConPass());
                dtread = command.ExecuteReader();
                if (dtread.Read())
                {
                    textBox3.Text = (dtread["Allow"].ToString());
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();


            try
            {
                s.ConnOpen();
                string query = "select * from salary where  (EmpID = '" + int.Parse(comboBox2.Text) + "')";
                command = new MySqlCommand(query, s.ConPass());
                dtread = command.ExecuteReader();
                if (dtread.Read())
                {
                    textBox4.Text = (dtread["Days"].ToString());
                    textBox5.Text = (dtread["NoPay"].ToString());
                    textBox6.Text = (dtread["EPF8"].ToString());
                    textBox7.Text = (dtread["EPF12"].ToString());
                    textBox8.Text = (dtread["ETF3"].ToString());
                    textBox9.Text = (dtread["OTPay"].ToString());
                    textBox10.Text = (dtread["ProductIns"].ToString());
                    textBox11.Text = (dtread["TravelIns"].ToString());
                }
               
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            s.ConnClose();
            try
            {
                s.ConnOpen();
                string query = "select * from loanadvance where (EmpID = '" + int.Parse(comboBox2.Text) + "')";
                command = new MySqlCommand(query, s.ConPass());
                dtread = command.ExecuteReader();
                if (dtread.Read())
                {
                    textBox14.Text = (dtread["Advance"].ToString());
                    textBox13.Text = (dtread["Loan"].ToString());
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops: Something went wrong with the DB Connection Please try again\n\n" + ex.Message);
            }
            s.ConnClose();
        }

        public double bs, allo, loan, adv, EPF8, EPF12, ETF3, finSal, otpay, nopay, travel, product,otcalc;
        public string desig;
        public int ot;
        private void button11_Click(object sender, EventArgs e)
        {
            try
                {
                    s.ConnOpen();
                    string query = "select * from employee where  (EmpID = '" + int.Parse(comboBox2.Text) + "')";
                    command = new MySqlCommand(query, s.ConPass());
                    dtread = command.ExecuteReader();
                    if (dtread.Read())
                    {
                        bs = double.Parse((dtread["Basic"].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
                s.ConnClose();
                try
                {
                    s.ConnOpen();
                    string query = "select * from attendance where  (EmpID = '" + int.Parse(comboBox2.Text) + "')";
                    command = new MySqlCommand(query, s.ConPass());
                    dtread = command.ExecuteReader();
                    if (dtread.Read())
                    {
                        allo = double.Parse((dtread["Allow"].ToString()));
                        ot = int.Parse((dtread["OTHours"].ToString()));
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
                s.ConnClose();

                try
                {
                    s.ConnOpen();
                    string query = "select * from loanadvance where  (EmpID = '" + int.Parse(comboBox2.Text) + "')";
                    command = new MySqlCommand(query, s.ConPass());
                    dtread = command.ExecuteReader();
                    if (dtread.Read())
                    {
                        loan = double.Parse((dtread["Loan"].ToString()));
                        adv = double.Parse((dtread["Advance"].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
                s.ConnClose();
                try
                {
                    s.ConnOpen();
                    string query = "select * from salary where  (EmpID = '" + int.Parse(comboBox2.Text) + "')";
                    command = new MySqlCommand(query, s.ConPass());
                    dtread = command.ExecuteReader();
                    if (dtread.Read())
                    {
                        otpay = double.Parse((dtread["OTPay"].ToString()));
                        nopay = double.Parse((dtread["NoPay"].ToString()));
                        product = double.Parse((dtread["ProductIns"].ToString()));
                        travel = double.Parse((dtread["TravelIns"].ToString()));

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
                s.ConnClose();

                if (textBox1.Text == "Admin")
                {
                    finSal = bs + allo - adv - loan + product + travel;
                }
                else if (textBox1.Text == "Site supervisor")
                {
                    EPF8 = (bs + allo) * 8 / 100;
                    EPF12 = (bs + allo) * 12 / 100;
                    ETF3 = (bs + allo) * 3 / 100;
                    otcalc = ((bs * 1.5) / (25 * 9)) * ot;
                    finSal = bs + allo - adv - loan - EPF8 + otcalc - nopay + product + travel;
                }
                else if (textBox1.Text == "Account Assistant")
                {
                    EPF8 = (bs + allo) * 8 / 100;
                    EPF12 = (bs + allo) * 12 / 100;
                    ETF3 = (bs + allo) * 3 / 100;
                    otcalc = ((bs * 1.5) / (25 * 9)) * ot;
                    finSal = bs + allo - adv - loan - EPF8 + otcalc - nopay + product + travel;
                }
                else if (textBox1.Text == "Office Assistant")
                {
                    EPF8 = (bs + allo) * 8 / 100;
                    EPF12 = (bs + allo) * 12 / 100;
                    ETF3 = (bs + allo) * 3 / 100;
                    otcalc = ((bs * 1.5) / (25 * 9)) * ot;
                    finSal = bs + allo - adv - loan - EPF8 + otcalc - nopay + product + travel;
                }
                else if (textBox1.Text == "Driver")
                {
                    EPF8 = (bs + allo) * 8 / 100;
                    EPF12 = (bs + allo) * 12 / 100;
                    ETF3 = (bs + allo) * 3 / 100;
                    otcalc = ((bs * 1.5) / (25 * 9)) * ot;
                    finSal = bs + allo - adv - loan - EPF8 + otcalc - nopay + product + travel;
                }
                else if (textBox1.Text == "Helper Driver")
                {
                    EPF8 = (bs + allo) * 8 / 100;
                    EPF12 = (bs + allo) * 12 / 100;
                    ETF3 = (bs + allo) * 3 / 100;
                    otcalc = ((bs * 1.5) / (25 * 9)) * ot;
                    finSal = bs + allo - adv - loan - EPF8 + otcalc - nopay + product + travel;
                }
                else if (textBox1.Text == "Labour")
                {
                    EPF8 = (bs + allo) * 8 / 100;
                    EPF12 = (bs + allo) * 12 / 100;
                    ETF3 = (bs + allo) * 3 / 100;
                    finSal = bs +allo - adv - loan - EPF8 + product;
                }


                textBox6.Text = EPF8.ToString();
                textBox7.Text = EPF12.ToString();
                textBox8.Text = ETF3.ToString();
                textBox9.Text = otcalc.ToString();
                textBox12.Text = finSal.ToString();

                try
                {
                    s.ConnOpen();
                    string query = "update salary set Final='" + textBox12.Text + "',EPF8='" + textBox6.Text + "',EPF12='" + textBox7.Text + "',ETF3='" + textBox8.Text + "',OTPay='" + textBox9.Text + "'where EmpID='"+comboBox2.Text+"'";
                    command = new MySqlCommand(query, s.ConPass());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Calculation Updated Sucessfully\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oops: Something went wrong with the DB Connection Please try again\n\n" + ex.Message);
                }
                s.ConnClose();
            
            comboBox2.ResetText();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
        }//calculate the salary details and update database when button click
    }

    }

