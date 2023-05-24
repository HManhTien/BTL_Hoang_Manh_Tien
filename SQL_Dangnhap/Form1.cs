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

namespace SQL_Dangnhap
{
    public partial class formlogin : Form
    {
        public formlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(@"Data Source=HOANGTIEN\SEVERTEN;Initial Catalog=Cuoi;Integrated Security=True");
            try
            {
                sql.Open();
                string tk = textbox_tk.Text;
                string mk = textbox_mk.Text;
                string str = "select* form NguoiDung where TaiKhoan = "+tk+"  and MatKhau = "+mk+"  ";
                SqlCommand cmd = new SqlCommand(str, sql);
                SqlDataReader   sdr = cmd.ExecuteReader();
                if (sdr.Read() == true )
                {
                    MessageBox.Show("Đăng Nhập thành công ");
                }else
                {
                    MessageBox.Show("Đăng NhậpThất Bại ");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
