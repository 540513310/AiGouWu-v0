using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace AiGouWu
{
    public partial class Login : System.Web.UI.Page
    {
        SqlComm sqlcom = new SqlComm();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (validateCode.Text.Trim().ToLower() != Request.Cookies["ValidateCookie"].Values["Chcode"].ToString().ToLower())
            {
                return;           
            }

            if (loginId.Text.Trim().Contains("@") && loginId.Text.Trim().Contains(".com"))
            {
                System.Data.DataTable dt = sqlcom.getDataByCondition("dbo.tbCustomer", "id,username", "email='" + loginId.Text.Trim().Replace("-", "").Replace("'", "") + "' AND Password='" + password.Text.Trim().Replace("-", "").Replace("'", "") + "'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    Session["Cid"] = dt.Rows[0][0].ToString();
                    Session["username"] = dt.Rows[0][1].ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "colse", "<script>close();</script>");

                }

            }
            else
            {
                System.Data.DataTable dt = sqlcom.getDataByCondition("dbo.tbCustomer", "id,username", "username='" + loginId.Text.Trim().Replace("-", "").Replace("'", "") + "' AND Password='" + password.Text.Trim().Replace("-", "").Replace("'", "") + "'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    Session["Cid"] = dt.Rows[0][0].ToString();
                    Session["username"] = dt.Rows[0][1].ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "colse", "<script>close();</script>");
                }
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void datalist_catlist_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }
    }
}