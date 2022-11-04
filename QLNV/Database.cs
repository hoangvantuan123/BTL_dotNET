using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV
{
    public class Database
    {
        private string connetionString =@"Data Source=.\sqlexpress;Initial Catalog=QuanLySinhVien;Integrated Security=True";
        private SqlConnection conn;
    
        private DataTable dt;
        private SqlCommand cmd;
        public Database()
        {
            try
            {
                conn = new SqlConnection(connetionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("connected failed: " + ex.Message);
            }
        }

        public DataTable SelectData(string sql, List<CustomParameter> lstPara)
        {
            try
            {
                conn.Open();
                //sql = "exec SelectAllSinhVien";
                cmd = new SqlCommand(sql, conn); // du lieu duoc truyen vao
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var para in lstPara) // gán cá tham số cho cmd
                {
                    cmd.Parameters.AddWithValue(para.key, para.value);
                }
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }


        public DataRow Select(String sql)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql , conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows[0];

            }
            catch(Exception  ex)
            {
                MessageBox.Show("Lỗi load thông tin chi tiết : " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }

        }

        public int ExeCute(string sql, List<CustomParameter> lstPara)
        {
            try
            {
                // cần sửa lại hàm execute như sau
                //string sql,List<CustomParameter> lstPara là tham số truyền vào 
                //CustomParameter đã được định nghĩa 
                //Mở kết nối rồi tiến hành thực thi câu lệnh
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach(var p in lstPara)  // gán các tham số cho cmd 
                {
                    cmd.Parameters.AddWithValue(p.key, p.value);
                }
                var rs = cmd.ExecuteNonQuery(); /// `lấy kết quả rồi thực thi câu lệnh truy vấn gán và rs
               return (int)rs; // trả về kết quả 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thông tin chi tiết : " + ex.Message);
                return -100;
            }
            finally { conn.Close(); }
        }
    }
}
