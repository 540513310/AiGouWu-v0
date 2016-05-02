using System;
using System.Data;
using System.Web;
using BLL;
using Model.Product;
namespace AiGouWu.Admin.Products
{
    public partial class ProductAdd: System.Web.UI.Page
    {
        proCatalog cat = new proCatalog();
        SqlComm com = new SqlComm();
        ProBLL pbll = new ProBLL();
        proCatalogBLL catbll = new proCatalogBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                typelistbang();
                cataloglist();

                PingPaiBind();

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
            tbProduct p = new tbProduct()
            {
                code = code.Text,
                cost_price = decimal.Parse(Cost_price.Text),
                description = FCKeditor1.Value.ToString(),
                expiry_date = DateTime.Parse(Expiry_date.Text.ToString()),
                lowerLimit = int.Parse(LowerLimit.Text),
                material = Material.Text,
                PingPaiId = int.Parse(ddlPingPai.SelectedValue.ToString()),
                product_name = Product_Name.Text,
                retail_price = this.Retail_Price.Text == "0" ? decimal.Parse((double.Parse(Retail_Price.Text) * 1.2).ToString()) : decimal.Parse(Retail_Price.Text),
                smallimg = s_fileName,
                spec = Spec.Text,
                type_id = int.Parse(ddlType.SelectedValue.ToString()),
                units = units.Text,
                upperLimit = int.Parse(UpperLimit.Text),
                weight = Weight.Text,
                wholesale_price = this.Wholesale_price.Text == "0" ?decimal.Parse((double.Parse(Wholesale_price.Text) * 1.1).ToString()): decimal.Parse(Wholesale_price.Text),
                Catalogid=int.Parse(ddlCatalog.SelectedValue.ToString()),
                Discount=decimal.Parse(txtdiscount.Text.Trim())
            };
            pbll.Add(p);
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
