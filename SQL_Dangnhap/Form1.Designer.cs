namespace SQL_Dangnhap
{
    partial class formlogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textbox_tk = new System.Windows.Forms.TextBox();
            this.textbox_mk = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.BackColor = System.Drawing.Color.Tomato;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Aquamarine;
            this.label2.Location = new System.Drawing.Point(260, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 71);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đăng Nhập Vào APP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Turquoise;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(75, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 42);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tài Khoản";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Turquoise;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(75, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 42);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mật Khẩu";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textbox_tk
            // 
            this.textbox_tk.Location = new System.Drawing.Point(295, 179);
            this.textbox_tk.Multiline = true;
            this.textbox_tk.Name = "textbox_tk";
            this.textbox_tk.Size = new System.Drawing.Size(268, 42);
            this.textbox_tk.TabIndex = 4;
            // 
            // textbox_mk
            // 
            this.textbox_mk.Location = new System.Drawing.Point(295, 264);
            this.textbox_mk.Multiline = true;
            this.textbox_mk.Name = "textbox_mk";
            this.textbox_mk.Size = new System.Drawing.Size(268, 42);
            this.textbox_mk.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Location = new System.Drawing.Point(333, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 53);
            this.button1.TabIndex = 6;
            this.button1.Text = "Đăng Nhập";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // formlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textbox_mk);
            this.Controls.Add(this.textbox_tk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "formlogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textbox_tk;
        private System.Windows.Forms.TextBox textbox_mk;
        private System.Windows.Forms.Button button1;
    }
}

