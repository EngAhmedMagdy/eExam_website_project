using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class addquestionpage : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=A-MAGDYPC\AHMED;Initial Catalog=myDatabase;Integrated Security=true");
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnDelete.Enabled = false;
               

            }
            
            str = (string)Session["name"];
            


        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("addQustion", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@questionId", hfvalue.Value == "" ? 0 : Convert.ToInt32(hfvalue.Value));
                sqlcmd.Parameters.AddWithValue("@question", tbq.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@firstChoice", tbfc.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@secondChoice", tbsc.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@thirdChoice", tbtc.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@fourthChoice", tbfoc.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@correctAns", ddlcorrectanswer.SelectedValue);
                sqlcmd.Parameters.AddWithValue("@category", ddlcategory.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@chapter", tbchapter.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@subject", ddlsubject.SelectedValue);
                sqlcmd.Parameters.AddWithValue("@profname", str);
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                GridView1.DataBind();
                
            }
        }

        protected void choice(object sender, EventArgs e)
        {
            if (tbfc.Text != "" && tbsc.Text != ""  && tbfoc.Text != "" && tbtc.Text != "")
            {
                ddlcorrectanswer.Items.Clear();
                ddlcorrectanswer.Items.Add(tbfc.Text);
                ddlcorrectanswer.Items.Add(tbsc.Text);
                ddlcorrectanswer.Items.Add(tbtc.Text);
                ddlcorrectanswer.Items.Add(tbfoc.Text);
            }
        }
        protected void view_click(object sender, EventArgs e)
        {
            btnClear_Click(sender, e);
            int id = Convert.ToInt16((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("mcqId", sqlcon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();
            hfvalue.Value = id.ToString();
            tbq.Text = dt.Rows[0]["question"].ToString();
            tbfc.Text = dt.Rows[0]["firstChoice"].ToString();
            tbsc.Text = dt.Rows[0]["secondChoice"].ToString();
            tbtc.Text = dt.Rows[0]["thirdChoice"].ToString();
            tbfoc.Text = dt.Rows[0]["fourthChoice"].ToString();
            ddlcorrectanswer.SelectedValue = dt.Rows[0]["correctAns"].ToString();
            ddlcategory.SelectedValue = dt.Rows[0]["category"].ToString();
            tbchapter.Text = dt.Rows[0]["chapter"].ToString();
            ddlsubject.SelectedValue = dt.Rows[0]["subject"].ToString();
            choice(sender, e);
            btnadd.Text = "Update";
            GridView1.DataBind();
            btnDelete.Enabled = true;
            sqlcon.Close();
        }
        protected void btnShowData_click(object sender, EventArgs e)
        {
            GridView1.Visible = GridView1.Visible ? false : true;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            hfvalue.Value = "";
            tbq.Text = tbfc.Text = tbsc.Text = tbtc.Text = tbfoc.Text = tbchapter.Text = "";
            ddlcorrectanswer.Items.Clear();
            ddlcategory.SelectedIndex = 0;
            btnadd.Text = "Add";
            btnDelete.Enabled = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("deleteQuestion", sqlcon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@id", hfvalue.Value);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();
            btnClear_Click(sender, e);
            GridView1.DataBind();
            sqlcon.Close();
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "Category")
            {
                args.IsValid = false;
            }
            else args.IsValid = true;
        }


    }
}