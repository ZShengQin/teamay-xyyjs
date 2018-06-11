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


public partial class bgbx_changepwd : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckAuthority("|23,");
        Label1.Text = Session["Admin"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string pwd = TextBox1.Text.Trim();
        string oldpwd = TextBox3.Text.Trim();
        DataAccess da = new DataAccess();
        string usercode = Session["Admin"].ToString();
        pwd = StringUtil.EncryptPassword(pwd, "MD5");
        oldpwd = StringUtil.EncryptPassword(oldpwd, "MD5");
        DataTable dt = da.GetTable("select * from tm_Admin where username='" + usercode + "' and pwd='" + oldpwd + "'");
        if (dt.Rows.Count == 0)
        {
            //Jscript.Alert("你所填的信息有误，尤其是原密码可能记错，请再确认，你的重改机会并不多！");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "ad2", "<script>alert('你所填的信息有误，尤其是原密码可能记错，另外还有新密码必须一致，请重新输入！')</script>");
            return;
        }
        da.RunSql("update tm_Admin set pwd='" + pwd + "' where username='" + usercode + "'");
        ClientScript.RegisterClientScriptBlock(this.GetType(), "ad1", "<script>alert('操作成功!')</script>");
    }
}
