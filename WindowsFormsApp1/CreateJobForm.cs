using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CreateJobForm : Form
    {
        public CreateJobForm()
        {
            InitializeComponent();
            OracleConnection con = new OracleConnection("User Id=COMP214_F22_ER_56;Password=password;Data Source=199.212.26.208:1521/SQLD");
            con.Open();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //load the datagrid
        private void CreateJobForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.HR_JOBS' table. You can move, or remove it, as needed.
            this.hR_JOBSTableAdapter.Fill(this.dataSet2.HR_JOBS);

        }
        //create new job 
        private void button1_Click(object sender, EventArgs e)
        {

            OracleConnection con = new OracleConnection("User Id=COMP214_F22_ER_56;Password=password;Data Source=199.212.26.208:1521/SQLD");
            con.Open();
            //string sql = "EXECUTE new_job(888, 'test2', 300);commit";
            // Create a new OracleDataAdapter object and specify the stored procedure to execute
            OracleDataAdapter da = new OracleDataAdapter("new_job", con);
            // Set the command type to "StoredProcedure"
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("p_jobid", OracleDbType.Varchar2).Value = textBox1.Text;
            da.SelectCommand.Parameters.Add("p_title", OracleDbType.Varchar2).Value = textBox2.Text;
            da.SelectCommand.Parameters.Add("v_minsal", OracleDbType.Int32).Value =int.Parse(textBox3.Text);
            // Create a new DataTable object to hold the results of the stored procedure
            DataTable dt = new DataTable();
            // Execute the stored procedure and fill the DataTable with the results
            da.Fill(dt);
            // Close the connection to the database
            con.Close();
            MessageBox.Show("Record created successfully.");
            dt.AcceptChanges();
         
            this.hR_JOBSTableAdapter.Fill(this.dataSet2.HR_JOBS);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = (int.Parse(textBox3.Text) * 2).ToString();
        }
    }
}
