using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Model.Orders;
namespace BLL
{
  
   public  class tbLogsBLL
    {
       DAL.DataBaseHepler sqlhelper = new DataBaseHepler();
       /// <summary>
       /// 物流公司信息添加业务
       /// </summary>
        /// <param name="model">tbLogs对象</param>
       /// <returns>int</returns>
       public int tbLogs_ADD(tbLogs model)
       {
           SqlParameter[] pars = new SqlParameter[]{
        new SqlParameter("@ID",SqlDbType.Int,4),
        new SqlParameter("@LogisticsName",model.LogisticsName),
        new SqlParameter("@Address",model.Address),
        new SqlParameter("@LinkMan",model.LinkMan),
        new SqlParameter("@Tel",model.Tel),
        new SqlParameter("@Mobile",model.Mobile)
       };
           pars[0].Direction = ParameterDirection.Output;
       int count=  sqlhelper.ExcuteCommandReturnInt("tbLogs_ADD", CommandType.StoredProcedure, pars);
       if (count != 0)
       {
           return int.Parse(pars[0].Value.ToString());
       }
       else
       {
           return 0;
       }
       }
       /// <summary>
       /// 修改业务方法封装
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public int tbLogs_Update(tbLogs model)
       {
           SqlParameter[] pars = new SqlParameter[]{        
        new SqlParameter("@ID",model.ID),
        new SqlParameter("@LogisticsName",model.LogisticsName),
        new SqlParameter("@Address",model.Address),
        new SqlParameter("@LinkMan",model.LinkMan),
        new SqlParameter("@Tel",model.Tel),
        new SqlParameter("@Mobile",model.Mobile)      
        };
         return  sqlhelper.ExcuteCommandReturnInt("tbLogs_Update", CommandType.StoredProcedure, pars);
       }

       /// <summary>
       /// 获取详细对象
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public tbLogs tbLogs_GetModel(string id)
       {
           SqlParameter[] pars = new SqlParameter[]{
           new SqlParameter("@ID",int.Parse(id))
           };
       SqlDataReader reader= sqlhelper.SelectSqlReturnDataReader("tbLogs_GetModel", CommandType.StoredProcedure, pars);
       tbLogs logs = new tbLogs();
       if (reader.Read())
       {
           logs.ID =int.Parse(reader["ID"].ToString());
           logs.LogisticsName = reader["LogisticsName"].ToString();
           logs.Mobile = reader["Mobile"].ToString();
           logs.Tel = reader["Tel"].ToString();
           logs.LinkMan = reader["LinkMan"].ToString();
           logs.Address = reader["Address"].ToString();
           
       }
       reader.Close();
       return logs;
       
       }
    }
}
