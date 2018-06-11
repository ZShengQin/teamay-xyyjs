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

public partial class bgbx_Article_setfirst : AdminBase
{
    DataAccess da = new DataAccess();
    static private string vldInput2(string strId)
    {
        return strId.Replace("'", "''").Replace("-", "－");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckAuthority("|54,");
        if (!IsPostBack)
        {
            if (Request.QueryString["type"] == null)
            {
                Response.Write("<script>alert('ID传输错误！');location.href='Article_list.aspx';</script>");
            }
            else
            {

                //这里读取数据根据ID读取
                string t_id = QueryString.GetTypeid;
                string sql = "select * from smn_lanmu_type where id=" + t_id;
                DataSet ds = da.GetDs(sql);
                this.TextBox1.Text = ds.Tables[0].Rows[0]["firsttitle"].ToString();
                this.TextBox2.Text = ds.Tables[0].Rows[0]["firstsub"].ToString();
                if (ds.Tables[0].Rows[0]["firstimg"] == null || ds.Tables[0].Rows[0]["firstimg"].ToString() == "")
                {
                    this.Image1.ImageUrl = "include/images/nonebig.gif";
                    this.TextBox4.Text = null;
                }
                else
                {
                    this.Image1.ImageUrl = "~/" + ds.Tables[0].Rows[0]["firstimg"].ToString();
                    this.TextBox4.Text = ds.Tables[0].Rows[0]["firstimg"].ToString();
                }
                this.TextBox3.Text = ds.Tables[0].Rows[0]["firstUrl"].ToString();
                //下拉默认值
                string ClassID = ds.Tables[0].Rows[0]["id"].ToString();
                this.Dro(ClassID);
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
        string sql = "select id, lei from smn_lanmu_type";
        DataSet ds = da.GetDs(sql);
        DropDownList1.DataSource = ds.Tables[0].DefaultView;
        DropDownList1.DataTextField = "lei";
        DropDownList1.DataValueField = "ID";
        DropDownList1.DataBind();
        DropDownList1.Items.FindByValue(Str).Selected = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                //图片地址
                string pic = this.TextBox4.Text;
                //目前的类型
                string class1 = this.DropDownList1.Text;
                //标题
                string title = this.TextBox1.Text;
                //链接地址
                string url = this.TextBox3.Text;
                //摘要
                string sub = this.TextBox2.Text;

                string sql = "update smn_lanmu_type set firstimg='" + pic + "',firsttitle='" + title + "',firstsub='" + sub + "',firsturl='" + url + "' where id= " + class1 + "";
                da.RunSql(sql);
                Response.Write("<script>alert('修改成功！');</script>");
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
                    this.TextBox4.Text = "Upload/" + ming;
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
