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
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class Themsv1 : Form
    {
        public Themsv1()
        {
            InitializeComponent();
        }

        string ChuoiKetNoi = @"Data Source=HOANGTIEN\SQL;Initial Catalog=SV56KMT;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
       


        public void Themsv_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(ChuoiKetNoi);
            ketnoi.Open();
 



        }

        public void themsinhvien()      
        {
          
            string mssv = textmssv.Text;
            string hoten = texthoten.Text;
            string lop = txtlop.Text;
            string diachi = textdiachi.Text;
            string dt = textdt.Text;
            //int dtdd = int.Parse(dt);

            sql = @"insert into lop56KMT
	        values 
            ('1' , '"+mssv+ "' , '"+ hoten + "' , '"+ lop + "'  , '"+ diachi + "'  ,  "+ dt + ")";
            MessageBox.Show(sql);

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            ketnoi.Close();
        }
        private void cmd_Themsv_Click(object sender, EventArgs e)
        {
            themsinhvien();
            
        }
    }
}
