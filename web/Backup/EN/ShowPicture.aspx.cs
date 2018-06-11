using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamayBase;
using System.Data;

namespace Teamay_CBST.EN
{
    public partial class ShowPicture : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string id = QueryString.GetId;
                string mid = QueryString.GetTypeid;
                string tid = QueryString.GetPayway;
                if (mid != null && mid != "")
                {
                    id = DbHelperSQL.GetSingle("select top 1 id from tm_path where realid in (select [type] from tm_teacher where id=" + mid + ") and ntype<>'SinglePage' order by sequence desc").ToString();
                }
                if (tid != null && tid != "")
                {
                    id = DbHelperSQL.GetSingle("select top 1 id from tm_path where realid in (select [class] from tm_page where id=" + tid + ") and ntype<>'SinglePage' order by sequence desc").ToString();
                }
                if (id + mid + tid == "")
                {
                    return;
                }
                LeftMenu.DataSource = DbHelperSQL.Query("select id,cn_name,zlevel,myparent from tm_path where barid in(select barid from tm_path where id=" + id + ") and (zlevel=2 or zlevel=3) and showinleft=1 order by sequence");
                LeftMenu.DataBind();
                LeftTitle.Text = DbHelperSQL.GetSingle("select cn_name from tm_path where id in (select barid from tm_path where id=" + id + ")").ToString();



                DataTable dt = DbHelperSQL.Query("select cn_name,cn_intro,ntype,realID,barID from tm_path where id =" + id).Tables[0];
                if (dt != null && dt.Rows.Count == 1)
                {
                    DaoArticle.Text = dt.Rows[0]["cn_name"].ToString();
                    string typename = dt.Rows[0]["ntype"].ToString();
                    nowText.Value = dt.Rows[0]["cn_name"].ToString();
                    //如果是单篇文章
                    if (mid != null)
                    {
                        singleNews.Visible = true;
                        if (typename == "PhotoList-more")
                        {
                            DataTable dt1 = DbHelperSQL.Query("select title,pic,contents from tm_page where id =" + mid).Tables[0];
                            if (dt1 != null && dt1.Rows.Count == 1)
                            {
                                SingleContent.Text = dt1.Rows[0]["contents"].ToString();
                                //DbHelperSQL.ExecuteSql("update tm_page set pinglun=pinglun+1 where id=" + type);
                            }
                        }
                        return;
                    }

                    if (tid != null)
                    {
                        singleNews.Visible = true;
                        DataTable dt1 = DbHelperSQL.Query("select contents from tm_page where id =" + tid).Tables[0];
                        if (dt1 != null && dt1.Rows.Count == 1)
                        {
                            SingleContent.Text = dt1.Rows[0]["contents"].ToString();
                            //DbHelperSQL.ExecuteSql("update tm_page set pinglun=pinglun+1 where id=" + type);
                        }
                        return;
                    }



                    //如果是列表
                    if (typename == "PhotoList-more")
                    {
                        Classid = dt.Rows[0]["realID"].ToString();
                        simpleImgs.DataSource = DbHelperSQL.Query("select id,title,pic from tm_page where class=" + Classid + " order by id");
                        simpleImgs.DataBind();
                    }
                    else
                    {
                        simplelists.Visible = true;
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
            ss = da.GetDs("select id,title,class,pic from tm_page where [class]=" + Classid + " order by pxtime desc,id desc");
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ss.Tables[0].DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 9;
            pds.CurrentPageIndex = Convert.ToInt32(this.labPage.Text) - 1;
            simpleImgs.DataSource = pds;
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
            simpleImgs.DataBind();
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