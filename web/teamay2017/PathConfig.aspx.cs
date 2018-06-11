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

public partial class bgbx_PathConfig : AdminBase
{
    DataAccess da = new DataAccess();

    static private string vldInput2(string strId)
    {
        return strId.Replace("'", "''").Replace("-", "－");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckAuthority("|52,");
        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null)
            {

                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();

            }
            if (Request.QueryString["id"] == null)
            {
                Response.Write("<script>alert('ID传输错误！');location.href='PathConfig.aspx';</script>");
            }
            else
            {

                //这里读取数据根据ID读取
                string t_id = vldInput2(Request.QueryString["id"].ToString());
                string sql = "select * from tm_path where id=" + t_id;
                DataSet ds = da.GetDs(sql);
                this.TextBox1.Text = ds.Tables[0].Rows[0]["cn_name"].ToString();
                this.paixu.Text = ds.Tables[0].Rows[0]["id"].ToString();
                this.sequence.Text = ds.Tables[0].Rows[0]["sequence"].ToString();
                this.Editor1.Value = ds.Tables[0].Rows[0]["cn_intro"].ToString();
                this.Editor2.Value = ds.Tables[0].Rows[0]["en_intro"].ToString();
                
                
                string realid = ds.Tables[0].Rows[0]["realid"].ToString();
                string _ntype = ds.Tables[0].Rows[0]["ntype"].ToString();
                string _zlevel = ds.Tables[0].Rows[0]["zlevel"].ToString();
                if (_ntype == "SinglePage")
                {
                    DefaultOpen.DataSource = da.GetDs("select id,'打开子类【' + cn_name + '】' as name from tm_path where myParent=" + t_id + " order by sequence");
                    DefaultOpen.DataTextField = "name";
                    DefaultOpen.DataValueField = "ID";
                    DefaultOpen.DataBind();
                    DefaultOpen.Items.Insert(0, new ListItem("根据栏目类型默认打开", "NULL"));
                    DefaultOpen.Items.FindByValue(realid == "" ? "NULL" : realid).Selected = true;
                }
                else
                {
                    DefaultOpen.Items.Insert(0, new ListItem("根据栏目类型默认打开", t_id));
                }
                

                myParent.DataSource = da.GetDs("select id, cn_name from tm_path where id in(select distinct myParent from tm_path where myParent<>0) order by sequence");
                myParent.DataTextField = "cn_name";
                myParent.DataValueField = "ID";
                myParent.DataBind();
                myParent.Items.Insert(0, new ListItem("根类", "0"));
                myParent.Items.FindByValue(ds.Tables[0].Rows[0]["myparent"].ToString()).Selected = true;

                ntype.Items.FindByValue(_ntype).Selected = true;
                zlevel.Items.FindByValue(_zlevel).Selected = true;

                showinleft.Items.FindByValue(ds.Tables[0].Rows[0]["showinleft"].ToString()).Selected = true;
                if (_zlevel != "1")
                {
                    ntype.Items.RemoveAt(0);
                    ntype.Enabled = true;
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
                string title = this.TextBox1.Text;
                string contents = this.Editor1.Value.Replace("'", "''");
                string contents_en = this.Editor2.Value.Replace("'", "''");
                string paixu = this.paixu.Text.Replace("'", "''");
                string sequence = this.sequence.Text.Replace("'", "''");
                string realid = this.DefaultOpen.Text;
                string ntype = this.ntype.Text;
                string myparent = this.myParent.Text;
                string show = showinleft.Text;
                string sql = "update tm_path set cn_name='" + title + "',id='" + paixu + "',sequence='" + sequence + "',realid=" + realid + ",showinleft=" + show + ",ntype='" + ntype + "',myparent=" + myparent + ",cn_intro='" + contents + "',en_intro='" + contents_en + "' where id= " + Request.QueryString["id"].ToString() + "";
                da.RunSql(sql);
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

    protected void ntype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string _v = ntype.Text;
        string t_id = vldInput2(Request.QueryString["id"].ToString());
        if (_v == "SinglePage")
        {
            //string realid = ds.Tables[0].Rows[0]["realid"].ToString();
            
            DefaultOpen.DataSource = da.GetDs("select id,'打开子类【' + cn_name + '】' as name from tm_path where myParent=" + t_id + " order by sequence");
            DefaultOpen.DataTextField = "name";
            DefaultOpen.DataValueField = "ID";
            DefaultOpen.DataBind();
            DefaultOpen.Items.Insert(0, new ListItem("根据栏目类型默认打开", "NULL"));
            //DefaultOpen.Items.FindByValue(realid == "" ? "NULL" : realid).Selected = true;
        }
        else
        {
            DefaultOpen.Items.Clear();
            DefaultOpen.Items.Insert(0, new ListItem("根据栏目类型默认打开", t_id));
        }
    }
}
