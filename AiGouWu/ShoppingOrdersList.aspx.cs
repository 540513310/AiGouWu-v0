using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model.Orders;
using System.EnterpriseServices;

namespace AiGouWu
{
    public partial class ShoppingOrdersList: System.Web.UI.Page
    {
        SqlComm sqlcom = new SqlComm();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["Cid"] == null)
            {
                Response.Redirect("index.aspx");
                return;
            }

            if (!IsPostBack)
            {
             this.gvorderslist.DataSource=   sqlcom.getDataByCondition("dbo.tbOrders", "*", " Customerid=" + Session["Cid"].ToString());
             this.gvorderslist.DataBind();

            }
        }

        

     
    
       
    }
}