
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
        /// ���캯��
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
            //    Jscript.AlertAndRefreshParent(domain + "�Բ��𣬱�����ֻ��Ӧ����cnvedu.com,���蹺������ϵQQ��441031656��", "/");
            //}
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
            if (HttpContext.Current.Session["Admin"] == null)
            {
                Context.Response.Redirect("Default.aspx");
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
            ApplicationLog.Log("Admin___________________Message:" + ex.Message + "\r\nStackTrace" + ex.StackTrace);

            // ת�������Ϣҳ��
            //Context.Session["SystemError"] = ex.Message;
            //Session.Clear();
            Jscript.AlertAndRedirect("���쳣������������������¼�ѳ�ʱ�������³��ԡ�", "main.htm");
            //Context.Response.Redirect("main.htm");

            Server.ClearError();
        }

        /// <summary>
        /// ��֤�Ƿ��½���Ƿ��д�ҳ�����Ȩ��
        /// </summary>
        public void CheckAuthority(string vcode)
        {
            //
            //����û��Ƿ��½
            //
            if (HttpContext.Current.Session["AdminPurview"] == null)
            {
                //Context.Session["SystemError"] = "����û�е�½���ߵ�½�Ѿ���ʱ��";
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
            //����û��Ƿ���Է��ʴ�ҳ��
            //
            //if (!this.IsPostBack)
            //{
            //    string pageName = Context.Request.FilePath.Substring(Request.FilePath.LastIndexOf("/") + 1, Request.FilePath.LastIndexOf(".") - Request.FilePath.LastIndexOf("/") - 1);
            //    string loginID = Context.Session["LoginID"].ToString();
            //    SystemBusiness systemBusiness = new SystemBusiness();
            //    if (!systemBusiness.CheckRight(loginID, pageName))
            //    {
            //        Context.Session["SystemError"] = "��û��Ȩ�޷��ʴ�ҳ�棡";
            //        Context.Response.Redirect("Main.aspx");
            //    }
            //}
        }
    }

}
