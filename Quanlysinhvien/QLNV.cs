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
        DataRow row, ras;
        float tong = 0;
        int shd, shd1, shd2;
        string mahang;





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

        public void docgiatri()
        {
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
             mahang = Convert.ToString(firstRow1["SHD"]);
            firstRow1.ClearErrors();

            ketnoi.Close();



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
            ketnoi.Close();





            ketnoi.Open();
            string khtk1 = @"SELECT MAX(SHD) as 'SHD'
                            FROM BAN_HANG WHERE SHD >= 10 ";
            thuchien = new SqlCommand(khtk1, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dtaa = new DataTable();
            dtaa.Load(docdulieu);
            docdulieu.Close();
            if(dtaa.Rows.Count > 0)
            {
                DataRow ras = dtaa.Rows[0];
                shd1 = Convert.ToInt32(ras["SHD"]);
                row.ClearErrors();
            }
           else
            {
                shd1 = 0;
            }
            ketnoi.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string mancc = txt_mkh.Text;
            string tncc = txt_tkh.Text;
            string diachi = txt_dckh.Text;
            string sdt = txt_sdt.Text;



            docgiatri();
           




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




           if(shd1 > shd)
            {
                 shd2  = shd1;
            }
           else
            {
                shd2 = shd;
            }
            ketnoi.Open();
            string tenthungan = comboBox1.Text;
            int SoHD = Convert.ToInt32(textBox7.Text);

            shd2++;
            sql = @"insert into BAN_HANG
	              values 
                 (" + shd2 + " , N'" + tenthungan + "' , N'" + mancc + "'  , N'" + mahang + "' , " + SoHD + " )";
            thuchien = new SqlCommand(sql, ketnoi);
            MessageBox.Show(sql);
            thuchien.ExecuteNonQuery();

            xoa();
            ketnoi.Close();











        }

 
    }
}
