
using System;
using System.IO;
using System.Configuration;
namespace TeamayBase
{
    public sealed class ApplicationLog
    {
        private ApplicationLog()
        {
        }

        /// <summary>
        /// ��¼��־���ı��ļ�
        /// </summary>
        /// <param name="message">��¼������</param>
        public static void Log(string message)
        {
            //������д�����ݿ�
            DataAccess da = new DataAccess();
            da.RunSql("insert into tm_log(message) values('" + message + "')");

            //������д����־�ļ�
            //string fileName = System.Web.HttpContext.Current.Server.MapPath(ConfigurationSettings.AppSettings["Log"]);

            //if (File.Exists(fileName))
            //{
            //    StreamWriter sr = File.AppendText(fileName);
            //    sr.WriteLine("\n");
            //    sr.WriteLine(DateTime.Now.ToString() + message);
            //    sr.Close();
            //}
            //else
            //{
            //    StreamWriter sr = File.CreateText(fileName);
            //    sr.Close();
            //    Log(message);
            //}
        }
    }
}