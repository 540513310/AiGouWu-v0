using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
namespace AiGouWu
{
    /// <summary>
    /// NewsAutoSearch 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
   [System.Web.Script.Services.ScriptService]
    public class NewsAutoSearch : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        /// <summary>
        /// 查询咨询列表智能搜索
        /// </summary>
        /// <param name="prefixText"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public string[] GetNewsList(string prefixText, string count)
        {
            SqlComm sqlcomm = new SqlComm();
            System.Data.DataTable dt = sqlcomm.getDataByCondition("dbo.Veiw_News", " top " + count + " NewsID,NewsTitle", " NewsTitle like '%" + prefixText + "%' order by NewsTitle desc");
            if (dt != null && dt.Rows.Count > 0)
            {
                string[] newstitle = new string[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    newstitle[i] = dt.Rows[i]["NewsTitle"].ToString();

                }

                return newstitle;
            }
            else
            {
                return null;
            }
        }
    }
}
