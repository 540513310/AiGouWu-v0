using System;
using System.Data;
using System.Web;
using Model.Product;
using BLL;

namespace AiGouWu.Admin.Products
{
    public partial class Add : System.Web.UI.Page
    {
        TypeBLL tbll = new TypeBLL();
        proType type = new proType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["pid"] != null && Request.QueryString["pid"].ToString().Length>0)
            {
                this.lblPid.Text = Request.QueryString["pid"].ToString();
            }
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            type.isLock = false;
            type.ParentId = int.Parse(lblPid.Text);
            type.typeName = txtTitle.Text;

            if (tbll.type_Add(type) > 0)
            {
                Response.Redirect("typeList.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('提交失败')", true);

            }
        }
    }
}
