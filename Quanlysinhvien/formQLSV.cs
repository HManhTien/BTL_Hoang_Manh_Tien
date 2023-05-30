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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.Common;



namespace FormQLSV
{
    public partial class FormQLSV : Form
    {
        public FormQLSV()
        {
            InitializeComponent();
        }
        string ma, ma1;
        string id1, tk1, mk1, ht1, cv1;
        string ChuoiKetNoi = @"Data Source=HOANGTIEN\SQL;Initial Catalog=QL_BHST_GO;Integrated Security=True";
        string sql;
        string viewsp = @"select * from Mat_Hang";
        string viewncc = @"select * from Nha_cung_cap";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        DataTable dt;

 

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

 


        public void delete(string str)
        {
            string lenhxoa = "delete from Mat_Hang where Mahang ='" + str + "'";
 
            thuchien = new SqlCommand(lenhxoa,ketnoi);
            thuchien.ExecuteNonQuery(); 
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

        private void cmd_tuchoi_Click(object sender, EventArgs e)
        {
            
                ketnoi.Open();
                string lenhxoa = "delete from Yeu_cau where ID ='" + id1 + "'";

                thuchien = new SqlCommand(lenhxoa, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            sql = @"select * from TK_MK";
            hienthi();
            dataGridViewtkadd.DataSource = dt;
            ketnoi.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
                ketnoi.Open();
                string lenhxoa = "delete from TK_MK where ID ='" + id1 + "'";

                thuchien = new SqlCommand(lenhxoa, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();     
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
                ketnoi.Open();
                sql = @"select * from Khachhang";
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();

        }

        private void cmd_tkkh_Click(object sender, EventArgs e)
        {

            ketnoi.Open();
            string tensv = txt_tkkh.Text;
            sql = @"SELECT * FROM Khachhang WHERE MakhachHang   LIKE N'%" + tensv + "%'  or Khachhang  LIKE N'%" + tensv + "%'  or diachi  LIKE N'%\" + tensv + \"%'";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(docdulieu);
            dataGridView3.DataSource = dt;
            docdulieu.Close();
            ketnoi.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string mancc = txt_mkh.Text;
            string tncc = txt_tkh.Text;
            string diachi = txt_dckh.Text;
            string sdt = txt_sdt.Text;



            sql = @"insert into Khachhang
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

        private void button2_Click(object sender, EventArgs e)
        {
                ketnoi.Open();
                string lenhxoa = "delete from Khachhang where Makhachhang ='" + ma + "'";
                thuchien = new SqlCommand(lenhxoa, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();          
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

            ketnoi.Open();
            string sql = @"select * from NhAPHD";
            thuchien = new SqlCommand(sql, ketnoi);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = thuchien;

            DataTable tbl = new DataTable();
            da.Fill(tbl);
            comboBox1.DataSource = tbl;
            comboBox1.DisplayMember = "SHDN";
            comboBox1.ValueMember = "SHDN";
            ketnoi.Close();

            ketnoi.Open();
            string sql1 = @"select DISTINCT SOHD from BAN_HANG";
            thuchien = new SqlCommand(sql1, ketnoi);
            SqlDataAdapter da1 = new SqlDataAdapter();
            da1.SelectCommand = thuchien;

            DataTable tbl1 = new DataTable();
            da1.Fill(tbl1);
            comboBox2.DataSource = tbl1;
            comboBox2.DisplayMember = "SoHD";
            comboBox2.ValueMember = "SoHD";
            ketnoi.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            String text = comboBox1.Text;

            ketnoi.Open();
            sql = @"select SHDN , Ngay_nhap , TenNC , TenHang , Soluong
                from NHAPHD
                INNER JOIN Nha_cung_cap ON NHAPHD.MNCC = Nha_cung_cap.MNCC
                INNER JOIN Mat_Hang ON NHAPHD.Mahang = Mat_Hang.Mahang
                Where SHDN ='" + text + "'";
            hienthi();
            dataGridView4.DataSource = dt;
            ketnoi.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string texet = comboBox2.Text;


            ketnoi.Open();
            sql = @"select SHD , ThuNgan , Khachhang , TenHang , Soluong
                from BAN_HANG
                INNER JOIN Khachhang ON BAN_HANG.Makhachhang = Khachhang.Makhachhang
                INNER JOIN Mat_Hang ON BAN_HANG.Mahang = Mat_Hang.Mahang
                Where SOHD ='" + texet + "'";
            hienthi();
            dataGridView4.DataSource = dt;
            ketnoi.Close();

        }

        private void cmd_suasp_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string masp = txtmasanpham.Text;
            string tensp = txttensanpham.Text;
            string soluong = txtsoluong.Text;
            string dongia = txtdongia.Text;



            sql = @"UPDATE Mat_Hang
            SET Mahang  = N'"+masp+"', TenHang  ='"+ tensp + "' , Soluong = '"+ soluong + "', Dongia ='"+ dongia + "'  WHERE Mahang = '"+ma+"'";
            MessageBox.Show("SỬA THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            txtmasanpham.Clear();
            txttensanpham.Clear();
            txtsoluong.Clear();
            txtdongia.Clear();
            ketnoi.Close();
        }



        private void button4_Click(object sender, EventArgs e)
        {  // so luong hang trpng dgrv lon hon 0
            iTextSharp.text.Font textFont;
            if (dataGridView4.Rows.Count > 0)
                {
                // Tao cai luu file
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                    sfd.FileName = "Output.pdf";
                    bool fileError = false;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(sfd.FileName))    // neu file ton tai thi thay the no 
                        {
                            try
                            {
                                File.Delete(sfd.FileName);
                            }
                            catch (IOException ex)
                            {
                                fileError = true;
                                MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                            }
                        }
                        if (!fileError)
                        {
                            try
                            {
                                PdfPTable pdfTable = new PdfPTable(dataGridView4.Columns.Count);
                                pdfTable.DefaultCell.Padding = 3;          // gia tri le 
                                pdfTable.WidthPercentage = 100;             // do rong
                                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                                // BaseFont unicodeFont = BaseFont.CreateFont("arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                                //textFont = new iTextSharp.text.Font(unicodeFont, 12, iTextSharp.text.Font.NORMAL);

                            //Them cot
                            foreach (DataGridViewColumn column in dataGridView4.Columns)
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                    pdfTable.AddCell(cell);
                                }

                                // lap qua cac hang trong datagripview
                                foreach (DataGridViewRow row  in dataGridView4.Rows)
                                {
                                if (!row.IsNewRow)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                      
                                        {
                                            pdfTable.AddCell(cell.Value.ToString());
                                            
                                            //string cellValue = cell.Value.ToString();
                                            //PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue, textFont));
                                            //pdfTable.AddCell(pdfCell);
                                            
                                        }
                                    }
                                }
                            }

                                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                {
                                    //can le cho cai trang pdf
                                    Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                    PdfWriter.GetInstance(pdfDoc, stream);
                                    pdfDoc.Open();
                                    pdfDoc.Add(pdfTable);
                                    pdfDoc.Close();
                                    stream.Close();
                                }

                                MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Mô tả lỗi :" + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQL_Dangnhap.formlogin  frlogin = new SQL_Dangnhap.formlogin();
            this.Hide();
            frlogin.ShowDialog();
            frlogin.Show();
        }

        private void dataGridViewtkadd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridViewtkadd.Rows[e.RowIndex];
            id1 = row.Cells[0].Value.ToString();
            tk1 = row.Cells[1].Value.ToString();
            mk1 = row.Cells[2].Value.ToString();
            ht1 = row.Cells[3].Value.ToString();
            cv1 = row.Cells[4].Value.ToString();

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            
                ketnoi.Open();
                sql = @"select * from Yeu_cau";
                hienthi();
                dataGridViewtkadd.DataSource = dt;
                ketnoi.Close();
            
        }

        private void cmd_chapnhan_Click(object sender, EventArgs e)
        {
            {
                ketnoi.Open();
  
                sql = @"insert into TK_MK
	            values 
                  ('" + id1 + "' , '" + tk1 + "' , '" + mk1 + "'  , N'" + ht1 + "' , N'" + cv1 + "' )";
                MessageBox.Show(sql);

                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();

                ketnoi.Open();

                string lenhxoa = "delete from Yeu_cau where ID ='" + id1 + "'";

                thuchien = new SqlCommand(lenhxoa, ketnoi);
                thuchien.ExecuteNonQuery();

                MessageBox.Show("THÊM THÀNH CÔNG!!");


                ketnoi.Close();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

                if (e.RowIndex == -1) { return; }
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                ma1 = row.Cells[0].Value.ToString();
            
        }
    }
}
