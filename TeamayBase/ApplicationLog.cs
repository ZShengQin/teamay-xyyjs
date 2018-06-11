
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
        /// 记录日志至文本文件
        /// </summary>
        /// <param name="message">记录的内容</param>
        public static void Log(string message)
        {
            //将错误写到数据库
            DataAccess da = new DataAccess();
            da.RunSql("insert into tm_log(message) values('" + message + "')");

            //将错误写到日志文件
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