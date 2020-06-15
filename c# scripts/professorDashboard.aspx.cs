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
    public partial class professorDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nme =(string) Session["name"];
            Label1.Text = nme;
        }

        protected void btnmcq_Click(object sender, EventArgs e)
        {
            Response.Redirect("addquestionpage");
        }

        protected void btntf_Click(object sender, EventArgs e)
        {
            Response.Redirect("addTrueorfalse");
        }

        protected void btncreateexam_Click(object sender, EventArgs e)
        {
            Response.Redirect("createexampage");
        }
    }
}