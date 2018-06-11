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
using System.Data.SqlClient;
using TeamayBase;

public partial class Article_lanmu_add_v1 : TeamayBase.AdminBase
{
    DataAccess da = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckAuthority("|54,");
        if (!IsPostBack)
        {
            Bind();
        }
    }
    protected void Bind()
    {
        DataSet ds = new DataSet();
        ds = da.GetDs("select id,cn_name,en_name,sequence from tm_path where myParent=0  order by sequence ");
        DataList1.DataSource = ds;
        DataList1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                string lei = this.TextBox1.Text;
                string leishu = this.TextBox3.Text;

                int count = int.Parse(da.GetSingeData("select count(*) from tm_path where myParent = 0 and (cn_name ='" + lei + "' or id=" + leishu + ")").ToString());
                if (count > 0)
                {
                    Jscript.Alert("该名称或基准ID已被使用，请重试！");
                }
                else
                {
                    da.RunSql("insert into tm_path (cn_name,id,barid,myparent,visible,ntype,realid,sequence,zlevel,showinleft,showintop) "
                        + "values ('" + lei + "','" + leishu + "','" + leishu + "','0',1,'SinglePage',NULL," + leishu + "*10,1,1,1)");
                    this.Label1.Text = "<div class=\"boxdiv\">提交成功！</div>";
                    this.TextBox1.Text = null;
                    Bind();
                }
                //string sql = "insert into smn_lanmu_type (lei,leishu)values('" + lei + "','" + leishu + "')";
                //da.RunSql(sql);
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


    protected void DataList1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName == "edit")
        {
            Response.Redirect("PathConfig.aspx?id=" + id);
        }
        else if (e.CommandName == "Add")
        {
            Response.Redirect("Article_lanmu2_add.aspx?id=" + id);
        }
        else if (e.CommandName == "SetFirst")
        {
            Response.Redirect("Article_setfirst.aspx?type=" + id);
        }
        else if (e.CommandName == "Delete")
        {
            int count = int.Parse(da.GetSingeData("select count(*) from tm_path where myparent=" + id).ToString());
            if (count > 0)
            {
                Jscript.Alert("该分类存在子类，不能被删除！");
            }
            else
            {
                string sql = "delete from tm_path where id=" + id;
                da.RunSql(sql);
                Bind();
            }
            //Response.Redirect("Article_setfirst.aspx?type=" + id);
        }
    }
}
