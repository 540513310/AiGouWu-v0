using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.WebSet
{
  public  class tbWebSet
    {
      /// <summary>
      /// 编号
      /// </summary>
      public int ID { set; get; }
      /// <summary>
      /// 网站名称
      /// </summary>
      public string WebName { set; get; }
      /// <summary>
      /// 域名
      /// </summary>
      public string WebUrl { set; get; }
      /// <summary>
      /// 联系电话
      /// </summary>
      public string WebTel { set; get; }
      /// <summary>
      /// 传真
      /// </summary>
      public string WebFax { set; get; }
      /// <summary>
      /// 邮件
      /// </summary>
      public string WebEmail { set; get; }
      /// <summary>
      /// ICP备案号
      /// </summary>
      public string WebCrod { set; get; }
      /// <summary>
      /// 网站版权
      /// </summary>
      public string WebCopyright { set; get; }
      /// <summary>
      /// 关键字
      /// </summary>
      public string WebKeywords { set; get; }
      /// <summary>
      /// 描述
      /// </summary>
      public string WebDescription { set; get; }

    }
}
