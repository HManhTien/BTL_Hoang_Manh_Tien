using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace connnectC__SQL
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        String str = @"Data Source=HOANGTIEN\\SQL;Initial Catalog=BANHANG;Intted Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select* from Khach_Hang";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=HOANGTIEN\\SQL;Initial Catalog=BANHANG;Integrated Security=True;";
            sqlConnection.Open();
            loaddata();

        }
    }
}
