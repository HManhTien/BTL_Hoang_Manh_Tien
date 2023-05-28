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
using System.Data;
using System.Xml;
using FormQLSV;
using themsv;
using formsvview;



namespace SQL_Dangnhap
{
    public partial class formlogin : Form
    {
        public formlogin()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        // SqlCommand thuchien;
        string tk, mk;
      
        FormQLSV.FormQLSV fr2 = new FormQLSV.FormQLSV();
        themsv.Themuser themuser = new themsv.Themuser();
        string connStr = @"Data Source=HOANGTIEN\SQL;Initial Catalog=QL_BHST_GO;Integrated Security=True";

       

        public void checkchucvu()
        {

             ketnoi.Open();
            string sql1 = $"select * from TK_MK Where TaiKhoan = '" + tk + "' and MaKhau ='" + mk + "' AND Chucvu = N'Quản Trị Viên' ";
           



            thuchien = new SqlCommand(sql1, ketnoi);
            thuchien.ExecuteNonQuery();
            docdulieu = thuchien.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(docdulieu);
            

            if(dt1.Rows.Count > 0)
            {
                MessageBox.Show("ADMIN ĐĂNG NHẬP THÀNH CÔNG !!");
                this.Hide();
                fr2.ShowDialog();
               


            }
            else
            {
               
                MessageBox.Show("NHÂN VIÊN  ĐĂNG NHẬP THÀNH CÔNG !!");

                formsvview.formNV NV = new formsvview.formNV();
                this.Hide();
                NV.ShowDialog();

            }



        }
        private void button1_Click(object sender, EventArgs e)
        {




            ketnoi.Open();
            tk = textbox_tk.Text;
            mk = textbox_mk.Text;
            string str = $"select * from TK_MK  Where TaiKhoan = '" + tk + "' and MaKhau ='" + mk + "'";

            
            thuchien = new SqlCommand(str, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(docdulieu);

            docdulieu.Close();
            if (dt.Rows.Count > 0)
            {
                ketnoi.Close();
                checkchucvu();
            }
            else
            {
                MessageBox.Show("SAI THÔNG TIN ĐĂNG NHẬP !!!");
            }
            ketnoi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            themuser.ShowDialog();
        }

        private void formlogin_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(connStr);
            pictureBox1.Image = Image.FromFile("C:\\Users\\hoang\\Pictures\\Saved Pictures\\anhlogin.png");
        }
    }
}
