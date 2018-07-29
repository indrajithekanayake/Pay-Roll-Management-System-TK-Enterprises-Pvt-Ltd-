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
    public partial class NewEmployee : Form
    {
        public NewEmployee()
        {
            InitializeComponent();
        }
       
        string gender;
        private void btnSave_Click(object sender, EventArgs e)
        {
            string a, b, c, d, n, f, g, h, i, j, k, l, m;
            a = txtID.Text;
            b = txtName.Text;
            c = txtNIC.Text;
            d = gender;
            n = txtCont1.Text;
            f = txtCont2.Text;
            g = txtAdd1.Text;
            h = txtAdd2.Text;
            i = txtAdd3.Text;
            j = comDepart.Text;
            k = comDesig.Text;
            l = dateTimePicker1.Text;
            m = textBox1.Text;
            EmployeeDetNewEntry dt = new EmployeeDetNewEntry();
            if(dt.EmpInfo(a, b, c, d, n, f, g, h, i, j, k, l, m))
            {
                Home hm = new Home();
                MessageBox.Show("Employee details inserted \n to the database sucessfully..!");
                this.Hide();
                hm.Show();
            }
            else
            {
                MessageBox.Show("Employee details failed to add..!");
            }
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {
            EmployeeDetNewEntry dt = new EmployeeDetNewEntry();
            txtID.Text = dt.EmpID().ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }
        
        private void radioMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "M";
        }

        private void radioFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "F";
        }
    }
}
