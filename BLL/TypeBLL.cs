using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Model.Product;
namespace BLL
{
  public  class TypeBLL
    {
      DataBaseHepler dbhelper = new DataBaseHepler();
      /// <summary>
      /// 添加一个产品类别对象,并且返回当前对象的编号
      /// </summary>
        /// <param name="type">类别对象</param>
      /// <returns>对象编号</returns>
      public int type_Add(proType type)
      {
          SqlParameter[] pars = new SqlParameter[]{
         new SqlParameter("@id",SqlDbType.Int),
         new SqlParameter("@typeName",type.typeName),
         new SqlParameter("@ParentId",type.ParentId),
         new SqlParameter("@isLock",type.isLock)         
         };
          pars[0].Direction = ParameterDirection.Output;
          dbhelper.ExcuteCommandReturnInt("proType_Add", CommandType.StoredProcedure, pars);
          if (int.Parse(pars[0].Value.ToString()) != 0)
          {
              return int.Parse(pars[0].Value.ToString());
          }
          else
          {
              return 0;
          }


       
      }


      /// <summary>
      /// 修改产品类别
      /// </summary>
      /// <param name="type"></param>
      /// <returns>int</returns>
      public int type_Update(proType type)
      {
          SqlParameter[] pars = new SqlParameter[]{
          new SqlParameter("@id",type.id),
          new SqlParameter("@typeName",type.typeName),
          new SqlParameter("@ParentId",type.ParentId),
          new SqlParameter("@isLock",type.isLock)
          };
         return dbhelper.ExcuteCommandReturnInt("proType_Update", CommandType.StoredProcedure, pars);
      
      }
      /// <summary>
      /// 根据编号查询类别对象
      /// </summary>
      /// <param name="id">编号</param>
      /// <returns>类别对象</returns>
      public proType proType_GetModel(int id)
      { 
          SqlParameter []par=new  SqlParameter[]{
              new SqlParameter("@id",id)
          };

        proType type = new proType();
       SqlDataReader reader= dbhelper.SelectSqlReturnDataReader("proType_GetModel", CommandType.StoredProcedure, par);
       if (reader.Read())
       {
           type.id = int.Parse(reader["id"].ToString());
           type.typeName = reader["typeName"].ToString();
           type.ParentId = int.Parse(reader["ParentId"].ToString());
           type.isLock = bool.Parse(reader["isLock"].ToString());
       }
       reader.Close();
       return type;

      }

    }
}
