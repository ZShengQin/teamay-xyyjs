using System;
using System.Collections.Generic;
using TeamayBase;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamayBase;
using System.Data;

namespace Teamay_CBST.HOME
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("/CN");  
        }


    }
}