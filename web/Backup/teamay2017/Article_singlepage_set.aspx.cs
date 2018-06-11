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

public partial class bgbx_Article_singlepage_set : AdminBase
{
    DataAccess da = new DataAccess();
    static private string vldInput2(string strId)
    {
        return strId.Replace("'", "''").Replace("-", "－");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckAuthority("|51,");

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
                string sql = "select * from smn_lanmu_article where id=" + t_id;
                DataSet ds = da.GetDs(sql);
                this.TextBox1.Text = ds.Tables[0].Rows[0]["title"].ToString();
                this.TextBox2.Text = ds.Tables[0].Rows[0]["title_en"].ToString();
                this.Editor1.Value = ds.Tables[0].Rows[0]["thecontent"].ToString();
                this.Editor2.Value = ds.Tables[0].Rows[0]["thecontent_en"].ToString();
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                string contents = this.Editor1.Value;
                string contents_en = this.Editor2.Value.Replace("'", "''");
                string sql = "update smn_lanmu_article set thecontent='" + contents + "', thecontent_en='" + contents_en + "' where id= " + Request.QueryString["id"].ToString() + "";
                da.RunSql(sql);
                Response.Write("<script>alert('修改成功！');</script>");
            }
            catch
            {
                this.Label1.Text = "<div class=\"boxdiv\">提交失败！</div>";
            }
            finally
            {
                
            }
        }
    }

}
