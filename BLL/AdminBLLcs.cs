using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using DAL;
namespace BLL
{
   public  class AdminBLLcs
    {

       DataBaseHepler dbhelper = new DataBaseHepler();
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(Model.tbAdmin model)
        {
           
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.VarChar,20),
					new SqlParameter("@Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@RoseID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@isDel", SqlDbType.Bit,1)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.RoseID;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.isDel;

            dbhelper.ExcuteCommandReturnInt("tbAdmin_ADD",CommandType.StoredProcedure,parameters);
            return (int)parameters[0].Value;
        }


        public int Update(Model.tbAdmin model)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.VarChar,20),
					new SqlParameter("@Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@RoseID", SqlDbType.Int,4),				
					new SqlParameter("@isDel", SqlDbType.Bit,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.RoseID;     
            parameters[4].Value = model.isDel;

         int count=   dbhelper.ExcuteCommandReturnInt("tbAdmin_Update", CommandType.StoredProcedure, parameters);
         return count;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.tbAdmin GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Model.tbAdmin model = new Model.tbAdmin();
            DataSet ds = dbhelper.ExcuteSelectReturnDataSet("tbAdmin_GetModel",CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.Pwd = ds.Tables[0].Rows[0]["Pwd"].ToString();
                if (ds.Tables[0].Rows[0]["RoseID"].ToString() != "")
                {
                    model.RoseID = int.Parse(ds.Tables[0].Rows[0]["RoseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isDel"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isDel"].ToString() == "1") || (ds.Tables[0].Rows[0]["isDel"].ToString().ToLower() == "true"))
                    {
                        model.isDel = true;
                    }
                    else
                    {
                        model.isDel = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

       /// <summary>
       /// 系统管理员登录
       /// </summary>
       /// <param name="username"></param>
       /// <param name="pwd"></param>
       /// <returns></returns>
        public int adminLogin(string username, string pwd)
        {
            string sql = "select count(*) from tbAdmin where LoginName=@LoginName and Pwd=@Pwd and isDel=0";
            SqlParameter[] pars = new SqlParameter[]{
            new SqlParameter("@LoginName",username),
            new SqlParameter("@Pwd",pwd)
            };
          object obj=  dbhelper.SelectSqlReturnObject(sql, CommandType.Text, pars);
          if (obj != null)
          {
             return int.Parse(obj.ToString());
          }
          else
          {
              return 0;
          }

           
        }
    }
}
