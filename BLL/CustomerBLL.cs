using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.Customer;
using DAL;
namespace BLL
{

  public  class CustomerBLL
    {
      DataBaseHepler dbhelper = new DataBaseHepler();
       
        /// <summary>
        ///  增加一条数据
        /// </summary>
      public int CType_Add(Model.Customer.tbCType model)
        {
            
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,20),
					new SqlParameter("@isLock", SqlDbType.Bit,1)};

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.TypeName;
            parameters[2].Value = model.isLock;

            dbhelper.ExcuteCommandReturnInt("tbCType_ADD", CommandType.StoredProcedure, parameters);
          
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int CType_Update(Model.Customer.tbCType model)
        {
          
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,20),
					new SqlParameter("@isLock", SqlDbType.Bit,1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.TypeName;
            parameters[2].Value = model.isLock;

           return dbhelper.ExcuteCommandReturnInt("tbCType_Update", CommandType.StoredProcedure, parameters);
          
           
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Customer.tbCType CType_GetModel(int id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            Model.Customer.tbCType model = new Model.Customer.tbCType();
            DataSet ds = dbhelper.ExcuteSelectReturnDataSet("tbCType_GetModel", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
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



        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(Model.Customer.tbCustomer model)
        {
          
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.NVarChar,20),
					new SqlParameter("@password", SqlDbType.NVarChar,20),
					new SqlParameter("@types", SqlDbType.Int,4),
					new SqlParameter("@c_name", SqlDbType.NVarChar,20),
					new SqlParameter("@c_code", SqlDbType.NVarChar,20),
					new SqlParameter("@tel", SqlDbType.NVarChar,12),
					new SqlParameter("@mobile", SqlDbType.NVarChar,11),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@link_men", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@remark", SqlDbType.NVarChar,300),
					new SqlParameter("@rank", SqlDbType.NVarChar,20),
					new SqlParameter("@state", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.username;
            parameters[2].Value = model.password;
            parameters[3].Value = model.types;
            parameters[4].Value = model.c_name;
            parameters[5].Value = model.c_code;
            parameters[6].Value = model.tel;
            parameters[7].Value = model.mobile;
            parameters[8].Value = model.email;
            parameters[9].Value = model.link_men;
            parameters[10].Value = model.address;
            parameters[11].Value = model.remark;
            parameters[12].Value = model.rank;
            parameters[13].Value = model.state;
            dbhelper.ExcuteCommandReturnInt("tbCustomer_ADD", CommandType.StoredProcedure, parameters);
                    
            return (int)parameters[0].Value;
        }


        ///  增加一条供应商数据
        /// </summary>
        public int supplierAdd(Model.Customer.tbCustomer model)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.NVarChar,20),
					new SqlParameter("@password", SqlDbType.NVarChar,20),
					new SqlParameter("@types", SqlDbType.Int,4),
					new SqlParameter("@c_name", SqlDbType.NVarChar,20),
					new SqlParameter("@tel", SqlDbType.NVarChar,12),
					new SqlParameter("@mobile", SqlDbType.NVarChar,11),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@link_men", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@remark", SqlDbType.NVarChar,300),
                    new SqlParameter("@PinPai", SqlDbType.NVarChar,300),				
					new SqlParameter("@ProName", SqlDbType.NVarChar,2000)
                                        
                                        
                                        };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.username;
            parameters[2].Value = model.password;
            parameters[3].Value = model.types;
            parameters[4].Value = model.c_name;
           
            parameters[5].Value = model.tel;
            parameters[6].Value = model.mobile;
            parameters[7].Value = model.email;
            parameters[8].Value = model.link_men;
            parameters[9].Value = model.address;
            parameters[10].Value = model.remark;          
           
            parameters[11].Value = model.PinPai;
            parameters[12].Value = model.ProName;

            dbhelper.ExcuteCommandReturnInt("tbSupplierCustomer_ADD", CommandType.StoredProcedure, parameters);

            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(Model.Customer.tbCustomer model)
        {
            
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.NVarChar,20),
					new SqlParameter("@password", SqlDbType.NVarChar,20),
					new SqlParameter("@types", SqlDbType.Int,4),
					new SqlParameter("@c_name", SqlDbType.NVarChar,20),
					new SqlParameter("@c_code", SqlDbType.NVarChar,20),
					new SqlParameter("@tel", SqlDbType.NVarChar,12),
					new SqlParameter("@mobile", SqlDbType.NVarChar,11),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@link_men", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@remark", SqlDbType.NVarChar,300),
					new SqlParameter("@rank", SqlDbType.NVarChar,20),
					new SqlParameter("@state", SqlDbType.Int,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.username;
            parameters[2].Value = model.password;
            parameters[3].Value = model.types;
            parameters[4].Value = model.c_name;
            parameters[5].Value = model.c_code;
            parameters[6].Value = model.tel;
            parameters[7].Value = model.mobile;
            parameters[8].Value = model.email;
            parameters[9].Value = model.link_men;
            parameters[10].Value = model.address;
            parameters[11].Value = model.remark;
            parameters[12].Value = model.rank;
            parameters[13].Value = model.state;
            return  dbhelper.ExcuteCommandReturnInt("tbCustomer_Update", CommandType.StoredProcedure, parameters);
           
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Customer.tbCustomer GetModel(int id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            Model.Customer.tbCustomer model = new Model.Customer.tbCustomer();

            DataSet ds = dbhelper.ExcuteSelectReturnDataSet("getview_CustomerModel", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.username = ds.Tables[0].Rows[0]["username"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                if (ds.Tables[0].Rows[0]["types"].ToString() != "")
                {
                    model.types = int.Parse(ds.Tables[0].Rows[0]["types"].ToString());
                }
                model.c_name = ds.Tables[0].Rows[0]["c_name"].ToString();
                model.c_code = ds.Tables[0].Rows[0]["c_code"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                model.mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.link_men = ds.Tables[0].Rows[0]["link_men"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                model.rank = ds.Tables[0].Rows[0]["rank"].ToString();
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                model.Typename = ds.Tables[0].Rows[0]["Typename"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
