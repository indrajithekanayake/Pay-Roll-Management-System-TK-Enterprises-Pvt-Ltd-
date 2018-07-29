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
    public partial class EmployerDet : Form
    {
        public EmployerDet()
        {
            InitializeComponent();
        }
        EmployeeDetView vi = new EmployeeDetView();
        ConnectServer s = new ConnectServer();
        private void btnBack_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string x = comboBox1.Text;
            if (vi.empdetdel(x))
            {
                comboBox1.ResetText();
                txtName.Clear();
                txtNIC.Clear();
                txtCont1.Clear();
                txtCont2.Clear();
                txtAdd1.Clear();
                txtAdd2.Clear();
                txtAdd3.Clear();
                textBox1.Clear();
                comDepart.ResetText();
                comDesig.ResetText();
                radioFemale.Checked = false;
                radioMale.Checked = false;
                MessageBox.Show("Record deleted sucessfully...!");
            }
            else
            {
                MessageBox.Show("We are sorry..!");
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string a, b, c, d, n, x;
            if(vi.empdetup(a= txtCont1.Text, b= txtCont2.Text, c=txtAdd1.Text,d=txtAdd2.Text,n=txtAdd3.Text,x=comboBox1.Text))
            {
                comboBox1.ResetText();
                txtName.Clear();
                txtNIC.Clear();
                txtCont1.Clear();
                txtCont2.Clear();
                txtAdd1.Clear();
                txtAdd2.Clear();
                txtAdd3.Clear();
                textBox1.Clear();
                comDepart.ResetText();
                comDesig.ResetText();
                radioFemale.Checked = false;
                radioMale.Checked = false;
                MessageBox.Show("Employee updated sucessfully..!");
            }
                
           else
            {
                MessageBox.Show("Sorry something went wrong..!");
            }
               
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                s.ConnOpen();
                string query = "select * from employee where  (EmpID = '" + int.Parse(comboBox1.Text.Trim()) + "')";
                MySqlCommand command = new MySqlCommand(query, s.ConPass());
                MySqlDataReader dtread = command.ExecuteReader();
                if (dtread.Read())
                {
                    txtName.Text = (dtread["Name"].ToString());
                    txtNIC.Text = (dtread["NIC"].ToString());
                    if (dtread["Gender"].ToString() == "F")
                    {
                        radioMale.Checked = false;
                        radioFemale.Checked = true;
                    }
                    else
                    {
                        radioMale.Checked = true;
                        radioFemale.Checked = false;
                    }

                    txtCont1.Text = (dtread["Contact1"].ToString());
                    txtCont2.Text = (dtread["Contact2"].ToString());
                    txtAdd1.Text = (dtread["No"].ToString());
                    txtAdd2.Text = (dtread["Street"].ToString());
                    txtAdd3.Text = (dtread["Town"].ToString());
                    comDepart.Text = (dtread["Department"].ToString());
                    comDesig.Text = (dtread["Designation"].ToString());
                    dateTimePicker2.Text = (dtread["JoinDate"].ToString());
                    textBox1.Text = (dtread["Basic"].ToString());

                }
                else
                {
                    comboBox1.ResetText();
                    txtName.Clear();
                    txtNIC.Clear();
                    txtCont1.Clear();
                    txtCont2.Clear();
                    txtAdd1.Clear();
                    txtAdd2.Clear();
                    txtAdd3.Clear();
                    textBox1.Clear();
                    comDepart.ResetText();
                    comDesig.ResetText();
                    radioFemale.Checked = false;
                    radioMale.Checked = false;
                    MessageBox.Show("No Data found..!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Oops: Something went wrong with the DB Connection Please try again\n\n" + ex.Message);
            }
            s.ConnClose();
   
           }

 
   private void EmployerDet_Load(object sender, EventArgs e)
        {
            string query = "select * from employee";
            MySqlCommand command = new MySqlCommand(query, s.ConPass());
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
    }
}
