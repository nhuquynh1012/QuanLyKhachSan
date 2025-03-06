using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _33_Quynh_QuanLyKhachSan.All_Control_User
{
    public partial class UC_Checkout_33_Quynh : UserControl
    {
        funtion_33_Quynh fn_33_Quynh = new funtion_33_Quynh();
        String query_33_Quynh;

        public UC_Checkout_33_Quynh()
        {
            InitializeComponent();
        }

        private void UC_Checkout_Load(object sender, EventArgs e)
        {
            query_33_Quynh = "select customer.cid , customer.cname , customer.mobile , customer.nationality , customer.gender, customer.dob , customer.idproof, customer.address, customer.checkin, rooms.roomNo , rooms.roomType , rooms.bed , rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where chekout = 'NO'";
            DataSet ds_33_Quynh = fn_33_Quynh.getData__33_Quynh(query_33_Quynh);
            datagridviewCheckout_33_Quynh.DataSource= ds_33_Quynh.Tables[0];

        }

        private void txtSearch_33_Quynh_TextChanged(object sender, EventArgs e)
        {
            query_33_Quynh = "select customer.cid , customer.cname , customer.mobile , customer.nationality , customer.gender, customer.dob , customer.idproof, customer.address, customer.checkin, rooms.roomNo , rooms.roomType , rooms.bed , rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where cname like '" + txtSearch_33_Quynh.Text + "%' and chekout = 'NO'";
            DataSet ds_33_Quynh = fn_33_Quynh.getData__33_Quynh(query_33_Quynh);
            datagridviewCheckout_33_Quynh.DataSource = ds_33_Quynh.Tables[0];
        }

        int id_33_Quynh;
        private void datagridviewCheckout_33_Quynh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datagridviewCheckout_33_Quynh.Rows[e.RowIndex].Cells[e.RowIndex].Value!= null)
            {
                id_33_Quynh = int.Parse(datagridviewCheckout_33_Quynh.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtName_33_Quynh.Text = datagridviewCheckout_33_Quynh.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoomNo_33_Quynh.Text = datagridviewCheckout_33_Quynh.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btnCheckout_33_Quynh_Click(object sender, EventArgs e)
        {
            if(txtName_33_Quynh.Text!= "")
            {
                if (MessageBox.Show("Bạn Có Chắc Chắn  Không ?","Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    String cdate_33_Quynh = datetimepickerCheckOut_33_Quynh.Text;
                    query_33_Quynh = "update customer set chekout = 'YES', checkout = '" + cdate_33_Quynh + "' where cid = " + id_33_Quynh + " update rooms set booked = 'NO' where roomNo = '" + txtRoomNo_33_Quynh.Text + "'";
                    fn_33_Quynh.setData_33_Quynh(query_33_Quynh, "Thanh Toán Thành Công");
                    UC_Checkout_Load(this, null);
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Không Có Khách Hàng Để Lựa Chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            txtName_33_Quynh.Clear();
            txtSearch_33_Quynh.Clear();
            txtRoomNo_33_Quynh.Clear() ;
            datetimepickerCheckOut_33_Quynh.ResetText();
        }

        private void UC_Checkout_33_Quynh_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
