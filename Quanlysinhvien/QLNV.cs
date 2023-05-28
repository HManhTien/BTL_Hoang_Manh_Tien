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
        DataTable dtaa;
        DataRow row;
        float tong = 0;
        int shd;




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
        public void xoa()
        {
            txt_mkh.Clear();
            txt_tkh.Clear();
            txt_dckh.Clear();
            txt_sdt.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string mancc = txt_mkh.Text;
            string tncc = txt_tkh.Text;
            string diachi = txt_dckh.Text;
            string sdt = txt_sdt.Text;


            //check SL mat hang trong kho co hay ko ;
            ketnoi.Open();
            string mhtk = @"SELECT Mahang as 'SHD'
                        FROM MAT_HANG";
            thuchien = new SqlCommand(mhtk, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulieu);
            docdulieu.Close();
            DataRow firstRow1 = dt.Rows[0];
            string mahang = Convert.ToString(firstRow1["SHD"]);
            firstRow1.ClearErrors();
            MessageBox.Show("" + mahang + "");
            ketnoi.Close();

            // Checksl
            ketnoi.Open();
            string khtk = @"SELECT MAX(SHD) as 'SHD'
                            FROM BAN_HANG";
            thuchien = new SqlCommand(khtk, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dtaa = new DataTable();
            dtaa.Load(docdulieu);
            docdulieu.Close();
            
            DataRow row = dtaa.Rows[0];
             shd = Convert.ToInt32(row["SHD"]);
            row.ClearErrors();
            MessageBox.Show("" + shd + "");
            ketnoi.Close();



            ketnoi.Open();
            string str = $"select * from Khachhang  Where Makhachhang = '" + mancc + "' ";
            thuchien = new SqlCommand(str, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(docdulieu);
            docdulieu.Close();
            if (dt1.Rows.Count > 0)
            {
                MessageBox.Show("Da co khach hang nay !!");              
            }
            else
            {
                ketnoi.Close();
                ketnoi.Open();
                sql = @"insert into Khachhang
	              values 
                 ('" + mancc + "' , '" + tncc + "' , '" + diachi + "'  , '" + sdt + "' )";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();

                xoa();
                ketnoi.Close();

            }
            ketnoi.Close();




           // Them Hoa don ban hang;
            ketnoi.Open();
            string tenthungan = comboBox1.Text;
            int SoHD = Convert.ToInt32(textBox7.Text);
            shd++;
            sql = @"insert into BAN_HANG
	              values 
                 (" + shd + " , N'" + tenthungan + "' , N'" + mancc + "'  , N'" + mahang + "' , " + SoHD + " )";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            xoa();
            ketnoi.Close();











        }

 
    }
}
