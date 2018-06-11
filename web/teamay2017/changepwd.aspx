<%@ Page Language="C#" AutoEventWireup="True" Inherits="bgbx_changepwd" Codebehind="changepwd.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>初始化密码</title>
    <link href="Images/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
        <table cellSpacing="1" class="a">
        <tr><td width="30%"  class="c" align="right">用户名</td><td width="70%"  class="c">
            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label></td></tr>
        <tr><td  class="c" align="right">旧密码</td><td class="c">
             <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TextBox3" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td></tr>
         <tr><td  class="c" align="right">新密码</td><td class="c">
             <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td></tr>
         <tr><td  class="c" align="right">重复密码</td><td class="c"><asp:TextBox ID="TextBox2" 
                        runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td></tr>
         <tr><td colspan="2" align="center" class="c">
             <asp:CompareValidator ID="CompareValidator1" runat="server" 
                 ControlToCompare="TextBox1" ControlToValidate="TextBox2" Display="Dynamic" 
                 ErrorMessage="两个密码不同！"></asp:CompareValidator>
             </td></tr>
         <tr><td colspan="2" align="center" class="c">
             <asp:Button ID="Button1" runat="server" Text="更改密码" onclick="Button1_Click" /></td></tr>
        </table>
    </div>
    </form>
</body>
</html>
