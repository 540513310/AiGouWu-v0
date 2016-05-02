using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DAL
{
    public class DataBaseHepler
    {
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        public string ConnString {
            get {
                //return @"Data Source=Tiger-PC\TIGERME;Initial Catalog=MyB2CDb; User ID=sa;Pwd=123456";
                return System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            }


        }

        /// <summary>
        /// 执行一个Sql命令或者存储过程实现对数据库更改
        /// </summary>
        /// <param name="CommandText">insert,update或者delete相关命令或存储过程名</param>
        /// <param name="type">命令类型</param>
        /// <param name="pars">参数</param>
        /// <returns>受影响的行数int</returns>
        public int ExcuteCommandReturnInt(string CommandText, CommandType type, SqlParameter[] pars)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {

                SqlCommand cmd = new SqlCommand(CommandText, conn);
                cmd.CommandType = type;
                if (pars != null && pars.Length > 0)
                {
                    foreach (SqlParameter p in pars)
                    {
                        cmd.Parameters.Add(p);
                    }
                }

                int count = cmd.ExecuteNonQuery();

                return count;
            }
            catch (Exception ex)
            {

                return 0;

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        
        }

        
        /// <summary>
        /// 执行一个Select语句或者相应的存储过程实现返回数据集合DataSet
        /// </summary>
        /// <param name="SelectStr">执行一个Select语句或者相应的存储过程</param>
        /// <param name="type">指定命令类型</param>
        /// <param name="pars">相应参数集合</param>
        /// <returns>DataSet</returns>
        public DataSet ExcuteSelectReturnDataSet(string SelectStr, CommandType type, SqlParameter[] pars)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConnString);            
            SqlDataAdapter sda = new SqlDataAdapter(SelectStr, conn);
            if (pars != null && pars.Length > 0)
            {
                foreach (SqlParameter p in pars)
                {
                    sda.SelectCommand.Parameters.Add(p);
                }
            }
            sda.SelectCommand.CommandType = type;
            sda.Fill(ds);
            return ds;        
        }

        /// <summary>
        /// 执行一个Select SQL语句 返回一个DataSet
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <returns></returns>
        public DataSet ExcuteSelectReturnDataSet(string SelectStr)
        {
            DataSet ds = new DataSet();
            SqlConnection con=new SqlConnection(ConnString);
            SqlDataAdapter sda = new SqlDataAdapter(SelectStr, con);
            sda.Fill(ds);
            return ds;        
        }

        /// <summary>
        /// 执行一个Select语句或者相应的存储过程实现返回数据集合DataTable
        /// </summary>
        /// <param name="SelectStr">执行一个Select语句或者相应的存储过程</param>
        /// <param name="type">指定命令类型</param>
        /// <param name="pars">参数</param>
        /// <returns>DataTable</returns>
        public DataTable ExcuteSelectReturnDataTable(string SelectStr,CommandType type,SqlParameter[]pars)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnString);
            SqlDataAdapter sda = new SqlDataAdapter(SelectStr, con);
            if (pars != null && pars.Length > 0)
            {
                foreach (SqlParameter p in pars)
                {
                    sda.SelectCommand.Parameters.Add(p);
                }
            }
            sda.SelectCommand.CommandType = type;
            sda.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 执行一个Select语句或者相应存储过程返回一个数据阅读器对象
        /// </summary>
        /// <param name="cmdText">Select语句或者相应存储过程</param>
        /// <param name="type">命令类型</param>
        /// <param name="pars">参数集合</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader SelectSqlReturnDataReader(string cmdText, CommandType type, SqlParameter[] pars)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            try
            {

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                if (pars != null && pars.Length > 0)
                {
                    foreach (SqlParameter p in pars)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                cmd.CommandType = type;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 执行一个Select语句或者相应存储过程返回一个对象(值)
        /// </summary>
        /// <param name="cmdText">Select语句或者相应存储过程</param>
        /// <param name="type">命令类型</param>
        /// <param name="pars">参数集合</param>
        /// <returns>object</returns>
        public object SelectSqlReturnObject(string cmdText, CommandType type, SqlParameter[] pars)
        {
            SqlConnection con = new SqlConnection(ConnString);
            try
            {
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(cmdText, con);

                if (pars != null && pars.Length > 0)
                {
                    foreach (SqlParameter p in pars)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                cmd.CommandType = type;
                object obj = cmd.ExecuteScalar();
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
            }



        }



    }
}
