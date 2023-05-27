namespace FormQLSV
{
    partial class FormQLSV
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmd_view = new System.Windows.Forms.Button();
            this.cmd_themsv = new System.Windows.Forms.Button();
            this.cmd_sua = new System.Windows.Forms.Button();
            this.cmd_xoa1dong = new System.Windows.Forms.Button();
            this.cmd_ = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmd_tk = new System.Windows.Forms.Button();
            this.Seach = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(22, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 483);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(697, 483);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cmd_view
            // 
            this.cmd_view.BackColor = System.Drawing.Color.SpringGreen;
            this.cmd_view.Location = new System.Drawing.Point(22, 27);
            this.cmd_view.Name = "cmd_view";
            this.cmd_view.Size = new System.Drawing.Size(157, 59);
            this.cmd_view.TabIndex = 1;
            this.cmd_view.Text = "View";
            this.cmd_view.UseVisualStyleBackColor = false;
            this.cmd_view.Click += new System.EventHandler(this.cmd_view_Click);
            // 
            // cmd_themsv
            // 
            this.cmd_themsv.AutoSize = true;
            this.cmd_themsv.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cmd_themsv.Location = new System.Drawing.Point(742, 164);
            this.cmd_themsv.Name = "cmd_themsv";
            this.cmd_themsv.Size = new System.Drawing.Size(139, 61);
            this.cmd_themsv.TabIndex = 2;
            this.cmd_themsv.Text = "Thêmsv";
            this.cmd_themsv.UseVisualStyleBackColor = false;
            this.cmd_themsv.Click += new System.EventHandler(this.cmd_themsv_Click);
            // 
            // cmd_sua
            // 
            this.cmd_sua.Location = new System.Drawing.Point(742, 270);
            this.cmd_sua.Name = "cmd_sua";
            this.cmd_sua.Size = new System.Drawing.Size(139, 48);
            this.cmd_sua.TabIndex = 3;
            this.cmd_sua.Text = "Sửa";
            this.cmd_sua.UseVisualStyleBackColor = true;
            this.cmd_sua.Click += new System.EventHandler(this.cmd_xoa_Click);
            // 
            // cmd_xoa1dong
            // 
            this.cmd_xoa1dong.Location = new System.Drawing.Point(742, 471);
            this.cmd_xoa1dong.Name = "cmd_xoa1dong";
            this.cmd_xoa1dong.Size = new System.Drawing.Size(139, 48);
            this.cmd_xoa1dong.TabIndex = 4;
            this.cmd_xoa1dong.Text = "Xóa";
            this.cmd_xoa1dong.UseVisualStyleBackColor = true;
            this.cmd_xoa1dong.Click += new System.EventHandler(this.cmd_xoa1dong_Click);
            // 
            // cmd_
            // 
            this.cmd_.Location = new System.Drawing.Point(743, 366);
            this.cmd_.Name = "cmd_";
            this.cmd_.Size = new System.Drawing.Size(138, 51);
            this.cmd_.TabIndex = 5;
            this.cmd_.Text = "Xuất Exel ";
            this.cmd_.UseVisualStyleBackColor = true;
            this.cmd_.Click += new System.EventHandler(this.cmd__Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(264, 45);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(455, 42);
            this.textBox1.TabIndex = 6;
            // 
            // cmd_tk
            // 
            this.cmd_tk.Location = new System.Drawing.Point(742, 45);
            this.cmd_tk.Name = "cmd_tk";
            this.cmd_tk.Size = new System.Drawing.Size(138, 46);
            this.cmd_tk.TabIndex = 7;
            this.cmd_tk.Text = "Tìm Kiếm ";
            this.cmd_tk.UseVisualStyleBackColor = true;
            this.cmd_tk.Click += new System.EventHandler(this.cmd_tk_Click);
            // 
            // Seach
            // 
            this.Seach.AutoSize = true;
            this.Seach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Seach.Location = new System.Drawing.Point(260, 22);
            this.Seach.Name = "Seach";
            this.Seach.Size = new System.Drawing.Size(85, 20);
            this.Seach.TabIndex = 8;
            this.Seach.Text = "Tìm Kiếm ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(259, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "THÔNG TIN SINH VIEN";
            // 
            // FormQLSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(893, 648);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Seach);
            this.Controls.Add(this.cmd_tk);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmd_);
            this.Controls.Add(this.cmd_xoa1dong);
            this.Controls.Add(this.cmd_sua);
            this.Controls.Add(this.cmd_themsv);
            this.Controls.Add(this.cmd_view);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormQLSV";
            this.Text = "FormQLSV";
            this.Load += new System.EventHandler(this.FormQLSV_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmd_view;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmd_themsv;
        private System.Windows.Forms.Button cmd_sua;
        private System.Windows.Forms.Button cmd_xoa1dong;
        private System.Windows.Forms.Button cmd_;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cmd_tk;
        private System.Windows.Forms.Label Seach;
        private System.Windows.Forms.Label label1;
    }
}

