using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
namespace AiGouWu
{
    /// <summary>
    /// AutoSearchKeyWords 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class AutoSearchKeyWords : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public string[] GetProList(string prefixText, string count)
        {
            SqlComm sqlcomm = new SqlComm();
            System.Data.DataTable dt = sqlcomm.getDataByCondition("dbo.View_Product", "top " + count + " product_name,product_id", " product_name like '%" + prefixText + "%'  order by product_name desc");
            if (dt != null && dt.Rows.Count > 0)
            {
                string[] prolist = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    prolist[i] = dt.Rows[i]["product_name"].ToString();
                }

                return prolist;
            }
            else
            {
                return null;
            }

        
        }

        
    }
}
