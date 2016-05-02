using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model.Customer;
using System.Net.Mail;
using BLL;

namespace AiGouWu
{
    public partial class JiHuoEmail : System.Web.UI.Page
    {
        SqlComm sqlcom = new BLL.SqlComm();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                string cid = Request.QueryString["id"].ToString();
                System.Data.DataTable dt= sqlcom.getDataByCondition("dbo.tbCustomer", "id,username,isvalidate,state", " state=1 and id= " + cid);
                if (dt != null && dt.Rows.Count >= 0)
                {
                 bool istrue=bool.Parse( dt.Rows[0]["isvalidate"].ToString());
                 if (!istrue)
                 {
                   int count=  sqlcom.UpdateTableByCondition("dbo.tbCustomer", " isvalidate=1 ", " where id=" + cid);
                   if (count != 0)
                   {
                       LinkButton1.Text = "恭喜您，成功激活邮件验证，您可以轻松购物了。";
                       //免登录
                       Session["Cid"]=cid;
                       Session["CName"]=dt.Rows[0]["username"].ToString();
                   
                   }
                 }
                }
            }
           
        }

      
       
    }
}