using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
namespace AiGouWu.Admin.Article
{
    public partial class TypeAdd : System.Web.UI.Page
    {
        SqlComm sqlcomm = new SqlComm();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            string typeName = Request.QueryString["typename"];
            if (typeName != null)
            {
                int count = sqlcomm.InsertTable("tbNewsType", "TypeName", "'" + typeName + "'");
                if (count != 0)
                {
                    Response.Write("true");
                }
                else
                {
                    Response.Write("false");
                }

            }
            else
            {
                Response.Write("false");
            }
         


        }

     

     
    }
}