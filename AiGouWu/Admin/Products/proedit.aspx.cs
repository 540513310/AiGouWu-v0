using System;
using System.Data;
using System.Web;
using BLL;
using Model.Product;
namespace AiGouWu.Admin.Products
{
    public partial class proedit: System.Web.UI.Page
    {
        proCatalog cat = new proCatalog();
        SqlComm com = new SqlComm();
        ProBLL pbll = new ProBLL();
        proCatalogBLL catbll = new proCatalogBLL();
        static tbProduct p = new tbProduct();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                typelistbang();
                cataloglist();
                PingPaiBind();
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    string id = Request.QueryString["id"].ToString();
                    p=pbll.GetModel(int.Parse(id));

                    this.Product_Name.Text = p.product_name;
                    this.Retail_Price.Text= p.retail_price.ToString();
                    this.Cost_price.Text = p.cost_price.ToString();
                    this.units.Text = p.units;
                    this.Wholesale_price.Text = p.wholesale_price.ToString();
                    this.Weight.Text = p.weight;
                    this.Material.Text = p.material;
                    this.UpperLimit.Text = p.upperLimit.ToString();//库存
                    this.LowerLimit.Text = p.lowerLimit.ToString();
                    this.Spec.Text = p.spec.ToString();
                    this.code.Text = p.code.ToString();
                    this.Expiry_date.Text = p.expiry_date.ToString();
                    this.ddlCatalog.SelectedValue = p.Catalogid.ToString();
                    this.ddlType.SelectedValue = p.type_id.ToString();
                    this.ddlPingPai.SelectedValue = p.PingPaiId.ToString();
                    this.FCKeditor1.Value = p.description;
                    this.txtdiscount.Text = p.Discount.ToString();
                }


            }

           
        }
        /// <summary>
        /// 绑定品牌
        /// </summary>
        private void PingPaiBind()
        {
            this.ddlPingPai.DataSource = com.getDataByCondition("tbPingPai", "ID,PingPai", null);
            this.ddlPingPai.DataTextField = "PingPai";
            this.ddlPingPai.DataValueField = "ID";
            this.ddlPingPai.DataBind();
        }
        /// <summary>
        /// 绑定类别
        /// </summary>
        private void typelistbang()
        {
            this.ddlType.DataSource = com.getDataByCondition("proType", "id,typeName", "  isLock=0");
            this.ddlType.DataTextField = "typeName";
            this.ddlType.DataValueField = "id";
            this.ddlType.DataBind();
        }
        static string s_fileName = "";
        static string path1 = "";
        protected void btnSave_Click(object sender, EventArgs e)
        {          
                p.code = code.Text;
                p.cost_price = decimal.Parse(Cost_price.Text);
                p.description = FCKeditor1.Value.ToString();
                p.expiry_date = DateTime.Parse(Expiry_date.Text.ToString());
                p.lowerLimit = int.Parse(LowerLimit.Text);
                p.material = Material.Text;
                p.PingPaiId = int.Parse(ddlPingPai.SelectedValue.ToString());
                p.product_name = Product_Name.Text;
                p.retail_price = this.Retail_Price.Text == "0" ? decimal.Parse((double.Parse(Retail_Price.Text) * 1.2).ToString()) : decimal.Parse(Retail_Price.Text);
                p.smallimg = s_fileName;
                p.spec = Spec.Text;
                p.type_id = int.Parse(ddlType.SelectedValue.ToString());
                p.units = units.Text;
                p.upperLimit = int.Parse(UpperLimit.Text);
                p.weight = Weight.Text;
                p.wholesale_price = this.Wholesale_price.Text == "0" ?decimal.Parse((double.Parse(Wholesale_price.Text) * 1.1).ToString()): decimal.Parse(Wholesale_price.Text);
                p.Catalogid = int.Parse(ddlCatalog.SelectedValue.ToString());
                p.product_id =int.Parse(Request.QueryString["id"].ToString());
                p.Discount = decimal.Parse(txtdiscount.Text.Trim());
                pbll.Update(p);
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cataloglist();

        }

        private void cataloglist()
        {
            string typeid = this.ddlType.SelectedValue.ToString();
            DataTable dt = com.getDataByCondition("dbo.proCatalog", "id,catalogname", " isLock=0 and typid=" + typeid);

            this.ddlCatalog.DataSource = dt;
            this.ddlCatalog.DataTextField = "catalogname";
            this.ddlCatalog.DataValueField = "id";
            this.ddlCatalog.DataBind();

            this.ddlCatalog.Items.Add(new System.Web.UI.WebControls.ListItem("无类型", "0"));

        }

        protected void btnUpLoad_Click(object sender, EventArgs e)
        {
            uploadImg();



        }
        /// <summary>
        /// 上传原始图片并返回路径
        /// </summary>
        /// <returns></returns>
        private void uploadImg()
        {
            string filename = this.FileUpload1.FileName;
            string targetpath = Server.MapPath("../../ProImg/");
            string filepath = targetpath + this.FileUpload1.FileName;
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            FileUpload1.SaveAs(Server.MapPath("../../ProImg/") + this.FileUpload1.FileName);
            path1 = filepath;


            string path2 = Server.MapPath("../../ProImg/");
            s_fileName = "s_" + this.FileUpload1.FileName;
            MyComm.MakeThumbnail(path1, path2 + s_fileName, 100, 100, "Hw");

        }
    }
}
