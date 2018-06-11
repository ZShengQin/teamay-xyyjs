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

public partial class Article_lanmu2_add : TeamayBase.AdminBase
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

        string id = QueryString.GetId;
        if (id == null)
        {
            DropDownList1.DataSource = da.GetDv("select id,cn_name,en_name from tm_path where myParent=0  order by sequence ");
            DropDownList1.DataTextField = "cn_name";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
        }
        else
        {
            string zlevel = da.GetSingeData("select zlevel from tm_path where id=" + id).ToString();
            if (zlevel == "1")
            {
                DropDownList1.DataSource = da.GetDv("select id,cn_name,en_name from tm_path where myParent=0  order by sequence ");
            }
            else
            {
                DropDownList1.DataSource = da.GetDv("select id,cn_name,en_name from tm_path where myParent in( select myparent from tm_path where id =" + id + " ) order by sequence ");
            }
            DropDownList1.DataTextField = "cn_name";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
            DropDownList1.Items.FindByValue(id).Selected = true;
        }
        



        leiType.Text = DropDownList1.SelectedItem.Text;


        

        


        DataSet ds = new DataSet();
        ds = da.GetDs("select id,cn_name,en_name,sequence,zlevel from tm_path where myparent=" + DropDownList1.Text + " and myparent<>0  order by sequence ");
        DataList1.DataSource = ds;
        DataList1.DataBind();

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Article_lanmu2_add.aspx?id=" + DropDownList1.SelectedValue);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("PathConfig_New.aspx?id=" + DropDownList1.SelectedValue);
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
