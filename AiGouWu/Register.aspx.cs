using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model.Customer;
using System.Net.Mail;

namespace AiGouWu
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 用户基本信息提交注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            tbCustomer tbcustomer = new tbCustomer()
            {
                address = "",
                c_code = "",
                c_name = username.Value.Trim(),
                email = email.Value.Trim(),
                link_men = "",
                mobile = "",
                password = password.Value.Trim(),
                rank = "",
                remark = "",
                state = 1,
                tel = "",
                types = 1,
                username = username.Value.Trim()
            };

            CustomerBLL cbll = new CustomerBLL();
            int count= cbll.Add(tbcustomer);
            if (count != 0)
            {
                MailAddress messagefrom = new MailAddress("809420873@qq.com");
                string MessageTo = email.Value.Trim();
                string MessageSuject = "邮件主题";
                string MessageBody = "请进行邮箱验证来完成您注册的最后一步操作,<a href='http://localhost:55419/JiHuoEmail.aspx?id="+count+"'>邮箱账号激活</a>";

                //发送邮件
                if (emailsend(messagefrom, MessageTo, MessageSuject, MessageBody))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "test1", "alert('邮件发送成功，请激活邮件后登录')", true);
                    Session["Email"] = email.Value.Trim();
                    Response.Redirect("JiHuoEmail.aspx");
                }
            }


        }

        /// <summary>
        /// 邮件发送的方法
        /// </summary>
        /// <param name="MessageFrom"></param>
        /// <param name="MessageTo"></param>
        /// <param name="MessageSubject"></param>
        /// <param name="MessageBody"></param>
        /// <returns></returns>
        public bool emailsend(MailAddress MessageFrom, string MessageTo, string MessageSubject, string MessageBody)
        {
            MailMessage message = new MailMessage();
            message.From = MessageFrom;
            message.To.Add(MessageTo);//收件人的邮箱地址，可以实现群发邮件
            message.Subject = MessageSubject;//邮件主题
            message.Body = MessageBody;//邮件内容
            message.IsBodyHtml = false;//是否为HTML格式
            message.Priority = MailPriority.High;

            SmtpClient sc = new SmtpClient();
            sc.Host = "smtp.qq.com";//指定发送邮件的服务器
            sc.Port = 25;//指定飞发送邮件端口号
            sc.Credentials = new System.Net.NetworkCredential("809420873@qq.com", "19860512aa");
            try
            {
                sc.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}