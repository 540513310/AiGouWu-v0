using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model.Orders;
namespace AiGouWu
{
    public partial class GoBank : System.Web.UI.Page
    {
        public static BankPay bankpay = new BankPay();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderID"] != null)
            {
                string orderid = Request.QueryString["OrderID"].ToString();
                tbOrders order = new tbOrders();

                OrderBLL orderbll = new OrderBLL();
                order=  orderbll.getOrdersViewModel(int.Parse(orderid));

                bankpay.Orderid=   order.OrderNo;//订单编号
                bankpay.Amount = order.totalMoney.ToString();//订单金额
                bankpay.OrderDate = order.createdate.ToString();//订单日期
                bankpay.Path1 = Server.MapPath(@"bank\user.crt");//拆分pfx后缀的证书后的公钥路径
                bankpay.Path2 = Server.MapPath(@"bank\user.crt");
                bankpay.Path3 = Server.MapPath(@"bank\user.key");//拆分pfx后缀的证书后的私钥路径

                //加密
                bankpay.Msg = bankpay.InterfaceName + bankpay.InterfaceVersion + bankpay.MerID + bankpay.MerAcct + bankpay.MerURL + bankpay.NotifyType + bankpay.Orderid + bankpay + bankpay.Amount + bankpay.CurType + bankpay.ResultType + bankpay.OrderDate + bankpay.VerifyJoinFlag;

                ICBCEBANKUTILLib.B2CUtil obj = new ICBCEBANKUTILLib.B2CUtil();
                //加载公钥，私玥，密码，如果返回的0则成功
                if (obj.init(bankpay.Path1, bankpay.Path2, bankpay.Path3, bankpay.Key) == 0)
                {
                    bankpay.MerSignMsg = obj.signC(bankpay.Msg, bankpay.Msg.Length);
                    bankpay.MerCert = obj.getCert(1);
                }
                else
                {
                    Response.Write(obj.getRC());
                
                }



            }
        }
    }
}