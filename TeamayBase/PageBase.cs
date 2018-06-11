
using System;
using System.Web;
using System.Web.UI;
using System.ComponentModel;
using System.Data;
namespace TeamayBase
{
    public class PageBase : System.Web.UI.Page
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PageBase()
        {

        }

        protected override void OnPreInit(EventArgs e)
        {
            SingleLogin single = new SingleLogin();
            string domain = Request.Url.Host.ToLower();

            if (domain.IndexOf("localhost") == -1 && domain.IndexOf("cnvedu.com") == -1)
            {
                single.RemoveKey();
                Jscript.AlertAndRefreshParent(domain + "对不起，本程序只能应用于cnvedu.com,如需购买请联系QQ：441031656！", "/");
            }

            //check something
            //int year = DateTime.Now.Year;
            //int month = DateTime.Now.Month;
            //int day = DateTime.Now.Day;
            //if (year != 2010 || month != 10)
            //{
            //    Response.Write("测试阶段，不能更改时间！请将时间更新到2010年10月份！");
            //    Response.End();
            //}
            //else
            //{
            //    if (day > 10)
            //    {
            //        Response.Write("测试时间到期，请付余款。如您已经付款，请联系更新网站安全插件！");
            //        Response.End();
            //    }
            //}

            if (HttpContext.Current.Session["usercode"] == null)
            {
                //Context.Session["SystemError"] = "您还没有登陆或者登陆已经超时！";
                //Context.Response.Redirect("/Login_xk.aspx");
                Jscript.RefreshParent("/Login_xk.aspx");
            }
            
            if(!single.IsLogin(HttpContext.Current.Session["usercode"]))
            {
                Jscript.AlertAndRefreshParent("你的帐号已在别处登陆，你被强迫下线！","/");
            }
            base.OnPreInit(e);
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError(EventArgs e)
        {
            // 获取异常
            Exception ex = Server.GetLastError();

            // 写错误日志文件
            ApplicationLog.Log("Message:" + ex.Message + "\r\nStackTrace" + ex.StackTrace);

            // 转向错误信息页面
            //Context.Session["SystemError"] = ex.Message;
            Jscript.RefreshParent("/Login_xk.aspx");

            Server.ClearError();
        }
    }

}
