using System;
using System.Web;

namespace TeamayBase
{
	/// <summary>
	/// ˵������ȡ��ѯ�ַ�������
	/// ��д�ߣ����ȹ�
	/// Date��2006-4
	/// </summary>
	public class QueryString
	{
		public QueryString()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

        /// <summary>
        /// ��ȡ��ǰҳ���ļ���
        /// </summary>
        static public string strHttp { get { return (HttpContext.Current.Request.CurrentExecutionFilePath.Substring(HttpContext.Current.Request.CurrentExecutionFilePath.LastIndexOf("/") + 1).ToString()); } }
 
        /// <summary>
        /// ��ȡmember.aspxҳ�û�״̬
        /// </summary>
        static public string GetMemberid { get { return (System.Web.HttpContext.Current.Request.QueryString["memberid"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["memberid"]); } }
		
		/// <summary>
		///��ȡIDֵ--use
		/// </summary>
		static public string GetId { get { return (System.Web.HttpContext.Current.Request.QueryString["id"] == null ) ? null : vldInput(System.Web.HttpContext.Current.Request.QueryString["id"]); } }

        /// <summary>
        ///��ȡURLֵ
        /// </summary>
        static public string GetURL { get { return (System.Web.HttpContext.Current.Request.QueryString["url"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["url"]); } }
        
        /// <summary>
        ///��ȡ����Typeֵ
        /// </summary>
        static public string GetTypeid { get { return (System.Web.HttpContext.Current.Request.QueryString["type"] == null) ? null : vldInput(System.Web.HttpContext.Current.Request.QueryString["type"]); } }

        /// <summary>
        /// ��ȡPayWay
        /// </summary>
        static public string GetPayway { get { return (System.Web.HttpContext.Current.Request.QueryString["payway"] == null) ? null : vldInput(System.Web.HttpContext.Current.Request.QueryString["payway"]); } }

        /// <summary>
		/// ��ȡ��������
		/// </summary>
        static public string GetUsercode { get { return (System.Web.HttpContext.Current.Request.QueryString["usercode"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["usercode"]); } }

		/// <summary>
		/// ��ȡ��������
		/// </summary>
        static public string GetSearchContent { get { return (System.Web.HttpContext.Current.Request.QueryString["SearchContent"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["SearchContent"]); } }

        /// <summary>
        /// ��ȡ��½ҳ״̬
        /// </summary>
        static public string GetAction { get { return (System.Web.HttpContext.Current.Request.QueryString["action"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["action"]); } }

        /// <summary>
        /// ��ȡ��̨����״̬
        /// </summary>
        static public string GetFmenu { get { return (System.Web.HttpContext.Current.Request.QueryString["Fmenu"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["Fmenu"]); } }

        /// <summary>
        /// ��ȡ��̨����״̬
        /// </summary>
        static public string GetSmenu { get { return (System.Web.HttpContext.Current.Request.QueryString["Smenu"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["Smenu"]); } }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        static public string GetC_Year { get { return (System.Web.HttpContext.Current.Request.QueryString["C_Year"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["C_Year"]); } }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        static public string GetC_Month { get { return (System.Web.HttpContext.Current.Request.QueryString["C_Month"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["C_Month"]); } }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        static public string GetC_Day { get { return (System.Web.HttpContext.Current.Request.QueryString["C_Day"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["C_Day"]); } }
  
        /// <summary>
        /// ��ȡ��ҳ���ģʽ
        /// </summary>
        static public string GetViewType { get { return (System.Web.HttpContext.Current.Request.QueryString["distype"] == null) ? null : vldInput2(System.Web.HttpContext.Current.Request.QueryString["distype"]); } }

		/// <summary>
		/// ��ȡ��ҳ��Ϣ
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
			return strId.Replace("'","''").Replace("-","��");
		}
	}
}
