namespace themsv
{
    partial class themsv
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_mssv = new System.Windows.Forms.TextBox();
            this.txt_hoten = new System.Windows.Forms.TextBox();
            this.txt_diachi = new System.Windows.Forms.TextBox();
            this.txt_dt = new System.Windows.Forms.TextBox();
            this.txt_lop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "THÊM SINH VIÊN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "MSSV";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(25, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "HỌ TÊN :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(25, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "LỚP";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(25, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "ĐỊA CHỈ";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(25, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "SDT";
            // 
            // txt_mssv
            // 
            this.txt_mssv.Location = new System.Drawing.Point(129, 61);
            this.txt_mssv.Multiline = true;
            this.txt_mssv.Name = "txt_mssv";
            this.txt_mssv.Size = new System.Drawing.Size(189, 30);
            this.txt_mssv.TabIndex = 7;
            // 
            // txt_hoten
            // 
            this.txt_hoten.Location = new System.Drawing.Point(129, 107);
            this.txt_hoten.Multiline = true;
            this.txt_hoten.Name = "txt_hoten";
            this.txt_hoten.Size = new System.Drawing.Size(189, 30);
            this.txt_hoten.TabIndex = 8;
            // 
            // txt_diachi
            // 
            this.txt_diachi.Location = new System.Drawing.Point(129, 200);
            this.txt_diachi.Multiline = true;
            this.txt_diachi.Name = "txt_diachi";
            this.txt_diachi.Size = new System.Drawing.Size(189, 30);
            this.txt_diachi.TabIndex = 10;
            // 
            // txt_dt
            // 
            this.txt_dt.Location = new System.Drawing.Point(129, 249);
            this.txt_dt.Multiline = true;
            this.txt_dt.Name = "txt_dt";
            this.txt_dt.Size = new System.Drawing.Size(189, 30);
            this.txt_dt.TabIndex = 11;
            // 
            // txt_lop
            // 
            this.txt_lop.FormattingEnabled = true;
            this.txt_lop.Items.AddRange(new object[] {
            "56KMT.01",
            "57KMT.01",
            "58KMT.01"});
            this.txt_lop.Location = new System.Drawing.Point(129, 158);
            this.txt_lop.Name = "txt_lop";
            this.txt_lop.Size = new System.Drawing.Size(189, 24);
            this.txt_lop.TabIndex = 12;
            this.txt_lop.Text = "56KMT.01";
          //  this.txt_lop.SelectedIndexChanged += new System.EventHandler(this.txt_lop_SelectedIndexChanged);
            // 
            // themsv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 450);
            this.Controls.Add(this.txt_lop);
            this.Controls.Add(this.txt_dt);
            this.Controls.Add(this.txt_diachi);
            this.Controls.Add(this.txt_hoten);
            this.Controls.Add(this.txt_mssv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "themsv";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_mssv;
        private System.Windows.Forms.TextBox txt_hoten;
        private System.Windows.Forms.TextBox txt_diachi;
        private System.Windows.Forms.TextBox txt_dt;
        private System.Windows.Forms.ComboBox txt_lop;
    }
}

