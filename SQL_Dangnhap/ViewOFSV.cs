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


namespace formsvview
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string ChuoiKetNoi = @"Data Source=HOANGTIEN\SQL;Initial Catalog=SV56KMT;Integrated Security=True";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string sql;

     
        private void cmd_tk_Click(object sender, EventArgs e)
        {

        }

        private void cmd_hienthi_Click(object sender, EventArgs e)
        {
                

                ketnoi.Open();
                string tensv = textBox1.Text;
                
                 if (textBox1.Text == "")
                 {
                  MessageBox.Show("Hãy Nhập từ khóa vào ô bạn muốn tìm Kiềm !");
                  ketnoi.Close();
                return;
                  }
                sql = @"SELECT * FROM QL_SV WHERE HoTen LIKE '%" + tensv + "%' ";
                thuchien = new SqlCommand(sql, ketnoi);
                docdulieu = thuchien.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(docdulieu);
                dataGridView1.DataSource = dt;

                 docdulieu.Close();
                 ketnoi.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(ChuoiKetNoi);
           
        }
    }
}
