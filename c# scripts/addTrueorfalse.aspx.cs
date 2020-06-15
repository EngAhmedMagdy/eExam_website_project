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
    public partial class addTrueorfalse : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=A-MAGDYPC\AHMED;Initial Catalog=myDatabase;Integrated Security=true");
        string nme = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnDelete.Enabled = false;
            }
            nme = (string)Session["name"];
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string str = tbquestion.Text;
            string correctstr = ddlcorrectanswer.SelectedValue;
            string category = ddcategory.SelectedValue;
            string sub = ddlsubject.SelectedValue;
            int chapt = Convert.ToInt32(tbchapter.Text);
                
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("addTrueQuestion", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", hf.Value==""?0:Convert.ToInt32(hf.Value));
            sqlcmd.Parameters.AddWithValue("@question", str);
            sqlcmd.Parameters.AddWithValue("@correctAns",correctstr);
            sqlcmd.Parameters.AddWithValue("@category", category);
            sqlcmd.Parameters.AddWithValue("@chapter", chapt);
            sqlcmd.Parameters.AddWithValue("@subject", sub);
            sqlcmd.Parameters.AddWithValue("@profname", nme);
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            GridView1.DataBind();

        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            GridView1.Visible = GridView1.Visible ? false : true;
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            hf.Value = "";
            tbquestion.Text = tbchapter.Text = "";
            ddlcorrectanswer.SelectedIndex = 0;
            ddcategory.SelectedIndex = 0;
            btnadd.Text = "Add";
            btnDelete.Enabled = false;
        }

        protected void view_click(object sender, EventArgs e)
        {
            btnclear_Click(sender, e);
            int id = Convert.ToInt16((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("trueFalseId", sqlcon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();
            hf.Value = id.ToString();
            tbquestion.Text = dt.Rows[0]["question"].ToString();
            ddlcorrectanswer.SelectedValue = dt.Rows[0]["correctAns"].ToString();
            ddcategory.SelectedValue = dt.Rows[0]["category"].ToString();
            tbchapter.Text = dt.Rows[0]["chapter"].ToString();
            ddlsubject.SelectedValue = dt.Rows[0]["subject"].ToString();
            btnadd.Text = "Update";
            GridView1.DataBind();
            btnDelete.Enabled = true;

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("deleteQuestion2", sqlcon);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("@id", hf.Value);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                sqlcon.Close();
                btnclear_Click(sender, e);
                GridView1.DataBind();

            
        }
    }
}