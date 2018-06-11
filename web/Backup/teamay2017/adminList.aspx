<%@ Page Language="C#" AutoEventWireup="True" Inherits="bgbx_adminList" Codebehind="adminList.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学习卡打印</title>
    <link href="Images/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellSpacing="1" class="a">
    <tr><td colspan="8" class="f">管理员列表</td></tr>
        <tr><td width="5%"  class="c">ID</td><td width="16%" class="c">登录名</td>
        <td width="8%" class="c">用户名</td><%--<td width="8%" class="c">操作范围</td>--%>
        <td width="12%" class="c">最后登录IP</td><td width="12%" class="c">最后登录时间</td>
        <td width="12%" class="c">登陆次数</td><td width="12%" class="c">是否停用</td>
        <td width="15%" class="c">修改</td></tr>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <tr><td  class="d"><%# this.Repeater1.Items.Count+1%></td><td class="d"><%# Eval("username")%></td><td class="d"><%# Eval("realname")%></td>
            <%--<td class="d"><%# Eval("AdminPurview")%></td>--%><td class="d"><%# Eval("lastloginip")%></td><td class="d"><%# Eval("lastlogintime")%></td>
            <td class="d"><%# Eval("logintimes")%></td><td class="d"><%# Eval("isUsed").ToString() == "1" ? "已启用" : "已停用"%></td>
            <td class="d">
                <a href="addadmin.aspx?type=edit&id=<%# Eval("id") %>">修改</a></td></tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr><td  class="c" colspan="4"><asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click">页首</asp:LinkButton> 
<asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton> 
<asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton> 
<asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">页尾</asp:LinkButton></td>
<td class="c" colspan="4">第<asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>页/共<asp:Label ID="LabCountPage" runat="server" Text="Label"></asp:Label>页 </td></tr>
    </table>
    </div>
    </form>
</body>
</html>
