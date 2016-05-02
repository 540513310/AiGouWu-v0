using System;
using System.Data;
using System.Web;
using BLL;
using Model.Product;
namespace AiGouWu.Admin.Products
{
    public partial class CatalogtypeEdit : System.Web.UI.Page
    {

        SqlComm comm = new SqlComm();
        proCatalogBLL cbll = new proCatalogBLL();
        proCatalog cate = new proCatalog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    ddltype.DataSource = comm.getDataByCondition("proType", "id,typename", "1=1");
                    ddltype.DataTextField = "typename";
                    ddltype.DataValueField = "id";
                    ddltype.DataBind();

                    string id = Request.QueryString["ID"].ToString();
                    cate = cbll.getModelbyid(id);
                    if (cate != null)
                    {
                        this.txtTitle.Text = cate.catalogname;
                        this.txtNo.Text = cate.catalogid;
                        this.ddltype.SelectedValue = cate.typid.ToString();
                        this.cblItem.Items[0].Selected = bool.Parse(cate.isShow.ToString());
                        this.cblItem.Items[1].Selected = bool.Parse(cate.isLock.ToString());
                        this.lblPid.Text = cate.Parentid.ToString();

                        if (Request.QueryString["pname"] != null)
                        {
                            if (cate.Parentid != 0)
                            {
                                this.lblPname.Text = Request.QueryString["pname"].ToString();

                            }
                            else
                            {
                                this.lblPname.Text = "顶级类型";
                            }
                        }

                    }
                }
            }
           
        }

       

      
        protected void btnSave_Click(object sender, EventArgs e)
        {
            cate.id = int.Parse(Request.QueryString["ID"].ToString());
            cate.catalogname = txtTitle.Text;
            cate.catalogid = txtNo.Text;
            cate.isShow = this.cblItem.Items[0].Selected;
            cate.isLock = this.cblItem.Items[1].Selected;
            cate.typid = int.Parse(ddltype.SelectedValue.ToString());
            cate.Parentid = int.Parse(lblPid.Text);
            if (cbll.Update(cate) != 0)
            {
                Response.Redirect("CatalogtypeList.aspx");
            }
        }

    }
}
