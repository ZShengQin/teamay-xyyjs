<%@ Page Language="C#" AutoEventWireup="True" Inherits="bgbx_Left" CodeBehind="Left.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>��̨����ϵͳ</title>
    <style>
        body
        {
            margin: 0px;
            background: transparent;
            overflow: hidden;
            background: url(Images/left_1.gif);
        }
        hr
        {
            width: 90%;
            text-align: left;
            size: 0;
            height: 0px;
            border-top: 1px solid #46A0C8;
        }
        .main_left_title
        {
            text-align: left;
            background: url(Images/left_2.gif) no-repeat;
            filter: alpha(opacity=75);
            padding-left: 15px;
            font-size: 14px;
            font-weight: bold;
            color: #fff;
            height: 32px;
            padding-top: 10px;
            cursor: pointer;
            width: 180px;
            float: left;
        }
        .main_left_title a
        {
            display: block;
        }
        .menu
        {
            padding: 2px 0px;
            color: #fff;
            position: relative;
            filter: alpha(opacity=100);
        }
        .menu li
        {
            list-style: none;
            float: left;
        }
        .menu a
        {
            background: url("Images/left_6.gif") no-repeat;
            color: #fff;
            text-decoration: none;
            font-size: 12px;
            display: block;
            float: left;
            width: 180px;
            height: 20px !important;
            height: 22px;
            padding-top: 4px;
            text-align: left;
            padding-left: 25px;
            margin: 0px;
        }
        .menu a:hover
        {
            background: url("Images/left_5.gif") #94D0EE no-repeat;
            filter: alpha(opacity=60);
            color: #000;
            text-decoration: none;
            font-size: 12px;
            display: block;
            float: left;
            width: 180px;
            height: 20px !important;
            height: 22px;
            padding-top: 4px;
            border: 1px solid #BBD9EC !important;
            border: 1px solid #fff;
            text-align: left;
            padding-left: 25px;
            margin: 0px;
        }
    </style>
    <script type="text/javascript">
        var old = '';
        function menu(name) {
            var submenu = document.getElementById("submenu_" + name).style;
            if (old != submenu) {
                if (old != '') {
                    old.display = 'none';
                }
                submenu.display = 'block';
                old = submenu;
            }
            else {
                submenu.display = 'none';
                old = '';
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- menu begin -->
        <%
            if (Session["Admin"] != null && Session["Admin"].ToString() == "teamay")
            {
             %>
        <div class="main_left_title">
            <a onclick="menu(1);">վ�����</a></div>
        <div class="menu" id="submenu_1" style="display: none;">
            <li><a href="Adminlist.aspx" target='frmright'>����Ա�б�</a></li>
            <li><a href="addadmin.aspx" target='frmright'>��ӹ���Ա</a></li>
            <li><a href="Article_lanmu_add.aspx" target='frmright'>һ����Ŀ����</a></li>
            <li><a href="Article_lanmu2_add.aspx" target='frmright'>����Ŀ����</a></li>
            <li><a href="SiteList.aspx" target='frmright'>��վ����</a></li>
            <li><a href="SiteAdd.aspx" target='frmright'>�½���վ</a></li>
            <li><a href="addDownload.aspx" target='frmright'>��ͼ����</a></li>
            <li><a href="DownloadList.aspx" target='frmright'>��ͼ�б�</a></li>
        </div>
        <%} %>
        <div class="main_left_title">
            <a onclick="menu(2);">���ݹ���</a></div>
        <div class="menu" id="submenu_2" style="display: none;">
            <li><a href="Path_Man.aspx" target='frmright'>��Ŀ����</a></li>
            <li><a href="Article_add.aspx" target='frmright'>�������</a></li>
            <li><a href="Article_list.aspx" target='frmright'>�����б�</a></li>
            
        </div>
        <%--
		<li><a href="Teacher_add.aspx" target='frmright'>��ӵ�ʦ</a></li>
            <li><a href="Teacher_list.aspx" target='frmright'>��ʦ�б�</a></li><div class="main_left_title">
            <a onclick="menu(3);" >�о��Ŷ�����</a></div>
        <div class="menu" id="submenu_3" style="display: none;">
            <li><a href="addUser.aspx" target='frmright'>�Ŷ�����</a></li>
            <li><a href="UserList.aspx" target='frmright'>�Ŷ��б�</a></li>
        </div>
        <div class="main_left_title">
            <a onclick="menu(4);" >��ҳ���ӹ���</a></div>
        <div class="menu" id="submenu_4" style="display: none;">
            <li><a href="addDownload.aspx" target='frmright'>��������</a></li>
            <li><a href="DownloadList.aspx" target='frmright'>�����б�</a></li>
        </div>--%>
        <div class="main_left_title">
            <a onclick="menu(5);">��������</a></div>
        <div class="menu" id="submenu_5" style="display: none;">
            <li><a href="changepwd.aspx" target='frmright'>�޸�����</a></li>
            <li><a href="Logout.aspx" target='frmright'>�˳�ϵͳ</a></li>
        </div>
    </div>
    </form>
</body>
</html>
