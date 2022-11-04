using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV
{
    public partial class FormSinhVien : Form
    {
        public FormSinhVien(string msv)
        {
            this.msv = msv; // dung this de truyen lai ma sinh vien khi form chay
            InitializeComponent();
        }
        private string msv; 
        private void FormSinhVien_Load(object sender, EventArgs e)
        {
           // MessageBox.Show("Mã sinh vien nhận được là: " + msv);
           //neu msv khong cos => ta tien hanh them moi sv
           if(string.IsNullOrEmpty(msv))
            {
                this.Text = "Thêm mới sinh viên";
            }
           else
            {
                
                this.Text = "Cập nhật thông tin sinh viên ";
                // lấy thông tin chi tiết cho một sinh viên  dựa vào mã sinh viên ta đã cung cấp
                var r = new Database().Select("selectSinhVien '" + msv + "'");
                // MessageBox.Show(r[0].ToString()); Kiem Tra xem load thành công chưa 
                //Lấy giá trị vừa đặt từ form 
                textHoTen.Text = r["fldHoTen"].ToString();
                textMalop.Text = r["fldMaLop"].ToString();
                texthedaotao.Text = r["fldHeDaoTao"].ToString();
                maskedNgaySinh.Text = r["ngaysinh"].ToString();
                textDiaChi.Text = r["fldDiaChi"].ToString();
                // Giioiws tính
                if (int.Parse(r["gioitinh"].ToString()) == 1)
                {
                    radioNam.Checked = true;
                }
                else
                {
                    radioNu.Checked = true;
                };
              
              
                textDienThoai.Text = r["fldSDT"].ToString();

               
                


            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Khi người dùng click và lưu sẽ ra 2 trường hợp 
            // th1: nếu mã  sinh viên không có giá trị -> thêm mới sinh viên đó
            // th2: nếu mã sinh viên có giá trị -> thông báo cập nhật thông tin thành công
            // 
            // tạo một biến sql rông
            string sql = "";
         
            string hoten = textHoTen.Text;

            //ngày sinh đang ở dang dd /mm/yyyy
            // còn trong csdl là yyyy-mm-dd
            // Chuyen dd/mm/yyyy sang yyyy-mm-dd
            DateTime ngaysinh;
            try
            {
                ngaysinh = DateTime.ParseExact(maskedNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch(Exception )
            {
                MessageBox.Show("ERROR Ngày sinh không hợp lệ !");
                maskedNgaySinh.Select(); // tro chuot ve maskedNgaySinh
                return; //khong thuc hien dc
            };
            // Toán tử 2 ngôi
            string gioitinh = radioNam.Checked ? "1" : "0"; // nêu là nam thì đuọcư check là 1 ngược lại nữ là 0 
            string malop = textMalop.Text;
            string hedaotao = texthedaotao.Text;
            string diachi = textDiaChi.Text;
            string dienthoai = textDienThoai.Text;

            // khai báo một danh sách các tham số = với class CustomParameter --> đã đc ta khai báo 

            List<CustomParameter> lstPara = new List<CustomParameter>();
           

            if(string.IsNullOrEmpty(msv)) // trường hợp nếu ta thêm mới sinh viên đó 
            {
                sql = "ThemMoiSV"; // Gọi tới procedure để tiến hành thêm mới  sinh viên 
                
            }
            else //Nếu cập nhâtj sinh viên 
            {
                sql = "updateSV"; // gọi tới procedure để tiến hành cập nhật thông tin sinh viên 
                lstPara.Add(new CustomParameter()
                {
                    key = "@fldMaSV",
                    value = msv
                });
            }
            lstPara.Add(new CustomParameter()
            {
                key = "@fldHoTen",
                value = hoten
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@fldMaLop",
                value = malop
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@fldHeDaoTao",
                value = hedaotao
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@fldNgaySinh",
                value = ngaysinh.ToString("yyyy-MM-dd")
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@fldDiaChi",
                value = diachi
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@fldGioiTinh",
                value = gioitinh
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@fldSDT",
                value = dienthoai
            });

            var rs = new Database().ExeCute(sql, lstPara); // truyền 2 tham số trong câu lệnh sql

            // danh sách các tham số
            if(rs ==1 ) // neu thanh cong  
            {

                if(string.IsNullOrEmpty(msv)) // neu ta tien hanh them moi
                {
                    MessageBox.Show("Thêm mới thành công ");
                }
                else // neu ta tien hanh cap nhat
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                this.Dispose(); // đóng lại form sau khi thực hiện các bước

            }
            else // neu như cập nhật không thành công 
            {
                MessageBox.Show("LỖI! Thực thi thất bại");
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose(); // Đóng lại from 
        }
    }
}
