
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
        /// ���캯��
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
                Jscript.AlertAndRefreshParent(domain + "�Բ��𣬱�����ֻ��Ӧ����cnvedu.com,���蹺������ϵQQ��441031656��", "/");
            }

            //check something
            //int year = DateTime.Now.Year;
            //int month = DateTime.Now.Month;
            //int day = DateTime.Now.Day;
            //if (year != 2010 || month != 10)
            //{
            //    Response.Write("���Խ׶Σ����ܸ���ʱ�䣡�뽫ʱ����µ�2010��10�·ݣ�");
            //    Response.End();
            //}
            //else
            //{
            //    if (day > 10)
            //    {
            //        Response.Write("����ʱ�䵽�ڣ��븶�������Ѿ��������ϵ������վ��ȫ�����");
            //        Response.End();
            //    }
            //}

            if (HttpContext.Current.Session["usercode"] == null)
            {
                //Context.Session["SystemError"] = "����û�е�½���ߵ�½�Ѿ���ʱ��";
                //Context.Response.Redirect("/Login_xk.aspx");
                Jscript.RefreshParent("/Login_xk.aspx");
            }
            
            if(!single.IsLogin(HttpContext.Current.Session["usercode"]))
            {
                Jscript.AlertAndRefreshParent("����ʺ����ڱ𴦵�½���㱻ǿ�����ߣ�","/");
            }
            base.OnPreInit(e);
        }

        /// <summary>
        /// �쳣����
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError(EventArgs e)
        {
            // ��ȡ�쳣
            Exception ex = Server.GetLastError();

            // д������־�ļ�
            ApplicationLog.Log("Message:" + ex.Message + "\r\nStackTrace" + ex.StackTrace);

            // ת�������Ϣҳ��
            //Context.Session["SystemError"] = ex.Message;
            Jscript.RefreshParent("/Login_xk.aspx");

            Server.ClearError();
        }
    }

}
