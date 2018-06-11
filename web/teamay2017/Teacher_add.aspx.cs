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

public partial class Teacher_add : AdminBase
{
    DataAccess da = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckAuthority("|52,");

        if (!IsPostBack)
        {
            string StrSQL = "select a.id,b.cn_name + '-' + a.cn_name as lei from tm_path a left join tm_path b on a.myparent=b.id where a.ntype='PhotoList-more' and a.myparent>0 and (a.id in (-1" + Session["AdminPurview"].ToString() + "-1) or a.myParent in (-1" + Session["AdminPurview"].ToString() + "-1)) order by a.sequence";
            DataTable dt = da.GetTable(StrSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                Jscript.Alert("对不起，目前系统没有配置教师分类，请先联系管理员");
                Response.End();
            }
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "lei";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataBind();
            //修改页面复用
            string id = QueryString.GetId;
            if (id != null)
            {
                string sql = "select * from tm_teacher where id=" + id;
                dt = da.GetTable(sql);
                if (dt == null || dt.Rows.Count == 0)
                {
                    Jscript.Alert("请检查该ID合法性！");
                    Response.End();
                }
                DropDownList1.Items.FindByValue(dt.Rows[0]["pathid"].ToString()).Selected = true;
                Name_Cn.Text = dt.Rows[0]["Name_Cn"].ToString();
                Name_En.Text = dt.Rows[0]["Name_En"].ToString();
                Title_cn.Text = dt.Rows[0]["Title_cn"].ToString();
                Title_en.Text = dt.Rows[0]["Title_en"].ToString();
                Zy_Cn.Text = dt.Rows[0]["Zy_Cn"].ToString();
                Zy_en.Text = dt.Rows[0]["Zy_en"].ToString();
                Research_cn.Text = dt.Rows[0]["Research_cn"].ToString();
                Research_en.Text = dt.Rows[0]["Research_en"].ToString();
                Sequence.Text = dt.Rows[0]["Sequence"].ToString();
                Editor1.Value = dt.Rows[0]["intro_cn"].ToString();
                Editor2.Value = dt.Rows[0]["intro_en"].ToString();
                User_name.Text = dt.Rows[0]["User_name"].ToString();
                Photo.Text = dt.Rows[0]["Photo"].ToString();
                if (dt.Rows[0]["Photo"] == null || dt.Rows[0]["Photo"].ToString() == "")
                {
                    this.Image1.ImageUrl = "include/images/nonebig.gif";
                }
                else
                {
                    this.Image1.ImageUrl = Photo.Text;
                }
                //Name_Cn.Text = dt.Rows[0]["Name_Cn"].ToString();
            }
            else
            {
                string typeid = QueryString.GetTypeid;
                if (typeid != null)
                {
                    DropDownList1.Items.FindByValue(id).Selected = true;
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
                this.Label1.Text = "";
                string pathid = this.DropDownList1.Text;
                string name_cn = getSafeTextBoxText(Name_Cn);
                string name_en = getSafeTextBoxText(Name_En);
                string title_cn = getSafeTextBoxText(Title_cn);
                string title_en = getSafeTextBoxText(Title_en);
                string zy_cn = getSafeTextBoxText(Zy_Cn);
                string zy_en = getSafeTextBoxText(Zy_en);
                string research_cn = getSafeTextBoxText(Research_cn);
                string research_en = getSafeTextBoxText(Research_en);
                string sequence = getSafeTextBoxText(Sequence);
                string intro_cn = this.Editor1.Value.Replace("'", "''");
                string intro_en = this.Editor2.Value.Replace("'", "''");
                string user_name = getSafeTextBoxText(User_name);
                string password = getSafeTextBoxText(Password);
                password = StringUtil.EncryptPassword(password, "MD5");
                string photo = this.Photo.Text;

                if (name_cn == "")
                {
                    this.Label1.Text = "<div class=\"boxdiv2\">姓名必须填写！</div>";
                    return;
                }

                if (QueryString.GetId == null)
                {
                    string sql = "insert into [tm_teacher] (user_name,password,name_cn,name_en,photo,title_cn,zy_cn,research_cn,intro_cn,title_en,zy_en,research_en,intro_en,sequence,pathid) values('" + user_name + "','" + password + "','" + name_cn + "','" + name_en + "','" + photo + "','" + title_cn + "','" + zy_cn + "','" + research_cn + "','" + intro_cn + "','" + title_en + "','" + zy_en + "','" + research_en + "','" + intro_en + "','" + sequence + "','" + pathid + "')";
                    da.RunSql(sql);
                }
                else
                {
                    string sql = "update tm_teacher set user_name='" + user_name + "',name_cn='" + name_cn + "',name_en='" + name_en + "',photo='" + photo + "',title_cn='" + title_cn + "',zy_cn='" + zy_cn + "',research_cn='" + research_cn + "',intro_cn='" + intro_cn + "',title_en='" + title_en + "',zy_en='" + zy_en + "',research_en='" + research_en + "',intro_en='" + intro_en + "',sequence='" + sequence + "',pathid='" + pathid + "' where id = " + QueryString.GetId;
                    da.RunSql(sql);
                    if (getSafeTextBoxText(Password) != "")
                    {
                        da.RunSql("update tm_teacher set password = '" + password + "' where id=" + QueryString.GetId);
                    }
                }
                Jscript.AlertAndRedirect("保存成功！", "Teacher_List.aspx");
            }
            catch
            {
                this.Label1.Text = "<div class=\"boxdiv2\">提交失败！</div>";
            }
            finally
            {
                
                this.Image1.ImageUrl = "include/images/nonebig.gif";
            }
        }
    }

    public string getSafeTextBoxText(TextBox tb)
    {
        return tb.Text.Trim().Replace("'", "''");
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
                    this.Photo.Text = "/Upload/" + ming;
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
