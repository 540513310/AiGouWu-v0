using System;
using System.Data;
using System.Web;
using BLL;
using Model.Orders;


namespace AiGouWu.Admin.Orders
{
    public partial class logseditchange: System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();
        static tbLogs logs = new tbLogs();
        tbLogsBLL logsbll = new tbLogsBLL();
        OrderBLL orderbll = new OrderBLL();
        tbOrdersPros tbOP = new tbOrdersPros();
        tbOrders tborder = new tbOrders();


        //string id = Request.QueryString["ID"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                string id = Request.QueryString["ID"].ToString();
                int int_id = int.Parse(id);
               
                logs=logsbll.tbLogs_GetModel(id);

                    this.ddlClassId.DataSource = comm.getDataByCondition("tbLogs", "ID,LogisticsName", " ID=" + id);
                    this.ddlClassId.DataTextField = "LogisticsName";
                    this.ddlClassId.DataValueField = "ID";
                    this.ddlClassId.DataBind();
                  
                    this.txtAddress.Text = logs.Address;
                    this.txtLinkMan.Text = logs.LinkMan;

                    this.txtMobie.Text = logs.Mobile;
                    this.txtTel.Text = logs.Tel;

            }
            
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            logs.LinkMan = txtLinkMan.Text;
            //logs.LogisticsName = this.ddlClassId.SelectedItem.Text;
           
            //logs.LogisticsName = this.ddlClassId.Text;

            logs.Mobile = txtMobie.Text;
            logs.Tel = txtTel.Text;
            logs.Address = txtAddress.Text;

            tbLogsBLL logsbll = new tbLogsBLL();
            int count = logsbll.tbLogs_Update(logs);
            if (count != 0)
            {
                Response.Redirect("logsList.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('添加失败')", true);
            }

        }

        protected void ddlClassId_SelectedIndexChanged(object sender, EventArgs e)
        {

            logs = logsbll.tbLogs_GetModel(this.ddlClassId.DataValueField);
            this.txtAddress.Text = logs.Address;
            this.txtLinkMan.Text = logs.LinkMan;
            this.txtTel.Text = logs.Tel;
            this.txtMobie.Text = logs.Mobile;

        }

   

      

    }
}
