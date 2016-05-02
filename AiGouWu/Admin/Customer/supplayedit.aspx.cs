using System;
using System.Data;
using System.Web;
using BLL;
using Model.Customer;


namespace AiGouWu.Admin.Customer
{
    public partial class supplayedit: System.Web.UI.Page
    {
     public static   tbCustomer c = new tbCustomer();
     CustomerBLL cb = new CustomerBLL();
     SqlComm comm = new SqlComm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["id"]!=null )
                {
                    string id=Request.QueryString["id"].ToString();
                     c= cb.GetModel(int.Parse(id));

                     this.DropDownList1.SelectedValue = c.state.ToString();
                }
              

            }

           
        }
      
    
     
        protected void btnSave_Click(object sender, EventArgs e)
        {
            comm.UpdateTableByCondition("tbCustomer", "isvalidate="+this.ddlValidate.SelectedValue+" state=" + this.DropDownList1.SelectedValue, " where id=" + Request.QueryString["id"].ToString());
            Response.Redirect("supplyCustomer.aspx");
        }

   

      

    }
}
