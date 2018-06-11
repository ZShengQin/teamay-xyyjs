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

public partial class bgbx_Article_add : AdminBase
{
    DataAccess da = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckAuthority("|52,");

        if (!IsPostBack)
        {
            string StrSQL = "select a.id,b.cn_name + '-' + a.cn_name as lei from tm_path a left join tm_path b on a.myparent=b.id where a.ntype<>'SinglePage'  and a.myparent>0 and (a.id in (-1" + Session["AdminPurview"].ToString() + "-1) or a.myParent in (-1" + Session["AdminPurview"].ToString() + "-1)) order by a.sequence";
            DropDownList1.DataSource = da.GetDs(StrSQL);
            DropDownList1.DataTextField = "lei";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataBind();
            Author.Text = Session["Admin"].ToString();

            TextBox5.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            PXTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string id = QueryString.GetTypeid;
            if (id != null)
            {
                DropDownList1.Items.FindByValue(id).Selected = true;
            }

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                string pic = this.TextBox4.Text;
                string class1 = this.DropDownList1.Text;
                string title = this.TextBox1.Text;
                string title_en = this.TextBox1_en.Text.Replace("'", "''") ;
                string pinglun = this.RadioButtonList1.SelectedValue;
                string theTime = this.TextBox5.Text;
                string author = this.Author.Text;
                string keytxt = this.KeyTxt.Text;
                string rq = this.ClickTimes.Text;
                int rqint;
                bool isint = int.TryParse(rq, out rqint);
                if (!isint) rq = "1";
                string laiyuan = this.TextBox5.Text;//时间
                string pxtime = PXTime.Text;
                string contents = this.Editor1.Value.Replace("'", "''");
                string contents_en = this.Editor2.Value.Replace("'", "''");
                string ip = Request.UserHostAddress;
                if (theTime == "")
                {
                    theTime = DateTime.Now.ToString();
                }
                string sql = "insert into tm_page (class,title,contents,pinglun,[time],[keytxt],[rq],pic,author,ip,title_en,contents_en,pxtime) values('" + class1 + "','" + title + "','" + contents + "','" + pinglun + "','" + theTime + "','" + keytxt + "','" + rq + "','" + pic + "','" + author + "','" + ip + "','" + title_en + "','" + contents_en + "','"+pxtime+"')";
                da.RunSql(sql);
            }
            catch
            {
                this.Label1.Text = "<div class=\"boxdiv\">提交失败！</div>";
            }
            finally
            {
                this.Label1.Text = "<div class=\"boxdiv\">提交成功！</div>";
                this.TextBox1.Text = null;
                this.Editor1.Value = null;
				TextBox5.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.Image1.ImageUrl = "include/images/nonebig.gif";
            }
        }
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
                    //Label1.Text = "客户端路径：" + FileUpload1.PostedFile.FileName + "<br>" +
                    //              "文件名：" + System.IO.Path.GetFileName(FileUpload1.FileName) + "<br>" +
                    //              "文件扩展名：" + System.IO.Path.GetExtension(FileUpload1.FileName) + "<br>" +
                    //              "文件大小：" + FileUpload1.PostedFile.ContentLength + " KB<br>" + 
                    //              "文件MIME类型：" + FileUpload1.PostedFile.ContentType + "<br>" +
                    //              "保存路径：" + Server.MapPath("upload") + "\\" + FileUpload1.FileName;
                    this.TextBox4.Text = "/Upload/" + ming;
                    this.Image1.ImageUrl = "~/Upload/" + ming;
                    //this.Editor1.Text = "<img src='Upload/" + ming + "'>" + Editor1.Text;
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
