using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _33_Quynh_QuanLyKhachSan
{
    public partial class Login_33_Quynh : Form
    {
        funtion_33_Quynh fn_33_Quynh = new funtion_33_Quynh();
        String query_33_Quynh;
        public Login_33_Quynh()
        {
            InitializeComponent();
        }

        private void btnExit_33_Quynh_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_33_Quynh_Click(object sender, EventArgs e)
        {
            query_33_Quynh = " select username,pass from employee where username = '" + txtUserName_33_Quynh.Text 
            + "' and pass = '" + txtPass_33_Quynh.Text + "'";
            DataSet ds_33_Quynh = fn_33_Quynh.getData__33_Quynh(query_33_Quynh);
            if (ds_33_Quynh.Tables[0].Rows.Count != 0)
            {
                lbError_33_Quynh.Visible = false;
                BangDieuKhien_33_Quynh bdk_33_Quynh = new BangDieuKhien_33_Quynh();
                this.Hide();
                bdk_33_Quynh.Show();
            }
            else
            {
                lbError_33_Quynh.Visible = true;
                txtPass_33_Quynh.Text = txtPass_33_Quynh.Text = "";
            }
        }
    }
}
