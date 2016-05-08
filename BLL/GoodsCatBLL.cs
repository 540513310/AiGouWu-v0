using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model.Product;
using System.Data;
using System.Data.SqlClient;
namespace BLL
{
   public  class GoodsCatBLL
    {
       DataBaseHepler dbhelper = new DataBaseHepler();
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(TbCat model)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@CatID", SqlDbType.Int,4),
					new SqlParameter("@Customerid", SqlDbType.Int,4),
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@DisCount", SqlDbType.Money,8),
					new SqlParameter("@ProPrice", SqlDbType.Money,8),
                    new SqlParameter ("@IsOrders",SqlDbType.Bit,4 )};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.Customerid;
            parameters[2].Value = model.ProID;
            parameters[3].Value = model.Num;
            parameters[4].Value = model.DisCount;
            parameters[5].Value = model.ProPrice;
            parameters[6].Value = model.IsOrders;

            dbhelper.ExcuteCommandReturnInt("TbCat_ADD", CommandType.StoredProcedure, parameters);

            return (int)parameters[0].Value;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TbCat GetModel(int CatID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@CatID", SqlDbType.Int,4)
};
            parameters[0].Value = CatID;

           TbCat model = new TbCat();
           DataSet ds = dbhelper.ExcuteSelectReturnDataSet("TbCat_GetModel", CommandType.StoredProcedure, parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CatID"].ToString() != "")
                {
                    model.CatID = int.Parse(ds.Tables[0].Rows[0]["CatID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Customerid"].ToString() != "")
                {
                    model.Customerid = int.Parse(ds.Tables[0].Rows[0]["Customerid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProID"].ToString() != "")
                {
                    model.ProID = int.Parse(ds.Tables[0].Rows[0]["ProID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Num"].ToString() != "")
                {
                    model.Num = int.Parse(ds.Tables[0].Rows[0]["Num"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DisCount"].ToString() != "")
                {
                    model.DisCount = decimal.Parse(ds.Tables[0].Rows[0]["DisCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProPrice"].ToString() != "")
                {
                    model.ProPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProPrice"].ToString());
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
