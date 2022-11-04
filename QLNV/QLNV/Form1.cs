using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QLNV
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
     //   SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QuanLySinhVien;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
           // var db = new SqlDataAdapter("SELECT * FROM tblSinhVien", conn);
           // var table = new DataTable();
          //  db.Fill(table);
          //  dataGridView1.DataSource = table;
            // from main để hiển thị điemer cho sinh vien 

            var db = new Database();

            //dataGridView1.DataSource = db.SelectData(null);

        }
    }
}
