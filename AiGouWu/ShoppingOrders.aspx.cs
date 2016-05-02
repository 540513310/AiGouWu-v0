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
    public partial class ShoppingOrders: System.Web.UI.Page
    {
        SqlComm sqlcom = new SqlComm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cartlistband();

                getcustmoerinfo();

                this.txtGoodsMoney.Text = lbtotal.Text;
                this.txtPostMoney.Text = "0.00";

            
  
            }
        }

        private void getcustmoerinfo()
        {
            CustomerBLL cbll = new CustomerBLL();
           Model.Customer.tbCustomer tbcustomer=  cbll.GetModel(int.Parse(Session["Cid"].ToString()));
           if (tbcustomer.address != null && tbcustomer.address.Length>0)
           {
               this.txtAddress.Text = tbcustomer.address;
           }


           if (tbcustomer.email != null && tbcustomer.email.Length > 0)
           {
               this.txtEmail.Text = tbcustomer.email;
           }

           if (tbcustomer.mobile != null && tbcustomer.mobile.Length > 0)
           {
               this.txtMobile.Text = tbcustomer.mobile;
           }


           if (tbcustomer.link_men != null && tbcustomer.link_men.Length > 0)
           {
               this.txtOthors.Text = tbcustomer.link_men;
           }


           if (tbcustomer.c_name != null && tbcustomer.c_name.Length > 0)
           {
               this.txtRealName.Text = tbcustomer.c_name;
           }


           if (tbcustomer.tel != null && tbcustomer.tel.Length > 0)
           {
               this.txtTel.Text = tbcustomer.tel;
           }
           
          
          
        
          


        }

        private void cartlistband()
        {
            System.Data.DataTable dt = sqlcom.getDataByCondition("dbo.TbCat", "*,dbo.getProNameByProId(ProID)as proname", "  isOrders=0 and Customerid=" + Session["Cid"].ToString());
            this.gvCart.DataSource = dt;

            this.gvCart.DataBind();
            double total = 0.00;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int Num = int.Parse(dt.Rows[i]["Num"].ToString());
                    double price = double.Parse(dt.Rows[i]["ProPrice"].ToString());
                    double discount = double.Parse(dt.Rows[i]["DisCount"].ToString());
                    total += price * Num * discount;
                }
            }
            lbtotal.Text = total.ToString("0.00");
        }
        protected void imgorder_Click(object sender, ImageClickEventArgs e)
        {
            OrderBLL orderbll = new OrderBLL();

            tbOrders orders = new tbOrders()
            {
                Address = txtAddress.Text.Trim(),
                createdate = DateTime.Now,
                Customerid = int.Parse(Session["Cid"].ToString()),
                Mobile = txtMobile.Text.Trim(),
                Tel = txtTel.Text.Trim(),
                Postmoney = decimal.Parse(txtPostMoney.Text.Trim()),
                totalMoney = decimal.Parse(txtGoodsMoney.Text.Trim()) + decimal.Parse(txtPostMoney.Text.Trim()),
                Username = lbCustomer.Text,
                salesincome = decimal.Parse(txtGoodsMoney.Text.Trim()),
                sendUser = txtRealName.Text,
                remark = ""       

            };
         int ordersid=   orderbll.tbOrders_ADD(orders);
         int count= orderbll.setorderprosbycid(int.Parse(Session["Cid"].ToString()), ordersid);
         int cartcount=   sqlcom.UpdateTableByCondition("dbo.TbCat", " isOrders=1 ", " where isOrders=0 and  Customerid=" + Session["Cid"].ToString());
         int ccount= sqlcom.UpdateTableByCondition("dbo.tbCustomer", "c_name='" + txtRealName.Text.Trim() + "',tel='" + orders.Tel + "',mobile='" + orders.Mobile + "',email='" + txtEmail.Text + "',link_men='" + txtOthors.Text + "',address='" + txtAddress.Text + "'", " where id=" + Session["Cid"].ToString());
        
         if (ordersid == 0 || count == 0 || cartcount == 0 || ccount == 0)
         {
             ContextUtil.SetAbort();
         }
         else
         {
             ContextUtil.SetComplete();
             Response.Redirect("PayWay.aspx?OrderID=" + ordersid);
         }


            
        }

      
       
    }
}