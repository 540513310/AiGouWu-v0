using System;
using System.Data;
using System.Web;
using BLL;
using Model.Orders;


namespace AiGouWu.Admin.Orders
{
    public partial class OrdersShenHe: System.Web.UI.Page
    {
        OrderBLL obll = new OrderBLL();
        public tbOrders orders = new tbOrders();
        SqlComm comm = new SqlComm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            


                if (Request.QueryString["id"] != null)
                {
                    this.ddllogs.DataSource = comm.getDataByCondition("tbLogs", "ID,LogisticsName", null);
                    this.ddllogs.DataTextField = "LogisticsName";
                    this.ddllogs.DataValueField = "ID";
                    this.ddllogs.DataBind();
                    this.ddllogs.Items.Add(new System.Web.UI.WebControls.ListItem("请选择","0"));
                    this.ddllogs.SelectedValue = "0";

                    string id = Request.QueryString["id"].ToString();
                    orders = obll.getOrdersViewModel(int.Parse(id));
                    if (orders.Logid.ToString() != "" && orders.Logid.ToString() != "0")
                    {
                        this.ddllogs.SelectedValue = orders.Logid.ToString();
                    }
                    this.ddlState.SelectedValue = orders.State.ToString();
                    this.txtSendUser.Text = orders.sendUser;
                    this.txtRemark.Text = orders.remark;
                }
                else
                {
                    Response.Redirect("OrdersList.aspx");
                }
              

            }

           
        }
      
    
     
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string columns = "";
            if (this.txtSendUser.Text.Trim().Length > 0 && this.ddllogs.SelectedValue.ToString() != "0" && this.ddlState.SelectedValue == "1" && this.txtRemark.Text.Trim().Length > 0)
            {
                string LogNumber = DateTime.Now.ToString("yyyyMMdd") + Request.QueryString["id"].ToString();
                columns = " LogNumber='" + LogNumber + "', state='" + ddlState.SelectedValue.ToString() + "',sendUser='" + txtSendUser.Text.Replace("'", "").Replace("-", "") + "',Logid='" + this.ddllogs.SelectedValue + "',remark='" + this.txtRemark.Text + "' ";
            }
            else
            { 
            columns = " state='" + ddlState.SelectedValue.ToString() + "',sendUser='" + txtSendUser.Text.Replace("'", "").Replace("-", "") + "',Logid='" + this.ddllogs.SelectedValue + "',remark='" + this.txtRemark.Text + "' ";
            }
           
            string condition = " where OrderID="+Request.QueryString["id"].ToString();
           
            
            if (comm.UpdateTableByCondition("tbOrders", columns, condition) != 0)
            {
                Response.Redirect("OrdersList.aspx");
            }



        }

   

      

    }
}
