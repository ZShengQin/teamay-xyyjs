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

public partial class Path_Man : TeamayBase.AdminBase
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
        DropDownList1.DataSource = da.GetDv("select id,cn_name,en_name from tm_path where myParent=0 and id in(select distinct myParent from tm_path where id in(-1" + Session["AdminPurview"].ToString() + "-1)) order by sequence ");
        DropDownList1.DataTextField = "cn_name";
        DropDownList1.DataValueField = "id";
        DropDownList1.DataBind();
        if (id == null)
        {
            id = DropDownList1.SelectedValue;
        }
        else
        {
            DropDownList1.Items.FindByValue(id).Selected = true;
        }
        DataSet ds = new DataSet();
        ds = da.GetDs("select id,cn_name,en_name,backchar,realID,ntype,zlevel,sequence from tm_path where barID=" + id + " and (id in (-1" + Session["AdminPurview"].ToString() + "-1) or myParent in (-1" + Session["AdminPurview"].ToString() + "-1)) order by sequence ");
        DataList1.DataSource = ds;
        DataList1.DataBind();

        leiType.Text = DropDownList1.SelectedItem.Text;
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Path_Man.aspx?id=" + DropDownList1.SelectedValue);
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
            HiddenField hf = e.Item.FindControl("ntype") as HiddenField;
            if (hf != null && hf.Value == "PhotoList-more")
            {
                Response.Redirect("userlist.aspx?type=" + e.CommandArgument.ToString());
            }
            else
            {
                Response.Redirect("Article_list.aspx?type=" + e.CommandArgument.ToString());
            }
        }
        else if (e.CommandName == "Delete")
        {
            HiddenField hf = e.Item.FindControl("ntype") as HiddenField;
            if (hf != null && hf.Value == "PhotoList-more")
            {
                Response.Redirect("addUser.aspx?type=" + e.CommandArgument.ToString());
            }
            else
            {
                Response.Redirect("Article_add.aspx?type=" + e.CommandArgument.ToString());
            }
        }
    }
}
