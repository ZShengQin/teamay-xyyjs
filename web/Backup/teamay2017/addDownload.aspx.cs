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

public partial class bgbx_addDownload : AdminBase
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
                DataTable dt = da.GetTable("select downloadTitle,orderIndex,filePath,language,id,linkurl from tm_link where id=" + id);
                if (dt.Rows.Count == 1)
                {
                    ViewState["editmode"] = dt.Rows[0][4].ToString();
                    downloadTitle.Text = dt.Rows[0][0].ToString();
                    orderIndex.Text = dt.Rows[0][1].ToString();
                    filePath.Text = dt.Rows[0][2].ToString();
                    downloadLink.Text = dt.Rows[0][5].ToString();
                    language.Items.FindByValue(dt.Rows[0][3].ToString()).Selected = true;
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        string _downloadTitle = downloadTitle.Text;
        string _orderIndex = orderIndex.Text;
        string _filePath = filePath.Text;
        string _language = language.SelectedValue;
        string _linkurl = downloadLink.Text;

        if (ViewState["editmode"] != null)
        {
            da.RunSql("update tm_link set downloadTitle='" + _downloadTitle + "',orderIndex='" + _orderIndex + "',filePath='" + _filePath + "',language='" + _language + "',linkurl='" + _linkurl + "' where id='" + ViewState["editmode"].ToString() + "'");
        }
        else
        {
            da.RunSql("insert into tm_link(downloadTitle,orderIndex,filePath,language,linkurl) values('" + _downloadTitle + "','" + _orderIndex + "','" + _filePath + "','" + _language + "','" + _linkurl + "')");
        }
		Jscript.AlertAndRedirect("成功保存链接！", "downloadList.aspx");
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "success_add_zs_user", "<script>alert('操作成功！')</script>");
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                string ex_filename = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();
                string ming = DateTime.Now.ToString("yyyyMMddHHmmss") + ex_filename;
                if (ex_filename == ".jpg" || ex_filename == ".bmp" || ex_filename == ".png" || ex_filename == ".gif")
                {

                    FileUpload1.SaveAs(Server.MapPath("\\Upload") + "\\" + ming);
                    this.filePath.Text = "/Upload/" + ming;

                }
                else
                {
                    Label1.Text = "不是图像文件！";

                }

            }
            catch (Exception ex)
            {
                Label1.Text = "发生错误：" + ex.Message.ToString();
            }
        }
        else
        {
            Response.Write("<script>alert('请先选择要上传的文件！');</script>");

        }
    }
}
