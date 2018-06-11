using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamayBase;
using System.Data;

namespace Teamay_CBST.CN
{
    public partial class ErrorHandle : System.Web.UI.Page
    {
        public string barID = "about_03.jpg";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string id = QueryString.GetId;

                if (id == null)
                {
                    Response.Redirect("ErrorHandle.aspx?id=1340");
                }

            }
        }

  
    }
}