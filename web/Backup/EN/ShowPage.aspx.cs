using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamayBase;
using System.Data;

namespace Teamay_CBST.EN
{
    public partial class ShowPage : System.Web.UI.Page
    {
        public string barID = "about_03.jpg";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string id = QueryString.GetId;
                string mid = QueryString.GetTypeid;

                if (id == null && mid == null)
                {
                    Response.Redirect("ErrorHandle.aspx?id=1340");
                }

                try
                {
                    if (mid != null)
                    {
                        id = DbHelperSQL.GetSingle("select top 1 id from tm_path where realid in (select [class] from tm_page where id=" + mid + ") and ntype<>'SinglePage' order by sequence desc").ToString();
                    }
                    DataSet ds = DbHelperSQL.Query("select id,cn_name,zlevel,myparent from tm_path where barid in(select barid from tm_path where id=" + id + ") and (zlevel=2 or zlevel=3) and showinleft=1 order by sequence");
                    LeftMenu.DataSource = ds;
                    LeftMenu.DataBind();
                    LeftTitle.Text = DbHelperSQL.GetSingle("select cn_name from tm_path where id in (select barid from tm_path where id=" + id + ")").ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("ErrorHandle.aspx?id=2580");
                }



                DataTable dt = DbHelperSQL.Query("select cn_name,cn_intro,ntype,realID,barID from tm_path where id =" + id).Tables[0];
                if (dt != null && dt.Rows.Count == 1)
                {
                    ArticleTitle.Text = dt.Rows[0]["cn_name"].ToString();
                    nowText.Value = dt.Rows[0]["cn_name"].ToString();
                    DaoArticle.Text = LeftTitle.Text + " > " + dt.Rows[0]["cn_name"].ToString();
                    barID = dt.Rows[0]["barID"].ToString();

                    //如果是单篇文章
                    string type = QueryString.GetTypeid;
                    if (type != null)
                    {
						Page.EnableViewState = false;
                        if (dt.Rows[0]["cn_name"].ToString() == "教师介绍")
                        {
                            faculty.Visible = true;
                            DataTable dt1 = DbHelperSQL.Query("select title,contents,pinglun,convert(varchar(20),[time],23) as time from tm_page where id =" + type).Tables[0];
                            if (dt1 != null && dt1.Rows.Count == 1)
                            {
                                facultyviewContent.Text = dt1.Rows[0]["contents"].ToString();
                                DbHelperSQL.ExecuteSql("update tm_page set rq=rq+1 where id=" + type);
                            }
                        }
                        else
                        {
                            singleNews.Visible = true;
                            DataTable dt1 = DbHelperSQL.Query("select title,contents,pinglun,convert(varchar(20),[time],23) as time,len(keytxt) enlink,keytxt  from tm_page where id =" + type).Tables[0];
                            if (dt1 != null && dt1.Rows.Count == 1)
                            {
                                string nums = dt1.Rows[0]["enlink"].ToString();
                                if (nums != "0" && nums != "")
                                {
                                    Response.Redirect(dt1.Rows[0]["keytxt"].ToString());
                                    Response.End();
                                    return;
                                }
                                SingleTitle.Text = dt1.Rows[0]["title"].ToString();
                                SingleDate.Text = dt1.Rows[0]["time"].ToString();
                                SingleTimes.Text = dt1.Rows[0]["pinglun"].ToString();
                                SingleContent.Text = dt1.Rows[0]["contents"].ToString();
                                DbHelperSQL.ExecuteSql("update tm_page set rq=rq+1 where id=" + type);
                            }
                        }
                        return;
                    }


                    if (dt.Rows[0]["ntype"].ToString() == "SinglePage")
                    {
						Page.EnableViewState = false;
                        TextList_time.Visible = false;
                        if (dt.Rows[0]["realID"].ToString() == "")
                        {
                            ContentFromDB.Text = dt.Rows[0]["cn_intro"].ToString();
                        }
                        else
                        {
                            Response.Redirect("ShowPage.aspx?id=" + dt.Rows[0]["realID"].ToString());
                            Response.End();
                            return;
                        }

                    }
                    else if (dt.Rows[0]["ntype"].ToString().Contains("PhotoList"))
                    {
                        Response.Redirect("ShowPicture.aspx?id=" + id);
                        Response.End();
                        return;
                    }
                    else
                    {
                    
                        TextList_time.Visible = true;
                        Classid = dt.Rows[0]["realID"].ToString();
                        this.labPage.Text = "1";
                        this.contrlRepeater();
                    }

                }
            }
        }

        public string Classid;

        public void contrlRepeater()
        {
            string id = QueryString.GetId;
            if (Classid == null)
            {
                DataTable dt = DbHelperSQL.Query("select realID from tm_path where id =" + id).Tables[0];
                Classid = dt.Rows[0]["realID"].ToString();
            }
            DataAccess da = new DataAccess();
            DataSet ss = new DataSet();
            ss = da.GetDs("select id,title,convert(varchar(20),[time],23) as timenew,class from tm_page where [class]=" + Classid + " order by pxtime desc,id desc");
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ss.Tables[0].DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 20;
            pds.CurrentPageIndex = Convert.ToInt32(this.labPage.Text) - 1;
            Repeater_news.DataSource = pds;
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
            Repeater_news.DataBind();
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
}