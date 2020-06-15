using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication4
{
    public partial class Registration1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Mycon = @"Data Source=HACONA-MATATA\SQLEXPRESS;Initial Catalog=e-exam1;Integrated Security=True";
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "Student")
            {
                using (SqlConnection sqlcon = new SqlConnection(Mycon))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand("useradd", sqlcon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@fullname", TextBox2.Text);
                    sqlcmd.Parameters.AddWithValue("@Gender", DropDownList2.Text);
                    sqlcmd.Parameters.AddWithValue("@country", "Egypt");
                    sqlcmd.Parameters.AddWithValue("@phone", TextBox4.Text);
                    sqlcmd.Parameters.AddWithValue("@email", TextBox1.Text);
                    sqlcmd.Parameters.AddWithValue("@username", TextBox5.Text);
                    sqlcmd.Parameters.AddWithValue("@password", TextBox3.Text);
                    sqlcmd.Parameters.AddWithValue("@typeofuser", DropDownList1.Text);
                    sqlcmd.ExecuteNonQuery();    
                }
            }
           else if (DropDownList1.SelectedItem.Text == "Proffessor")
            {
                using (SqlConnection sqlcon = new SqlConnection(Mycon))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand("useradd2", sqlcon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@fullname", TextBox2.Text);
                    sqlcmd.Parameters.AddWithValue("@Gender", DropDownList2.Text);
                    sqlcmd.Parameters.AddWithValue("@phone", TextBox4.Text);
                    sqlcmd.Parameters.AddWithValue("@country", "Egypt");
                    sqlcmd.Parameters.AddWithValue("@email", TextBox1.Text);
                    sqlcmd.Parameters.AddWithValue("@username", TextBox5.Text);
                    sqlcmd.Parameters.AddWithValue("@password", TextBox3.Text);
                    sqlcmd.Parameters.AddWithValue("@typeofuser", DropDownList1.Text);
                    sqlcmd.ExecuteNonQuery();
                }
            }
    }
    }
}