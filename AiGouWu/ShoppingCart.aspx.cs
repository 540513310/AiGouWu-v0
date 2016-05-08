using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace AiGouWu
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        SqlComm sqlcom = new SqlComm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cid"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            if (!IsPostBack)
            {
                cartlistband();     
            }
        }

        public  void cartlistband()
        {
            System.Data.DataTable dt = sqlcom.getDataByCondition("dbo.TbCat", "*,dbo.getProNameByProId(ProID)as proname", " isOrders=0 and  Customerid=" + Session["Cid"].ToString());

            if (dt.Rows.Count == 0)
            {
                this.imgOrder.Visible = false;
                return;
            }
            this.gvCart.DataSource = dt;
            this.gvCart.DataBind();
            double total = 0.00;
            //double thistotal = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int Num = int.Parse(dt.Rows[i]["Num"].ToString());
                    double price = double.Parse(dt.Rows[i]["ProPrice"].ToString());
                    double discount = double.Parse(dt.Rows[i]["DisCount"].ToString());

                    //total += price * Num * discount;


                  
                }

                //for (int i = 0; i < gvCart.Rows.Count; i++)
                //{
                //    CheckBox check = gvCart.Rows[i].FindControl("cbxId") as CheckBox;
                //    if (check.Checked == true)
                //    {
                //        int Num = int.Parse(dt.Rows[i]["Num"].ToString());
                //        double discount = double.Parse(dt.Rows[i]["DisCount"].ToString());
                //        string thisPrice = gvCart.Rows[i].Cells[2].Text;
                //        int thePrice = int.Parse(thisPrice);
                //        thistotal = thePrice * Num * discount;
                //    }
                //    total += total + thistotal;
                //}
            }
            lbtotal.Text = total.ToString("0.00");
        }
        
        protected void gvCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
           
        }

        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           string CatID=     this.gvCart.DataKeys[e.RowIndex].Value.ToString();
           sqlcom.DeleteByCondition("dbo.TbCat", " where  CatID=" + CatID);
           cartlistband();
        }

        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
      
          
        }

        //增加
        protected void gvCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
         string cartid = this.gvCart.DataKeys[e.RowIndex].Value.ToString();

        TextBox count= (TextBox)this.gvCart.Rows[e.RowIndex].FindControl("txtAmount");
        int num = int.Parse(count.Text.Trim());
        num++;
        count.Text = num.ToString();
        sqlcom.UpdateTableByCondition("TbCat", " Num=" + num, " where CatID=" + cartid);
        cartlistband();

        }
        //当点击减少按钮时
        protected void gvCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string cartid = this.gvCart.DataKeys[e.NewEditIndex].Value.ToString();
            TextBox count = (TextBox)this.gvCart.Rows[e.NewEditIndex].FindControl("txtAmount");
            int num = int.Parse(count.Text.Trim());
            num--;
            if (num < 0)
            {
                num = 0;
            }
            count.Text = num.ToString();

            sqlcom.UpdateTableByCondition("TbCat", " Num=" + num, " where CatID=" + cartid);
            cartlistband();
        }

        protected void gvCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

           
            //this.gvCart.DataBind();
            
            double total = 0.00;
            double thistotal = 0;
            for (int i = 0; i < gvCart.Rows.Count; i++)
            {
                CheckBox check = gvCart.Rows[i].FindControl("cbxId") as CheckBox;
                if (check.Checked == true)
                {
                    
                    TextBox count = (TextBox)this.gvCart.Rows[i].FindControl("txtAmount");
                    int Num = int.Parse(count.Text.Trim());
                    double discount = double.Parse(gvCart.Rows[i].Cells[4].Text);
                    string thisPrice = gvCart.Rows[i].Cells[2].Text;
                    double thePrice = double.Parse(thisPrice);
                    thistotal = thePrice * Num * discount;
                    total += thistotal;
                    //string cartid = this.gvCart.Rows[i]..Value.ToString();
                   // string cartid = this.gvCart.DataKeys[e.NewEditIndex].Value.ToString();
                }
                
            }
            lbtotal.Text = total.ToString("0.00");
        }

        protected void imgOrder_Click(object sender, ImageClickEventArgs e)
        {
            System.Data.DataTable dt = sqlcom.getDataByCondition("dbo.TbCat", "*,dbo.getProNameByProId(ProID)as proname", " isOrders=0 and  Customerid=" + Session["Cid"].ToString());

            for (int i = 0; i < gvCart.Rows.Count; i++)
            {
                CheckBox check = gvCart.Rows[i].FindControl("cbxId") as CheckBox;
                if (check.Checked == true)
                {
                    string cartid =dt.Rows[i]["CatID"].ToString ();
                    sqlcom.UpdateTableByCondition("TbCat", " isGoingBuy=" + 1, " where CatID=" + cartid);
                }

            }
            Response.Redirect("ShoppingOrders.aspx");

        }
    }
}