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

    public partial class createexampage : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=A-MAGDYPC\AHMED;Initial Catalog=myDatabase;Integrated Security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {


                btncreateexam.Enabled = false;
                btnaddquestionexam.Enabled = false;
            }
            string str = "";
            str =(string) Session["name"];
            Label1.Text = str;
            
        }
        protected void clear()
        {
            
            ddlcategoryexam.SelectedIndex = 0;
            ddltypeexam.SelectedIndex = 0;
            tbchapterexam.Text = "";
            ddlquestionexam.Items.Clear();
           
        }
    

        

        protected void rest_Click(object sender, EventArgs e)
        {
            string nme =(string) Session["name"];
            int i = Convert.ToInt32(tbquestionsexam.Text);
            string sub = ddlsubjects.SelectedValue;
            int time = Convert.ToInt32(tballowedtime.Text);
            
            if (i > 0)
            {
               
                clear();
                int initial = 1;
                while (initial <= i)
                {
                    ddlquestionexam.Items.Add(initial.ToString());
                    initial++;
                }
                btnaddquestionexam.Enabled = true;
            }
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("addExamHeader", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("maxNumber",i);
            sqlcmd.Parameters.AddWithValue("subject ", sub);
            sqlcmd.Parameters.AddWithValue("time", time);
            sqlcmd.Parameters.AddWithValue("professorName",nme);
            sqlcmd.ExecuteNonQuery();
            
            //used to get last id
            SqlDataAdapter sqlda = new SqlDataAdapter("getExamId", sqlcon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            hfid.Value = dt.Rows[0][0].ToString();
            sqlcon.Close();


        }
        protected void btnaddquestionexam_Click(object sender, EventArgs e)
        {

            int ddlq = Convert.ToInt32(ddlquestionexam.SelectedValue);
            string type = ddltypeexam.SelectedValue;
            string categ = ddlcategoryexam.SelectedValue;
            int chapt = Convert.ToInt32(tbchapterexam.Text);
            int i = ddlquestionexam.Items.Count;
            int j = Convert.ToInt32(ddlquestionexam.SelectedValue);
            i -= j;
            int initial = 1;
            clear();
            while (initial <= i)
            {
                ddlquestionexam.Items.Add(initial.ToString());
                initial++;
            }
            if (ddlquestionexam.SelectedItem == null)
            {

                btnaddquestionexam.Enabled = false;
                btncreateexam.Enabled = true;
            }

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("addExamPaper", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("examId", hfid.Value);
            sqlcmd.Parameters.AddWithValue("numQuestion", ddlq);
            sqlcmd.Parameters.AddWithValue("type", type);
            sqlcmd.Parameters.AddWithValue("category", categ);
            sqlcmd.Parameters.AddWithValue("chapter", chapt);
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        protected void btncreateexam_Click(object sender, EventArgs e)
        {
            clear();
            tbquestionsexam.Text = "";
            btncreateexam.Enabled = false;
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {

        }
    }
}