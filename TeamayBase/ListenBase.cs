
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace TeamayBase
{

    /// <summary>
    /// ListenBase 的摘要说明
    /// </summary>
    public class ListenBase : System.Web.UI.Page
    {
        public ListenBase()
        {
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
            Session.Clear();
            Context.Response.Redirect("~/Default.aspx");

            Server.ClearError();
        }

        /// <summary>
        /// 验证是否登陆及是否有此页面访问权限
        /// </summary>
        public bool CheckAuthority(string chapterCode)
        {
            chapterCode = chapterCode.Replace(" ", "").Replace("'", "");

            //可以试听
            if (IsFree(chapterCode))
                return true;

            //该章节不可以试听

            //检查用户是否登陆
            if (HttpContext.Current.Session["userid"] == null)
            {
                //Context.Session["SystemError"] = "您还没有登陆或者登陆已经超时！";
                Session.Clear();
                return false;
            }

            SingleLogin single = new SingleLogin();
            if (!single.IsLogin(HttpContext.Current.Session["usercode"]))
            {
                Jscript.AlertAndRefreshParent("你的帐号已在别处登陆，你被强迫下线！", "/");
            }

            //用户已登陆
            string userID = HttpContext.Current.Session["userid"].ToString();
            if (!CheckPayAndTime(chapterCode, userID))
            {
                return false;
            }
            return true;
        }

        //检查该章节是否可以试听
        protected bool IsFree(string chaptercode)
        {
            string isFreeSql = "select isFree from zxd_Cur_type where classcode='" + chaptercode + "'";
            DataAccess da = new DataAccess();
            return da.RunSqlReturn(isFreeSql) == "1";
        }

        //检查该用户是否付费以及时间是否到期
        protected bool CheckPayAndTime(string chapterCode, string userID)
        {
            bool result = false;
            string videoID = GetVideoIDByChapterCode(chapterCode);
            DateTime dateToday = DateTime.Now;
            string getPaiedVideosSql = "select videoID,ExpireDate from jings_UserVideos where user_id=" + userID;
            DataAccess da = new DataAccess();
            SqlDataReader paiedVideosDr = da.GetDataReader(getPaiedVideosSql);
            while (paiedVideosDr.Read())
            {
                if (paiedVideosDr.GetValue(0).ToString() == videoID)
                {
                    if (DateTime.Compare(dateToday, DateTime.Parse(paiedVideosDr.GetValue(1).ToString())) <= 0)
                        result = true;
                    else result = false;
                    break;
                }
            }
            paiedVideosDr.Close();
            return result;
        }

        protected string GetVideoIDByChapterCode(string chapterCode)
        {
            string getVideoIDSql = "select videoID from zxd_Cur_type where classcode='" + chapterCode + "'";
            DataAccess da = new DataAccess();
            return da.RunSqlReturn(getVideoIDSql);
        }
    }
}