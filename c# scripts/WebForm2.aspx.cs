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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label13.Visible = false;
        }

        public string Mycon  = @"Data Source=HACONA-MATATA\SQLEXPRESS;Initial Catalog=e-exam1;Integrated Security=True";

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedItem.Text == "student")
            {
                if (Session["randum"].ToString() == TextBox8.Text)
                {

                    using (SqlConnection sqlcon = new SqlConnection(Mycon))
                    {
                        sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("useradd", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@fullname", TextBox1.Text);
                        sqlcmd.Parameters.AddWithValue("@Gender", RadioButtonList1.Text);
                        sqlcmd.Parameters.AddWithValue("@country", DropDownList1.Text);
                        sqlcmd.Parameters.AddWithValue("@phone", TextBox2.Text);
                        sqlcmd.Parameters.AddWithValue("@email", TextBox3.Text);
                        sqlcmd.Parameters.AddWithValue("@username", TextBox4.Text);
                        sqlcmd.Parameters.AddWithValue("@password", TextBox5.Text);
                        sqlcmd.Parameters.AddWithValue("@typeofuser", DropDownList2.Text);
                        sqlcmd.ExecuteNonQuery();
                        Label13.Text = "your account has been created";
                    }
                }
                else
                {
                    Response.Write("captcha image is incorrect");
                }
            }

            if (DropDownList2.SelectedItem.Text == "Proffessor")
            {
                if (Session["randum"].ToString() == TextBox8.Text)
                {

                    using (SqlConnection sqlcon = new SqlConnection(Mycon))
                    {
                        sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("useradd2", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@fullname", TextBox1.Text);
                        sqlcmd.Parameters.AddWithValue("@Gender", RadioButtonList1.Text);
                        sqlcmd.Parameters.AddWithValue("@country", DropDownList1.Text);
                        sqlcmd.Parameters.AddWithValue("@phone", TextBox2.Text);
                        sqlcmd.Parameters.AddWithValue("@email", TextBox3.Text);
                        sqlcmd.Parameters.AddWithValue("@username", TextBox4.Text);
                        sqlcmd.Parameters.AddWithValue("@password", TextBox5.Text);
                        sqlcmd.Parameters.AddWithValue("@typeofuser", DropDownList2.Text);
                        sqlcmd.ExecuteNonQuery();
                        Label13.Text = "your account has been created";
                        Label13.Visible = true;
                    }
                }
                else
                {
                    Response.Write("captcha image is incorrect");
                }
            }

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}