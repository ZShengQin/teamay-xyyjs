<%@ Page Language="C#" AutoEventWireup="true" Inherits="Article_lanmu_add_v1" Codebehind="Article_lanmu_add.aspx.cs" %>

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
        <tr>
            <td style="background-image: url(include/images/back-1.gif); border-bottom-width: 1px; border-bottom-color: #cadcea; border-top-width: 1px; border-top-color: #cadcea;  height: 28px; font-weight:bold; font-size:14px;" colspan="3">
            一级栏目管理
                </td>
        </tr>
        <tr>
            <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; padding-left: 20px;width: 100%;" colspan="3">
                         <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; font-weight:bold " width="80px">序号</td>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; font-weight:bold ">一级栏目名称</td>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; font-weight:bold " width="80px">排序</td>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; font-weight:bold " width="220px">操作</td>
                </tr>
             <asp:Repeater ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">
                
                <ItemTemplate>
 
                            <tr>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; " >
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("id") %>'></asp:Label></td>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left;" >
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("cn_name") %>'></asp:Label></td>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left;" ><%# Eval("sequence") %>
                                    </td>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left;" >
                                <asp:Button ID="Button7" runat="server" Text="首条新闻" CommandArgument='<%# Eval("id") %>' CommandName="SetFirst" CausesValidation="False" Visible="false" CssClass="Button" />&nbsp;
                                <asp:Button ID="Button6" runat="server" Text="管理子栏目" CommandArgument='<%# Eval("id") %>' CommandName="Add" CausesValidation="False" CssClass="Button" />&nbsp;
                                    <asp:Button ID="Button2" runat="server" Text="配置" CommandArgument='<%# Eval("id") %>' CommandName="edit" CausesValidation="False" CssClass="Button" />&nbsp;
                                    <asp:Button ID="Button3" runat="server" Text="删除" CommandArgument='<%# Eval("id") %>' CausesValidation="False" CommandName="Delete" CssClass="Button" OnClientClick="return confirm('确定删除吗？');" /></td>
                            </tr>

                     </ItemTemplate>
                    
                </asp:Repeater>
                </table>
                </td>
        </tr>
    </table>  
    
    <table border="0" cellpadding="0" cellspacing="0" style="border-right: #a2d0e5 1px solid; 
        border-top: #a2d0e5 1px solid; margin-top: 15px; border-left: #a2d0e5 1px solid;
        border-bottom: #a2d0e5 1px solid; background-color: #f6fbff;" width="100%">
        <tr>
            <td style="background-image: url(include/images/back-1.gif); border-bottom-width: 1px; border-bottom-color: #cadcea; border-top-width: 1px; border-top-color: #cadcea;  height: 28px; font-weight:bold; font-size:14px;" colspan="3">
            一级分类添加
                </td>
        </tr>
        <tr>
            <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; padding-left: 20px;" colspan="3">
                <table border="0" cellpadding="0" cellspacing="0" >
                <tr><td colspan="2" height="10"></td></tr>
                    <tr>
                        <td style="width: 400px;">
                一级栏目名称：<asp:TextBox ID="TextBox1" runat="server"  Width="153px" CssClass="TextBox"></asp:TextBox></td>
                        <td style="text-align: left;"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage='<div class="boxdiv2">不能为空！</div>'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                                ErrorMessage='<div class="boxdiv2">最多20个字符！</div>' ValidationExpression="^.{0,20}$"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td >
                栏目基准ID：<asp:TextBox ID="TextBox3" runat="server"  Width="153px" CssClass="TextBox" Text=""></asp:TextBox></td>
                        <td style="text-align: left;">请根据已有序号确认该栏目的基准ID，应为10的整数倍，不能和现有重复，它的子栏目将均以此ID为基准。<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3"
                    ErrorMessage='<div class="boxdiv2">不能为空！</div>'></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left; padding-left: 20px; height: 35px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 237px">
                    <tr>
                        <td style="width: 73px">
                <asp:Button ID="Button1" runat="server" Text="提交分类" CssClass="Button" OnClick="Button1_Click"  /></td>
                        <td style="width: 100px">
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
