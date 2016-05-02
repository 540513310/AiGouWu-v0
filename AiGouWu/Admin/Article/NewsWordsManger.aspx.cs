using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model.Product;
namespace AiGouWu.Admin.Article
{
    public partial class NewsWordsManger: System.Web.UI.Page
    {
  
      
        SqlComm comm = new SqlComm();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                          
               
                    NewsWordslist();
            }
        }
        static string condition = "";
        static int pagesize = 5;
        static int pageindex = 0;
        static int recordcount;
        private void NewsWordslist()
        {

            this.rptClassList.DataSource = comm.getdatabyPageIndex("dbo.NewsWords_View", "*", condition, pagesize, pageindex, "Id", out recordcount, null, null);
            this.rptClassList.DataBind();
            this.AspNetPager1.RecordCount = recordcount;
            this.AspNetPager1.PageSize = pagesize;
        }
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "lbDelete")
            {
                string id = e.CommandArgument.ToString();
              
                comm.UpdateTableByCondition("dbo.tbNewsWords", "isDel=1", " where ID=" + id);
                pageindex = 0;
                NewsWordslist();
            }

            if (e.CommandName == "lbShenHe")
            {
                string id = e.CommandArgument.ToString();

                comm.UpdateTableByCondition("dbo.tbNewsWords", "isShenhe=1,isDel=0", " where ID=" + id);
                pageindex = 0;
                NewsWordslist();
            }

            if (e.CommandName == "lbNoShenHe")
            {
                string id = e.CommandArgument.ToString();

                comm.UpdateTableByCondition("dbo.tbNewsWords", "isShenhe=0,isDel=0", " where ID=" + id);
                pageindex = 0;
                NewsWordslist();
            
            }
        }
     
        protected void rptClassList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
          
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            pageindex = this.AspNetPager1.CurrentPageIndex - 1;
            NewsWordslist();
        }
     

    }
}
