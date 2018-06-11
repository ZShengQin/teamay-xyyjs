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

public partial class bgbx_addUser : AdminBase
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
                DataTable dt = da.GetTable("select login_name,name_cn,name_en,photo,sequence,type from tm_teacher where id=" + id);
                if (dt.Rows.Count == 1)
                {
                    ViewState["editmode"] = dt.Rows[0][0].ToString();
                    UserName.Text = dt.Rows[0][0].ToString();
                    UserName.ReadOnly = true;
                    name_cn.Text = dt.Rows[0]["name_cn"].ToString();
                    name_en.Text = dt.Rows[0]["name_en"].ToString();
                    photo.Text = dt.Rows[0]["photo"].ToString();
                    sequence.Text = dt.Rows[0]["sequence"].ToString();
                    DropDownList1.Items.FindByValue(dt.Rows[0]["type"].ToString()).Selected = true;
                }
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = QueryString.GetId;
        DataAccess da = new DataAccess();
        string username = UserName.Text;
        string password = pwd.Text;
        string _name_cn = name_cn.Text;
        string _name_en = name_en.Text;
        string _photo = photo.Text;
        string _sequence = sequence.Text;
        string _type = DropDownList1.SelectedValue;

        password = StringUtil.EncryptPassword(password, "MD5");

        if (ViewState["editmode"] != null)
        {
            if (pwd.Text.Trim() != "")
            {
                da.RunSql("update tm_teacher set password='" + password + "',name_cn='" + _name_cn + "',name_en='" + _name_en + "',photo='" + _photo + "',sequence='" + _sequence + "',type=" + _type + " where id='" + id + "'");
            }
            else
            {
                da.RunSql("update tm_teacher set name_cn='" + _name_cn + "',name_en='" + _name_en + "',photo='" + _photo + "',sequence='" + _sequence + "',type=" + _type + " where id='" + id + "'");
            }
        }
        else
        {
            da.RunSql("insert into tm_teacher(login_name,password,name_cn,name_en,photo,sequence,type) values('" + username + "','" + password + "','" + _name_cn + "','" + _name_en + "','" + _photo + "','" + _sequence + "'," + _type + ")");
        }
        ClientScript.RegisterClientScriptBlock(this.GetType(), "success_add_zs_user", "<script>alert('操作成功！')</script>");
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
                    this.photo.Text = "Upload/" + ming;
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
