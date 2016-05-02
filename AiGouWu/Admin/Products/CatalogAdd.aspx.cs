using System;
using System.Data;
using System.Web;
using BLL;
using Model.Product;
namespace AiGouWu.Admin.Products
{
    public partial class CatalogAdd : System.Web.UI.Page
    {
        proCatalog cat = new proCatalog();
        SqlComm com = new SqlComm();
        proCatalogBLL catbll = new proCatalogBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null && Request.QueryString["pname"]!=null)
                {
                    string id = Request.QueryString["ID"].ToString();
                    lblPid.Text = id.ToString();
                    lblPname.Text = Request.QueryString["pname"].ToString();
                }
                ddltype.DataSource = com.getDataByCondition("proType", "id,typename", "1=1");
                ddltype.DataTextField = "typename";
                ddltype.DataValueField = "id";
                ddltype.DataBind();
            }

           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            cat.catalogname = txtTitle.Text;
            cat.catalogid = txtNo.Text;
            cat.isShow = this.cblItem.Items[0].Selected;
            cat.isLock = this.cblItem.Items[1].Selected;
            cat.typid = int.Parse(ddltype.SelectedValue.ToString());
            cat.Parentid = int.Parse(lblPid.Text);

            if (catbll.Add(cat) != 0)
            {
                Response.Redirect("CatalogtypeList.aspx");
            }
        }
    }
}
