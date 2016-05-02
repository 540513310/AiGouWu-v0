using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AiGouWu.Admin.Products
{
    public partial class List : System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();
       
        protected void Page_Load(object sender, EventArgs e)
        {
           this.rptClassList.DataSource= comm.getDataByCondition("proType", "*", " 1=1 ");
           this.rptClassList.DataBind();
        }


       
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btndel")
            {
                string id = e.CommandArgument.ToString();
                //修改当前编号的状态
            }
        }
     
        protected void rptClassList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
          
        }
    }
}
