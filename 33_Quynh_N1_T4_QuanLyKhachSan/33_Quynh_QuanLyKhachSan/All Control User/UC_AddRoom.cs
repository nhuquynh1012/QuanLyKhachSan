using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _33_Quynh_QuanLyKhachSan.All_Control_User
{
    public partial class UC_AddRoom_33_Quynh : UserControl
    {
        funtion_33_Quynh fn_33_Quynh = new funtion_33_Quynh();
        String query_33_Quynh;
        public UC_AddRoom_33_Quynh()
        {
            InitializeComponent();
        }

        private void UC_AddRoom_33_Quynh_Load(object sender, EventArgs e)
        {
            query_33_Quynh = "select * from rooms";
            DataSet ds_33_Quynh = fn_33_Quynh.getData__33_Quynh(query_33_Quynh);
            DataGVAddroom_33_Quynh.DataSource = ds_33_Quynh.Tables[0];
        }

        private void btnUCAddRoom_33_Quynh_Click(object sender, EventArgs e)
        {
            if(txtRoomNumber_33_Quynh.Text!=""&&comboboxRoomType_33_Quynh.Text!=""&&comboboxBed_33_Quynh.Text!=""&&txtPrice_33_Quynh.Text!="")
            {
                String roomNo_33_Quynh = txtRoomNumber_33_Quynh.Text;
                String roomType_33_Quynh = comboboxRoomType_33_Quynh.Text;
                String bed_33_Quynh = comboboxBed_33_Quynh.Text;
                Int64 price_33_Quynh = Int64.Parse(txtPrice_33_Quynh.Text);


                query_33_Quynh = "insert into rooms (roomNo ,roomType , bed , price) values(N'" + roomNo_33_Quynh + "',N'" + roomType_33_Quynh + "',N'" + bed_33_Quynh + "'," + price_33_Quynh + ")";
                fn_33_Quynh.setData_33_Quynh(query_33_Quynh, "Đã Thêm Phòng");

                UC_AddRoom_33_Quynh_Load(this, null);
                clearAll_33_Quynh();
            }
            else
            {
                MessageBox.Show("Xin Vui Lòng Điền Đầy Đủ Thông Tin", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void clearAll_33_Quynh()
        {
            txtRoomNumber_33_Quynh.Clear();
            comboboxRoomType_33_Quynh.SelectedIndex = -1;
            comboboxBed_33_Quynh.SelectedIndex= -1;
            txtPrice_33_Quynh.Clear() ;
        }

        private void UC_AddRoom_33_Quynh_Leave(object sender, EventArgs e)
        {
            clearAll_33_Quynh();
        }

        private void UC_AddRoom_33_Quynh_Enter(object sender, EventArgs e)
        {
            UC_AddRoom_33_Quynh_Load(this,null);
        }

        private void DataGVAddroom_33_Quynh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
