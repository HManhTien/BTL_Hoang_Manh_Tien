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

namespace SQL_Dangnhap
{
    public partial class formlogin : Form
    {
        public formlogin()
        {
            InitializeComponent();
        }

        FormQLSV.FormQLSV fr2 = new FormQLSV.FormQLSV();

        private void button1_Click(object sender, EventArgs e)
        {

            string connStr = @"Data Source=HOANGTIEN\SQL;Initial Catalog=Quanly;Integrated Security=True";
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = connStr;
            
            try
            {
                sql.Open();
                string tk = textbox_tk.Text;
                string mk = textbox_mk.Text;
                string str = $"select * from NguoiDung where TaiKhoan = \'{tk}\'  and MatKhau = \'{mk}\'  ";
                SqlCommand cmd = sql.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = str;
                SqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Đăng Nhập thành công ");
                    fr2.Show();
                }
                else
                {
                    MessageBox.Show("Đăng NhậpThất Bại ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
