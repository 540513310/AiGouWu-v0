using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model.Orders;
using Model.Customer;
namespace AiGouWu.Admin.Orders
{
    public partial class OdersDetail : System.Web.UI.Page
    {
      static  OrderBLL obll = new OrderBLL();
      static SqlComm sql = new SqlComm();
      tbOrders order = new tbOrders();
      tbCustomer c = new tbCustomer();
      CustomerBLL cb = new CustomerBLL();
      static  public System.Data.DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                string orderid = Request.QueryString["id"].ToString();
                order= obll.getOrdersViewModel(int.Parse(orderid));
                this.customer_name.Text = order.Username;
                this.sales_orderid.Text = order.OrderNo;
                this.customer_address.Text = order.Address;
               
                //查询详细客户信息
                 c= cb.GetModel(int.Parse(order.Customerid.ToString()));
                 this.customer_linker.Text = c.link_men;
                 this.customer_tel.Text = order.Tel + "/" + order.Mobile;
                 this.customet_email.Text = c.email;

                //查询详细物流公司信息
                tbLogs logs=new tbLogs();
                tbLogsBLL tblogbll=new tbLogsBLL();
                logs= tblogbll.tbLogs_GetModel(order.Logid.ToString());
                this.logistics.Text = logs.LogisticsName;
                this.logistics_num.Text = order.LogNumber;
                this.state.Text = order.StateName;
                this.create_date.Text = DateTime.Parse(order.createdate.ToString()).ToString("yyyy-MM-dd");
                attach_pay.Text =decimal.Parse(order.Postmoney.ToString()).ToString("0.00");
                dt = sql.getDataByCondition("dbo.OrdersPro_View", "*", " OrderID="+order.OrderID);


            }

        }
    }
}