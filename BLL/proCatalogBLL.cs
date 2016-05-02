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
  public  class proCatalogBLL
    {
      DataBaseHepler dbhelper = new DataBaseHepler();
        /// <summary>
        ///  增加一条数据
        /// </summary>

        public int Add(Model.Product.proCatalog model)
        {
          
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@catalogid", SqlDbType.NVarChar,20),
					new SqlParameter("@catalogname", SqlDbType.NVarChar,20),
					new SqlParameter("@typid", SqlDbType.Int,4),
					new SqlParameter("@Parentid", SqlDbType.Int,4),
					new SqlParameter("@isShow", SqlDbType.Bit,1),
					new SqlParameter("@isLock", SqlDbType.Bit,1)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.catalogid;
            parameters[2].Value = model.catalogname;
            parameters[3].Value = model.typid;
            parameters[4].Value = model.Parentid;
            parameters[5].Value = model.isShow;
            parameters[6].Value = model.isLock;

            dbhelper.ExcuteCommandReturnInt("proCatalog_ADD", CommandType.StoredProcedure, parameters);
            return  int.Parse(parameters[0].Value.ToString());
           
        }
       /// <summary>
       /// 修改一条数据
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        public int Update(Model.Product.proCatalog model)
        {
          
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@catalogid", SqlDbType.NVarChar,20),
					new SqlParameter("@catalogname", SqlDbType.NVarChar,20),
					new SqlParameter("@typid", SqlDbType.Int,4),
					new SqlParameter("@Parentid", SqlDbType.Int,4),
					new SqlParameter("@isShow", SqlDbType.Bit,1),
					new SqlParameter("@isLock", SqlDbType.Bit,1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.catalogid;
            parameters[2].Value = model.catalogname;
            parameters[3].Value = model.typid;
            parameters[4].Value = model.Parentid;
            parameters[5].Value = model.isShow;
            parameters[6].Value = model.isLock;

            return  dbhelper.ExcuteCommandReturnInt("proCatalog_Update", CommandType.StoredProcedure, parameters);

        }

        /// <summary>
        /// 根据类型编号返回类型对象
        /// </summary>
        /// <param name="id">类型编号</param>
        /// <returns>proCatalog对象</returns>
        public Model.Product.proCatalog getModelbyid(string id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;
            Model.Product.proCatalog model = new Model.Product.proCatalog();         
            DataSet ds = dbhelper.ExcuteSelectReturnDataSet("proCatalog_GetModel", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.catalogid = ds.Tables[0].Rows[0]["catalogid"].ToString();
                model.catalogname = ds.Tables[0].Rows[0]["catalogname"].ToString();
                if (ds.Tables[0].Rows[0]["typid"].ToString() != "")
                {
                    model.typid = int.Parse(ds.Tables[0].Rows[0]["typid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Parentid"].ToString() != "")
                {
                    model.Parentid = int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isShow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isShow"].ToString() == "1") || (ds.Tables[0].Rows[0]["isShow"].ToString().ToLower() == "true"))
                    {
                        model.isShow = true;
                    }
                    else
                    {
                        model.isShow = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["isLock"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isLock"].ToString() == "1") || (ds.Tables[0].Rows[0]["isLock"].ToString().ToLower() == "true"))
                    {
                        model.isLock = true;
                    }
                    else
                    {
                        model.isLock = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

    }
}
