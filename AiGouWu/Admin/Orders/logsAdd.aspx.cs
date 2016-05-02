using System;
using System.Data;
using System.Web;
using BLL;
using Model.Orders;


namespace AiGouWu.Admin.Orders
{
    public partial class logsAdd: System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
           

           
        }
      
    
     
        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbLogs logs = new tbLogs()
            {
                Address = txtAddress.Text,
                LinkMan = txtLinkMan.Text,
                LogisticsName = txtLogsName.Text,
                Mobile = txtMobie.Text,
                Tel = txtTel.Text
            };
            tbLogsBLL logsbll = new tbLogsBLL();
          int count=   logsbll.tbLogs_ADD(logs);
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
