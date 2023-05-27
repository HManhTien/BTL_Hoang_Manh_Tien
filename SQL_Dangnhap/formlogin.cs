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
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        // SqlCommand thuchien;
        string tk, mk;
        FormQLSV.FormQLSV fr2 = new FormQLSV.FormQLSV();

        string connStr = @"Data Source=HOANGTIEN\SQL;Initial Catalog=SV56KMT;Integrated Security=True";

       

        public void checkchucvu()
        {

             ketnoi.Open();
            string sql1 = $"select * from QL_TaiKhoan Where TaiKhoan = '" + tk + "' and MatKhau ='" + mk + "' AND Chucvu = N'Giáo Viên' ";
            MessageBox.Show(sql1);



            thuchien = new SqlCommand(sql1, ketnoi);
            thuchien.ExecuteNonQuery();
            docdulieu = thuchien.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(docdulieu);
            

            if(dt1.Rows.Count > 0)
            {
                MessageBox.Show("GIÁO VIÊN ĐĂNG NHẬP THÀNH CÔNG !!");
                fr2.ShowDialog();
                

            }
            else
            {
                MessageBox.Show("SINH VIÊN ĐĂNG NHẬP THÀNH CÔNG !!");
            }

            

        }
        private void button1_Click(object sender, EventArgs e)
        {




            ketnoi.Open();
            tk = textbox_tk.Text;
            mk = textbox_mk.Text;
            string str = $"select * from QL_TaiKhoan Where TaiKhoan = '" + tk + "' and MatKhau ='" + mk + "'";

            
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
  

            
        

        private void formlogin_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(connStr);
            pictureBox1.Image = Image.FromFile("C:\\Users\\hoang\\Pictures\\Saved Pictures\\anhlogin.png");
        }
    }
}
