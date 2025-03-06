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
    public partial class BangDieuKhien_33_Quynh : Form
    {
        public BangDieuKhien_33_Quynh()
        {
            InitializeComponent();
        }
        private void btnExit_33_Quynh_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BangDieuKhien_33_Quynh_Load(object sender, EventArgs e)
        {
            uC_AddRoom_33_Quynh1.Visible=false;
            uC_CustomerRes_33_Quynh1.Visible = false;
            uC_Checkout_33_Quynh1.Visible=  false;
            uC_CustomerDetail_33_Quynh1.Visible = false;
            uC_Employee_33_Quynh1.Visible=false;
            btnAddRoom_33_Quynh.PerformClick();//tim hieu
        }

        private void btnAddRoom_33_Quynh_Click(object sender, EventArgs e)
        {
            pannelMoving_33_Quynh.Left = btnAddRoom_33_Quynh.Left + 82;
            uC_AddRoom_33_Quynh1.Visible = true;
            uC_AddRoom_33_Quynh1.BringToFront();//tim hieu
        }


        private void btnCustumerRes_33_Quynh_Click(object sender, EventArgs e)
        {
            pannelMoving_33_Quynh.Left = btnCustumerRes_33_Quynh.Left + 82;
            uC_CustomerRes_33_Quynh1.Visible = true;
            uC_CustomerRes_33_Quynh1.BringToFront();
        }

        private void btnCheckOut_33_Quynh_Click(object sender, EventArgs e)
        {
            pannelMoving_33_Quynh.Left = btnCheckOut_33_Quynh.Left + 82;
            uC_Checkout_33_Quynh1.Visible=true;
            uC_Checkout_33_Quynh1.BringToFront() ;
        }

        private void btnCustumerDetail_33_Quynh_Click(object sender, EventArgs e)
        {
            pannelMoving_33_Quynh.Left = btnCustumerDetail_33_Quynh.Left + 82;
            uC_CustomerDetail_33_Quynh1.Visible=true ;
            uC_CustomerDetail_33_Quynh1.BringToFront();
        }

        private void btnEmployee_33_Quynh_Click(object sender, EventArgs e)
        {
            pannelMoving_33_Quynh.Left = btnEmployee_33_Quynh.Left + 82;
            uC_Employee_33_Quynh1.Visible=true;
            uC_Employee_33_Quynh1.BringToFront();
        }
    }
}
