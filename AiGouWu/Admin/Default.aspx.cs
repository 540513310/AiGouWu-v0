using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace Shannon.Web.Admin
{
    public partial class Default :System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
               this.lblAdminName.Text= Session["Username"].ToString();
            }
           
        }

        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            
        }
    }
}
