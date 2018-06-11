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

public partial class bgbx_Article_list : AdminBase
{
    DataAccess da = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckAuthority("|53,");
        if (!IsPostBack)
        {
            string StrSQL = "select a.id,b.cn_name + '-' + a.cn_name as cn_name from tm_path a left join tm_path b on a.myparent=b.id where a.ntype<>'SinglePage'  and a.myparent>0 and (a.id in (-1" + Session["AdminPurview"].ToString() + "-1) or a.myParent in (-1" + Session["AdminPurview"].ToString() + "-1)) order by a.sequence";
            Fenlei.DataSource = da.GetDs(StrSQL);
            Fenlei.DataTextField = "cn_name";
            Fenlei.DataValueField = "ID";
            Fenlei.DataBind();
            Fenlei.Items.Insert(0, new ListItem("所有", ""));

            if (QueryString.GetTypeid != null)
            {
                Fenlei.Items.FindByValue(QueryString.GetTypeid).Selected = true;
            }

            this.dlBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string type = Fenlei.SelectedValue;
        string key = GjC.Text.Trim();
        string where = " where a.[class] in  (select id from tm_path c where c.id in (-1" + Session["AdminPurview"].ToString() + "-1) or c.myParent in (-1" + Session["AdminPurview"].ToString() + "-1) ) ";
        if (type != "")
        {
            where += " and a.[class]=" + type;
        }
        if (key != "")
        {
            where += " and a.title like '%" + key + "%'";
        }
        ViewState["sql"] = where;
        dlBind();
    }

    static private string vldInput2(string strId)
    {
        return strId.Replace("'", "''").Replace("-", "－");
    }

    public void dlBind()
    {
        //这里是分类的一些参数声明
        int curpage = Convert.ToInt32(labNowPage.Text);
        PagedDataSource ps = new PagedDataSource();
        string sql1 = "";
        //这里是Datalist的数据帮定
        if (ViewState["sql"] == null)
        {
            sql1 = "SELECT a.id,a.title,a.time,b.cn_name,rq FROM tm_page a left join tm_path b on a.[class]=b.id where a.[class] in (select id from tm_path c where c.id in (-1" + Session["AdminPurview"].ToString() + "-1) or c.myParent in (-1" + Session["AdminPurview"].ToString() + "-1) )   ORDER BY [time] DESC";
            if (QueryString.GetTypeid != null)
            {
                sql1 = "SELECT a.id,a.title,a.time,b.cn_name,rq FROM tm_page a left join tm_path b on a.[class]=b.id where [class]=" + vldInput2(QueryString.GetTypeid) + "  ORDER BY [time] DESC";
            }
        }
        else
        {
            sql1 = "SELECT a.id,a.title,a.time,b.cn_name,rq FROM tm_page a left join tm_path b on a.[class]=b.id  " + ViewState["sql"].ToString() + " ORDER BY [time] DESC";
        }
        if (Fenlei.SelectedValue != "")
        {
            Label1.Text = Fenlei.SelectedItem.Text + "-检索";
        }
        else
        {
            Label1.Text = "所有新闻-检索";
        }
        DataSet ds = da.GetDs(sql1);
        DataList1.DataSource = ds;
        DataList1.DataBind();
        //帮定分页到这个
        ps.DataSource = ds.Tables[0].DefaultView;
        //分页代码
        ps.AllowPaging = true; //是否可以分页
        ps.PageSize = 15; //显示的数量
        ps.CurrentPageIndex = curpage - 1; //取得当前页的页码
        lnkbtnPrve.Enabled = true;
        lnkbtnTop.Enabled = true;
        lnkbtnNext.Enabled = true;
        lnkbtnLast.Enabled = true;
        //这里是帮定到分页的按钮
        if (curpage == 1)
        {
            lnkbtnTop.Enabled = false;//不显示第一页按钮
            lnkbtnPrve.Enabled = false;//不显示上一页按钮
        }
        if (curpage == ps.PageCount)
        {
            lnkbtnNext.Enabled = false;//不显示下一页
            lnkbtnLast.Enabled = false;//不显示最后一页

        }
        this.labCount.Text = Convert.ToString(ps.PageCount);
        this.DataList1.DataSource = ps;
        this.DataList1.DataBind();
    }

    //第一页
    protected void lnkbtnTop_Click(object sender, EventArgs e)
    {
        this.labNowPage.Text = "1";
        this.dlBind();
    }
    //下一页
    protected void lnkbtnPrve_Click(object sender, EventArgs e)
    {
        this.labNowPage.Text = Convert.ToString(Convert.ToInt32(this.labNowPage.Text) - 1);
        this.dlBind();
    }
    //前一页
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        this.labNowPage.Text = Convert.ToString(Convert.ToInt32(this.labNowPage.Text) + 1);
        this.dlBind();
    }
    //最后一页了
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {
        this.labNowPage.Text = this.labCount.Text;
        this.dlBind();
    }

    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        int id = (int)e.CommandArgument;
        Response.Redirect("article_edit.aspx?id=" + id);
    }

    protected void DataList1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            string id = e.CommandArgument.ToString();
            string sql = "delete from tm_page where id=" + id;
            da.RunSql(sql);
            this.dlBind();
        }
        else if (e.CommandName == "Edit")
        {
            string id = e.CommandArgument.ToString();
            Response.Redirect("article_edit.aspx?id=" + id);
        }
    }
}
