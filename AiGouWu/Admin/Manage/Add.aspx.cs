using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
namespace AiGouWu.Admin.Manage
{
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
            }
        }
        AdminBLLcs adminbll = new AdminBLLcs();
        tbAdmin admin = new tbAdmin();
        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            admin.LoginName = txtUserName.Text;
            admin.Pwd = txtUserPwd.Text;
            admin.isDel = bool.Parse(rblIsLock.SelectedValue.ToString());
            admin.RoseID = int.Parse(rblUserType.SelectedValue.ToString());

            if (adminbll.Add(admin) != 0)
            {
                Response.Redirect("List.aspx");
            }
        }
    }
}
