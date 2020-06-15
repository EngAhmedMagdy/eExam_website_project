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
    public partial class Levels_departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source=A-MAGDYPC\AHMED;Initial Catalog=myDatabase;Integrated Security=true");

        protected void Button1_Click(object sender, EventArgs e)
        {

            int level = Convert.ToInt32(TextBox1.Text);
            string dep = TextBox2.Text;
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("addLevel", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("level_id", hfvalue.Value == "" ? 0 : Convert.ToInt32(hfvalue.Value));
            sqlcmd.Parameters.AddWithValue("level_number", level);
            sqlcmd.Parameters.AddWithValue("department",dep);
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        protected void view_click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt16((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("level_id", sqlcon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();
            hfvalue.Value = id.ToString();
            TextBox1.Text = dt.Rows[0]["level_number"].ToString();
            TextBox2.Text = dt.Rows[0]["department"].ToString();


            GridView1.DataBind();
     
            sqlcon.Close();
        }

    }
}