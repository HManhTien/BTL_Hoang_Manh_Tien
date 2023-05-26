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
    public partial class themsv1 : Form
    {
        public themsv1()
        {
            InitializeComponent();
        }

        string ChuoiKetNoi = @"Data Source=HOANGTIEN\SQL;Initial Catalog=SV56KMT;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;

        public void themsinhvien()
        {

            string mssv = txt_mssv.Text;
            string hoten = txt_hoten.Text;
            string lop = txt_lop.Text;
            string diachi = txt_diachi.Text;
            string dt = txt_dt.Text;
            //int dtdd = int.Parse(dt);

            sql = @"insert into lop56KMT
	        values 
            ('1' , '" + mssv + "' , '" + hoten + "' , '" + lop + "'  , '" + diachi + "'  ,  " + dt + ")";
            MessageBox.Show(sql);

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            ketnoi.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            themsinhvien();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(ChuoiKetNoi);
            ketnoi.Open();
        }

  
    }
}
