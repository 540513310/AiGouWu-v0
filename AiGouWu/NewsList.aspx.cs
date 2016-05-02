using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AiGouWu
{
    public partial class NewsList : System.Web.UI.Page
    {
        SqlComm sqlcom = new SqlComm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                xuanxiangkabind();
                renqipaihang();
                newstypeband();
                newsband();
            }
        }
        static int pagesize = 20;
        static int pageindex = 0;
        static string condition = "";
        static int count = 0;
        /// <summary>
        /// 新闻绑定
        /// </summary>
        public void newsband()
        {
          this.re_NewsList.DataSource=  sqlcom.getdatabyPageIndex("dbo.Veiw_News", "*", condition, pagesize, pageindex, "NewsID",out count,"NewsID","Desc");
          this.re_NewsList.DataBind();
          this.AspNetPager1.RecordCount = count;
          this.AspNetPager1.PageSize = pagesize;

         
          
        }

        /// <summary>
        /// 新闻类型
        /// </summary>
        public void newstypeband()
        {
           this.ddlNewsTypeList.DataSource= sqlcom.getDataByCondition("dbo.tbNewsType", "TypeID,TypeName", " 1=1");
           this.ddlNewsTypeList.DataTextField = "TypeName";
           this.ddlNewsTypeList.DataValueField = "TypeID";
           this.ddlNewsTypeList.DataBind();
           this.ddlNewsTypeList.Items.Add(new ListItem("所有","0"));
        }

        /// <summary>
        /// 选项卡绑定
        /// </summary>
        public void xuanxiangkabind()
        {
            this.retuijian.DataSource = sqlcom.getDataByCondition("ProimgsbyTypeid_view", "Product_id,product_name,smallimg,type_id", " type_id=9");
            this.retuijian.DataBind();
        }

        /// <summary>
        /// 人气排行，统计销售数量前10的产品信息
        /// </summary>
        public void renqipaihang()
        {
            this.re_renqi.DataSource = sqlcom.getDataByCondition("tbProduct", "tbProduct.product_name,tbProduct.product_id", "product_id IN(SELECT TOP 10 proid FROM tbOrdersPros GROUP BY ProID ORDER BY sum(Procount) DESC)");
            this.re_renqi.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.ddlNewsTypeList.SelectedValue.ToString() == "0")
            {
                condition = " NewsTitle like '"+keywords1.Text+"%'";
                pageindex = 0;
            }
            else
            {
                condition = " and NewsTitle like '" + keywords1.Text + "%' and TypeID=" + this.ddlNewsTypeList.SelectedValue.ToString();
                pageindex = 0;
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            pageindex = this.AspNetPager1.CurrentPageIndex - 1;
            newsband();
        }
        /// <summary>
        /// 根据新闻类型筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlNewsTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlNewsTypeList.SelectedValue.ToString()=="0")
            {
              condition = "";
                pageindex = 0; 
            }
            else
            {
                condition = " and TypeID=" + this.ddlNewsTypeList.SelectedValue.ToString();
                pageindex = 0;
            }
            newsband();
        }
    }
}