using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class employeeHiring : Form
    {
        public employeeHiring()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void employeeHiring_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.HR_EMPLOYEES' table. You can move, or remove it, as needed.
            this.hR_EMPLOYEESTableAdapter.Fill(this.dataSet2.HR_EMPLOYEES);
            // TODO: This line of code loads data into the 'dataSet2.HR_JOBS' table. You can move, or remove it, as needed.
            this.hR_JOBSTableAdapter.Fill(this.dataSet2.HR_JOBS);
            OracleConnection con = new OracleConnection("User Id=COMP214_F22_ER_56;Password=password;Data Source=199.212.26.208:1521/SQLD");
            con.Open();
            // Create a command to retrieve data from the database
            OracleCommand cmd = new OracleCommand("SELECT job_id||',  '||job_title as a FROM hr_jobs", con);

            // Execute the command and retrieve the data
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataTable data = new DataTable();
            adapter.Fill(data);

            // Set the ComboBox's data source and display and value members
            comboBox2.DataSource = data;
            comboBox2.DisplayMember = "a";
            comboBox2.ValueMember = "a";

            // Close the connection
            con.Close();

            OracleConnection con2 = new OracleConnection("User Id=COMP214_F22_ER_56;Password=password;Data Source=199.212.26.208:1521/SQLD");
            con2.Open();
            OracleCommand cmd2 = new OracleCommand("SELECT department_id||',  '||department_name as b FROM hr_departments", con2);

            // Execute the command and retrieve the data
            OracleDataAdapter adapter2 = new OracleDataAdapter(cmd2);
            DataTable data2 = new DataTable();
            adapter2.Fill(data2);

            // Set the ComboBox's data source and display and value members
            comboBox1.DataSource = data2;
            comboBox1.DisplayMember = "b";
            comboBox1.ValueMember = "b";



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("111");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            employeeUpdate updatepage = new employeeUpdate();
            updatepage.Show();
        }
    }
}
