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
using themsv;
using SQL_Dangnhap;



namespace FormQLSV
{
    public partial class FormQLSV : Form
    {
        public FormQLSV()
        {
            InitializeComponent();
        }
        string ma, ma1;
        string ChuoiKetNoi = @"Data Source=HOANGTIEN\SQL;Initial Catalog=QL_BHST_GO;Integrated Security=True";
        string sql;
        string viewsp = @"select * from Mat_Hang";
        string viewncc = @"select * from Nha_cung_cap";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        DataTable dt;

        themsv.themsv1 tsv = new themsv.themsv1();

        private void FormQLSV_Load(object sender, EventArgs e)
        {

            ketnoi = new SqlConnection(ChuoiKetNoi);

           
        }

        public void hienthi()
        {

           
           
            thuchien = new SqlCommand(sql,ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulieu);
            
           






        }

        public void themsp()
        {
            ketnoi.Open();
            string masp = txtmasanpham.Text;
            string tensp = txttensanpham.Text;
            string soluong = txtsoluong.Text;
            string dongia = txtdongia.Text;
            
      

            sql = @"insert into Mat_Hang
	        values 
            ('" + masp + "' , '" + tensp + "' , '" + soluong + "'  , '" + dongia + "' )";
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            txtmasanpham.Clear();
            txttensanpham.Clear();
            txtsoluong.Clear();
            txtdongia.Clear();
            ketnoi.Close();
        }

 

        private void cmd_themsv_Click(object sender, EventArgs e)
        {
            tsv.ShowDialog();
        }

        public void delete(string str)
        {
            string lenhxoa = "delete from Mat_Hang where Mahang ='" + str + "'";
 
            thuchien = new SqlCommand(lenhxoa,ketnoi);
            thuchien.ExecuteNonQuery(); 
        }



        private void timkiem()
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {            
                ketnoi.Open();
                sql = viewsp;
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();  
        }

        private void cmd_themsp_Click(object sender, EventArgs e)
        {
            themsp();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
               
                ketnoi.Open();
                sql = viewncc;
                hienthi();
                dataGridView2.DataSource = dt;
               ketnoi.Close();
           
        }

        private void cmd_tk_sanpham_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string tensv = tk_sanpham.Text;
            sql = @"SELECT * FROM Mat_Hang WHERE TenHang  LIKE N'%" + tensv + "%'  or Mahang  LIKE N'%" + tensv + "%' ";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(docdulieu);
            dataGridView1.DataSource = dt;
            docdulieu.Close();
            ketnoi.Close();
        }

        private void cmd_xoasp_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            delete(ma);
            hienthi();
            ketnoi.Close();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
                if (e.RowIndex == -1) { return; }
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ma = row.Cells[0].Value.ToString();             
        }

        private void cmd_tk_nhcc_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string tensv = txt_tk_ncc.Text;
            sql = @"SELECT * FROM Nha_cung_cap WHERE TenNC   LIKE N'%" + tensv + "%'  or MNCC  LIKE N'%" + tensv + "%' ";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(docdulieu);
            dataGridView2.DataSource = dt;
            docdulieu.Close();
            ketnoi.Close();
        }

        private void cmd_themnhacc_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string mancc = txt_mncc.Text;
            string tncc = txt_tncc.Text;
            string diachi = txt_dcncc.Text;
            string sdt = txt_sdtncc.Text;



            sql = @"insert into Nha_cung_cap
	        values 
            ('" + mancc + "' , '" + tncc + "' , '" + diachi + "'  , '" + sdt + "' )";
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            txt_mncc.Clear();
            txt_tncc.Clear();
            txt_dcncc.Clear();
            txt_sdtncc.Clear();
            ketnoi.Close();
        }

        private void cmd_xoanhacc_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete from Nha_cung_cap where MNCC ='" + ma1 + "'";

            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

                if (e.RowIndex == -1) { return; }
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                ma1 = row.Cells[0].Value.ToString();
            
        }
    }
}
