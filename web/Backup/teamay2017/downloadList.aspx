<%@ Page Language="C#" AutoEventWireup="True" Inherits="bgbx_downloadList" Codebehind="downloadList.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学习卡打印</title>
    <link href="Images/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="1" class="a">
    <tr><td colspan="7" class="f">组图列表</td></tr>
        <tr><td width="50px"  class="c">ID</td><td width="350px" class="c">组图文本</td><td width="350px" class="c">组图地址</td><td class="c">链接地址</td><td width="50px" class="c">排序</td>
        <td width="60px" class="c">修改</td><td width="60px" class="c">删除</td></tr>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <tr><td  class="d"><%# this.Repeater1.Items.Count+1%></td><td class="d"><%# Eval("downloadTitle")%></td><td class="d"><%# Eval("filepath")%></td>
            <td class="d"><%# Eval("linkurl")%></td><td class="d"><%# Eval("orderIndex")%></td>
            <td class="d">
                <a href="addDownload.aspx?type=edit&id=<%# Eval("id") %>">修改</a></td>
                <td class="d">
                <a href="deleteAction.aspx?action=download&id=<%# Eval("id") %>" onclick="return confirm('确认删除该记录吗？')">删除</a></td>
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
