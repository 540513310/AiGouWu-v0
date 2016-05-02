using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Orders
{
 public  class tbLogs
    {
     /// <summary>
     /// 编号
     /// </summary>
     public int ID { set; get; }
     /// <summary>
     /// 物流公司
     /// </summary>
     public string LogisticsName { set; get; }
     /// <summary>
     /// 地址
     /// </summary>
     public string Address { set; get; }
     /// <summary>
     /// 联系人
     /// </summary>
     public string LinkMan { set; get; }
     /// <summary>
     /// 电话号码
     /// </summary>
     public string Tel { set; get; }
     /// <summary>
     /// 手机号码
     /// </summary>
     public string Mobile { set; get; }
    }
}
