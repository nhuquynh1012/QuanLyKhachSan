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

    public partial class UC_Employee_33_Quynh : UserControl
    {
        funtion_33_Quynh fn_33_Quynh = new funtion_33_Quynh();
        String query_33_Quynh;

        public UC_Employee_33_Quynh()
        {
            InitializeComponent();
        }

        private void UC_Employee_33_Quynh_Load(object sender, EventArgs e)
        {
            getMaxID_33_Quynh();
        }

        /*-------------------------------------------------*/
        public void getMaxID_33_Quynh()
        {
            query_33_Quynh = "select max(eid) from employee";
            DataSet ds_33_Quynh = fn_33_Quynh.getData__33_Quynh(query_33_Quynh);

            if (ds_33_Quynh.Tables[0].Rows[0][0].ToString()!="")
            {
                Int64 num_33_Quynh = Int64.Parse(ds_33_Quynh.Tables[0].Rows[0][0].ToString());
                lbToSet_33_Quynh.Text = (num_33_Quynh+1).ToString();
            }
        }

        private void btnRegister_33_Quynh_Click(object sender, EventArgs e)
        {
            if (txtName_33_Quynh.Text!=""&& txtContact_33_Quynh.Text!=""&&comboboxGender_32_Quynh.Text!=""&&txtEmail_33_Quynh.Text!= ""&& txtUserName_33_Quynh.Text!=""&& txtPass_33_Quynh.Text != "")
            {
                String name_33_Quynh = txtName_33_Quynh.Text;
                Int64 mobile_33_Quynh = Int64.Parse(txtContact_33_Quynh.Text);
                String gender_33_Quynh = comboboxGender_32_Quynh.Text;
                String email_33_Quynh = txtEmail_33_Quynh.Text ;
                String userName_33_Quynh = txtUserName_33_Quynh.Text;
                String pass_33_Quynh = txtPass_33_Quynh.Text;

                query_33_Quynh = " insert into employee (ename ,mobile ,gender ,emailid ,username , pass) values (N'" + name_33_Quynh + "'," + mobile_33_Quynh + ",N'" + gender_33_Quynh + "',N'" + email_33_Quynh + "',N'" + userName_33_Quynh + "',N'" + pass_33_Quynh + "')";
                fn_33_Quynh.setData_33_Quynh(query_33_Quynh, "Đã Đăng Ký Nhân Viên Thành Công!!");

                clearAll_33_Quynh();
                getMaxID_33_Quynh();
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearAll_33_Quynh()
        {
            txtName_33_Quynh.Clear();
            txtContact_33_Quynh.Clear();
            comboboxGender_32_Quynh.SelectedIndex = -1;
            txtEmail_33_Quynh.Clear() ;
            txtUserName_33_Quynh.Clear() ;
            txtPass_33_Quynh.Clear() ;
        }

        private void tabEmployee_33_Quynh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEmployee_33_Quynh.SelectedIndex==1)
            {
                setEmployee_33_Quynh(datagridviewDetail_33_Quynh);
            }else if (tabEmployee_33_Quynh.SelectedIndex == 2)
            {
                setEmployee_33_Quynh(datagridviewDel_33_Quynh);
            }
        }

        public void setEmployee_33_Quynh(DataGridView drv_33_Quynh)
        {
            query_33_Quynh = "select * from employee";
            DataSet ds_33_Quynh = fn_33_Quynh.getData__33_Quynh(query_33_Quynh);
            drv_33_Quynh.DataSource = ds_33_Quynh.Tables[0];
        }

        private void btnDelID_33_Quynh_Click(object sender, EventArgs e)
        {
            if (txtDelID_33_Quynh.Text!="")
            {
                if(MessageBox.Show("Bạn Có Muốn Xóa Không","Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query_33_Quynh = "delete from employee where eid = " + txtDelID_33_Quynh.Text + "";
                    fn_33_Quynh.setData_33_Quynh(query_33_Quynh, "Thông Tin Nhân Viên Đã Xóa");
                    tabEmployee_33_Quynh_SelectedIndexChanged(this,null);
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UC_Employee_33_Quynh_Leave(object sender, EventArgs e)
        {
            clearAll_33_Quynh();
        }
    }
}
