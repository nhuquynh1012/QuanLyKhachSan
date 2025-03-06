using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _33_Quynh_QuanLyKhachSan.All_Control_User
{
    public partial class UC_CustomerRes_33_Quynh : UserControl
    {
        funtion_33_Quynh fn_33_Quynh = new funtion_33_Quynh();
        String quetry_33_Quynh;

        public UC_CustomerRes_33_Quynh()
        {
            InitializeComponent();
        }

        public void setCombobox_33_Quynh(String quetry_33_Quynh ,ComboBox combo_33_Quynh) 
        {
            SqlDataReader sdr_33_Quynh = fn_33_Quynh.getForCombo_33_Quynh(quetry_33_Quynh);
            while (sdr_33_Quynh.Read())
            {
                for(int i = 0; i < sdr_33_Quynh.FieldCount; i++)
                {
                    combo_33_Quynh.Items.Add(sdr_33_Quynh.GetString(i));
                }
            }
            sdr_33_Quynh.Close();
        }

        private void comboboxBed_33_Quynh_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxRoomType_33_Quynh.SelectedIndex = -1;
            comboboxRoomNo_33_Quynh.Items.Clear();
            txtPrice_33_Quynh.Clear();
        }

        private void comboboxRoomType_33_Quynh_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxRoomNo_33_Quynh.Items.Clear();
            quetry_33_Quynh = "select roomNo from rooms where bed = '" + comboboxBed_33_Quynh.Text + "' and roomType = '" + comboboxRoomType_33_Quynh.Text + "' and booked = 'NO'";
            setCombobox_33_Quynh(quetry_33_Quynh, comboboxRoomNo_33_Quynh);
        }

        int rid_33_Quynh;// biến toàn cục
        private void comboboxRoomNo_33_Quynh_SelectedIndexChanged(object sender, EventArgs e)
        {
            quetry_33_Quynh = "select price , roomid from rooms where roomNo = '" + comboboxRoomNo_33_Quynh.Text + "'";
            DataSet ds_33_Quynh = fn_33_Quynh.getData__33_Quynh(quetry_33_Quynh);
            txtPrice_33_Quynh.Text= ds_33_Quynh.Tables[0].Rows[0][0].ToString();
            rid_33_Quynh = int.Parse(ds_33_Quynh.Tables[0].Rows[0][1].ToString());
        }

        private void btnAllotCustomer_33_Quynh_Click(object sender, EventArgs e)
        {
            if (txtName_33_Quynh.Text != "" && txtContact_33_Quynh.Text != "" && txtNationnality_33_Quynh.Text != "" && comboboxGender_33_Quynh.Text != "" && DateTimePickerDate_33_Quynh.Text != "" && txtID_33_Quynh.Text != "" && txtAddress_33_Quynh.Text != "" && DateTimePickerCheckIn_33_Quynh.Text != "" && txtPrice_33_Quynh.Text != "")
            {
                String name_33_Quynh = txtName_33_Quynh.Text;
                Int64 moblie_33_Quynh = Int64.Parse(txtContact_33_Quynh.Text);
                String nationnal_33_Quynh = txtNationnality_33_Quynh.Text;
                String gender_33_Quynh = comboboxGender_33_Quynh.Text;
                String dob_33_Quynh = DateTimePickerDate_33_Quynh.Text;
                String id_33_Quynh = txtID_33_Quynh.Text;
                String address_33_Quynh= txtAddress_33_Quynh.Text;
                String price_33_Quynh = txtPrice_33_Quynh.Text;

                quetry_33_Quynh = "insert into customer (cname, mobile, nationality, gender, dob, idproof, address, checkin, roomid) values (N'" + name_33_Quynh + "'," + moblie_33_Quynh + ",N'" + nationnal_33_Quynh + "',N'" + gender_33_Quynh + "',N'" + dob_33_Quynh+ "',N'" + id_33_Quynh + "',N'" + address_33_Quynh + "',N'" + price_33_Quynh + "'," + rid_33_Quynh + ")update rooms set booked = 'YES' where roomNo = '" + comboboxRoomNo_33_Quynh.Text + "'";
                fn_33_Quynh.setData_33_Quynh(quetry_33_Quynh,"Số Phòng : "+comboboxRoomNo_33_Quynh.Text+" Đã Đăng Ký Khách Hàng Thành Công ");
                clearAll();

            }
            else
            {
                MessageBox.Show("Xin Vui Lòng Nhập Đày Đủ Thông Tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            txtName_33_Quynh.Clear();
            txtContact_33_Quynh.Clear();
            comboboxGender_33_Quynh.SelectedIndex = -1;
            DateTimePickerDate_33_Quynh.ResetText();
            DateTimePickerCheckIn_33_Quynh.ResetText();
            txtID_33_Quynh.Clear();
            txtAddress_33_Quynh.Clear();
            txtNationnality_33_Quynh.Clear();
            txtPrice_33_Quynh.Clear();
            comboboxRoomNo_33_Quynh.Items.Clear();
            comboboxBed_33_Quynh.SelectedIndex = -1;
            comboboxRoomType_33_Quynh.SelectedIndex = -1;

        }

        private void UC_CustomerRes_33_Quynh_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
