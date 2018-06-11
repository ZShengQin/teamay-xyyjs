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

public partial class bgbx_Article_Edit : AdminBase
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
            if (Request.QueryString["id"] == null)
            {
                Response.Write("<script>alert('ID传输错误！');location.href='Article_list.aspx';</script>");
            }
            else
            {

                //这里读取数据根据ID读取
                string t_id = vldInput2(Request.QueryString["id"].ToString());
                string sql = "select * from tm_page where id=" + t_id;
                DataSet ds = da.GetDs(sql);
                this.TextBox1.Text = ds.Tables[0].Rows[0]["title"].ToString();
                this.TextBox1_en.Text = ds.Tables[0].Rows[0]["title_en"].ToString();
                this.TextBox5.Text = ds.Tables[0].Rows[0]["time"].ToString();
                if (ds.Tables[0].Rows[0]["pic"] == null || ds.Tables[0].Rows[0]["pic"].ToString() == "")
                {
                    this.Image1.ImageUrl = "include/images/nonebig.gif";
                    this.TextBox4.Text = null;
                }
                else
                {
                    this.Image1.ImageUrl = "" + ds.Tables[0].Rows[0]["pic"].ToString();
                    this.TextBox4.Text = ds.Tables[0].Rows[0]["pic"].ToString();
                }
                this.Author.Text = ds.Tables[0].Rows[0]["author"].ToString();
                this.ClickTimes.Text = ds.Tables[0].Rows[0]["rq"].ToString();
                this.KeyTxt.Text = ds.Tables[0].Rows[0]["keytxt"].ToString();
                this.Editor1.Value = ds.Tables[0].Rows[0]["contents"].ToString().Replace("input", "img");
                this.Editor2.Value = ds.Tables[0].Rows[0]["contents_en"].ToString();
                PXTime.Text = ds.Tables[0].Rows[0]["pxtime"].ToString();
                //下拉默认值
                string ClassID = ds.Tables[0].Rows[0]["class"].ToString();
                this.Dro(ClassID);
                //单选数据
                string danxuang = ds.Tables[0].Rows[0]["pinglun"].ToString();
                danxuang = danxuang == "" ? "0" : danxuang;
                RadioButtonList1.Items.FindByValue(danxuang).Selected = true;
            }
        }
    }


    /// 把下拉菜单显示出来，并根据ClassID选择相应的栏目
    /// </summary>
    /// <param name="Str">文章所属ClassID</param>
    /// <returns>把下拉菜单显示出来，并根据ClassID选择相应的栏目</returns>	
    /// 
    public void Dro(string Str)
    {
        string StrSQL = "select a.id,b.cn_name + '-' + a.cn_name as lei from tm_path a left join tm_path b on a.myparent=b.id where a.ntype<>'SinglePage'  and a.myparent>0 order by a.sequence";
        DataSet ds = da.GetDs(StrSQL);
        DropDownList1.DataSource = ds.Tables[0].DefaultView;
        DropDownList1.DataTextField = "lei";
        DropDownList1.DataValueField = "ID";
        DropDownList1.DataBind();
        DropDownList1.Items.FindByValue(Str).Selected = true;
        //DropDownList1.Enabled = false;
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
                string pinglun = this.RadioButtonList1.Text;
                string theTime = this.TextBox5.Text;
                string author = this.Author.Text;
                string keytxt = this.KeyTxt.Text;
                string rq = this.ClickTimes.Text;
                int rqint;
                bool isint = int.TryParse(rq, out rqint);
                if (!isint) rq = "1";
                string contents = this.Editor1.Value.Replace("'", "''");
                string contents_en = this.Editor2.Value.Replace("'", "''");
                string ip = Request.UserHostAddress;
                string title_en = this.TextBox1_en.Text.Replace("'", "''");
                string pxtime = PXTime.Text;
                string sql = "";
                if (theTime == "")
                {
                    sql = "update tm_page set class='" + class1 + "',title='" + title + "',contents='" + contents + "',keytxt='" + keytxt + "',pic='" + pic + "',author='" + author + "',pinglun='" + pinglun + "',rq='" + rq + "',title_en='" + title_en + "',contents_en='" + contents_en + "',pxtime='"+pxtime+"' where id= " + Request.QueryString["id"].ToString() + "";
                }
                else
                {
                    sql = "update tm_page set class='" + class1 + "',title='" + title + "',contents='" + contents + "',keytxt='" + keytxt + "',pic='" + pic + "',author='" + author + "',pinglun='" + pinglun + "',rq='" + rq + "',title_en='" + title_en + "',contents_en='" + contents_en + "',time='" + theTime + "',pxtime='"+pxtime+"' where id= " + Request.QueryString["id"].ToString() + "";
                }
                
                da.RunSql(sql);
            }
            catch
            {
                this.Label1.Text = "<div class=\"boxdiv\">提交失败！</div>";
            }
            finally
            {
                Response.Write("<script>alert('修改成功！');location.href='Article_list.aspx?type=" + this.DropDownList1.Text + "';</script>");
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
