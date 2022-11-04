using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV
{
    public partial class FormDSSinhVien : Form
    {
        public FormDSSinhVien()
        {
            InitializeComponent();
        }
        private string tukhoa = "";

        private void FormDSSinhVien_Load(object sender, EventArgs e)
        {
            // dgvDSSV.DataSource = new Database().SelectData("exec SelectAllSinhVien ");

            // Dat ten cot 
            //dgvDSSV.Columns["fldMaSV"].HeaderText = "Mã SV";
            //dgvDSSV.Columns["fldHoTen"].HeaderText = "Họ Tên ";
            // dgvDSSV.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            // dgvDSSV.Columns["GioiTinh"].HeaderText = "Giới Tính";
            // dgvDSSV.Columns["fldDiaChi"].HeaderText = "Địa Chỉ ";
            //dgvDSSV.Columns["fldSDT"].HeaderText = "Số Điện Thoại ";
            // ==> Sau khi load laij from ta không cần hạt code treen 
            // tạo một hàm loadDSSV
            LoadDSSV(); // Gọi tới hàm load sinh viên from được load 

        }
        private void LoadDSSV()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            });
            dgvDSSV.DataSource = new Database().SelectData("SelectAllSinhVien " , lstPara);
          
            // Dat ten cot 
            dgvDSSV.Columns["fldMaSV"].HeaderText = "Mã SV";
            dgvDSSV.Columns["fldHoTen"].HeaderText = "Họ Tên ";
            dgvDSSV.Columns["fldMaLop"].HeaderText = "Lớp";
            dgvDSSV.Columns["fldHeDaoTao"].HeaderText = "Hệ Đào Tạo";
            dgvDSSV.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvDSSV.Columns["fldDiaChi"].HeaderText = "Địa Chỉ ";
            dgvDSSV.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvDSSV.Columns["fldSDT"].HeaderText = "Số Điện Thoại ";

        }


        private void dgvDSSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tạo from khi cick vào một sinh vien 
            // sẽ hiện tra một khung from mới
            // Từ đó ta có thể cập nhật được sinh vien
            // trước hết ta cần lấy được mã sinh viên 
            if (e.RowIndex >= 0)
            {
                var msv = dgvDSSV.Rows[e.RowIndex].Cells["fldMaSV"].Value.ToString();
                // tao mot ham de truyen  ma sinh vien vao formSInhVIen
                new FormSinhVien(msv).ShowDialog();

                // Sau khi fromSinhVien được đongs lại 
                // ta cần load lại danh sách sinh viên 
                LoadDSSV();
            }
        }

        private void buttonThemmoi_Click(object sender, EventArgs e)
        {
            // Neeu như thêm mới sinh viên => mã sinh vien = null 
            new FormSinhVien(null).ShowDialog();
            LoadDSSV(); // Sau khi thêm sinh viên tiến hành rest lại form 
        }

        private void textimkiem_TextChanged(object sender, EventArgs e)
        {
            tukhoa = textimkiem.Text;
            LoadDSSV();
        }
    }
}
 