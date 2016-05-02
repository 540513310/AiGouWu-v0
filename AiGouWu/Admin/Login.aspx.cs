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
using BLL;
namespace AiGouWu
{
    public partial class login : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void loginsubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.Cookies["ValidateCookie"].Values["Chcode"].ToString().ToLower() == this.txtCode.Text.Trim().ToString().ToLower())
            {
                string username = txtUserName.Text.Trim();
                string pwd = txtUserPwd.Text.Trim();
                AdminBLLcs adminbll = new AdminBLLcs();
                int count = adminbll.adminLogin(username, pwd);
                if (count != 0)
                {
                    Session["Username"] = username;
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(FormsAuthentication.FormsCookieName, false);
                    //Response.Redirect("Default.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('请检查您的用户名或密码是否正确')", true);
                    // Response.Write("<script>alert('请检查您的用户名或密码是否正确')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('请重新输入验证码')", true);
            }
        }
    }
}
