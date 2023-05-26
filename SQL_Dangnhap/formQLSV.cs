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



namespace FormQLSV
{
    public partial class FormQLSV : Form
    {
        public FormQLSV()
        {
            InitializeComponent();
        }

        string ChuoiKetNoi = @"Data Source=HOANGTIEN\SQL;Initial Catalog=SV56KMT;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;

        private void FormQLSV_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(ChuoiKetNoi);
           
        }

        public void hienthi()
        {
          
            ketnoi.Open();
            sql = @"select * from lop56KMT ";
            thuchien = new SqlCommand(sql,ketnoi);
            docdulieu = thuchien.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(docdulieu);
            dataGridView1.DataSource = dt;
         
            ketnoi.Close();
            
        }
        
        private void cmd_view_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void cmd_themsv_Click(object sender, EventArgs e)
        {
           
        }
    }
}
