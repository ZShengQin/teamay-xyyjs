using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamayBase;
namespace Teamay_CBST.bgbx
{
    public partial class deleteAction : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataAccess da = new DataAccess();
                string id = QueryString.GetId;
                string type = QueryString.GetAction;
                if (type == "user")
                {
                    da.RunSql("delete from tm_User where id=" + id);
                    Response.Redirect("userList.aspx");
                    Response.End();
                }
                if (type == "download")
                {
                    da.RunSql("delete from tm_link where id=" + id);
                    Response.Redirect("downloadList.aspx");
                    Response.End();
                }
                if (type == "teacher")
                {
                    da.RunSql("delete from tm_teacher where id=" + id);
                    Response.Redirect("userList.aspx");
                    Response.End();
                }
            }
        }
    }
}