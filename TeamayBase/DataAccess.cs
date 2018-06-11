using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TeamayBase
{
    public class DataAccess
    {
        public string connectstring = ConfigurationManager.ConnectionStrings["cnveduConnectionString"].ConnectionString;
        private SqlConnection cn;
        private SqlDataAdapter sda;
        private SqlDataReader sdr;
        private SqlCommand cmd;
        private DataSet ds;			
        private DataView dv;			

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void Open()
        {
            #region
            cn = new SqlConnection(connectstring);
            cn.Open();
            #endregion
        }


        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            #region
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
            }
            #endregion
        }


        /// <summary>
        /// 返回DataSet数据集
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        public DataSet GetDs(string strSql)
        {
            #region
            Open();
            sda = new SqlDataAdapter(strSql, cn);
            ds = new DataSet();
            sda.Fill(ds);
            Close();
            return ds;
            #endregion
        }

        /// <summary>
        /// 添加DataSet表
        /// </summary>
        /// <param name="ds">DataSet对象</param>
        /// <param name="strSql">Sql语句</param>
        /// <param name="strTableName">表名</param>
        public void GetDs(DataSet ds, string strSql, string strTableName)
        {
            #region
            Open();
            sda = new SqlDataAdapter(strSql, cn);
            sda.Fill(ds, strTableName);
            Close();
            #endregion
        }


        /// <summary>
        /// 返回DataView数据视图
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        public DataView GetDv(string strSql)
        {
            #region
            dv = GetDs(strSql).Tables[0].DefaultView;
            return dv;
            #endregion
        }


        /// <summary>
        /// 获得DataTable对象
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public DataTable GetTable(string strSql)
        {
            #region
            return GetDs(strSql).Tables[0];
            #endregion
        }


        /// <summary>
        /// 获得一行数据
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(string strSql)
        {
            #region
            Open();
            try
            {
                cmd = new SqlCommand(strSql, cn);
                sdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                return sdr;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
        }

        /// <summary>
        /// 获得单个记录
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public object GetSingeData(string strSql)
        {
            #region
            Open();
            try
            {
                cmd = new SqlCommand(strSql, cn);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Close();
            }
            #endregion
        }


        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        public void RunSql(string strSql)
        {
            #region
            Open();
            cmd = new SqlCommand(strSql, cn);
            cmd.ExecuteNonQuery();
            Close();
            #endregion
        }



        /// <summary>
        /// 执行SQL语句，并返回第一行第一列结果
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public string RunSqlReturn(string strSql)
        {
            #region
            string strReturn = "";
            Open();
            try
            {
                cmd = new SqlCommand(strSql, cn);
                strReturn = cmd.ExecuteScalar().ToString();
            }
            catch 
            {
                strReturn = null;
            }
            Close();
            return strReturn;
            #endregion
        }

        /// <summary>
        /// 执行SQL语句，并返回name字段的结果集合
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public List<string>  RunSqlReturn(string strSql,string name )
        {
            #region
            List<string> strReturn = new List<string>();
            Open();
            try
            {
                cmd = new SqlCommand(strSql, cn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    strReturn.Add(reader[name] as string);
                }
            }
            catch
            {
                strReturn = null;
            }
            Close();
            return strReturn;
            #endregion
        }


    }
}
