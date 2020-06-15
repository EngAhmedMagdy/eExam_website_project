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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminNavigation");

           /* SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con.ConnectionString = Mycon;
            con.Open();
            cmd.CommandText = "select* from Table_1 where email='" + TextBox2.Text + "'and password='" + TextBox1.Text + "'and typeofuser='" + "admin" + "'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "Table_1");
            if (ds.Tables[0].Rows.Count > 0)
            {
                           
            }
            else
            {
                Label1.Visible = true;
            }*/
        }
    }
}