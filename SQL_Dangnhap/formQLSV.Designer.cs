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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(4, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 248);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN SV";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(601, 223);
            this.dataGridView1.TabIndex = 0;
            // 
            // cmd_view
            // 
            this.cmd_view.BackColor = System.Drawing.Color.SpringGreen;
            this.cmd_view.Location = new System.Drawing.Point(637, 23);
            this.cmd_view.Name = "cmd_view";
            this.cmd_view.Size = new System.Drawing.Size(139, 59);
            this.cmd_view.TabIndex = 1;
            this.cmd_view.Text = "View";
            this.cmd_view.UseVisualStyleBackColor = false;
            this.cmd_view.Click += new System.EventHandler(this.cmd_view_Click);
            // 
            // cmd_themsv
            // 
            this.cmd_themsv.AutoSize = true;
            this.cmd_themsv.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cmd_themsv.Location = new System.Drawing.Point(646, 126);
            this.cmd_themsv.Name = "cmd_themsv";
            this.cmd_themsv.Size = new System.Drawing.Size(130, 61);
            this.cmd_themsv.TabIndex = 2;
            this.cmd_themsv.Text = "Thêmsv";
            this.cmd_themsv.UseVisualStyleBackColor = false;
            this.cmd_themsv.Click += new System.EventHandler(this.cmd_themsv_Click);
            // 
            // FormQLSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

