
using System;
using System.Web;
using System.Web.UI;
using System.ComponentModel;
using System.Data;
namespace TeamayBase
{
    public class AdminBase : System.Web.UI.Page
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public AdminBase()
        {

        }

        protected override void OnPreInit(EventArgs e)
        {
            //check something
            SingleLogin single = new SingleLogin();
            string domain = Request.Url.Host.ToLower();

            //if (domain.IndexOf("localhost") == -1 && domain.IndexOf("cnvedu.com") == -1)
            //{
            //    single.RemoveKey();
            //    Jscript.AlertAndRefreshParent(domain + "对不起，本程序只能应用于cnvedu.com,如需购买请联系QQ：441031656！", "/");
            //}
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
            if (HttpContext.Current.Session["Admin"] == null)
            {
                Context.Response.Redirect("Default.aspx");
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
            ApplicationLog.Log("Admin___________________Message:" + ex.Message + "\r\nStackTrace" + ex.StackTrace);

            // 转向错误信息页面
            //Context.Session["SystemError"] = ex.Message;
            //Session.Clear();
            Jscript.AlertAndRedirect("有异常发生，可能由于您登录已超时，请重新尝试。", "main.htm");
            //Context.Response.Redirect("main.htm");

            Server.ClearError();
        }

        /// <summary>
        /// 验证是否登陆及是否有此页面访问权限
        /// </summary>
        public void CheckAuthority(string vcode)
        {
            //
            //检查用户是否登陆
            //
            if (HttpContext.Current.Session["AdminPurview"] == null)
            {
                //Context.Session["SystemError"] = "您还没有登陆或者登陆已经超时！";
                Session.Clear();
                Context.Response.Redirect("Default.aspx");
            }

            string AdminPurview = HttpContext.Current.Session["AdminPurview"].ToString();
            if (AdminPurview.IndexOf(vcode) == -1)
            {
                //Context.Response.Redirect("Main.aspx");
                Jscript.RefreshParent("Main.aspx");
            }
            //
            //检查用户是否可以访问此页面
            //
            //if (!this.IsPostBack)
            //{
            //    string pageName = Context.Request.FilePath.Substring(Request.FilePath.LastIndexOf("/") + 1, Request.FilePath.LastIndexOf(".") - Request.FilePath.LastIndexOf("/") - 1);
            //    string loginID = Context.Session["LoginID"].ToString();
            //    SystemBusiness systemBusiness = new SystemBusiness();
            //    if (!systemBusiness.CheckRight(loginID, pageName))
            //    {
            //        Context.Session["SystemError"] = "您没有权限访问此页面！";
            //        Context.Response.Redirect("Main.aspx");
            //    }
            //}
        }
    }

}
