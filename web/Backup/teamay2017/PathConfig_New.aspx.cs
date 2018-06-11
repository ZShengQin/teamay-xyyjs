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
using System.Drawing;
using System.Drawing.Imaging;

using TeamayBase;

public partial class PathConfig_New : AdminBase
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
            if (Request.UrlReferrer != null)
            {

                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();

            }
            if (Request.QueryString["id"] == null)
            {
                Response.Write("<script>alert('ID传输错误！');location.href='PathConfig_New.aspx';</script>");
            }
            else
            {

                //这里读取数据根据ID读取
                string t_id = vldInput2(Request.QueryString["id"].ToString());
                string sql = "select * from tm_path where id=" + t_id;
                DataSet ds = da.GetDs(sql);
                this.ParentID.Text = ds.Tables[0].Rows[0]["id"].ToString();
                this.ParentSequence.Text = ds.Tables[0].Rows[0]["sequence"].ToString();
                this.barID.Value = ds.Tables[0].Rows[0]["barID"].ToString();
                int _zlevel = int.Parse(ds.Tables[0].Rows[0]["zlevel"].ToString());
                _zlevel++;

                myParent.DataSource = ds;
                myParent.DataTextField = "cn_name";
                myParent.DataValueField = "ID";
                myParent.DataBind();
                zlevel.Items.FindByValue(_zlevel.ToString()).Selected = true;
                zlevel.Enabled = false;

                //give advice
                DataTable dt = da.GetTable("select max(sequence)+10 ,max(id)+1 from tm_path where myparent=" + t_id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][1].ToString() != "")
                    {
                        paixu.Text = dt.Rows[0][1].ToString();
                        sequence.Text = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        paixu.Text = (int.Parse(this.ParentID.Text) + 1).ToString();
                        sequence.Text = (int.Parse(this.ParentSequence.Text) + 10).ToString();
                    }
                }
                else
                {
                    paixu.Text = (int.Parse(this.ParentID.Text) + 1).ToString();
                    sequence.Text = (int.Parse(this.ParentSequence.Text) + 10).ToString();
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                string t_id = vldInput2(Request.QueryString["id"].ToString());
                string title = this.TextBox1.Text;
                string contents = this.Editor1.Value.Replace("'", "''");
                string contents_en = this.Editor2.Value.Replace("'", "''");
                string paixu = this.paixu.Text.Replace("'", "''");
                string sequence = this.sequence.Text.Replace("'", "''");
                
                string ntype = this.ntype.Text;
                string myparent = this.myParent.Text;
                string show = showinleft.Text;
                string zlevel = this.zlevel.Text;
                string barid = barID.Value;
                string barchar = (zlevel == "2" ? "└" : "└└");
                string realid = ntype == "SinglePage" ? "NULL" : paixu;
                da.RunSql("insert into tm_path (cn_name,id,barid,myparent,visible,ntype,realid,sequence,zlevel,showinleft,showintop,backchar) "
                        + "values ('" + title + "','" + paixu + "','" + barid + "','" + t_id + "',1,'" + ntype + "'," + realid + "," + sequence + "," + zlevel + "," + show + ",1,'" + barchar + "')");
                string old = ViewState["UrlReferrer"] as string;
                if (old == null)
                {
                    old = "Article_lanmu_add.aspx";
                }
                Response.Write("<script>alert('修改成功！');location.href='" + old + "';</script>");
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
