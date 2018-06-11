using System;
using System.Web;

namespace TeamayBase
{
    public class UsersInfo
    {
        /// <summary>
        /// 返回用户ID
        /// </summary>
        static public string GetUserId
        {
            #region
            get
            {
                return (HttpContext.Current.Request.Cookies["userid"] == null) ? null : HttpContext.Current.Request.Cookies["userid"].Value;
            }
            #endregion
        }

        /// <summary>
        /// 返回用户名
        /// </summary>
        static public string GetUserName
        {
            #region
            get
            {
                return (HttpContext.Current.Request.Cookies["username"] == null) ? null : HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies["username"].Value);
            }
            #endregion
        }
        
        /// <summary>
        /// 返回发贴时长权限
        /// </summary>
        static public string GetcommTimerout
        {
            #region
            get
            {
                return (HttpContext.Current.Request.Cookies["blog_commTimerout"] == null) ? null : HttpContext.Current.Request.Cookies["blog_commTimerout"].Value;
            }
            #endregion
        }

        /// <summary>
        /// 返回用户权限
        /// </summary>
        static public string GetUserCode
        {
            #region
            get
            {
                return (HttpContext.Current.Request.Cookies["usercode"] == null) ? HttpContext.Current.Application["GuestCode"].ToString() : HttpContext.Current.Request.Cookies["usercode"].Value;
            }
            #endregion
        }

        /// <summary>
        /// 返回后台管理状态
        /// </summary>
        static public string GetmemhashKey
        {
            #region
            get
            {
                return (HttpContext.Current.Request.Cookies["memhashKey"] == null) ? null : HttpContext.Current.Request.Cookies["memhashKey"].Value;
            }
            #endregion
        }

        /// <summary>
        /// 在线访客
        /// </summary>
        static public string GetOnline
        {
            #region
            get
            {
                return (HttpContext.Current.Request.Cookies["online"] == null) ? null : HttpContext.Current.Request.Cookies["online"].Value;
            }
            #endregion
        } 
    }
}
