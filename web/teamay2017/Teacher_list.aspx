<%@ Page Language="C#" AutoEventWireup="True" Inherits="Teacher_list" Codebehind="Teacher_list.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
        <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="include/StyleSheet.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
          <table border="0" cellpadding="0" cellspacing="0" style="border-right: #a2d0e5 1px solid;
        border-top: #a2d0e5 1px solid; margin-top: 15px; border-left: #a2d0e5 1px solid;
        border-bottom: #a2d0e5 1px solid; background-color: #f6fbff;" width="100%">
        <tr><td colspan="3" align="center"><h3 style="font-size:15px; margin:4px auto; padding:0">
            <asp:Label ID="Label1" runat="server" Text="导师列表"></asp:Label></h3></td></tr>

        <tr>
            <td colspan="3" align="center">
                分类：<asp:DropDownList ID="Fenlei" runat="server" CssClass="TextBox">
                            </asp:DropDownList>
                关键词：<asp:TextBox ID="GjC" runat="server" CssClass="TextBox" Width="120px" ></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="搜索" CssClass="Button"  
                    ValidationGroup="aa" onclick="Button1_Click"/>
            </td>
        </tr>
        <tr>
            <td style="background-image: url(include/images/back-1.gif); border-bottom-width: 1px; border-bottom-color: #cadcea; border-top-width: 1px; border-top-color: #cadcea;  height: 28px; font-weight:bold; font-size:14px;" colspan="3">
            导师管理
                </td>
        </tr>
        <tr>
            <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; padding-left: 20px;" colspan="3">
             <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; font-weight:bold " width="80px">文章序号</td>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; font-weight:bold " width="100px">分类</td>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; font-weight:bold ">导师姓名</td>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; font-weight:bold ">头衔</td>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; font-weight:bold " width="120px">排序</td>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; font-weight:bold " width="120px">操作</td>
                </tr>
                <asp:Repeater ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">
                
                <ItemTemplate>
                       
                            <tr>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; " >
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("id") %>'></asp:Label></td>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left;" >
                                    <%# Eval("cn_name")%></td>
                                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left;" >
                                    <a href="Teacher_Add.aspx?id=<%# Eval("id") %>"><%# Eval("name_cn")%></a></td>
                                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; " >
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("title_cn") %>'></asp:Label></td>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; " >
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("sequence") %>'></asp:Label></td>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center;" >
                                    <asp:Button ID="Button2" CommandArgument='<%# Eval("id") %>' runat="server" Text="修改" CausesValidation="False" CssClass="Button" CommandName="Edit" />&nbsp;
                                    <asp:Button ID="Button3" CommandArgument='<%# Eval("id") %>' runat="server" Text="删除" CausesValidation="False" CommandName="Delete" CssClass="Button" OnClientClick="return confirm('确定删除？不可恢复哦！')" /></td>
                            </tr>
                       
                    </ItemTemplate>
                    
                </asp:Repeater>
                 </table><table cellpadding="0" cellspacing="0" style="width: 100%; height: 30px;">
                                <tr>
                                    <td style="height: 15px" colspan="2">
                                        <asp:LinkButton ID="lnkbtnTop" runat="server" Font-Size="9pt" Font-Underline="False"
                                            ForeColor="Black" OnClick="lnkbtnTop_Click">首页</asp:LinkButton>
                                        &nbsp; &nbsp;&nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrve" runat="server" Font-Size="9pt" Font-Underline="False"
                                            ForeColor="Black" OnClick="lnkbtnPrve_Click">上一页</asp:LinkButton>
                                        &nbsp; &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnNext" runat="server" Font-Size="9pt" Font-Underline="False"
                                            ForeColor="Black" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>
                                        &nbsp; &nbsp;&nbsp; &nbsp;<asp:LinkButton ID="lnkbtnLast" runat="server" Font-Overline="False" Font-Size="9pt"
                                            Font-Underline="False" ForeColor="Black" OnClick="lnkbtnLast_Click">尾页</asp:LinkButton>
                                        &nbsp; &nbsp; <span style="font-size: 9pt">共有</span><asp:Label ID="labCount" runat="server" Font-Size="9pt"
                                            ForeColor="Red"></asp:Label><span style="font-size: 9pt; vertical-align: bottom;
                                                text-align: center">页</span><span style="font-size: 9pt"></span></td>
                                    <td style="width: 130px; height: 15px; text-align: center">
                                        <span style="font-size: 9pt">当前第</span><asp:Label ID="labNowPage" runat="server"
                                            Font-Size="9pt" ForeColor="Red">1</asp:Label><span style="font-size: 9pt; vertical-align: bottom;
                                                text-align: center">页</span></td>
                                </tr>
                            </table></td>
        </tr>
    </table> 
    </div>
    </form>
</body>
</html>
