using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Links
{
   public  class tbLinks
    {
       /// <summary>
       /// 站点编号
       /// </summary>
       public int SiteId { get; set; }
       /// <summary>
       /// 站点名称
       /// </summary>
       public string SiteName { get; set; }
       /// <summary>
       /// 站点路径
       /// </summary>
       public string SiteUrl { get; set; }

       /// <summary>
       /// 站点图片
       /// </summary>
       public string SiteImg { get; set; }
       /// <summary>
       /// 是否显示图片
       /// </summary>
       public bool isshowimg { get; set; }
       /// <summary>
       /// 是否删除
       /// </summary>
       public bool isDel { get; set; }
    }
}
