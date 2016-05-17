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
  public   class ProBLL
    {
      DataBaseHepler dbhelper = new DataBaseHepler();
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(tbProduct model)
        {
             SqlParameter[] parameters = {
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_name", SqlDbType.NVarChar,200),
					new SqlParameter("@type_id", SqlDbType.Int,4),
					new SqlParameter("@cost_price", SqlDbType.Money,8),
					new SqlParameter("@wholesale_price", SqlDbType.Money,8),
					new SqlParameter("@retail_price", SqlDbType.Money,8),
					new SqlParameter("@units", SqlDbType.NVarChar,50),
					new SqlParameter("@weight", SqlDbType.NVarChar,50),
					new SqlParameter("@material", SqlDbType.NVarChar,50),
					new SqlParameter("@spec", SqlDbType.NVarChar,100),
					new SqlParameter("@upperLimit", SqlDbType.Int,4),
					new SqlParameter("@lowerLimit", SqlDbType.Int,4),
					new SqlParameter("@expiry_date", SqlDbType.DateTime),
					new SqlParameter("@code", SqlDbType.NVarChar,50),
					new SqlParameter("@description", SqlDbType.Text),
					new SqlParameter("@smallimg", SqlDbType.NVarChar,100),
                    new SqlParameter("@PingPaiId",SqlDbType.Int,4),
                    new SqlParameter("@catalogid",SqlDbType.Int,4),
                    new SqlParameter("@discount",SqlDbType.Int,4)

                                         };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.product_name;
            parameters[2].Value = model.type_id;
            parameters[3].Value = model.cost_price;
            parameters[4].Value = model.wholesale_price;
            parameters[5].Value = model.retail_price;
            parameters[6].Value = model.units;
            parameters[7].Value = model.weight;
            parameters[8].Value = model.material;
            parameters[9].Value = model.spec;
            parameters[10].Value = model.upperLimit;
            parameters[11].Value = model.lowerLimit;
            parameters[12].Value = model.expiry_date;
            parameters[13].Value = model.code;
            parameters[14].Value = model.description;
            parameters[15].Value = model.smallimg;
            parameters[16].Value = model.PingPaiId;
            parameters[17].Value = model.Catalogid;
            parameters[18].Value = model.Discount;
            dbhelper.ExcuteCommandReturnInt("tbProduct_ADD", CommandType.StoredProcedure, parameters);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(tbProduct model)
        {
             SqlParameter[] parameters = {
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_name", SqlDbType.NVarChar,200),
					new SqlParameter("@type_id", SqlDbType.Int,4),
					new SqlParameter("@cost_price", SqlDbType.Money,8),
					new SqlParameter("@wholesale_price", SqlDbType.Money,8),
					new SqlParameter("@retail_price", SqlDbType.Money,8),
					new SqlParameter("@units", SqlDbType.NVarChar,50),
					new SqlParameter("@weight", SqlDbType.NVarChar,50),
					new SqlParameter("@material", SqlDbType.NVarChar,50),
					new SqlParameter("@spec", SqlDbType.NVarChar,100),
					new SqlParameter("@upperLimit", SqlDbType.Int,4),
					new SqlParameter("@lowerLimit", SqlDbType.Int,4),
					new SqlParameter("@expiry_date", SqlDbType.DateTime),
					new SqlParameter("@code", SqlDbType.NVarChar,50),
					new SqlParameter("@description", SqlDbType.Text),
					new SqlParameter("@smallimg", SqlDbType.NVarChar,100),
                      new SqlParameter("@PingPaiId",SqlDbType.Int,4),
                       new SqlParameter("@catalogid",SqlDbType.Int,4),
                        new SqlParameter("@discount",SqlDbType.Int,4)
                                         };
            parameters[0].Value = model.product_id;
            parameters[1].Value = model.product_name;
            parameters[2].Value = model.type_id;
            parameters[3].Value = model.cost_price;
            parameters[4].Value = model.wholesale_price;
            parameters[5].Value = model.retail_price;
            parameters[6].Value = model.units;
            parameters[7].Value = model.weight;
            parameters[8].Value = model.material;
            parameters[9].Value = model.spec;
            parameters[10].Value = model.upperLimit;
            parameters[11].Value = model.lowerLimit;
            parameters[12].Value = model.expiry_date;
            parameters[13].Value = model.code;
            parameters[14].Value = model.description;
            parameters[15].Value = model.smallimg;
            parameters[16].Value = model.PingPaiId;
            parameters[17].Value = model.Catalogid;
            parameters[18].Value = model.Discount;
           return  dbhelper.ExcuteCommandReturnInt("tbProduct_Update", CommandType.StoredProcedure, parameters);

          
        }


      //更新库存
        public int Update_upperlimit(int proid)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@product_id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = proid;
            return dbhelper.ExcuteCommandReturnInt("change_pro_upperlimit", CommandType.StoredProcedure, parameters);


        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public tbProduct GetModel(int product_id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@product_id", SqlDbType.Int,4)
             };
            parameters[0].Value = product_id;
            tbProduct model = new tbProduct();
            DataSet ds = dbhelper.ExcuteSelectReturnDataSet("tbProduct_GetModel", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["product_id"].ToString() != "")
                {
                    model.product_id = int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
                }
                model.product_name = ds.Tables[0].Rows[0]["product_name"].ToString();
                if (ds.Tables[0].Rows[0]["type_id"].ToString() != "")
                {
                    model.type_id = int.Parse(ds.Tables[0].Rows[0]["type_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cost_price"].ToString() != "")
                {
                    model.cost_price = decimal.Parse(ds.Tables[0].Rows[0]["cost_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["wholesale_price"].ToString() != "")
                {
                    model.wholesale_price = decimal.Parse(ds.Tables[0].Rows[0]["wholesale_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["retail_price"].ToString() != "")
                {
                    model.retail_price = decimal.Parse(ds.Tables[0].Rows[0]["retail_price"].ToString());
                }
                model.units = ds.Tables[0].Rows[0]["units"].ToString();
                model.weight = ds.Tables[0].Rows[0]["weight"].ToString();
                model.material = ds.Tables[0].Rows[0]["material"].ToString();
                model.spec = ds.Tables[0].Rows[0]["spec"].ToString();
                if (ds.Tables[0].Rows[0]["upperLimit"].ToString() != "")
                {
                    model.upperLimit = int.Parse(ds.Tables[0].Rows[0]["upperLimit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lowerLimit"].ToString() != "")
                {
                    model.lowerLimit = int.Parse(ds.Tables[0].Rows[0]["lowerLimit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["expiry_date"].ToString() != "")
                {
                    model.expiry_date = DateTime.Parse(ds.Tables[0].Rows[0]["expiry_date"].ToString());
                }
                model.code = ds.Tables[0].Rows[0]["code"].ToString();
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                model.smallimg = ds.Tables[0].Rows[0]["smallimg"].ToString();
                model.PingPaiId = int.Parse(ds.Tables[0].Rows[0]["PingPaiId"].ToString());
                model.Catalogid = int.Parse(ds.Tables[0].Rows[0]["catalogid"].ToString());
                model.Discount = decimal.Parse(ds.Tables[0].Rows[0]["discount"].ToString());
                model.Adddate = DateTime.Parse(ds.Tables[0].Rows[0]["addDate"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        ///  增加一条产品图片数据
        /// </summary>
        public int proImagsAdd(tbProimgs model)
        {
           
            SqlParameter[] parameters = {
					new SqlParameter("@imgID", SqlDbType.Int,4),
					new SqlParameter("@Proid", SqlDbType.Int,4),
					new SqlParameter("@ImgName", SqlDbType.NVarChar,200)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.Proid;
            parameters[2].Value = model.ImgName;

            dbhelper.ExcuteCommandReturnInt("tbProimgs_ADD", CommandType.StoredProcedure, parameters);
            return (int)parameters[0].Value;
        }

       /// <summary>
       /// 修改产品图片信息
       /// </summary>
        /// <param name="model">tbProimgs对象</param>
        /// <returns>int</returns>
        public int proimgsUpdate(tbProimgs model)
        {
         
            SqlParameter[] parameters = {
					new SqlParameter("@imgID", SqlDbType.Int,4),
					new SqlParameter("@Proid", SqlDbType.Int,4),
					new SqlParameter("@ImgName", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.imgID;
            parameters[1].Value = model.Proid;
            parameters[2].Value = model.ImgName;

           return  dbhelper.ExcuteCommandReturnInt("tbProimgs_Update", CommandType.StoredProcedure, parameters);

           
        }
       
        /// <summary>
        /// 根据图片编号查询图片详细模型
        /// </summary>
        /// <param name="imgsid">图片编号</param>
        /// <returns>tbProimgs</returns>
        public tbProimgs proImgsGetModel(string imgID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@imgID", SqlDbType.Int,4)
};
            parameters[0].Value = imgID;

            tbProimgs model = new tbProimgs();
            DataSet ds = dbhelper.ExcuteSelectReturnDataSet("tbProimgs_GetModel", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["imgID"].ToString() != "")
                {
                    model.imgID = int.Parse(ds.Tables[0].Rows[0]["imgID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Proid"].ToString() != "")
                {
                    model.Proid = int.Parse(ds.Tables[0].Rows[0]["Proid"].ToString());
                }
                model.ImgName = ds.Tables[0].Rows[0]["ImgName"].ToString();
                model.Product_name = ds.Tables[0].Rows[0]["Product_name"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        
        }


      /// <summary>
      /// 产品点评添加
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
        public int proLevelWords(tbLevelwords model)
        {
           
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@proid", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@LevelWords", SqlDbType.NVarChar,500),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@isDel", SqlDbType.Bit,1)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.proid;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.LevelWords;
            parameters[4].Value = model.type;
            parameters[5].Value = model.createdate;
            parameters[6].Value = model.isDel;

            int count= dbhelper.ExcuteCommandReturnInt("tbLevelwords_ADD", CommandType.StoredProcedure, parameters);
            return (int)parameters[0].Value;
        
        }

    }
}
