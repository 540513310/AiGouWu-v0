using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AiGouWu.Admin.Links
{
    public partial class List :System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();

        string condition = " ";
        //每页5条
        int pagesize = 5;
        //总共条数
        int recordCount = 0;
        //第几页
        int pageindex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                getNewsList();
                AspNetPager1.RecordCount = recordCount;
                AspNetPager1.PageSize = pagesize;
            
            }
        }
     
        /// <summary>
        /// 列表绑定
        /// </summary>
        private void getNewsList()
        {

            rptList.DataSource = comm.getdatabyPageIndex("dbo.tbLinks", "*", condition, pagesize, pageindex, "SiteId", out recordCount,null,null);
            rptList.DataBind();
        }
              
       
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
            
        }

       


        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            condition = " and SiteName like '%" + this.txtKeywords.Text + "%'";
            getNewsList();
        }
     

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            pageindex=this.AspNetPager1.CurrentPageIndex - 1;
            getNewsList();

        }

    }
}
