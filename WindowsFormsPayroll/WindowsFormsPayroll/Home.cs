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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Close();
            log.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Account acc = new Account();
            this.Hide();
            acc.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EmployerDet det = new EmployerDet();
            this.Hide();
            det.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NewEmployee empnew = new NewEmployee();
            this.Hide();
            empnew.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Attendance pay = new Attendance();
            this.Hide();
            pay.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Login lo = new Login();
            this.Close();
            lo.Show();
        }
    }
}
