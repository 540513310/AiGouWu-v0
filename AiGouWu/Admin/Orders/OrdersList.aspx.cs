using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AiGouWu.Admin.Orders
{
    public partial class OrdersList: System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();
        string condition = "  ";
        //每页5条
       static  int pagesize = 5;
        //总共条数
       static int recordCount = 0;
        //第几页
       static int pageindex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                customerlistbind();
               
               
            }
        }

        private void customerlistbind()
        {
            rptList.DataSource = comm.getdatabyPageIndex("View_Orders", "*", condition, pagesize, pageindex, "orderid", out recordCount,null,null);
            rptList.DataBind();
            AspNetPager1.RecordCount = recordCount;
            AspNetPager1.PageSize = pagesize;
        }
       
     
              
       
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

           
        }

     

        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            condition = " and (createdate>='" + this.txtStart.Text + "' and createdate<='"+txtEnd.Text+"') and Address like '%" + this.txtKeywords.Text + "%'";
            pageindex = 0;
            customerlistbind();
          
        }
       

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            pageindex=this.AspNetPager1.CurrentPageIndex - 1;
            customerlistbind();
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            condition = " and state="+this.ddlState.SelectedValue.ToString();
            
            pageindex = 0;
            customerlistbind();
          
        }

    }
}
