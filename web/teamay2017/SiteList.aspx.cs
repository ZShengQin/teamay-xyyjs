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

public partial class SiteList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckAuthority("|11,");
        if (!IsPostBack)
        {
            this.labPage.Text = "1";
            this.contrlRepeater();
        }
    }

    //Repeater分页控制显示方法 
    public void contrlRepeater()
    {
        DataAccess da = new DataAccess();
        DataSet ss = new DataSet();
        ss = da.GetDs("select * from tm_Admin");
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ss.Tables[0].DefaultView;
        pds.AllowPaging = true;
        pds.PageSize = 20;
        pds.CurrentPageIndex = Convert.ToInt32(this.labPage.Text) - 1;
        Repeater1.DataSource = pds;
        LabCountPage.Text = pds.PageCount.ToString();
        labPage.Text = (pds.CurrentPageIndex + 1).ToString();
        this.lbtnpritPage.Enabled = true;
        this.lbtnFirstPage.Enabled = true;
        this.lbtnNextPage.Enabled = true;
        this.lbtnDownPage.Enabled = true;
        if (pds.CurrentPageIndex < 1)
        {
            this.lbtnpritPage.Enabled = false;
            this.lbtnFirstPage.Enabled = false;
        }
        if (pds.CurrentPageIndex == pds.PageCount - 1)
        {
            this.lbtnNextPage.Enabled = false;
            this.lbtnDownPage.Enabled = false;
        }
        Repeater1.DataBind();
    }

    protected void lbtnpritPage_Click(object sender, EventArgs e)
    {
        this.labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text) - 1);
        this.contrlRepeater();
    }
    protected void lbtnFirstPage_Click(object sender, EventArgs e)
    {
        this.labPage.Text = "1";
        this.contrlRepeater();
    }
    protected void lbtnDownPage_Click(object sender, EventArgs e)
    {
        this.labPage.Text = this.LabCountPage.Text;
        this.contrlRepeater();
    }

    protected void lbtnNextPage_Click(object sender, EventArgs e)
    {
        this.labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text) + 1);
        this.contrlRepeater();
    }
}
