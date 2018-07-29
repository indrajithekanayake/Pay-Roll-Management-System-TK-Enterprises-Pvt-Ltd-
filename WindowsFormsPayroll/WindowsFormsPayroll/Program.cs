using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsPayroll
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
    class ConnectServer
    {
        MySqlConnection connection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=prodb;SslMode=none;");
        public MySqlConnection ConPass()//pass Parameters
        {
            return connection;
        }
        public void ConnOpen()//Open Xampp Server connection
        {
            connection.Open();
        }
        public void ConnClose()//Close Xampp Server connection
        {
            connection.Close();
        }
    }
    class EmployeeDetNewEntry
    {
        public int i;//return new EmpID
        ConnectServer s = new ConnectServer();
        public int EmpID()//generate new employee id and pass it to form
        {
           try
            {
                s.ConnOpen();
                MySqlCommand com = new MySqlCommand("select max(EmpID) from employee", s.ConPass());
                i = Convert.ToInt32(com.ExecuteScalar());
                s.ConnClose();
                i++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            return i;
        }
        public bool val;//return whether function is returning true or false
        //run insert query to the database
        public bool EmpInfo(string a, string b, string c, string d, string e, string f, string g, string h, string i, string j, string k, string l, string m)
        {
            NewEmployee n = new NewEmployee();
            if(b==null||c==null||d==null||e==null||g==null||h==null||i==null||j==null||k==null||l==null||m==null)
            {
                MessageBox.Show("All the fields must be filled properly");
            }
            else
            {
                try
                {
                    s.ConnOpen();
                    string query = "insert into employee (EmpID,Name,NIC,Gender,Contact1,Contact2,No,Street,Town,Department,Designation,JoinDate,Basic) values('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "','" + f + "','" + g + "','" + h + "','" + i + "','" + j + "','" + k + "','" + l + "','" + m + "')";
                    MySqlCommand cmd = new MySqlCommand(query, s.ConPass());
                    cmd.ExecuteNonQuery();
                    val = true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Oops: Something went wrong with the DB Connection Please try again\n\n" + ex.Message);
                    val = false;
                }
                s.ConnClose();
            }
            return val;
        }
    }

    class EmployeeDetView
    {
        ConnectServer s = new ConnectServer();

        public bool empdetup(string a, string b, string c, string d, string e, string x)
        {
            string query = "update employee set Contact1='" + a + "',Contact2='" + b + "',No='" + c + "',Street='" + d + "',Town='" + e + "' where EmpID='" + x + "'";
            try
            {
                s.ConnOpen();
                MySqlCommand cmd = new MySqlCommand(query, s.ConPass());
                cmd.ExecuteNonQuery();
                val = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error caught please contact the developers" + ex.Message);
            }
            s.ConnClose();
            return val;
        }
        public bool val;
        public bool empdetdel(string a)
        {
            try
            {
                s.ConnOpen();
                string qry = "delete from employee where EmpID = '" + int.Parse(a) + "'";
                MySqlCommand command = new MySqlCommand(qry, s.ConPass());
                MessageBox.Show("Do you really want to continue..?");
                command.ExecuteNonQuery();
                val = true;
            }
            catch (Exception ex)
            {
                val = false;
                MessageBox.Show("Oops: Something went wrong with the DB Connection Please try again\n\n" + ex.Message);
            }
            s.ConnClose();
            return val;
        }
    }

}
