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
    public partial class UC_CustomerDetail_33_Quynh : UserControl
    {
        funtion_33_Quynh fn_33_Quynh = new funtion_33_Quynh();
        String query_33_Quynh;
        public UC_CustomerDetail_33_Quynh()
        {
            InitializeComponent();
        }

        private void comboboxCustomerDetail_33_Quynh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxCustomerDetail_33_Quynh.SelectedIndex==0)
            {
                query_33_Quynh = "select customer.cid , customer.cname , customer.mobile , customer.nationality , customer.gender, customer.dob , customer.idproof, customer.address, customer.checkin, rooms.roomNo , rooms.roomType , rooms.bed , rooms.price from customer inner join rooms on customer.roomid = rooms.roomid";
                getRecord_33_Quynh(query_33_Quynh);
            }
            else if (comboboxCustomerDetail_33_Quynh.SelectedIndex == 1)
            {
                query_33_Quynh = "select customer.cid , customer.cname , customer.mobile , customer.nationality , customer.gender, customer.dob , customer.idproof, customer.address, customer.checkin, rooms.roomNo , rooms.roomType , rooms.bed , rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout is null";
                getRecord_33_Quynh (query_33_Quynh);
            }
            else if(comboboxCustomerDetail_33_Quynh.SelectedIndex==2) 
            {
                query_33_Quynh = "select customer.cid , customer.cname , customer.mobile , customer.nationality , customer.gender, customer.dob , customer.idproof, customer.address, customer.checkin, rooms.roomNo , rooms.roomType , rooms.bed , rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout is not null";
                getRecord_33_Quynh(query_33_Quynh);
            }
        }
        private void getRecord_33_Quynh(String query_33_Quynh)
        {
            DataSet ds_33_Quynh = fn_33_Quynh.getData__33_Quynh(query_33_Quynh);
            datagridviewCustomerDetail_33_Quynh.DataSource = ds_33_Quynh.Tables[0];
        }
    }
}
