using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model.Orders;
using DAL;
namespace BLL
{
  public  class OrderBLL
    {
      DataBaseHepler dbhelper = new DataBaseHepler();

      /// <summary>
      /// 订单基本信息添加
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public int tbOrders_ADD(tbOrders model)
      {
          SqlParameter[] pars = new SqlParameter[]{
          new SqlParameter("@OrderID",SqlDbType.Int,4),
          new SqlParameter("@Customerid",model.Customerid),
          new SqlParameter("@Address",model.Address),
          new SqlParameter("@totalMoney",model.totalMoney),
          new SqlParameter("@Postmoney",model.Postmoney),
          new SqlParameter("@salesincome",model.salesincome),
          new SqlParameter("@createdate",model.createdate),
          new SqlParameter("@remark",model.remark)
          };
          pars[0].Direction = ParameterDirection.Output;

         int count=  dbhelper.ExcuteCommandReturnInt("tbOrders_ADD", CommandType.StoredProcedure, pars);
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
      ///  增加一条订单产品数据
      /// </summary>
      public int tbOrdersPros_Add(tbOrdersPros model)
      {
         
          SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@Discount", SqlDbType.Money,8),
					new SqlParameter("@ProPrice", SqlDbType.Money,8),
					new SqlParameter("@ProCount", SqlDbType.Int,4)};
          parameters[0].Direction = ParameterDirection.Output;
          parameters[1].Value = model.OrderID;
          parameters[2].Value = model.ProID;
          parameters[3].Value = model.Discount;
          parameters[4].Value = model.ProPrice;
          parameters[5].Value = model.ProCount;

          dbhelper.ExcuteCommandReturnInt("tbOrdersPros_ADD", CommandType.StoredProcedure, parameters);

          return (int)parameters[0].Value;
      }

      /// <summary>
      ///  更新一条订单产品数据
      /// </summary>
      public int tbOrdersPros_Update(tbOrdersPros model)
      {
        
          SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@Discount", SqlDbType.Money,8),
					new SqlParameter("@ProPrice", SqlDbType.Money,8),
					new SqlParameter("@ProCount", SqlDbType.Int,4)};
          parameters[0].Value = model.ID;
          parameters[1].Value = model.OrderID;
          parameters[2].Value = model.ProID;
          parameters[3].Value = model.Discount;
          parameters[4].Value = model.ProPrice;
          parameters[5].Value = model.ProCount;

         return  dbhelper.ExcuteCommandReturnInt("tbOrdersPros_Update", CommandType.StoredProcedure, parameters);

       
      }

      /// <summary>
      /// 得到一个订单产品对象实体
      /// </summary>
      public tbOrdersPros tbOrdersPros_GetModel(int ID)
      {
          SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
          parameters[0].Value = ID;

          tbOrdersPros model = new tbOrdersPros();

          DataSet ds = dbhelper.ExcuteSelectReturnDataSet("tbOrdersPros_GetModel", CommandType.StoredProcedure, parameters);
          if (ds.Tables[0].Rows.Count > 0)
          {
              if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
              {
                  model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
              }
              if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
              {
                  model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
              }
              if (ds.Tables[0].Rows[0]["ProID"].ToString() != "")
              {
                  model.ProID = int.Parse(ds.Tables[0].Rows[0]["ProID"].ToString());
              }
              if (ds.Tables[0].Rows[0]["Discount"].ToString() != "")
              {
                  model.Discount = decimal.Parse(ds.Tables[0].Rows[0]["Discount"].ToString());
              }
              if (ds.Tables[0].Rows[0]["ProPrice"].ToString() != "")
              {
                  model.ProPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProPrice"].ToString());
              }
              if (ds.Tables[0].Rows[0]["ProCount"].ToString() != "")
              {
                  model.ProCount = int.Parse(ds.Tables[0].Rows[0]["ProCount"].ToString());
              }

             
              return model;
          }
          else
          {
              return null;
          }
      }

      /// <summary>
      /// 通过订单编号返回订单视图对象
      /// </summary>
      /// <param name="orderid"></param>
      /// <returns></returns>
      public tbOrders getOrdersViewModel(int orderid)
      {
          SqlParameter[] pars = new SqlParameter[]{
        new SqlParameter("@OrderID",orderid)
       };
          
        DataSet ds=  dbhelper.ExcuteSelectReturnDataSet("tbOrders_GetModel", CommandType.StoredProcedure, pars);

        tbOrders model = new tbOrders();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
            {
                model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
            }
            model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
            if (ds.Tables[0].Rows[0]["Customerid"].ToString() != "")
            {
                model.Customerid = int.Parse(ds.Tables[0].Rows[0]["Customerid"].ToString());
            }
            model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
            if (ds.Tables[0].Rows[0]["totalMoney"].ToString() != "")
            {
                model.totalMoney = decimal.Parse(ds.Tables[0].Rows[0]["totalMoney"].ToString());
            }
            if (ds.Tables[0].Rows[0]["Postmoney"].ToString() != "")
            {
                model.Postmoney = decimal.Parse(ds.Tables[0].Rows[0]["Postmoney"].ToString());
            }
            if (ds.Tables[0].Rows[0]["Logid"].ToString() != "")
            {
                model.Logid = int.Parse(ds.Tables[0].Rows[0]["Logid"].ToString());
            }
            model.LogNumber = ds.Tables[0].Rows[0]["LogNumber"].ToString();
            model.auditinguser = ds.Tables[0].Rows[0]["auditinguser"].ToString();
            if (ds.Tables[0].Rows[0]["salesincome"].ToString() != "")
            {
                model.salesincome = decimal.Parse(ds.Tables[0].Rows[0]["salesincome"].ToString());
            }
            if (ds.Tables[0].Rows[0]["userid"].ToString() != "")
            {
                model.userid = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
            }
            if (ds.Tables[0].Rows[0]["createdate"].ToString() != "")
            {
                model.createdate = DateTime.Parse(ds.Tables[0].Rows[0]["createdate"].ToString());
            }
            model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
            model.sendUser = ds.Tables[0].Rows[0]["sendUser"].ToString();
            if (ds.Tables[0].Rows[0]["state"].ToString() != "")
            {
                model.State = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
            }
            model.Username = ds.Tables[0].Rows[0]["username"].ToString();
            model.Tel = ds.Tables[0].Rows[0]["tel"].ToString();
            model.Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
            model.StateName = ds.Tables[0].Rows[0]["stateName"].ToString();
            return model;
        }
        else
        {
            return null;
        }
      }


      /// <summary>
      /// 把此客户在购物车中产品提交到订单产品表
      /// </summary>
      /// <param name="customerid"></param>
      /// <param name="ordersid"></param>
      /// <returns>受影响行数</returns>
      public int setorderprosbycid(int customerid, int ordersid)
      {
          SqlParameter[] pars = new SqlParameter[]{
              new SqlParameter("@Customerid",customerid),
              new SqlParameter("@orderid",ordersid)
          };
        return   dbhelper.ExcuteCommandReturnInt("setorderprosbycid", CommandType.StoredProcedure, pars);
      }
    }
}
