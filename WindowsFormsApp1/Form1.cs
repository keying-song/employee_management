using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OracleConnection con = new OracleConnection("User Id=COMP214_F22_ER_56;Password=password;Data Source=199.212.26.208:1521/SQLD");
            con.Open();
            Console.WriteLine("Connected to the oracle db");

        }

       

        //using connection string attributes to connect to Oracle Database
        
       //  connection.Open();
        // Console.WriteLine("Connected to Oracle" + con.ServerVersion);
       //
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateJobForm createJob = new CreateJobForm();
            createJob.Show();

        }
    }
}
