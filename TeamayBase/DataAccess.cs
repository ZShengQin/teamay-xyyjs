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
        /// �����ݿ�����
        /// </summary>
        public void Open()
        {
            #region
            cn = new SqlConnection(connectstring);
            cn.Open();
            #endregion
        }


        /// <summary>
        /// �ر����ݿ�����
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
        /// ����DataSet���ݼ�
        /// </summary>
        /// <param name="strSql">SQL���</param>
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
        /// ���DataSet��
        /// </summary>
        /// <param name="ds">DataSet����</param>
        /// <param name="strSql">Sql���</param>
        /// <param name="strTableName">����</param>
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
        /// ����DataView������ͼ
        /// </summary>
        /// <param name="strSql">Sql���</param>
        public DataView GetDv(string strSql)
        {
            #region
            dv = GetDs(strSql).Tables[0].DefaultView;
            return dv;
            #endregion
        }


        /// <summary>
        /// ���DataTable����
        /// </summary>
        /// <param name="strSql">SQL���</param>
        /// <returns></returns>
        public DataTable GetTable(string strSql)
        {
            #region
            return GetDs(strSql).Tables[0];
            #endregion
        }


        /// <summary>
        /// ���һ������
        /// </summary>
        /// <param name="strSql">sql���</param>
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
        /// ��õ�����¼
        /// </summary>
        /// <param name="strSql">sql���</param>
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
        /// ִ��Sql���
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
        /// ִ��SQL��䣬�����ص�һ�е�һ�н��
        /// </summary>
        /// <param name="strSql">SQL���</param>
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
        /// ִ��SQL��䣬������name�ֶεĽ������
        /// </summary>
        /// <param name="strSql">SQL���</param>
        /// <param name="name">�ֶ���</param>
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
