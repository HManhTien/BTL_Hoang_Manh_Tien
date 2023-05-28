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
using formsvview;
using SQL_Dangnhap;

namespace formsvview
{
    public partial class formNV : Form
    {
        public formNV()
        {
            InitializeComponent();
        }

        string ChuoiKetNoi = @"Data Source=HOANGTIEN\SQL;Initial Catalog=QL_BHST_GO;Integrated Security=True";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string sql;
        DataTable dt;
        float tong = 0;




        private void cmd_hienthi_Click(object sender, EventArgs e)
        {
                

       
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(ChuoiKetNoi);
            ketnoi.Open();
            datta();
            string sql = @"select * from MAT_HANG";
            thuchien = new SqlCommand(sql, ketnoi);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = thuchien;

            DataTable tbl = new DataTable();
            da.Fill(tbl);
            comboBox1.DataSource = tbl;
            comboBox1.DisplayMember = "TenHang";
            comboBox1.ValueMember = "MaHang";
            ketnoi.Close();
        }

        public void datta()
        {
            dt = new DataTable();
            dt.Columns.Add("Tên Hàng", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("Đơn Giá", typeof(int));
            dt.Columns.Add("Thành Tiền", typeof(int));


            dataGridView1.DataSource = dt;
        }
        public void hienthi()
        {



            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulieu);


        }
        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text == "" || textBox2.Text == "" )
            {
                return;
            }
            string tenhang = comboBox1.Text;
            int soluong = Convert.ToInt32(textBox1.Text);
            int dongia = Convert.ToInt32(textBox2.Text);
            int thanhtien = soluong * dongia;          
            tong  +=  thanhtien ;
            dt.Rows.Add(tenhang,soluong, dongia , thanhtien);
            textBox1.Clear();
            textBox2.Clear();
            dataGridView1.DataSource = dt;
             label10.Text = "Tổng Tiền Là :"+ tong + "  $ ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQL_Dangnhap.formlogin login = new formlogin();
            this.Hide();
            login.ShowDialog();
        }
    }
}
