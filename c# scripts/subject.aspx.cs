using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class subject : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source=A-MAGDYPC\AHMED;Initial Catalog=myDatabase;Integrated Security=true");
        protected void Button1_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            SqlCommand sqlCommand = new SqlCommand("addSubjct", sqlcon);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("subject_id", hfvalue.Value == "" ? 0 : Convert.ToInt32(hfvalue.Value));
            sqlCommand.Parameters.AddWithValue("subject_name",TextBox1.Text);
            sqlCommand.Parameters.AddWithValue("level_number",DropDownList2.SelectedValue);
            sqlCommand.Parameters.AddWithValue("department", DropDownList1.SelectedValue);
            sqlCommand.ExecuteNonQuery();
            sqlcon.Close();
            GridView1.DataBind();
        }

        protected void view_click(object sender, EventArgs e)
        {

            int id = Convert.ToInt16((sender as LinkButton).CommandArgument);
           
                sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("subject_id", sqlcon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();
            hfvalue.Value = id.ToString();
            DropDownList2.SelectedValue = dt.Rows[0]["level_number"].ToString();
            DropDownList1.SelectedValue = dt.Rows[0]["department"].ToString();
            TextBox1.Text = dt.Rows[0]["subject_name"].ToString();
            


            GridView1.DataBind();

            sqlcon.Close();
        }
    }
}