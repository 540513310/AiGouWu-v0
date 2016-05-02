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
    public partial class proLevelWordsword: System.Web.UI.Page
    {
  
      
        SqlComm comm = new SqlComm();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                          
               
                    Proimglist();
                }
        }
        static string condition = "";
        static int pagesize = 5;
        static int pageindex = 0;
        static int recordcount;
        private void Proimglist()
        {

            this.rptClassList.DataSource = comm.getdatabyPageIndex("dbo.View_LevelWords", "*", condition, pagesize, pageindex, "ID", out recordcount, null, null);
            this.rptClassList.DataBind();
            this.AspNetPager1.RecordCount = recordcount;
            this.AspNetPager1.PageSize = pagesize;
        }
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "lbDelete")
            {
                string id = e.CommandArgument.ToString();
                //comm.DeleteByCondition("dbo.tbLevelwords", " where ID=" + id);
                comm.UpdateTableByCondition("dbo.tbLevelwords", "isDel=1", " where ID=" + id);
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
     

    }
}
