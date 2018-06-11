using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;


namespace TeamayBase
{

    /// <summary>
    /// ListenBase 的摘要说明
    /// </summary>
    public class SingleLogin
    {

        private readonly string appKey = "online";
        private readonly string logout = "{$}";

        public SingleLogin() { }

        /// <summary>
        /// 用户登陆操作
        /// </summary>
        /// <param name="id">为用户ID或用户名这个必须是用户的唯一标识</param>
        public void UserLogin(object id)
        {
            System.Collections.Hashtable ht = (System.Collections.Hashtable)HttpContext.Current.Application[appKey];
            if (ht == null) ht = new System.Collections.Hashtable();

            System.Collections.IDictionaryEnumerator IDE = ht.GetEnumerator();

            while (IDE.MoveNext())
            {
                if (IDE.Value.ToString().Equals(id.ToString()))
                {
                    ht[IDE.Key.ToString()] = logout;
                    break;
                }
            }

            ht[HttpContext.Current.Session.SessionID] = id.ToString();
            HttpContext.Current.Application.Lock();
            HttpContext.Current.Application[appKey] = ht;
            HttpContext.Current.Application.UnLock();
        }

        /// <summary>
        /// 判断某用户是否已经登陆 
        /// </summary>
        /// <param name="id">为用户ID或用户名这个必须是用户的唯一标识</param>
        /// <returns>true为没有登陆 flase为被迫下线</returns>
        public bool IsLogin(object id)
        {
            bool flag = true;
            string uid = id.ToString();
            System.Collections.Hashtable ht = (System.Collections.Hashtable)HttpContext.Current.Application[appKey];
            if (ht != null)
            {
                System.Collections.IDictionaryEnumerator IDE = ht.GetEnumerator();
                while (IDE.MoveNext())
                {
                    //找到自己的登陆ID
                    if (IDE.Key.ToString().Equals(HttpContext.Current.Session.SessionID))
                    {
                        //判断用户是否被注销
                        if (IDE.Value.ToString().Equals(logout))
                        {
                            ht.Remove(HttpContext.Current.Session.SessionID);
                            HttpContext.Current.Application.Lock();
                            HttpContext.Current.Application[appKey] = ht;
                            HttpContext.Current.Application.UnLock();
                            HttpContext.Current.Session.RemoveAll();
                            //HttpContext.Current.Response.Write("<script type='text/javascript'>alert('你的帐号已在别处登陆，你被强迫下线！')</script>");
                            flag = false;
                        }
                        break;
                    }
                }
            }
            return flag;
        }

        public void RemoveKey()
        {
            System.Collections.Hashtable ht = (System.Collections.Hashtable)HttpContext.Current.Application[appKey];
            if (ht != null)
            {

                ht.Remove(HttpContext.Current.Session.SessionID);
                HttpContext.Current.Application.Lock();
                HttpContext.Current.Application[appKey] = ht;
                HttpContext.Current.Application.UnLock();
            }
        }
    }
}