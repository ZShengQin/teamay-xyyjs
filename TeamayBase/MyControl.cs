using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeamayBase
{
    /// <summary>
    /// 对控件的处理类
    /// 创建时间：2006-8-3
    /// 创建者：马先光
    /// </summary>
    public class MyControl 
    {        

        /// <summary>
        /// 获取文本框中输入内容
        /// </summary>
        /// <param name="ctrl">TextBox控件ID</param>
        /// <returns></returns>
        static public string GetText(TextBox ctrl)
        {            
            #region
            return ctrl.Text.Trim().Replace("'", "\"");
            #endregion
        }     

        /// <summary>
        /// 清除文本框内容
        /// </summary>
        /// <param name="list">TextBox控件数组</param>
        static public void ClearText(TextBox[] list)
        {
            foreach (TextBox ctrl in list)
                ctrl.Text = null;
        }

        /// <summary>
        /// 获取下拉列表框中选择内容，类型0为Text值，类型1为Value值
        /// </summary>
        /// <param name="ctrl">DropDownList控件ID</param>
        /// <param name="strType">取值类型，0为Text,1为Value</param>
        /// <returns></returns>
        static public string GetDdlValue(DropDownList ctrl, int strType)
        {
            #region
            return (strType == 0) ? ctrl.SelectedItem.Text : ctrl.SelectedValue;
            #endregion
        } 

        /// <summary>
        /// 绑定日期
        /// </summary>
        /// <param name="list">日期控件数组</param>
        static public void time2(DropDownList[] list)
        {
            #region
            int year = Convert.ToInt32(DateTime.Now.Year);
            int month = Convert.ToInt32(DateTime.Now.Month);
            int day = Convert.ToInt32(DateTime.Now.Day);
            int hour = Convert.ToInt32(DateTime.Now.Hour);
            int minute = Convert.ToInt32(DateTime.Now.Minute);
            for (int i = year - 80; i < year + 1; i++)
            {
                list[0].Items.Add(i.ToString());
            }
            ((DropDownList)list[0]).SelectedValue = "1980";
            for (int i = 1; i < 13; i++)
            {
                list[1].Items.Add(i.ToString());
            }
            ((DropDownList)list[1]).SelectedValue = month.ToString();
            for (int i = 1; i < DateTime.DaysInMonth(year, month) + 1; i++)
            {
                list[2].Items.Add(i.ToString());
            }
            list[2].SelectedValue = day.ToString();
            switch (list.Length)
            {
                case 4:
                    {
                        for (int i = 0; i < 24; i++)
                        {
                            list[3].Items.Add(i.ToString());
                        }
                        list[3].SelectedValue = hour.ToString();
                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < 24; i++)
                        {
                            list[3].Items.Add(i.ToString());
                        }
                        list[3].SelectedValue = hour.ToString();
                        for (int i = 0; i < 60; i++)
                        {
                            list[4].Items.Add(i.ToString());
                        }
                        list[4].SelectedValue = minute.ToString();
                        break;
                    }
            }
            #endregion
        }

        /// <summary>
        /// 通过年月日控件获取当月日期
        /// </summary>
        /// <param name="ctrl1">年控件</param>
        /// <param name="ctrl2">月控件</param>
        /// <param name="ctrl3">日控件</param>
        static public void time(DropDownList ctrl1, DropDownList ctrl2, DropDownList ctrl3)
        {
            #region
            ctrl3.Items.Clear();
            for (int i = 1; i < DateTime.DaysInMonth(Convert.ToInt32(ctrl1.SelectedValue), Convert.ToInt32(ctrl2.SelectedValue)) + 1; i++)
            {
                ctrl3.Items.Add(i.ToString());
            }
            #endregion
        }
        /// <summary>
        /// 简单绑定DataList
        /// </summary>
        /// <param name="ctrl">控件ID</param>
        /// <param name="mydv">数据视图</param>
        public void BindDataList(Control ctrl, DataView mydv)
        {
            ((DataList)ctrl).DataSource = mydv;
            ((DataList)ctrl).DataBind();
        }
        /// <summary>
        /// SqlDataReader简单绑定DataList
        /// </summary>
        /// <param name="ctrl">控件ID</param>
        /// <param name="mydv">数据视图</param>
        public void BindDataReaderList(Control ctrl, SqlDataReader mydv)
        {
            ((DataList)ctrl).DataSource = mydv;
            ((DataList)ctrl).DataBind();
        }

        /// <summary>
        /// 简单绑定GridView1
        /// </summary>
        /// <param name="ctrl">控件ID</param>
        /// <param name="mydv">数据视图</param>
        public void BindGridView(Control ctrl, DataView mydv)
        {
            ((GridView)ctrl).DataSource = mydv;
            ((GridView)ctrl).DataBind();
        }
    }
}
