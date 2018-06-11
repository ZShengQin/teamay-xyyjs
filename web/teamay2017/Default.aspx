<%@ Page Language="C#" AutoEventWireup="true" Inherits="bgbx_Default" EnableEventValidation="true" Codebehind="Default.aspx.cs" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript">
        //检查管理员登录------------------------------------------------------------------------------
        function CheckAdminLogin() {
            var check;
            if (!voidNum(document.AdminLogin.LoginName.value)) {
                alert("请正确输入管理员名称（由0-9,a-z,-_任意组合的字符串）。");
                document.AdminLogin.LoginName.focus();
                return false;
                exit;
            }
            if (!voidNum(document.AdminLogin.LoginPassword.value)) {
                alert("请输入管理员密码。");
                document.AdminLogin.LoginPassword.focus();
                return false;
                exit;
            }
            if (!voidNum(document.AdminLogin.CheckCode.value)) {
                alert("请正确输入验证码。");
                document.AdminLogin.CheckCode.focus();
                return false;
                exit;
            }
            return true;
        }
        function voidNum(argValue) {
            var flag1 = false;
            var compStr = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_-";
            var length2 = argValue.length;
            for (var iIndex = 0; iIndex < length2; iIndex++) {
                var temp1 = compStr.indexOf(argValue.charAt(iIndex));
                if (temp1 == -1) {
                    flag1 = false;
                    break;
                }
                else
                { flag1 = true; }
            }
            return flag1;
        } 
    </script>
    <style type="text/css">
        body
        {
            background-color: #0666B3; margin-top:100px; font-size:12px;
        }
        div{ padding:0; margin:0; }
        table{ margin-left:1px;}
    </style>
</head>
<body>
    <form id="AdminLogin" runat="server">
    <div>
        <div align="center">
            <img src="images/login_r1.jpg"></div>
        <div align="center">
            <img src="images/login_r2.jpg"></div>
        <div align="center">
            <img src="images/login_r3.jpg"></div>
        <div align="center">
            <img src="images/login_r4.jpg"></div>
        <div align="center">
            <img src="images/login_r5.jpg"></div>
        <div align="center">
            <img src="images/login_r6.jpg"></div>
        <div align="center">
            <img src="images/login_r7.jpg"></div>
        <div align="center">
            <table width="595" height="76" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="144" height="0" rowspan="2" background="images/login_h1.jpg" >
                        <div style="margin-top: 15px; margin-left: 60px">
                            <input name="LoginName" type="text" id="LoginName" runat="server" maxlength="12"
                                style="width: 80px; border-right: #F7F7F7 0px solid; border-top: #F7F7F7 0px solid;
                                font-size: 9pt; border-left: #F7F7F7 0px solid; border-bottom: #c0c0c0 1px solid;
                                height: 16px; background-color: #F7F7F7" onmouseover="this.style.background='#ffffff'"
                                onmouseout="this.style.background='#F7F7F7'" onfocus="this.select(); " />
                        </div>
                    </td>
                    <td width="122" rowspan="2" valign="bottom" background="images/login_h2.jpg">
                        <div style="margin-bottom: 19px; margin-left: 35px">
                            <input name="LoginPassword" type="password" id="LoginPassword" runat="server" maxlength="12"
                                style="width: 80px; border-right: #F7F7F7 0px solid; border-top: #F7F7F7 0px solid;
                                font-size: 9pt; border-left: #F7F7F7 0px solid; border-bottom: #c0c0c0 1px solid;
                                height: 16px; background-color: #F7F7F7" onmouseover="this.style.background='#ffffff'"
                                onmouseout="this.style.background='#F7F7F7'" onfocus="this.select();" />
                        </div>
                    </td>
                    <td width="211" height="0" rowspan="2" valign="bottom" background="images/login_h3.jpg">
                        <div style="margin-bottom: 19px; margin-left: 50px">
                            <input name="CheckCode" type="text" id="CheckCode" runat="server" style="width: 60px;
                                border-right: #F7F7F7 0px solid; border-top: #F7F7F7 0px solid; font-size: 9pt;
                                border-left: #F7F7F7 0px solid; border-bottom: #c0c0c0 1px solid; height: 16px;
                                background-color: #F7F7F7;" onfocus="this.select();" onmouseover="this.style.background='#ffffff'"
                                onmouseout="this.style.background='#F7F7F7'" maxlength="8" />
                            <img id='checkcode' src='CheckCode.aspx' style='border: 1px solid #ffffff; width: 40px;
                                vertical-align: middle' />
                        </div>
                    </td>
                    <td width="118" valign="bottom" background="images/login_h4.jpg" height="76">
                        <div style="margin-bottom: 10px; margin-left: 0px">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/login_menu.jpg"
                                Width="102" Height="37" OnClientClick="return CheckAdminLogin()" OnClick="ImageButton1_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div align="center">
            <img src="images/login_r8.jpg"></div>
        <div align="center">
            <img src="images/login_r9.jpg"></div>
    </div>
    </form>
</body>
</html>
