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
        string ma;
        string ChuoiKetNoi = @"Data Source=HOANGTIEN\SQL;Initial Catalog=SV56KMT;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;

        themsv.themsv1 tsv = new themsv.themsv1();

        private void FormQLSV_Load(object sender, EventArgs e)
        {

            ketnoi = new SqlConnection(ChuoiKetNoi);

           
        }

        public void hienthi()
        {

           
            sql = @"select * from QL_SV ";
            thuchien = new SqlCommand(sql,ketnoi);
            docdulieu = thuchien.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(docdulieu);
            dataGridView1.DataSource = dt;
            




        }
        
        private void cmd_view_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            hienthi();
            ketnoi.Close();
        }

        private void cmd_themsv_Click(object sender, EventArgs e)
        {
            tsv.ShowDialog();
        }

        public void delete(string str)
        {
            string lenhxoa = "delete from QL_SV where MSSV ='" + str + "'";
 
            thuchien = new SqlCommand(lenhxoa,ketnoi);
            thuchien.ExecuteNonQuery(); 
        }
        private void cmd_xoa_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
    
            tsv.ShowDialog();           

            ketnoi.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
             ma = row.Cells[1].Value.ToString();
            
        }

        private void cmd_xoa1dong_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            delete(ma);
            hienthi();
            ketnoi.Close();
        }

        private void cmd__Click(object sender, EventArgs e)
        {
              
        }

        private void cmd_tk_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string tensv = textBox1.Text;
            sql = @"SELECT * FROM QL_SV WHERE HoTen LIKE '%" + tensv+"%' ";
            MessageBox.Show(sql);
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(docdulieu);
            dataGridView1.DataSource = dt;
            docdulieu.Close();
            ketnoi.Close();

        }

 
    }
}
