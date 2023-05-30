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
using System.Security.Cryptography;
using System.Resources;

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
        DataTable dtaa, dtbb;
        float tong = 0;
        int shd, shd1, shd2, slmh, soluongmhbh;
        string mahang;
        int slmhbanra;



        // Chưa làm gì đã chạy
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
            dt.Columns.Add("Số Lượng ", typeof(int));
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

            if(slmh_banra.Text == "" || textBox2.Text == "" )
            {
                return;
            }
            string tenhang = comboBox1.Text;
            slmhbanra = Convert.ToInt32(slmh_banra.Text);
            int dongia = Convert.ToInt32(textBox2.Text);
            int thanhtien = slmhbanra * dongia;                 
            tong  +=  thanhtien ;

            dt.Rows.Add(tenhang, slmhbanra, dongia , thanhtien);
            slmh_banra.Clear();
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
            textBox7.Clear();
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

            // So luong lon nhat trong hoa don 
            ketnoi.Open();
            string khtk = @"SELECT MAX(SHD) as 'SHD'
                            FROM BAN_HANG ";
            thuchien = new SqlCommand(khtk, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dtaa = new DataTable();
            dtaa.Load(docdulieu);
            docdulieu.Close();
            DataRow row = dtaa.Rows[0];          
            string tringshd  = Convert.ToString(row["SHD"]);
            if (tringshd == "")
            {
                MessageBox.Show("" + tringshd + "");
            }
            else
            {
                shd = Convert.ToInt32(tringshd);
                MessageBox.Show("" + shd + "");
            }

            row.ClearErrors();
            ketnoi.Close();


            //Neu so luong lon nhat lon hon 10 thi tinh tiep
             ketnoi.Open();
            string khtk1 = @"SELECT MAX(SHD) as 'SOHOADON'
                             FROM BAN_HANG WHERE SHD >= 10 ";
            thuchien = new SqlCommand(khtk1, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dtaa = new DataTable();
            dtaa.Load(docdulieu);
            docdulieu.Close();
            if (dtaa.Rows.Count > 0)
            {
                DataRow ras = dtaa.Rows[0];

                string stringshd1 = Convert.ToString(ras["SOHOADON"]);
             if (stringshd1 == "")
                 { } else
                    {
                        shd2 = Convert.ToInt32(stringshd1);
                        MessageBox.Show("" + shd2 + "");
                }
             ras.ClearErrors();
             }
            
            else
            {
                shd1 = 0;
            }
            ketnoi.Close();
        }
        // Neu cai so luong ban ra nhieu hon so luong trong kho thi sua sl trong kho 
        public void suaslmh(int slmhtrongkho)
        {
            ketnoi.Open();
            string tenmh = comboBox1.Text;
            MessageBox.Show(tenmh);
            string updtslmh = @"UPDATE Mat_Hang
            SET Soluong  = " +slmhtrongkho+" WHERE TenHang  = N'"+ tenmh + "' ";
            MessageBox.Show(updtslmh);
            thuchien = new SqlCommand(updtslmh, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }

        // Koem tra xem sl trong kho co lon hon sl ban ra hay ko 
        public void kiemtraslmh()
        {
            string tenmh = comboBox1.Text;
            ketnoi.Open();
            string mhtk = @"select SoLuong 'Soluong'
                        from Mat_Hang
                        WHERE TenHang = N'" + tenmh + "'";
            thuchien = new SqlCommand(mhtk, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dtbb = new DataTable();
            dtbb.Load(docdulieu);
            docdulieu.Close();
            if (dtbb.Rows.Count > 0)
            {
                DataRow rit = dtbb.Rows[0];
                slmh = Convert.ToInt32(rit["Soluong"]);
                rit.ClearErrors();
                ketnoi.Close();
            }
            else
            {
                ketnoi.Close();
                return ;
            }

            // Trừ đi sl mặt hàng bán ra 
            if(slmh > slmhbanra)
            {
                slmh =  slmh - slmhbanra;
                suaslmh(slmh);
            }
            else
            {
                MessageBox.Show("Số Lượng Loại Hàng "+tenmh+" Không đủ chỉ còn "+slmh+"Thùng");
                return;
            }



        }
        private void button3_Click(object sender, EventArgs e)
        {
            string mancc = txt_mkh.Text;
            string tncc = txt_tkh.Text;
            string diachi = txt_dckh.Text;
            string sdt = txt_sdt.Text;                     
            int SoHD = Convert.ToInt32(textBox7.Text);


            docgiatri();
            kiemtraslmh();
           



            // Kiểm tra tệp khách hàng này tồn tại hay chưa 
            // Nếu tồn tại thì không cần thêm mới 
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
            // Thêm mới Tệp Khách hàng vào bảng khách hàng; 
            else
            {
                ketnoi.Close();
                ketnoi.Open();
                sql = @"insert into Khachhang
	              values 
                 (N'" + mancc + "' , N'" + tncc + "' , N'" + diachi + "'  , N'" + sdt + "' )";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();

            }
            ketnoi.Close();


            // Kiểm tra Cái SHD nào nhiều hơn thì dùng nó 
           if(shd2 > shd1)
            {
            }
           else
            {
                shd2 = shd1; 
            }
            MessageBox.Show("" + shd2 + "");
            ketnoi.Open();
            string tenthungan = comboBox1.Text;
           
            // Tăng cái giá trị SHD rồi add dữ liệu vào bảng mặt hàng 
            shd2++;
            sql = @"insert into BAN_HANG
	              values 
                 (" + shd2 + " , N'"+tenthungan+"' , N'"+mancc+"'  , N'"+mahang+"' , "+SoHD+")";
            thuchien = new SqlCommand(sql, ketnoi);
            MessageBox.Show(sql);
            thuchien.ExecuteNonQuery();

            xoa();
            ketnoi.Close();
        }
    }
}
