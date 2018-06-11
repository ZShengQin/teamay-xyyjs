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

public partial class bgbx_addadmin : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckAuthority("|12,");
        DataAccess da = new DataAccess();
        if (!IsPostBack)
        {

            string id = QueryString.GetId;
            if (id != null)
            {
                DataTable dt = da.GetTable("select * from tm_Admin where id=" + id);
                if (dt.Rows.Count == 1)
                {
                    ViewState["editmode"] = dt.Rows[0][4].ToString();
                    UserName.Text = dt.Rows[0][1].ToString();
                    UserName.ReadOnly = true;
                    RealName.Text = dt.Rows[0][2].ToString();
                    roles.Value = dt.Rows[0]["AdminPurview"].ToString();
                    Youxiao.Checked = dt.Rows[0][8].ToString() == "1";
                    Superman.Checked = dt.Rows[0]["superType"].ToString() == "1";
                    RequiredFieldValidator2.Enabled = false;
                }
            }

            outer.DataSource = da.GetDs("select id,cn_name,zlevel from tm_path where myparent=0 order by sequence");
            outer.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        string username = UserName.Text;
        if (username == "")
        {
            Jscript.Alert("用户名不能为空");
            return;
        }
        string realname = RealName.Text;
        if (realname == "")
        {
            Jscript.Alert("姓名不能为空");
            return;
        }
        string password = pwd.Text;
        password = StringUtil.EncryptPassword(password, "MD5");
        string youxiao = Youxiao.Checked ? "1" : "0";
        string superType = Superman.Checked ? "1" : "0";
        string quan = "," + Request.Form["innerc"] + ",";
        
        if (ViewState["editmode"] != null)
        {
            da.RunSql("update tm_Admin set realname='" + realname + "',AdminPurview='" + quan + "',isused=" + youxiao + ",supertype=" + superType + " where username='" + username + "'");
            if (pwd.Text.Trim() != "")
            {
                da.RunSql("update tm_Admin set pwd='" + password + "' where username='" + username + "'");
            }
        }
        else
        {
            da.RunSql("insert into tm_Admin(username,realname,pwd,AdminPurview,isUsed,supertype) values('" + username + "','" + realname + "','" + password + "','" + quan + "'," + youxiao + "," + superType + ")");
        }
        Jscript.AlertAndRedirect("成功新增管理员！", "Adminlist.aspx");
    }

  

    protected void outer_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataAccess da = new DataAccess();
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptProduct = (Repeater)e.Item.FindControl("inner");
            //找到分类Repeater关联的数据项 
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取分类ID 
            int CategorieId = Convert.ToInt32(rowv["id"]);
            //根据分类ID查询该分类下的产品，并绑定产品Repeater 
            rptProduct.DataSource = da.GetDs("select id,cn_name,zlevel,myparent from tm_path where myparent=" + CategorieId + " order by sequence");
            rptProduct.DataBind();
        } 
    }
}
