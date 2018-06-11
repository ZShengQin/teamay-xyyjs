using System;
using System.Web;

namespace TeamayBase
{
	/// <summary>
	/// 说明：获取查询字符串的类
	/// 编写者：马先光
	/// Date：2006-4
	/// </summary>
	public class QueryString
	{
		public QueryString()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        /// <summary>
        /// 获取当前页面文件名
        /// </summary>
        static public string strHttp { get { return (HttpContext.Current.Request.CurrentExecutionFilePath.Substring(HttpContext.Current.Request.CurrentExecutionFilePath.LastIndexOf("/") + 1).ToString()); } }
 
        /// <summary>
        /// 获取member.aspx页用户状态
        /// </summary>
        static public string GetMemberid { get { return (System.Web.HttpContext.Current.Request.QueryString["memberid"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["memberid"]); } }
		
		/// <summary>
		///获取ID值--use
		/// </summary>
		static public string GetId { get { return (System.Web.HttpContext.Current.Request.QueryString["id"] == null ) ? null : vldInput(System.Web.HttpContext.Current.Request.QueryString["id"]); } }

        /// <summary>
        ///获取URL值
        /// </summary>
        static public string GetURL { get { return (System.Web.HttpContext.Current.Request.QueryString["url"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["url"]); } }
        
        /// <summary>
        ///获取分类Type值
        /// </summary>
        static public string GetTypeid { get { return (System.Web.HttpContext.Current.Request.QueryString["type"] == null) ? null : vldInput(System.Web.HttpContext.Current.Request.QueryString["type"]); } }

        /// <summary>
        /// 获取PayWay
        /// </summary>
        static public string GetPayway { get { return (System.Web.HttpContext.Current.Request.QueryString["payway"] == null) ? null : vldInput(System.Web.HttpContext.Current.Request.QueryString["payway"]); } }

        /// <summary>
		/// 获取搜索类型
		/// </summary>
        static public string GetUsercode { get { return (System.Web.HttpContext.Current.Request.QueryString["usercode"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["usercode"]); } }

		/// <summary>
		/// 获取搜索内容
		/// </summary>
        static public string GetSearchContent { get { return (System.Web.HttpContext.Current.Request.QueryString["SearchContent"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["SearchContent"]); } }

        /// <summary>
        /// 获取登陆页状态
        /// </summary>
        static public string GetAction { get { return (System.Web.HttpContext.Current.Request.QueryString["action"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["action"]); } }

        /// <summary>
        /// 获取后台管理状态
        /// </summary>
        static public string GetFmenu { get { return (System.Web.HttpContext.Current.Request.QueryString["Fmenu"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["Fmenu"]); } }

        /// <summary>
        /// 获取后台管理状态
        /// </summary>
        static public string GetSmenu { get { return (System.Web.HttpContext.Current.Request.QueryString["Smenu"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["Smenu"]); } }

        /// <summary>
        /// 获取日期年
        /// </summary>
        static public string GetC_Year { get { return (System.Web.HttpContext.Current.Request.QueryString["C_Year"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["C_Year"]); } }

        /// <summary>
        /// 获取日期年
        /// </summary>
        static public string GetC_Month { get { return (System.Web.HttpContext.Current.Request.QueryString["C_Month"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["C_Month"]); } }

        /// <summary>
        /// 获取日期年
        /// </summary>
        static public string GetC_Day { get { return (System.Web.HttpContext.Current.Request.QueryString["C_Day"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["C_Day"]); } }
  
        /// <summary>
        /// 获取主页浏览模式
        /// </summary>
        static public string GetViewType { get { return (System.Web.HttpContext.Current.Request.QueryString["distype"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["distype"]); } }

		/// <summary>
		/// 获取分页信息
		/// </summary>
		static public int IntPage { get { return (HttpContext.Current .Request.QueryString["page"] == null) ? 0 : int.Parse(vldInput(HttpContext.Current.Request.QueryString["page"])); } }
        
        static private string vldInput(string strId)
		{
			try
			{
				int.Parse(strId);
				return strId;
			}
			catch { HttpContext.Current.Response.Redirect("Default.aspx"); return ""; }
		}

		static private string vldInput2(string strId)
		{
			return strId.Replace("'","''").Replace("-","－");
		}
	}
}
