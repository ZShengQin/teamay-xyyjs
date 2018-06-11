<%@ Page Language="C#" AutoEventWireup="True" EnableViewState="true" Inherits="bgbx_addUser" CodeBehind="addUser.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="Images/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="1" class="a">
            <tr>
                <td colspan="4" class="f" align="center">
                    <asp:Label ID="Label6" runat="server" Text="新增研究团队信息"></asp:Label>
                </td>
            </tr>
             <tr style="display:none">
                <td width="25%" class="c">
                    登 录 名：
                </td>
                <td width="25%" class="c">
                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                </td>
                <td width="25%" class="c">
                    密码：
                </td>
                <td width="25%" class="c">
                    <asp:TextBox ID="pwd" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%" class="c">
                   中文姓名：
                </td>
                <td width="25%" class="c">
                    <asp:TextBox ID="name_cn" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="name_cn" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td width="25%" class="c">
                    英文姓名：
                </td>
                <td width="25%" class="c">
                    <asp:TextBox ID="name_en" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="name_en" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="25%" class="c">
                   照片：
                </td>
                <td width="25%" class="c" colspan="3">
                     <asp:FileUpload ID="FileUpload1" runat="server" CssClass="TextBox" 
                                Width="200px" />
                            <asp:Button ID="Button2" runat="server" CssClass="Button" Text="上传图片" OnClick="Button2_Click"  />上传路径：<asp:TextBox ID="photo" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                </td>
                </tr>
            <tr style="display:none">
                <td width="25%" class="c">
                    顺序：
                </td>
                <td width="25%" class="c" colspan="3">
                    <asp:TextBox ID="sequence" runat="server" Text="0" Width="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="sequence" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            
            </tr>
            <tr >
                <td width="25%" class="c">
                    分类：
                </td>
                <td width="25%" class="c" colspan="3">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Text="博士生导师" Value="1"></asp:ListItem>
                        <asp:ListItem Text="教授" Value="2"></asp:ListItem>
                        <asp:ListItem Text="硕士生导师" Value="3"></asp:ListItem>
                        <asp:ListItem Text="副教授" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            
            </tr>

            <tr>
                <td width="25%" class="c" colspan="4">
                    &nbsp;</td>

            </tr>
            <tr>
                <td class="c" colspan="4">
                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="c" colspan="4">
                    <asp:Button ID="Button1" runat="server"
                        Text="提交" onclick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
