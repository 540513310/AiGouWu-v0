using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace AiGouWu.Control
{
    public partial class top : System.Web.UI.UserControl
    {
       public  static int sum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                this.lbUserName.Text = Session["username"].ToString();
                lbUser.Visible = true;
            }

            if (Session["Cid"] != null)
            {
                SqlComm sql = new SqlComm();
               System.Data.DataTable dt= sql.getDataByCondition("dbo.TbCat", "isnull(sum(num),0)", "Customerid=" + Session["Cid"].ToString() + " AND isOrders=0");
               if (dt != null && dt.Rows.Count > 0)
               {
                   sum = int.Parse(dt.Rows[0][0].ToString());
               }
               else
               {
                   sum = 0;
               }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("prolist.aspx?proname=" +Server.UrlEncode(this.searchInput.Text.Trim()));
        }

      
    }
}