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

public partial class Teacher_Set : AdminBase
{
    DataAccess da = new DataAccess();
    static private string vldInput2(string strId)
    {
        return strId.Replace("'", "''").Replace("-", "－");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Write("<script>alert('ID传输错误！');location.href='Article_list.aspx';</script>");
            }
            else
            {

                //这里读取数据根据ID读取
                string t_id = vldInput2(Request.QueryString["id"].ToString());
                string sql = "select * from tm_teacher where id=" + t_id;
                DataSet ds = da.GetDs(sql);
                this.TitleLabel.Text = ds.Tables[0].Rows[0]["name_cn"].ToString() + "(" + ds.Tables[0].Rows[0]["login_name"].ToString() + ")";
                this.zy_cn.Text = ds.Tables[0].Rows[0]["zy_cn"].ToString();
                this.zy_en.Text = ds.Tables[0].Rows[0]["zy_en"].ToString();
                this.Editor1.Value = ds.Tables[0].Rows[0]["intro_cn"].ToString();
                this.Editor2.Value = ds.Tables[0].Rows[0]["intro_en"].ToString();
                this.title_cn.Text = ds.Tables[0].Rows[0]["title_cn"].ToString();
                this.title_en.Text = ds.Tables[0].Rows[0]["title_en"].ToString();
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                string _zy_cn = this.zy_cn.Text;
                string _zy_en = this.zy_en.Text;
                string _intro_cn = this.Editor1.Value.Replace("'", "''");
                string _intro_en = this.Editor2.Value.Replace("'", "''");
                string _title_en = this.title_en.Text.Replace("'", "''");
                string _title_cn = this.title_cn.Text.Replace("'", "''");

                string sql = "update tm_teacher set zy_cn='" + _zy_cn + "',zy_en='" + _zy_en + "',intro_cn='" + _intro_cn + "',intro_en='" + _intro_en + "',title_cn='" + _title_cn + "',title_en='" + _title_en + "' where id= " + Request.QueryString["id"].ToString() + "";
                da.RunSql(sql);
            }
            catch
            {
                this.Label1.Text = "<div class=\"boxdiv\">修改失败！</div>";
            }
            finally
            {
                Response.Write("<script>alert('修改成功！');location.href='userlist.aspx';</script>");
            }
        }
    }
}
