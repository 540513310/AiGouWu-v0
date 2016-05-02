using System;
using System.Data;
using System.Web;
using BLL;
using Model.Orders;


namespace AiGouWu.Admin.Orders
{
    public partial class logsedit: System.Web.UI.Page
    {
        static tbLogs logs = new tbLogs();
        tbLogsBLL logsbll = new tbLogsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"].ToString();
                    logs = logsbll.tbLogs_GetModel(id);
                    this.txtAddress.Text = logs.Address;
                    this.txtLinkMan.Text = logs.LinkMan;
                    this.txtLogsName.Text = logs.LogisticsName;
                    this.txtMobie.Text = logs.Mobile;
                    this.txtTel.Text = logs.Tel;
                }
                else
                {
                    Response.Redirect("logsList.aspx");
                }
            }
        }
      
    
     
        protected void btnSave_Click(object sender, EventArgs e)
        {
            logs.LinkMan = txtLinkMan.Text;
            logs.LogisticsName = txtLogsName.Text;
            logs.Mobile = txtMobie.Text;
            logs.Tel = txtTel.Text;
            logs.Address = txtAddress.Text;
            
            tbLogsBLL logsbll = new tbLogsBLL();
          int count=   logsbll.tbLogs_Update(logs);
          if (count != 0)
          {
              Response.Redirect("logsList.aspx");
          }
          else
          {
              ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('添加失败')", true);
          }

        }

   

      

    }
}
