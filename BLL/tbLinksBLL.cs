using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Model.Links;
namespace BLL
{
  public   class tbLinksBLL
    {
      DataBaseHepler dbhelper = new DataBaseHepler();

      /// <summary>
      /// 友情链接的添加
      /// </summary>
      /// <param name="links">tbLinks对象</param>
      /// <returns>int </returns>
      public int Links_Add(tbLinks links)
      {
          SqlParameter[] pars = new SqlParameter[]{
            new SqlParameter("@SiteName",links.SiteName),
            new SqlParameter("@SiteUrl",links.SiteUrl),
            new SqlParameter("@SiteImg",links.SiteImg),
            new SqlParameter("@isshowimg",links.isshowimg),
            new SqlParameter("@isDel",links.isDel)

          };
         return  dbhelper.ExcuteCommandReturnInt("Links_Add", CommandType.StoredProcedure, pars);
      }

      /// <summary>
      /// 修改指定对象
      /// </summary>
      /// <param name="links">tbLinks对象</param>
      /// <returns>int</returns>
      public int Links_Update(tbLinks links)
      {
          SqlParameter[] pars = new SqlParameter[]{
              new SqlParameter("@SiteId",links.SiteId),
              new SqlParameter("@SiteName",links.SiteName),
              new SqlParameter("@SiteUrl",links.SiteUrl),
              new SqlParameter("@SiteImg",links.SiteImg),
              new SqlParameter("@isshowimg",links.isshowimg),
              new SqlParameter("@isDel",links.isDel)


       };
       
       return dbhelper.ExcuteCommandReturnInt("Links_Update", CommandType.StoredProcedure, pars);


      }

      /// <summary>
      /// 根据编号获取友情链接对象的详细属性
      /// </summary>
      /// <param name="id">编号</param>
      /// <returns>tbLinks对象</returns>
      public tbLinks Links_getModel(string id)
      {
          SqlParameter[] pars = new SqlParameter[]{
        new SqlParameter("@SiteId",int.Parse(id))
        };

       SqlDataReader reader=dbhelper.SelectSqlReturnDataReader("Links_getModel", CommandType.StoredProcedure, pars);
       tbLinks links = new tbLinks();
       if (reader != null &&reader.Read()==true)
       {
           links.SiteId = int.Parse(reader["SiteId"].ToString());
           links.SiteName = reader["SiteName"].ToString();
           links.SiteImg = reader["SiteImg"].ToString();
           links.SiteUrl = reader["SiteUrl"].ToString();
           links.isshowimg =bool.Parse(reader["isshowimg"].ToString());
           links.isDel = bool.Parse(reader["isDel"].ToString());
       }
       return links;
      }

    }
}
