using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model.Product;
namespace AiGouWu.Admin.Products
{
    public partial class proimgslist: System.Web.UI.Page
    {
        static tbProduct p = new tbProduct();
        static tbProimgs pimg = new tbProimgs();
        ProBLL pbll = new ProBLL();
        SqlComm comm = new SqlComm();
        static  string newfilename="";
        static int proid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    proid =int.Parse( Request.QueryString["id"].ToString());
                    p= pbll.GetModel(proid);
                    this.lbProname.Text = p.product_name;
                    Proimglist();
                }

            }
        }
        static string condition = "";
        static int pagesize = 5;
        static int pageindex = 0;
        static int recordcount;
        private void Proimglist()
        {
            condition = " and proid=" + proid;
            this.rptClassList.DataSource = comm.getdatabyPageIndex("dbo.View_ProImgs", "*", condition, pagesize,pageindex, "imgID",out recordcount,null,null);
            this.rptClassList.DataBind();
            this.AspNetPager1.RecordCount = recordcount;
            this.AspNetPager1.PageSize = pagesize;
        }
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "lbEdit")
            {
                string id = e.CommandArgument.ToString();
                proid = int.Parse(id);
                pimg=  pbll.proImgsGetModel(id);
                this.lbProname.Text = pimg.Product_name;
                this.proimg.ImageUrl = "~/ProImg/" + pimg.ImgName;
                if (!this.proimg.Visible)
                {
                    this.proimg.Visible = true;               
                }
                this.btnSubmit.Text = "修改";
            }

            if (e.CommandName == "lbDelete")
            {
                string id = e.CommandArgument.ToString();
                comm.DeleteByCondition("dbo.tbProimgs", " where imgID=" + id);
                pageindex = 0; 
                Proimglist();
            }
        }
     
        protected void rptClassList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
          
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            pageindex = this.AspNetPager1.CurrentPageIndex - 1;
            Proimglist();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "提交")
            {
                pimg.ImgName = newfilename;
                pimg.Proid = int.Parse(Request.QueryString["id"].ToString()); ;
                if (pbll.proImagsAdd(pimg) != 0)
                {
                    pageindex = 0;
                    Proimglist();
                }
            }
            else
            {
                pimg.ImgName = newfilename;
                pimg.Proid =proid;
                if (pbll.proimgsUpdate(pimg) != 0)
                {
                    pageindex = 0;
                    Proimglist();
                }
            }
               

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string path=Server.MapPath("../../ProImg/");
            string filename=this.fp_img.FileName;
            newfilename = MyComm.FileUpLoad(this.fp_img, path, filename);
            if (newfilename != "false")
            {
                this.proimg.ImageUrl = "~/ProImg/" + filename;
                this.proimg.Visible = true;
            }
        }
    }
}
