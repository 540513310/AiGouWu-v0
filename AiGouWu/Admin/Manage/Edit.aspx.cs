using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
namespace AiGouWu.Admin.Manage
{
    public partial class edit : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowInfo();
            }

        }
        AdminBLLcs adminbll = new AdminBLLcs();
        tbAdmin admin = new tbAdmin();
        //页面加载
        private void ShowInfo()
        {
            if (Request.QueryString["ID"] != null)
            {
                string id = Request.QueryString["ID"].ToString();
                admin=  adminbll.GetModel(int.Parse(id));
               txtUserName.Text = admin.LoginName;
               if (bool.Parse(admin.isDel.ToString()))
               {
                   this.rblIsLock.SelectedValue = "True";
               }
               else
               {
                   this.rblIsLock.SelectedValue = "False";
               }
               if (admin.RoseID == 1)
               {
                   this.rblUserType.SelectedValue = "1";
               }
               else if (admin.RoseID == 2)
               {
                   this.rblUserType.SelectedValue = "2";
               }
               else
               {
                   this.rblUserType.SelectedValue = "3";
               }


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            admin.ID =int.Parse(Request.QueryString["ID"].ToString());
            admin.LoginName = txtUserName.Text;
            admin.Pwd = txtUserPwd.Text;
            admin.isDel = bool.Parse(rblIsLock.SelectedValue.ToString());
            admin.RoseID = int.Parse(rblUserType.SelectedValue.ToString());

            if (adminbll.Update(admin) != 0)
            {
                Response.Redirect("List.aspx");
            }
        }
    }
}
