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


namespace themsv
{
    public partial class ADDuser : Form
    {
        public ADDuser()
        {
            InitializeComponent();
        }

        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string sql;
        string connStr = @"Data Source=HOANGTIEN\SQL;Initial Catalog=QL_BHST_GO;Integrated Security=True";

        public void  themnguoidung()
        {
            ketnoi.Open();
            string id = textBox1.Text;
            string tk = textBox2.Text;
            string mk = textBox3.Text;
            string hoten = textBox4.Text;
            string chucvu = comboBox1.Text;



            sql = @"insert into Yeu_cau
	        values 
            ('" + id + "' , '" + tk + "' , '" + mk + "'  , N'"+ hoten + "' , N'"+ chucvu + "' )";
            

            MessageBox.Show(sql) ;
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Items.Clear();
            ketnoi.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {



            ketnoi.Open();
            string tk = textBox2.Text;
            string id = textBox1.Text;
            string str = $"select * from TK_MK  Where ID = '" + id + "' or TaiKhoan ='" + tk + "'";


            thuchien = new SqlCommand(str, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(docdulieu);

            docdulieu.Close();
            if (dt.Rows.Count > 0)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                MessageBox.Show("Đã Tồn Tại Tài khoản ");
                
            }
            else
            {
                ketnoi.Close();
                themnguoidung();
            }
            ketnoi.Close();
        }

        private void ADDuser_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(connStr);
        }
    }
}
