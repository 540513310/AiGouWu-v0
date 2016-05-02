using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;
using System.Data.SqlClient;
namespace BLL
{
  public   class NewBLL
    {
      DataBaseHepler db = new DataBaseHepler();
      /// <summary>
      /// 修改新闻类型
      /// </summary>
      /// <param name="typeid"></param>
      /// <param name="typename"></param>
      /// <returns></returns>
      public int updatenewtype(string typeid, string typename)
      {
          SqlParameter[] pars = new SqlParameter[]{
          new SqlParameter("@TypeID",typeid),
         new SqlParameter("@TypeName",typename)
       };
        int count=  db.ExcuteCommandReturnInt("tbNewsType_Update", CommandType.StoredProcedure, pars);
        return count;
      }
      /// <summary>
      /// 添加新闻类型
      /// </summary>
      /// <param name="typeid"></param>
      /// <param name="typename"></param>
      /// <returns></returns>
      public int newtypeadd(string typename)
      {
          SqlParameter[] pars = new SqlParameter[]{        
         new SqlParameter("@TypeName",typename)
       };
          int count = db.ExcuteCommandReturnInt("tbNewsType_Add", CommandType.StoredProcedure, pars);
          return count;
      }

      /// <summary>
      ///  增加一条数据
      /// </summary>
      public int Add(tbNews model)
      {      
          SqlParameter[] parameters = {				
					new SqlParameter("@NewsTitle", SqlDbType.NVarChar,20),
					new SqlParameter("@NewsContent", SqlDbType.Text),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@OldUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@Author", SqlDbType.NVarChar,20),
					new SqlParameter("@KeyWords", SqlDbType.NVarChar,200),
					new SqlParameter("@Metades", SqlDbType.NVarChar,200),
					new SqlParameter("@Review", SqlDbType.NVarChar,200),
					new SqlParameter("@ClickNum", SqlDbType.Int,4),
                    new SqlParameter("@ImgUrl",SqlDbType.NVarChar,200)
				   };
        
          parameters[0].Value = model.NewsTitle;
          parameters[1].Value = model.NewsContent;
          parameters[2].Value = model.TypeID;
          parameters[3].Value = model.OldUrl;
          parameters[4].Value = model.Author;
          parameters[5].Value = model.KeyWords;
          parameters[6].Value = model.Metades;
          parameters[7].Value = model.Review;
          parameters[8].Value = model.ClickNum;
          parameters[9].Value = model.ImgUrl;
      
        return   db.ExcuteCommandReturnInt("tbNews_ADD", CommandType.StoredProcedure, parameters);
         
      }
      
      /// <summary>
      ///  更新一条数据
      /// </summary>
      public int Update(tbNews model)
      {
         SqlParameter[] parameters = {
					new SqlParameter("@NewsID", SqlDbType.Int,4),
					new SqlParameter("@NewsTitle", SqlDbType.NVarChar,20),
					new SqlParameter("@NewsContent", SqlDbType.Text),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@OldUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@Author", SqlDbType.NVarChar,20),
					new SqlParameter("@KeyWords", SqlDbType.NVarChar,200),
					new SqlParameter("@Metades", SqlDbType.NVarChar,200),
					new SqlParameter("@Review", SqlDbType.NVarChar,200),
					new SqlParameter("@ClickNum", SqlDbType.Int,4),
					new SqlParameter("@IsDel", SqlDbType.Bit,1)
					};
          parameters[0].Value = model.NewsID;
          parameters[1].Value = model.NewsTitle;
          parameters[2].Value = model.NewsContent;
          parameters[3].Value = model.TypeID;
          parameters[4].Value = model.OldUrl;
          parameters[5].Value = model.Author;
          parameters[6].Value = model.KeyWords;
          parameters[7].Value = model.Metades;
          parameters[8].Value = model.Review;
          parameters[9].Value = model.ClickNum;
          parameters[10].Value = model.IsDel;

        return   db.ExcuteCommandReturnInt("tbNews_Update", CommandType.StoredProcedure, parameters);
        
      }

      /// <summary>
      /// 添加新闻评论
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public int NewsWordsAdd(Model.News.tbNewsWords model)
      {
          SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@NewsID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@LevelContent", SqlDbType.NVarChar,500),
					new SqlParameter("@Createdate", SqlDbType.DateTime),
					new SqlParameter("@isShenhe", SqlDbType.Bit,1),
					new SqlParameter("@isDel", SqlDbType.Bit,1)};
          parameters[0].Direction = ParameterDirection.Output;
          parameters[1].Value = model.NewsID;
          parameters[2].Value = model.UserName;
          parameters[3].Value = model.LevelContent;
          parameters[4].Value = model.Createdate;
          parameters[5].Value = model.isShenhe;
          parameters[6].Value = model.isDel;
          return  db.ExcuteCommandReturnInt("tbNewsWords_ADD", CommandType.StoredProcedure, parameters);

      
      }
    }
}
