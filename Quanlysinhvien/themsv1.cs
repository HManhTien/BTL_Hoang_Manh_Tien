﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace themsv
{
    public partial class Themuser : Form
    {
        public Themuser()
        {
            InitializeComponent();
        }

        string ChuoiKetNoi = @"Data Source=HOANGTIEN\SQL;Initial Catalog=QL_BHST_GO;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;

        public void themnguoidung()
        {
            ketnoi.Open();
            string id = textbox1.Text;
            string tk = textbox2.Text;
            string mk = textbox3.Text;
            string hoten = textbox4.Text;
            string chucvu = combobox1.Text;



            sql = @"insert into Yeu_cau
	        values 
            ('" + id + "' , '" + tk + "' , '" + mk + "'  , N'" + hoten + "' , N'" + chucvu + "' )";


            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            textbox1.Clear();
            textbox2.Clear();
            textbox3.Clear();
            textbox4.Clear();
            combobox1.Items.Clear();
            ketnoi.Close();

        }


        private void button1_Click(object sender, EventArgs e)
        {

            ketnoi.Open();
            string tk = textbox2.Text;
            string id = textbox1.Text;
            string str = $"select * from TK_MK  Where ID = '" + id + "' or TaiKhoan ='" + tk + "'";
          

            thuchien = new SqlCommand(str, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(docdulieu);

            docdulieu.Close();
            if (dt.Rows.Count > 0)
            {
                textbox1.Clear();
                textbox2.Clear();
                textbox3.Clear();
                textbox4.Clear();
                MessageBox.Show("Đã Tồn Tại Tài khoản ");

            }
            else
            {
                ketnoi.Close();
                themnguoidung();
            }
            ketnoi.Close();



        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(ChuoiKetNoi);
          
        }

 
    }
}
