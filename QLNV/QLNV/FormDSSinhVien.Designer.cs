namespace QLNV
{
    partial class FormDSSinhVien
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
            this.dgvDSSV = new System.Windows.Forms.DataGridView();
            this.buttonTimKiem = new System.Windows.Forms.Button();
            this.textimkiem = new System.Windows.Forms.TextBox();
            this.labelTuKhoa = new System.Windows.Forms.Label();
            this.buttonThemmoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDSSV
            // 
            this.dgvDSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDSSV.Location = new System.Drawing.Point(0, 83);
            this.dgvDSSV.Name = "dgvDSSV";
            this.dgvDSSV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSSV.Size = new System.Drawing.Size(843, 281);
            this.dgvDSSV.TabIndex = 0;
            this.dgvDSSV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSSV_CellContentClick);
            // 
            // buttonTimKiem
            // 
            this.buttonTimKiem.Location = new System.Drawing.Point(666, 27);
            this.buttonTimKiem.Name = "buttonTimKiem";
            this.buttonTimKiem.Size = new System.Drawing.Size(75, 23);
            this.buttonTimKiem.TabIndex = 1;
            this.buttonTimKiem.Text = "TIM KIEM";
            this.buttonTimKiem.UseVisualStyleBackColor = true;
            // 
            // textimkiem
            // 
            this.textimkiem.Location = new System.Drawing.Point(560, 27);
            this.textimkiem.Name = "textimkiem";
            this.textimkiem.Size = new System.Drawing.Size(100, 20);
            this.textimkiem.TabIndex = 3;
            this.textimkiem.TextChanged += new System.EventHandler(this.textimkiem_TextChanged);
            // 
            // labelTuKhoa
            // 
            this.labelTuKhoa.AutoSize = true;
            this.labelTuKhoa.Location = new System.Drawing.Point(499, 32);
            this.labelTuKhoa.Name = "labelTuKhoa";
            this.labelTuKhoa.Size = new System.Drawing.Size(55, 13);
            this.labelTuKhoa.TabIndex = 4;
            this.labelTuKhoa.Text = "TU KHOA";
            // 
            // buttonThemmoi
            // 
            this.buttonThemmoi.Location = new System.Drawing.Point(759, 27);
            this.buttonThemmoi.Name = "buttonThemmoi";
            this.buttonThemmoi.Size = new System.Drawing.Size(75, 23);
            this.buttonThemmoi.TabIndex = 5;
            this.buttonThemmoi.Text = "Them Moi";
            this.buttonThemmoi.UseVisualStyleBackColor = true;
            this.buttonThemmoi.Click += new System.EventHandler(this.buttonThemmoi_Click);
            // 
            // FormDSSinhVien
            // 
            this.ClientSize = new System.Drawing.Size(843, 364);
            this.Controls.Add(this.buttonThemmoi);
            this.Controls.Add(this.labelTuKhoa);
            this.Controls.Add(this.textimkiem);
            this.Controls.Add(this.buttonTimKiem);
            this.Controls.Add(this.dgvDSSV);
            this.Name = "FormDSSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sach Sinh Vien";
            this.Load += new System.EventHandler(this.FormDSSinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.DataGridView dgvDSSV;
        private System.Windows.Forms.Button buttonTimKiem;
        private System.Windows.Forms.TextBox textimkiem;
        private System.Windows.Forms.Label labelTuKhoa;
        private System.Windows.Forms.Button buttonThemmoi;
    }
}