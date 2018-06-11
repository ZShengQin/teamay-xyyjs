<%@ Page Language="C#" AutoEventWireup="True" Inherits="bgbx_Main" CodeBehind="Main.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=gb2312" />
    <title>后台管理系统</title>
    <style type="text/css">
        .navPoint
        {
            cursor: hand;
        }
        a
        {
            color: #135294;
            text-decoration: none;
        }
        a:hover
        {
            color: #ff6600;
            text-decoration: underline;
        }
        body
        {
            overflow-x: hidden;
            overflow: hidden;
            font-size: 12px;
            font-family: tahoma, 宋体, fantasy;
            text-align: center;
            margin: 0;
        }
        .top_table
        {
            width: 100%;
            background: url("Images/top_1.gif");
            height: 43px;
        }
        .top_table_bg
        {
            width: auto;
            background-image: url("Images/top_2.gif");
            background-repeat: repeat-y;
            height: 41px;
        }
        .system_logo
        {
            width: 20%;
            float: left;
            text-align: left;
        }
        .time
        {
            width: 80%;
            padding: 25px 40px 0px 5px;
            float: left;
            text-align: right;
            color:#fff;
        }
        .main_left
        {
            table-layout: auto;
            width: 180px;
            background: url(Images/left_1.gif);
        }
        .left_iframe
        {
            height: 100%;
            visibility: inherit;
            width: 180px;
            background: transparent;
        }
        .main_iframe
        {
            height: 92%;
            visibility: inherit;
            width: 100%;
            z-index: 1;
        }
        table
        {
            font-size: 12px;
            font-family: tahoma, 宋体, fantasy;
        }
        td
        {
            font-size: 12px;
            font-family: tahoma, 宋体, fantasy;
        }
    </style>
    <script type="text/javascript">
        var status = 1;
        function switchSysBar() {
            if (1 == window.status) {
                window.status = 0;
                switchPoint.innerHTML = '<img src="Images/left_3.gif">';
                document.all("frmTitle").style.display = "none"
            }
            else {
                window.status = 1;
                switchPoint.innerHTML = '<img src="Images/left_4.gif">';
                document.all("frmTitle").style.display = ""
            } 
        }
    </script>
    <script type="text/javascript" language="javascript">
        function setTime() {
            var currentTime = new Date().toLocaleString();
            document.getElementById("timmers").innerHTML = currentTime;
        }
        setInterval(setTime, 1000);
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--导航部分-->
        <div class="top_table">
            <div class="top_table_bg">
                <div class="system_logo">
                </div>
                <div class="time">
                    <div id="htmer_time">
                    </div>
                </div>
            </div>
        </div>
        <!--导航部分结束-->
        <table border="0" cellpadding="0" cellspacing="0" height="93%" width="100%" style="background: #337ABB;">
            <tr>
                <td height="437"  align="middle" valign="top" class="main_left" id="frmTitle" name="fmTitle">
                    <iframe frameborder="0" id="frmleft" width="180" name="frmleft" src="left.aspx" class="left_iframe" allowtransparency="true"></iframe>
                </td>
                <td bgcolor="#337ABB" style="width: 10px">
                    <table border="0" cellpadding="0" cellspacing="0" height="100%">
                        <tr>
                            <td onclick="switchSysBar()" style="height: 100%">
                                <span class="navPoint" id="switchPoint" title="关闭/打开左栏">
                                    <img src="Images/left_4.gif"></span>
                            </td>
                        </tr>
                    </table>
                </td>
                <td bgcolor="#337ABB"  valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#C4D8ED">
                        <tr height="32">
                            <td valign="top" width="10" background="Images/top_3.gif">
                                <img src="Images/table_1.gif" alt="" />
                            </td>
                            <td background="Images/top_3.gif" width="23">
                                <img src="Images/top_4.gif" alt="" align="absmiddle" />
                            </td>
                            <td background="Images/top_3.gif" width="200px" style="color: #135294;">
                                <span id="timmers"></span>
                            </td>
                            <td background="Images/top_3.gif" style="text-align: right; color: #135294;">
                               用户（<%=Session["Admin"].ToString()%>）正在登录 | <a href="changepwd.aspx" target="frmright">更改密码</a> | <a href="Logout.aspx" target="_top">
                                    退出</a>
                            </td>
                            <td align="right" valign="top" background="Images/top_3.gif" width="28">
                                <img src="Images/table_2.gif" />
                            </td>
                            <td align="right" width="16" bgcolor="#337ABB">
                            </td>
                        </tr>
                    </table>
                    <iframe frameborder="0" id="frmright" name="frmright" scrolling="yes" src="main.htm"
                        class="main_iframe"></iframe>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background: #C4D8ED;">
                        <tr>
                            <td>
                                <img src="Images/table_3.gif" alt="" width="5" height="6" />
                            </td>
                            <td align="right">
                                <img src="Images/table_4.gif" alt="" width="5" height="6" />
                            </td>
                            <td align="right" width="16" bgcolor="#337ABB">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
