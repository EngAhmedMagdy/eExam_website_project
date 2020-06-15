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
    public partial class accept_requests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string Mycon = @"Data Source=HACONA-MATATA\SQLEXPRESS;Initial Catalog=e-exam1;Integrated Security=True";
            

                using (SqlConnection sourcecon = new SqlConnection(Mycon))
                {
                    SqlCommand cmd = new SqlCommand("select* from Table_2 where username='" + TextBox1.Text + "'", sourcecon);
                    sourcecon.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        using (SqlConnection sourcecon2 = new SqlConnection(Mycon))

                        {
                            using (SqlBulkCopy bc = new SqlBulkCopy(Mycon))
                            {
                                bc.DestinationTableName = "Table_1";
                                sourcecon2.Open();
                                bc.WriteToServer(rdr);


                                Label6.Text = "done";
                                Label6.Visible = true;

                            }

                        }

                    }
                }


           



            }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

