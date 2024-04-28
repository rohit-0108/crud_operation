using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace crudoperation
{
    public partial class Form1 : Form
    {
        string con;
        SqlConnection sql;
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
            con = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            GetAllEmployeeRecord();
        }
        private void button1_click(object sender, EventArgs e)
        {
            MessageBox.Show("This is Code 4 Jobs");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void GetAllEmployeeRecord()  
        {
            sql = new SqlConnection(con);
            cmd = new SqlCommand("Display_Employee", sql)
            {
                CommandType = CommandType.StoredProcedure
            };
            sql.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            sql.Close();
            dataGridView1.DataSource =dataTable;
            
        }  
        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection sql = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sql;
            cmd.Parameters.Add(new SqlParameter("@EmpName", SqlDbType.VarChar));
            cmd.Parameters["@EmpName"].Value = textBox3.Text;
            cmd.Parameters.Add(new SqlParameter("@EmpSalary", SqlDbType.Int));
            cmd.Parameters["@EmpSalary"].Value = Convert.ToInt32(textBox2.Text);
            cmd.Parameters.Add(new SqlParameter("@EmpCity", SqlDbType.VarChar));
            cmd.Parameters["@EmpCity"].Value = textBox1.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Insert_Employee";
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
            GetAllEmployeeRecord();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sql;
            cmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int));
            cmd.Parameters["@EmployeeID"].Value = Convert.ToInt32(textBox4.Text);
            cmd.Parameters.Add(new SqlParameter("@EmpName", SqlDbType.VarChar));
            cmd.Parameters["@EmpName"].Value = textBox3.Text;
            cmd.Parameters.Add(new SqlParameter("@EmpSalary", SqlDbType.Int));
            cmd.Parameters["@EmpSalary"].Value = Convert.ToInt32(textBox2.Text);
            cmd.Parameters.Add(new SqlParameter("@EmpCity", SqlDbType.VarChar));
            cmd.Parameters["@EmpCity"].Value = textBox1.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Update_Employee";
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
            GetAllEmployeeRecord();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sql;
            cmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int));
            cmd.Parameters["@EmployeeID"].Value = Convert.ToInt32(textBox4.Text);
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Delete_Employee";
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
            GetAllEmployeeRecord();
        }

        
    }
}
