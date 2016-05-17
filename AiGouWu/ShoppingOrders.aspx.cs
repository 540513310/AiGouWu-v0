using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model.Orders;
using System.EnterpriseServices;
using Model.Product;

namespace AiGouWu
{
    public partial class ShoppingOrders: System.Web.UI.Page
    {
        SqlComm sqlcom = new SqlComm();
        ProBLL probll = new ProBLL();
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
            System.Data.DataTable dt = sqlcom.getDataByCondition("dbo.TbCat", "*,dbo.getProNameByProId(ProID)as proname", "  isOrders=0 and isGoingBuy=1 and Customerid=" + Session["Cid"].ToString());
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




         //ProBLL probll = new ProBLL();
         //tbProduct model_pro = new tbProduct();
         //model_pro= probll.GetModel(ordersid);
         //int int_model_pro = int.Parse(model_pro.upperLimit.ToString());

         //根据 ordersid从tbOrdersPros中选出ProID
         System.Data.DataTable dt_proid = sqlcom.getDataByCondition("tbOrdersPros", "ProID", " OrderID=" + ordersid);
         int procount = dt_proid.Rows.Count;
         for (int i = 0; i < procount; i++)
         {
             string str_proid = dt_proid.Rows[i][0].ToString();
             int int_proid = int.Parse(str_proid);
             probll.Update_upperlimit(int_proid);
             //从tbProduct查询出product_id为str_proid的库存量
             //System.Data.DataTable dt_product = sqlcom.getDataByCondition("tbProduct", " upperLimit ", " product_id=" + int_proid);
             //string product_count = dt_product.Rows[0][0].ToString();
             //int int_product_count = int.Parse(product_count);
             //ProBLL probll = new ProBLL();
             //tbProduct model_pro = new tbProduct();
             //model_pro = probll.GetModel(int_proid);
             //int int_model_pro_upper = int.Parse(model_pro.upperLimit.ToString());
             //库存数量减一
             //int_model_pro_upper = int_model_pro_upper - 1;

             //更新tbProduct中product_id为str_proid的库存量
             //sqlcom.UpdateTableByCondition("dt_product", "upperLimit=upperLimit-1" , " where product_id=" + int_proid);


         }






         int cartcount = sqlcom.UpdateTableByCondition("dbo.TbCat", " isOrders=1 ", " where isOrders=0 and isGoingBuy=1 and  Customerid=" + Session["Cid"].ToString());
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

         //System.Data.DataTable dt = sqlcom.getDataByCondition("dbo.TbCat", "*,dbo.getProNameByProId(ProID)as proname", "  isOrders=0 and isGoingBuy=1 and Customerid=" + Session["Cid"].ToString());
         //int jubuI = 0;
         //while  (jubuI < gvCart.Rows.Count)
         //{
         //    string cartid = dt.Rows[jubuI]["CatID"].ToString();
         //    sqlcom.UpdateTableByCondition("TbCat", " isGoingBuy=" + 0, " where CatID=" + cartid);
         //    jubuI++;
         //}
            
         //   for (int i = 0; i < gvCart.Rows.Count; i++)
         //{
            
         //        string cartid = dt.Rows[i]["CatID"].ToString();
         //        sqlcom.UpdateTableByCondition("TbCat", " isGoingBuy=" + 0, " where CatID=" + cartid);
                 
         //}
         
        }

      
       
    }
}