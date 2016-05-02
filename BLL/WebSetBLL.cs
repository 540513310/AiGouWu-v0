using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Model.WebSet;
namespace BLL
{
   public class WebSetBLL
    {
       DataBaseHepler dbhelper = new DataBaseHepler();
        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(tbWebSet model)
        {
           
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@WebName", SqlDbType.NVarChar,100),
					new SqlParameter("@WebUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@WebTel", SqlDbType.NVarChar,100),
					new SqlParameter("@WebFax", SqlDbType.NVarChar,100),
					new SqlParameter("@WebEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@WebCrod", SqlDbType.NVarChar,50),
					new SqlParameter("@WebCopyright", SqlDbType.NVarChar,50),
					new SqlParameter("@WebKeywords", SqlDbType.NVarChar,100),
					new SqlParameter("@WebDescription", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.WebName;
            parameters[2].Value = model.WebUrl;
            parameters[3].Value = model.WebTel;
            parameters[4].Value = model.WebFax;
            parameters[5].Value = model.WebEmail;
            parameters[6].Value = model.WebCrod;
            parameters[7].Value = model.WebCopyright;
            parameters[8].Value = model.WebKeywords;
            parameters[9].Value = model.WebDescription;

          return    dbhelper.ExcuteCommandReturnInt("tbWebSet_Update", CommandType.StoredProcedure, parameters);

           
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public tbWebSet GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            tbWebSet model = new tbWebSet();

            DataSet ds = dbhelper.ExcuteSelectReturnDataSet("getModel_tbWebSet", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.WebName = ds.Tables[0].Rows[0]["WebName"].ToString();
                model.WebUrl = ds.Tables[0].Rows[0]["WebUrl"].ToString();
                model.WebTel = ds.Tables[0].Rows[0]["WebTel"].ToString();
                model.WebFax = ds.Tables[0].Rows[0]["WebFax"].ToString();
                model.WebEmail = ds.Tables[0].Rows[0]["WebEmail"].ToString();
                model.WebCrod = ds.Tables[0].Rows[0]["WebCrod"].ToString();
                model.WebCopyright = ds.Tables[0].Rows[0]["WebCopyright"].ToString();
                model.WebKeywords = ds.Tables[0].Rows[0]["WebKeywords"].ToString();
                model.WebDescription = ds.Tables[0].Rows[0]["WebDescription"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }



    }
}
