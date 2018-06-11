<%@ Page Language="C#" AutoEventWireup="True" Inherits="bgbx_userList" CodeBehind="userList.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>团队列表</title>
    <link href="Images/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellSpacing="1" class="a">
    <tr><td colspan="7" class="f">团队列表</td></tr>
        <tr><td width="5%"  class="c">ID</td>
        <td width="15%" class="c">中文名</td><td width="15%" class="c">英文名</td><td width="15%" class="c">分类</td>
        <td width="15%" class="c">修改</td><td width="15%" class="c">正文编辑</td><td width="10%" class="c">删除</td></tr>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <tr><td  class="d"><%# this.Repeater1.Items.Count+1%></td>
            <td class="d"><%# Eval("name_cn")%></td><td class="d"><%# Eval("name_en")%></td><td class="d"><%# Eval("cn_name").ToString()%></td>
            <td class="d">
                <a href="adduser.aspx?type=edit&id=<%# Eval("id") %>">修改</a></td>
                <td class="d">
                <a href="Teacher_Set.aspx?id=<%# Eval("id") %>">正文编辑</a></td>
                <td class="d">
                <a href="deleteAction.aspx?action=teacher&id=<%# Eval("id") %>" onclick="return confirm('确认删除该记录吗？')">删除</a></td>
             </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr><td  class="c" colspan="4"><asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click">页首</asp:LinkButton> 
<asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton> 
<asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton> 
<asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">页尾</asp:LinkButton></td>
<td class="c" colspan="3">第<asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>页/共<asp:Label ID="LabCountPage" runat="server" Text="Label"></asp:Label>页 </td></tr>
    </table>
    </div>
    </form>
</body>
</html>
