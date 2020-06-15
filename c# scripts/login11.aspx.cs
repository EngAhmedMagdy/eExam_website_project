using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication4
{
    public partial class login11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         
        [WebMethod]
        public static string event1 ( )
        {
            
            return ("hello");
        }
        public string Mycon = @"Data Source=HACONA-MATATA\SQLEXPRESS;Initial Catalog=e-exam1;Integrated Security=True";

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}