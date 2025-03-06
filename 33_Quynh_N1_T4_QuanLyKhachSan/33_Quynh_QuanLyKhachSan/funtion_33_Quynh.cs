using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace _33_Quynh_QuanLyKhachSan
{
    internal class funtion_33_Quynh
    {
        protected SqlConnection getConnection_33_Quynh()
        {
            SqlConnection con_33_Quynh = new SqlConnection();
            con_33_Quynh.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Acer\\Documents\\dbMyHotel.mdf;Integrated Security=True;Connect Timeout=30";
            return con_33_Quynh;
        }
        public DataSet getData__33_Quynh(String query)//lấy dữ liệu 
        {
            SqlConnection con_33_Quynh = getConnection_33_Quynh();
            SqlCommand cmd_33_Quynh = new SqlCommand();
            cmd_33_Quynh.Connection = con_33_Quynh;
            cmd_33_Quynh.CommandText = query;
            SqlDataAdapter da_33_Quynh= new SqlDataAdapter(cmd_33_Quynh);
            DataSet ds_33_Quynh = new DataSet();
            da_33_Quynh.Fill(ds_33_Quynh);
            return ds_33_Quynh;
        }
        public void setData_33_Quynh(String query ,String message)//cập nhật dữ liệu 
        {
            SqlConnection con_33_Quynh = getConnection_33_Quynh();
            SqlCommand cmd_33_Quynh = new SqlCommand();
            cmd_33_Quynh.Connection = con_33_Quynh;
            con_33_Quynh.Open();
            cmd_33_Quynh.CommandText = query;
            cmd_33_Quynh.ExecuteNonQuery();
            con_33_Quynh.Close();

            MessageBox.Show(message,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public SqlDataReader getForCombo_33_Quynh(String query)
        {
            SqlConnection con_33_Quynh = getConnection_33_Quynh();    
            SqlCommand cmd_33_Quynh = new SqlCommand();
            cmd_33_Quynh.Connection = con_33_Quynh;
            con_33_Quynh.Open();
            cmd_33_Quynh = new SqlCommand(query,con_33_Quynh);
            SqlDataReader sdr_33_Quynh = cmd_33_Quynh.ExecuteReader();
            return sdr_33_Quynh;
        }
    }
}
