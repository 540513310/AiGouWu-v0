using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;


namespace AiGouWu.Admin.Products
{
    public partial class CatalogtypeList : System.Web.UI.Page
    {
        static SqlComm comm = new SqlComm();
        static string condition = "";
        static int pagesize = 5;
        static int pageindex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
               CatalogListBind();
             
            }
            
        }

        private void CatalogListBind()
        {
            int totalcount = 0 ;
            rptClassList.DataSource = comm.getdatabyPageIndex("View_Types", "*", condition, pagesize, pageindex, "id", out  totalcount,null,null);
            rptClassList.DataBind();          
            this.AspNetPager1.RecordCount = totalcount;
            this.AspNetPager1.PageSize = pagesize;
        }       
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        }
     
        protected void rptClassList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
          
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            pageindex = this.AspNetPager1.CurrentPageIndex - 1;
            CatalogListBind();
        }
    }
}
