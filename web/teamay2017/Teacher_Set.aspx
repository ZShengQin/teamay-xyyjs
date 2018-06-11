<%@ Page Language="C#" AutoEventWireup="true" Inherits="Teacher_Set" Codebehind="Teacher_Set.aspx.cs" %>
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
        border-bottom: #a2d0e5 1px solid;background-color: #f6fbff;" width="100%">
        <tr>
            <td style="background-image: url(include/images/back-1.gif); border-bottom-width: 1px; border-bottom-color: #cadcea; width: 20px; height: 28px;">
                </td>
            <td style="font-weight: bold; background-image: url(include/images/back-12.gif);
                border-bottom-width: 1px; border-bottom-color: #cadcea; width: 79px; height: 28px;">
                文章添加</td>
            <td style="background-image: url(include/images/back-1.gif); border-bottom-width: 1px;
                border-bottom-color: #cadcea; width: 651px;">
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; padding-left: 20px;" colspan="3" align="left">
                <table border="0" cellpadding="5" cellspacing="0" style="width: 730px">
                    <tr>
                        <td style="width: 75px; text-align: right;">
                            当前用户：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:Label ID="TitleLabel" runat="server" Text="Label"></asp:Label>
                            </td>
                    </tr>
                    <tr style="display:none">
                        <td style="width: 75px; text-align: right;">
                            中文职务：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="title_cn" runat="server" CssClass="TextBox" Width="600px" ValidationGroup="aa"></asp:TextBox>
                            </td>
                    </tr>
                    <tr style="display:none">
                        <td style="width: 75px; text-align: right;">
                            英文职务：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="title_en" runat="server" CssClass="TextBox" Width="600px" ValidationGroup="aa"></asp:TextBox>
                            </td>
                    </tr>
                    <tr style="display:none">
                        <td style="width: 75px; text-align: right;">
                            中文摘要：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="zy_cn" runat="server" CssClass="TextBox" TextMode="MultiLine" Width="600px" Height="90px" ValidationGroup="aa"></asp:TextBox><br /><span style="color:red">摘要为研究领域、研究内容，请参考已有的格式，请将每个研究内容放在&lt;li&gt;&lt;/li&gt;标记之间</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="zy_cn"
                                ErrorMessage="中文摘要不能为空！" ValidationGroup="aa"></asp:RequiredFieldValidator>
                            </td>
                    </tr>
                    <tr style="display:none">
                        <td style="width: 75px; text-align: right;">
                            英文摘要：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="zy_en" runat="server" CssClass="TextBox" TextMode="MultiLine" Width="600px" Height="90px" ValidationGroup="aa"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="zy_en"
                                ErrorMessage="英文摘要不能为空！" ValidationGroup="aa"></asp:RequiredFieldValidator>
                            </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; height: 376px;" valign="top" colspan="3">中文内容：<br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Editor1"
                                ErrorMessage="内容不能为空！" ValidationGroup="aa"></asp:RequiredFieldValidator>
                            <textarea id="Editor1" cols="100" rows="8" style="width:700px;height:400px;visibility:hidden;" runat="server"></textarea>         </td>
        </tr>
                    <tr>
                    
                        <td style="text-align: left; height: 376px;" valign="top" colspan="3">英文内容：<br />
                                <textarea id="Editor2" cols="100" rows="8" style="width:700px;height:400px;visibility:hidden;" runat="server"></textarea>
                        </td>
                    </tr>
                        </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left; padding-left: 20px; height: 35px;">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 70px">
                </td>
                        <td style="width: 73px">
                <asp:Button ID="Button1" runat="server" Text="提交修改" CssClass="Button" OnClick="Button1_Click" ValidationGroup="aa"/></td>
                        <td style="width: 435px; text-align: left;">
                            &nbsp;
                <asp:Label ID="Label1" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
