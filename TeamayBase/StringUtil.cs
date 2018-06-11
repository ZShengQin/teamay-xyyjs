using System;
using System.Drawing;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Imaging;
using System.Text;
using System.Web.Security;

namespace TeamayBase
{
    /// <summary>
    /// 对一些字符串进行操作的类
    /// 创建时间：2006-8-3
    /// 创建者：马先光
    /// </summary>
    public class StringUtil
    {
        private static string passWord;	//加密字符串

        /// <summary>
        /// 判断输入是否数字
        /// </summary>
        /// <param name="num">要判断的字符串</param>
        /// <returns></returns>
        static public bool VldInt(string num)
        {
            #region
            try
            {
                Convert.ToInt32(num);
                return true;
            }
            catch { return false; }
            #endregion
        }
          

        /// <summary>
        /// 修改特殊字符
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        static public string CheckStr(string str)
        {
            #region
            return str.Replace("<br />\r\n", "\r\n").Replace("&", "&amp;").Replace("'", "&apos;").Replace(@"""", "&quot;").Replace(" ", "&nbsp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace(" ", "&nbsp;").Replace(" where ", " wh&#101;re ").
                Replace(" select ", " sel&#101;ct ").Replace(" insert ", " ins&#101;rt ").Replace(" create ", " cr&#101;ate ").Replace(" drop ", " dro&#112 ").
                Replace(" alter ", " alt&#101;r ").Replace(" delete ", " del&#101;te ").Replace(" update ", " up&#100;ate ").Replace(" or ", " o&#114; ").Replace("\"", @"&#34;").
                Replace("\r\n", "<br />\r\n");
            #endregion
        }

        /// <summary>
        /// 恢复特殊字符
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        static public string UnCheckStr(string str)
        {
            #region
            return str.Replace("&amp;", "&").Replace("&apos;", "'").Replace("&quot;", @"""").Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&nbsp;", " ").Replace(" wh&#101;re ", " where ").
                Replace(" sel&#101;ct ", " select ").Replace(" ins&#101;rt ", " insert ").Replace(" cr&#101;ate ", " create ").Replace(" dro&#112 ", " drop ").
                Replace(" alt&#101;r ", " alter ").Replace(" del&#101;te ", " delete ").Replace(" up&#100;ate ", " update ").Replace(" o&#114; ", " or ").Replace(@"&#34;", "\"");
            #endregion
        }

        /// <summary>
        /// 编辑器代码转换
        /// </summary>
        /// <returns></returns>
        static public string UBBCode(string strContent, string DisSM, string DisUBB, string DisIMG, string AutoURL, string AutoKEY, DataView log_Smilies, DataView log_KeywordsContent)
        {
            #region
            string re, tmpStr, tmpStr1, tmpStr2, tmpStr3, tmpStr4, rndID;
            // Regex r;// 声明一个 Regex类的变量
            MatchCollection strMatchs;//表示非重叠匹配的序列
            //string strContent,string DisSM,string DisUBB,string DisIMG,string AutoURL,string AutoKEY

            if (AutoURL == "1")
            {
                re = @"([^=\]][\'']*?|^)(http|https|rstp|ftp|mms|ed2k)://([A-Za-z0-9\.\/=\?%\-_~`&@':+!]*)";
                // r = new Regex(re);
                //strMatchs = r.Matches(strContent);
                strMatchs = Regex.Matches(strContent, re);
                foreach (Match NextMatch in strMatchs)
                {
                    tmpStr = NextMatch.Groups[0].Value;
                    tmpStr1 = NextMatch.Groups[1].Value;
                    tmpStr2 = NextMatch.Groups[2].Value;
                    tmpStr3 = NextMatch.Groups[3].Value;
                    strContent = strContent.Replace(tmpStr, @"<a href=""" + tmpStr2 + @"://" + tmpStr3 + @""" target=""_blank"">" + tmpStr2 + @"://" + tmpStr3 + @"</a>");
                }
            }
            if (DisUBB != "1")
            {
                if (DisIMG == "1")
                {
                    re = @"(\[img\])(.[^\]]*)\[\/img\]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr2 = NextMatch.Groups[2].Value;
                        if (DisIMG == "1")
                            strContent = strContent.Replace(tmpStr, @"<img src=""" + tmpStr2 + @""" border=""0"" alt=""""/>");
                        else
                            strContent = strContent.Replace(tmpStr, @"<a href=""" + tmpStr2 + @""" target=""_blank"" title=""" + tmpStr2 + @"""><img src=""images/image.gif"" alt="""" style=""margin:0px 2px -3px 0px"" border=""0""/>查看图片</a>");
                    }

                    re = @"\[img=(left|right|center|absmiddle|)\](.[^\]]*)(\[\/img\])";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        tmpStr2 = NextMatch.Groups[2].Value;
                        if (DisIMG == "1")
                            strContent = strContent.Replace(tmpStr, @"<img align=""" + tmpStr1 + @""" src=""" + tmpStr2 + @""" border=""0"" alt=""""/>");
                        else
                            strContent = strContent.Replace(tmpStr, @"<a href=""" + tmpStr2 + @""" target=""_blank"" title=""" + tmpStr2 + @"""><img src=""images/image.gif"" alt="""" style=""margin:0px 2px -3px 0px"" border=""0""/>查看图片</a>");
                    }

                    re = @"\[img=(\d*|),(\d*|)\](.[^\]]*)\[\/img\]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        tmpStr2 = NextMatch.Groups[2].Value;
                        tmpStr3 = NextMatch.Groups[3].Value;
                        if (DisIMG == "1")
                            strContent = strContent.Replace(tmpStr, @"<img width=""" + tmpStr1 + @""" height=""" + tmpStr2 + @""" src=""" + tmpStr3 + @""" border=""0"" alt=""""/>");
                        else
                            strContent = strContent.Replace(tmpStr, @"<a href=""" + tmpStr3 + @""" target=""_blank"" title=""" + tmpStr3 + @"""><img src=""images/image.gif"" alt="""" style=""margin:0px 2px -3px 0px"" border=""0""/>查看图片</a>");
                    }

                    re = @"\[img=(\d*|),(\d*|),(left|right|center|absmiddle|)\](.[^\]]*)(\[\/img\])";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        tmpStr2 = NextMatch.Groups[2].Value;
                        tmpStr3 = NextMatch.Groups[3].Value;
                        tmpStr4 = NextMatch.Groups[4].Value;
                        if (DisIMG == "1")
                            strContent = strContent.Replace(tmpStr, @"<img width=""" + tmpStr1 + @""" height=""" + tmpStr2 + @""" align=""" + tmpStr3 + @""" src=""" + tmpStr4 + @""" border=""0"" alt=""""/>");
                        else
                            strContent = strContent.Replace(tmpStr, @"<a href=""" + tmpStr4 + @""" target=""_blank"" title=""" + tmpStr4 + @"""><img src=""images/image.gif"" alt="""" style=""margin:0px 2px -3px 0px"" border=""0""/>查看图片</a>");
                    }
                    //-----------多媒体标签----------------
                    re = @"\[(swf|wma|wmv|rm|ra|qt)(=\d*?|)(,\d*?|)\]([^<>]*?)\[\/(swf|wma|wmv|rm|ra|qt)\]";
                    strMatchs = Regex.Matches(strContent, re);
                    string strType, strWidth, strHeight, strSRC;
                    string TitleText = "";
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        strType = NextMatch.Groups[1].Value;
                        if (strType == "swf")
                            TitleText = @"<img src=""images/flash.gif"" alt="""" style=""margin:0px 2px -3px 0px"" border=""0""/>Flash动画";
                        else if (strType == "wma")
                            TitleText = @"<img src=""images/music.gif"" alt="""" style=""margin:0px 2px -3px 0px"" border=""0""/>播放音频文件";
                        else if (strType == "wmv")
                            TitleText = @"<img src=""images/mediaplayer.gif"" alt="""" style=""margin:0px 2px -3px 0px"" border=""0""/>播放视频文件";
                        else if (strType == "rm")
                            TitleText = @"<img src=""images/realplayer.gif"" alt="""" style=""margin:0px 2px -3px 0px"" border=""0""/>播放real视频流文件";
                        else if (strType == "ra")
                            TitleText = @"<img src=""images/realplayer.gif"" alt="""" style=""margin:0px 2px -3px 0px"" border=""0""/>播放real音频流文件";
                        else if (strType == "qt")
                            TitleText = @"<img src=""images/mediaplayer.gif"" alt="""" style=""margin:0px 2px -3px 0px"" border=""0""/>播放mov视频文件";

                        strWidth = NextMatch.Groups[2].Value;
                        strHeight = NextMatch.Groups[3].Value;
                        if (strWidth.Length == 0)
                            strWidth = "400";
                        else
                            strWidth = strWidth.Substring(strWidth.Length - 1);

                        if (strHeight.Length == 0)
                            strHeight = "300";
                        else
                            strHeight = strHeight.Substring(strHeight.Length - 1);

                        strSRC = NextMatch.Groups[4].Value;
                        rndID = GenerateCheckCode();
                        strContent = strContent.Replace(tmpStr, @"<div class=""UBBPanel""><div class=""UBBTitle"">" + TitleText + @"</div><div class=""UBBContent""><a id=""" + rndID + @"_href"" href=""javascript:MediaShow('" + strType + "','" + rndID + "','" + strSRC + "','" + strWidth + "','" + strHeight + @"')""><img name=""" + rndID + @"_img"" src=""images/mm_snd.gif"" style=""margin:0px 3px -2px 0px"" border=""0"" alt=""""/><span id=""" + rndID + @"_text"">在线播放</span></a><div id=""" + rndID + @"""></div></div></div>");
                    }

                    re = @"(\[mid\])(.[^\]]*)\[\/mid\]";
                    strContent = Regex.Replace(strContent, re, @"<embed src=""$2"" height=""45"" width=""314"" autostart=""0""></embed>");
                    //-----------常规标签----------------
                    re = @"\[url=(.[^\]]*)\](.[^\[]*)\[\/url]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        tmpStr2 = NextMatch.Groups[2].Value;
                        strContent = strContent.Replace(tmpStr, @"<a target=""_blank"" href=""" + tmpStr1 + @""">" + tmpStr2 + @"</a>");
                    }

                    re = @"\[url](.[^\[]*)\[\/url]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        strContent = strContent.Replace(tmpStr, @"<a target=""_blank"" href=""" + tmpStr1 + @""">" + tmpStr1 + @"</a>");
                    }

                    re = @"\[ed2k=([^\r]*?)\]([^\r]*?)\[\/ed2k]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        tmpStr2 = NextMatch.Groups[2].Value;
                        strContent = strContent.Replace(tmpStr, @"<img border="""" src=""images/ed2k.gif"" alt=""""/><a target=""_blank"" href=""" + tmpStr1 + @""">" + tmpStr2 + @"</a>");
                    }

                    re = @"\[ed2k]([^\r]*?)\[\/ed2k]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        strContent = strContent.Replace(tmpStr, @"<img border="""" src=""images/ed2k.gif"" alt=""""/><a target=""_blank"" href=""" + tmpStr1 + @""">" + tmpStr1 + @"</a>");
                    }

                    re = @"\[email=(.[^\]]*)\](.[^\[]*)\[\/email]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        tmpStr2 = NextMatch.Groups[2].Value;
                        strContent = strContent.Replace(tmpStr, @"<a href=""mailto:" + tmpStr1 + @""">" + tmpStr2 + @"</a>");
                    }


                    re = @"\[email](.[^\[]*)\[\/email]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        strContent = strContent.Replace(tmpStr, @"<a href=""mailto:" + tmpStr1 + @""">" + tmpStr1 + @"</a>");
                    }
                    //-----------字体格式----------------
                    re = @"\[pagesplitxx\]";
                    strContent = Regex.Replace(strContent, re, @"<span style=""PAGE-BREAK-AFTER: always"">[pagesplitxx]</span>");
                    re = @"\[space\]";
                    strContent = Regex.Replace(strContent, re, @"&#12288;&#12288;");
                    re = @"\[align=(\w{4,6})\]([^\r]*?)\[\/align\]";
                    strContent = Regex.Replace(strContent, re, @"<div align=""$1"">$2</div>");
                    re = @"\[color=(#\w{3,10}|\w{3,10})\]([^\r]*?)\[\/color\]";
                    strContent = Regex.Replace(strContent, re, @"<span style=""color:$1"">$2</span>");
                    re = @"\[size=(\d{1,2})\]([^\r]*?)\[\/size\]";
                    strContent = Regex.Replace(strContent, re, @"<span style=""font-size:$1pt"">$2</span>");
                    re = @"\[font=([^\r]*?)\]([^\r]*?)\[\/font\]";
                    strContent = Regex.Replace(strContent, re, @"<span style=""font-family:$1"">$2</span>");
                    re = @"\[b\]([^\r]*?)\[\/b\]";
                    strContent = Regex.Replace(strContent, re, @"<strong>$1</strong>");
                    re = @"\[i\]([^\r]*?)\[\/i\]";
                    strContent = Regex.Replace(strContent, re, @"<i>$1</i>");
                    re = @"\[u\]([^\r]*?)\[\/u\]";
                    strContent = Regex.Replace(strContent, re, @"<u>$1</u>");
                    re = @"\[s\]([^\r]*?)\[\/s\]";
                    strContent = Regex.Replace(strContent, re, @"<s>$1</s>");
                    re = @"\[sup\]([^\r]*?)\[\/sup\]";
                    strContent = Regex.Replace(strContent, re, @"<sup>$1</sup>");
                    re = @"\[sub\]([^\r]*?)\[\/sub\]";
                    strContent = Regex.Replace(strContent, re, @"<sub>$1</sub>");
                    re = @"\[fly\]([^\r]*?)\[\/fly\]";
                    strContent = Regex.Replace(strContent, re, @"<marquee width=""90%"" behavior=""alternate"" scrollamount=""3"">$1</marquee>");
                    //-----------特殊标签---------------
                    re = @"\[down=(.[^\]]*)\](.[^\[]*)\[\/down]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        tmpStr2 = NextMatch.Groups[2].Value;
                        strContent = strContent.Replace(tmpStr, @"<img src=""images/download.gif"" alt=""下载文件"" style=""margin:0px 2px -4px 0px""/> <a href=""" + tmpStr1 + @""" target=""_blank"">" + tmpStr2 + @"</a>");
                    }

                    re = @"\[down\](.[^\[]*)\[\/down]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        strContent = strContent.Replace(tmpStr, @"<img src=""images/download.gif"" alt=""下载文件"" style=""margin:0px 2px -4px 0px""/> <a href=""" + tmpStr1 + @""" target=""_blank"">下载此文件</a>");
                    }

                    re = @"\[mDown=(.[^\]]*)\](.[^\[]*)\[\/mDown]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        tmpStr2 = NextMatch.Groups[2].Value;
                        if (UsersInfo.GetUserName != null)
                            strContent = strContent.Replace(tmpStr, @"<img src=""images/download.gif"" alt=""下载文件"" style=""margin:0px 2px -4px 0px""/> <a href=""" + tmpStr1 + @""" target=""_blank"">" + tmpStr2 + @"</a>");
                        else
                            strContent = strContent.Replace(tmpStr, @"<img src=""images/download.gif"" alt=""只允许会员下载"" style=""margin:0px 2px -4px 0px""/> 该文件只允许会员下载! <a href=""login.aspx"">登录</a> | <a href=""register.aspx"">注册</a>");
                    }

                    re = @"\[mDown\](.[^\[]*)\[\/mDown]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        if (UsersInfo.GetUserName != null)
                            strContent = strContent.Replace(tmpStr, @"<img src=""images/download.gif"" alt=""下载文件"" style=""margin:0px 2px -4px 0px""/> <a href=""" + tmpStr1 + @""" target=""_blank"">下载此文件</a>");
                        else
                            strContent = strContent.Replace(tmpStr, @"<img src=""images/download.gif"" alt=""只允许会员下载"" style=""margin:0px 2px -4px 0px""/> 该文件只允许会员下载! <a href=""login.aspx"">登录</a> | <a href=""register.aspx"">注册</a>");
                    }

                    re = @"\[code\](.*?)\[\/code\]";
                    strContent = Regex.Replace(strContent, re, @"<div class=""UBBPanel""><div class=""UBBTitle""><img src=""images/code.gif"" style=""margin:0px 2px -3px 0px"" alt=""程序代码""/> 程序代码</div><div class=""UBBContent"">$1</div></div>");
                    re = @"\[quote\](.*?)\[\/quote\]";
                    strContent = Regex.Replace(strContent, re, @"<div class=""UBBPanel""><div class=""UBBTitle""><img src=""images/quote.gif"" style=""margin:0px 2px -3px 0px"" alt=""引用内容""/> 引用内容</div><div class=""UBBContent"">$1</div></div>");
                    re = @"\[quote=(.[^\]]*)\](.*?)\[\/quote\]";
                    strContent = Regex.Replace(strContent, re, @"<div class=""UBBPanel""><div class=""UBBTitle""><img src=""images/quote.gif"" style=""margin:0px 2px -3px 0px"" alt=""引用来自 $1""/> 引用来自 $1</div><div class=""UBBContent"">$2</div></div>");

                    re = @"\[hidden\](.*?)\[\/hidden\]";
                    if (UsersInfo.GetUserName != null)
                        strContent = Regex.Replace(strContent, re, @"<div class=""UBBPanel""><div class=""UBBTitle""><img src=""images/quote.gif"" style=""margin:0px 2px -3px 0px"" alt=""显示被隐藏内容""/> 显示被隐藏内容</div><div class=""UBBContent"">$1</div></div>");
                    else
                        strContent = Regex.Replace(strContent, re, @"<div class=""UBBPanel""><div class=""UBBTitle""><img src=""images/quote.gif"" style=""margin:0px 2px -3px 0px"" alt=""隐藏内容""/> 隐藏内容</div><div class=""UBBContent"">该内容已经被作者隐藏,只有会员才允许查阅 <a href=""login.aspx"">登录</a> | <a href=""register.aspx"">注册</a></div></div>");

                    re = @"\[hidden=(.[^\]]*)\](.*?)\[\/hidden\]";
                    if (UsersInfo.GetUserName != null)
                        strContent = Regex.Replace(strContent, re, @"<div class=""UBBPanel""><div class=""UBBTitle""><img src=""images/quote.gif"" style=""margin:0px 2px -3px 0px"" alt=""显示被隐藏内容 $1""/> 显示被隐藏内容来自 $1</div><div class=""UBBContent"">$2</div></div>");
                    else
                        strContent = Regex.Replace(strContent, re, @"<div class=""UBBPanel""><div class=""UBBTitle""><img src=""images/quote.gif"" style=""margin:0px 2px -3px 0px"" alt=""隐藏内容 $1""/> 隐藏内容</div><div class=""UBBContent"">该内容已经被作者隐藏,只有会员才允许查阅 <a href=""login.aspx"">登录</a> | <a href=""register.aspx"">注册</a></div></div>");

                    if (DisIMG == "1")
                        re = @"\[html\](.*?)\[\/html\]";
                    strMatchs = Regex.Matches(strContent, re);
                    foreach (Match NextMatch in strMatchs)
                    {
                        tmpStr = NextMatch.Groups[0].Value;
                        tmpStr1 = NextMatch.Groups[1].Value;
                        rndID = GenerateCheckCode();
                        strContent = strContent.Replace(tmpStr, @"<div class=""UBBPanel""><div class=""UBBTitle""><img src=""images/html.gif"" style=""margin:0px 2px -3px 0px""> HTML代码</div><div class=""UBBContent""><TEXTAREA rows=""8"" id=""" + rndID + @""">" + tmpStr1 + @"</TEXTAREA><br/><INPUT onclick=""runEx('" + rndID + @"')""  type=""button"" value=""运行此代码""/> <INPUT onclick=""doCopy('" + rndID + @"')""  type=""button"" value=""复制此代码""/><br/> [Ctrl+A 全部选择 提示：你可先修改部分代码，再按运行]</div></div>");
                    }
                }
            }

                //-----------List标签----------------
                strContent = strContent.Replace("[list]", "<ul>");
                re = @"\[list=(.[^\]]*)\]";
                strContent = Regex.Replace(strContent, re, @"<ul style=""list-style-type:$1"">");
                re = @"\[\*\](.[^\[]*)(\n|)";
                strContent = Regex.Replace(strContent, re, @"<li>$1</li>");
                strContent = strContent.Replace("[/list]", "</ul>");

            //-----------表情图标----------------
            if (DisSM == "1")
            {
                for (int i = 0; i < log_Smilies.Count; i++)
                {
                    strContent = strContent.Replace(log_Smilies[i]["sm_Text"].ToString(), @"<img src=""images/smilies/" + log_Smilies[i]["sm_Image"].ToString() + @""" border=""0"" style=""margin:0px 0px -2px 0px"" alt=""""/>  ");
                }
            }

            //-----------关键词识别----------------
             if (AutoKEY=="1")
             {
                 for (int i = 0; i < log_KeywordsContent.Count; i++)
                 {
                     if (log_KeywordsContent[i][3].ToString() != "" )
                         strContent = strContent.Replace(log_KeywordsContent[i][1].ToString(), @"<a href=""" + log_KeywordsContent[i][2].ToString() + @""" target=""_blank""><img src=""images/keywords/" + log_KeywordsContent[i][3].ToString() + @""" border=""0"" alt=""""/> " + log_KeywordsContent[i][1].ToString() + @"</a>");
                     else
                         strContent = strContent.Replace(log_KeywordsContent[i][1].ToString(), @"<a href=""" + log_KeywordsContent[i][2].ToString() + @""" target=""_blank"">" + log_KeywordsContent[i][1].ToString() + @"</a>");
                 }
             }

            return strContent;
            #endregion
        }
					
        /// <summary>
        /// 截取字符串函数
        /// </summary>
        /// <param name="str">所要截取的字符串</param>
        /// <param name="num">截取字符串的长度</param>
        /// <returns></returns>
        static public string GetSubString(string str, int num)
        {
            #region
            return (str.Length > num) ? str.Substring(0, num) + "..." : str;
            #endregion
        }

        /// <summary>
        /// 过滤输入信息
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns></returns>
        public static string InputText(string text, int maxLength)
        {
            #region
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
            text = text.Replace("'", "''");
            return text;
            #endregion
        }

        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <returns></returns>
        static public string GenerateCheckCode()
        {
            #region
            int number;
            char code;
            string checkCode = String.Empty;

            System.Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));

                checkCode += code.ToString();
            }

            HttpContext.Current.Response.Cookies.Add(new HttpCookie("CheckCode", checkCode));

            return checkCode;
            #endregion
        }

        /// <summary>
        /// 获取汉字第一个拼音
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string getSpells(string input)
        {
            #region
            int len = input.Length;
            string reVal = "";
            for (int i = 0; i < len; i++)
            {
                reVal += getSpell(input.Substring(i, 1));
            }
            return reVal;
            #endregion
        }

        /// <summary>
        /// 汉字编码转换,解决IE地址栏中文
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string Strencode(string input)
        {
            #region
            return System.Web.HttpUtility.UrlEncode(InputText(input,100));
            #endregion
        }

        static public string getSpell(string cn)
        {
            #region
            byte[] arrCN = Encoding.Default.GetBytes(cn);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "?";
            }
            else return cn;
            #endregion
        }


        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="BJstr"></param>
        /// <returns></returns>
        static public string GetQuanJiao(string BJstr)
        {
            #region
            char[] c = BJstr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 0)
                    {
                        b[0] = (byte)(b[0] - 32);
                        b[1] = 255;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }

            string strNew = new string(c);
            return strNew;

            #endregion
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="QJstr"></param>
        /// <returns></returns>
        static public string GetBanJiao(string QJstr)
        {
            #region
            char[] c = QJstr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 255)
                    {
                        b[0] = (byte)(b[0] + 32);
                        b[1] = 0;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }
            string strNew = new string(c);
            return strNew;
            #endregion
        }

        #region 加密的类型
        /// <summary>
        /// 加密的类型
        /// </summary>
        public enum PasswordType
        {
            SHA1,
            MD5
        }
        #endregion


        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="PasswordString">要加密的字符串</param>
        /// <param name="PasswordFormat">要加密的类别</param>
        /// <returns></returns>
        static public string EncryptPassword(string PasswordString, string PasswordFormat)
        {
            #region
            switch (PasswordFormat)
            {
                case "SHA1":
                    {
                        passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "SHA1");
                        break;
                    }
                case "MD5":
                    {
                        passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "MD5");
                        break;
                    }
                default:
                    {
                        passWord = string.Empty;
                        break;
                    }
            }
            return passWord;
            #endregion
        }        
    }
}
