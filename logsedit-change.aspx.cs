using System;
using System.Data;
using System.Web;
using BLL;
using Model.Orders;


namespace AiGouWu.Admin.Orders
{
    public partial class logsedit-change: System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();
        static tbLogs logs = new tbLogs();
        tbLogsBLL logsbll = new tbLogsBLL();
        OrderBLL orderbll = new OrderBLL();
        tbOrdersPros tbOP = new tbOrdersPros();
        tbOrders tborder = new tbOrders();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Request.QueryString["id"] != null)
            //    {
            //        string id = Request.QueryString["id"].ToString();
            //        logs = logsbll.tbLogs_GetModel(id);
            //        this.txtAddress.Text = logs.Address;
            //        this.txtLinkMan.Text = logs.LinkMan;
            //        //this.txtLogsName.Text = logs.LogisticsName;
            //        this.txtMobie.Text = logs.Mobile;
            //        this.txtTel.Text = logs.Tel;
            //    }
            //    else
            //    {
            //        Response.Redirect("logsList.aspx");
            //    }
            //}
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"].ToString();
                int int_id = int.Parse(id);
                tborder = orderbll.getOrdersViewModel(int_id);
                if (tborder.Logid != null)
                {
                    string str_logid=tborder.Logid.ToString ();
                    int int_logid = int.Parse(str_logid);
                    logs = logsbll.tbLogs_GetModel(str_logid);
                    this.ddlClassId.DataSource = comm.getDataByCondition("tbLogs", "ID,LogisticsName", " ID=" + str_logid);
                    this.ddlClassId.DataTextField = "LogisticsName";
                    this.ddlClassId.DataValueField = "ID";
                    this.ddlClassId.DataBind();
                    logs = logsbll.tbLogs_GetModel(str_logid);
                    this.txtAddress.Text = logs.Address;
                    this.txtLinkMan.Text = logs.LinkMan;

                    this.txtMobie.Text = logs.Mobile;
                    this.txtTel.Text = logs.Tel;


                }
                //if (id != null) 
                //{
                //    logs = logsbll.tbLogs_GetModel(id);
                //    DataTable dt = comm.getDataByCondition("View_Orders", "*", " OrderID="+ id);
                //    string logid = dt.Rows[0]["Logid"].ToString();
                //    if (logid == "")
                //    {
                //        this.ddlClassId.DataSource = comm.getDataByCondition("tbLogs", " ID,LogisticsName ", " ID=" + logid);
                //        this.ddlClassId.DataTextField = "LogisticsName";
                //        this.ddlClassId.DataValueField = "ID";
                //        this.ddlClassId.DataBind();
                //    }
               

         }
               

                
            }






        protected void btnSave_Click(object sender, EventArgs e)
        {
            logs.LinkMan = txtLinkMan.Text;
            logs.LogisticsName = this.ddlClassId.DataTextField;
            //logs.LogisticsName = txtLogsName.Text;
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
