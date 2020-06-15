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
    public partial class Specifysubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
       protected void Button1_Click(object sender, EventArgs e)
        {
           /* string Mycon3 = @"Data Source=HACONA-MATATA\SQLEXPRESS;Initial Catalog=e-exam1;Integrated Security=True";
            using (SqlConnection sourcecon4 = new SqlConnection(Mycon3))

            {
                sourcecon4.Open();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.CommandText = "update Table_1 set subject='" + TextBox2.Text + "'where username='" + TextBox1.Text + "' ";
                cmd3.Connection = sourcecon4;
                cmd3.ExecuteNonQuery();
                GridView1.DataBind();
            }*/
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}