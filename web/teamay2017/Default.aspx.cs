using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using TeamayBase;

public partial class bgbx_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["Admin"] == null)
        {
            string validatecode = this.CheckCode.Value;
            string codeincookie = (HttpContext.Current.Request.Cookies["CheckCode"] == null) ? "a" : HttpContext.Current.Request.Cookies["CheckCode"].Value;

            if (codeincookie != validatecode)
            {
                //Jscript.Alert("验证码过期或者输入错误！");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "errorOfvc", "<script>alert('验证码过期或者输入错误！')</script>");
                //Jscript.RefreshOpener();
                //Jscript.AlertAndRefreshParent("验证码过期或者输入错误！", "Default.aspx");
                return;
            }
            string username = vldInput(this.LoginName.Value.Trim());
            string pwd = this.LoginPassword.Value;
            pwd = StringUtil.EncryptPassword(pwd, "MD5");
            DataAccess da = new DataAccess();
            string loginIP = (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null) ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString() : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            string strsql = "select id,username,adminpurview,supertype from tm_Admin where username='" + username + "' or pwd='" + pwd + "' and isUsed=1";
            DataTable dt = da.GetTable(strsql);
            if (dt.Rows.Count == 0)
            {
                //Jscript.Alert("对不起，你输入的账号或密码错误！");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "errorOfpwd", "<script>alert('对不起，你输入的账号或密码错误！')</script>");
                //Jscript.AlertAndRefreshParent("对不起，你输入的账号或密码错误！", "Default.aspx");
                return;
            }
            Session.Clear();
            Session["Admin"] = dt.Rows[0][1].ToString();
            Session["AdminPurview"] = dt.Rows[0][2].ToString();
            Session["AdminType"] = dt.Rows[0][3].ToString();
            strsql = "update tm_Admin set Logintimes=Logintimes+1,lastloginip='" + loginIP + "',lastlogintime=getdate() where id=" + dt.Rows[0][0].ToString();
            da.RunSql(strsql);
            //string oldurl = Request.ServerVariables["HTTP_Referer"];
            //if (oldurl == null || oldurl.ToLower().Contains("login_xk"))
            //oldurl = "SMN_VIP.aspx";
            //Jscript.Alert(Request.RawUrl);
            
        }
        Jscript.RefreshParent("Main.aspx");
    }
    static private string vldInput(string strId)
    {
        return strId.Replace("'", "''").Replace("-", "－");
    }
}
