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

public partial class config : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckAuthority("|12,");
        DataAccess da = new DataAccess();
        if (!IsPostBack)
        {
            DataTable dt = da.GetTable("select * from config");
            if (dt.Rows.Count == 1)
            {
                width.Text = dt.Rows[0]["width"].ToString();
                height.Text = dt.Rows[0]["height"].ToString();
                filePath.Text = dt.Rows[0]["url"].ToString();
                link.Text = dt.Rows[0]["link"].ToString();
                mode.Items.FindByValue(dt.Rows[0]["mode"].ToString()).Selected = true;
            }

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        string _width = width.Text.Trim();
        string _height = height.Text.Trim();
        string _url = filePath.Text.Trim();
        string _mode = mode.SelectedValue;
        string _link = link.Text;

        da.RunSql("update config set width='" + _width + "',height='" + _height + "',url='" + _url + "',link='" + _link + "',mode='" + _mode + "' ");

        ClientScript.RegisterClientScriptBlock(this.GetType(), "success_add_zs_user1", "<script>alert('操作成功！')</script>");
    }
}
