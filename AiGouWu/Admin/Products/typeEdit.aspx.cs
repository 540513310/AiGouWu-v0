using System;
using System.Data;
using System.Web;
using BLL;
using Model;

namespace AiGouWu.Admin.Products
{
    public partial class Edit : System.Web.UI.Page
    {

        Model.Product.proType protype = new Model.Product.proType();
        TypeBLL typebll = new TypeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Length > 0)
                {
                    protype = typebll.proType_GetModel(int.Parse(Request.QueryString["id"].ToString()));
                    this.lblPid.Text = protype.ParentId.ToString();
                    this.txtTitle.Text = protype.typeName;
                    this.cbisdel.Checked = bool.Parse(protype.isLock.ToString());

                }
            }
           
        }

       

      
        protected void btnSave_Click(object sender, EventArgs e)
        {
            protype.id = int.Parse(Request.QueryString["id"].ToString());
            protype.isLock = this.cbisdel.Checked;
            protype.ParentId = int.Parse(lblPid.Text);
            protype.typeName = txtTitle.Text;
            if (typebll.type_Update(protype) != 0)
            {
                Response.Redirect("typeList.aspx");
            }
        }

    }
}
