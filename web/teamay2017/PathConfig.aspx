<%@ Page Language="C#" AutoEventWireup="True" Inherits="bgbx_PathConfig" Codebehind="PathConfig.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
        <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="include/StyleSheet.css" rel="stylesheet" type="text/css" />
        <link rel="stylesheet" href="../kindeditor/themes/default/default.css" />
	<link rel="stylesheet" href="../kindeditor/plugins/code/prettify.css" />
	<script charset="utf-8" src="../kindeditor/kindeditor-all.js"></script>
	<script charset="utf-8" src="../kindeditor/lang/zh-CN.js"></script>
	<script charset="utf-8" src="../kindeditor/plugins/code/prettify.js"></script>
    <script type="text/javascript">

        KindEditor.ready(function (K) {
            var editor1 = K.create('#Editor1', {
                cssPath: '../kindeditor/plugins/code/prettify.css',
                uploadJson: '../kindeditor/server/upload_json.ashx',
                fileManagerJson: '../kindeditor/server/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            var editor2 = K.create('#Editor2', {
                cssPath: '../kindeditor/plugins/code/prettify.css',
                uploadJson: '../kindeditor/server/upload_json.ashx',
                fileManagerJson: '../kindeditor/server/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style="border-right: #a2d0e5 1px solid;
        border-top: #a2d0e5 1px solid; margin-top: 15px; border-left: #a2d0e5 1px solid;
        border-bottom: #a2d0e5 1px solid; background-color: #f6fbff;" width="750">
        <tr>
            <td style="background-image: url(include/images/back-1.gif); border-bottom-width: 1px; border-bottom-color: #cadcea; width: 20px; height: 28px;" 
                width="50">
                </td>
            <td 
                style="font-weight: bold; background-image: url(include/images/back-12.gif);
                border-bottom-width: 1px; border-bottom-color: #cadcea; width: 79px; height: 28px;" 
                width="79px">
                配置分类</td>
            <td style="background-image: url(App_Themes/SkinFile/images/back-1.gif); border-bottom-width: 1px;
                border-bottom-color: #cadcea; padding-left: 10px; text-align: left;" width="621">
                <asp:Label ID="Label1" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; padding-left: 20px;" colspan="3" align="left">
                <table border="0" cellpadding="5" cellspacing="0">
                    <tr>
                        <td  align="right">
                            分类：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBox" Width="415px" ValidationGroup="aa"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                ErrorMessage="标题不能为空！" ValidationGroup="aa"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                                ErrorMessage="字符不得多于50个!" ValidationExpression="^.{0,50}$" ValidationGroup="aa"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td  align="right">
                            基准ID：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="paixu" ReadOnly="true" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td  align="right">
                            基准排序：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="sequence" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td  align="right">
                            栏目类型：</td>
                        <td style="padding-left: 10px; text-align: left;" colspan="2">
                            <asp:DropDownList ID="ntype" runat="server"  Enabled="false" 
                                AutoPostBack="True" onselectedindexchanged="ntype_SelectedIndexChanged">
                                <asp:ListItem Value="SinglePage" Text="一级分类默认类型"></asp:ListItem>
                                <asp:ListItem Value="SinglePage" Text="单页模式"></asp:ListItem>
                                <asp:ListItem Value="TextList-time" Text="文章列表（带时间）"></asp:ListItem>
                                <asp:ListItem Value="TextList" Text="文章列表（不带时间）"></asp:ListItem>
                                <asp:ListItem Value="PhotoList-more" Text="图文列表（更多介绍）"></asp:ListItem>
                                <asp:ListItem Value="PhotoList" Text="图文列表（简洁版）"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            点击默认打开：</td>
                        <td style="padding-left: 10px; text-align: left;" colspan="2">
                            <asp:DropDownList ID="DefaultOpen" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            父类：</td>
                        <td style="padding-left: 10px; text-align: left;" colspan="2">
                            <asp:DropDownList ID="myParent" runat="server" Enabled="false">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            分类级别：</td>
                        <td style="padding-left: 10px; text-align: left;" colspan="2">
                            <asp:DropDownList ID="zlevel" runat="server" Enabled="false">
                                <asp:ListItem Value="1" Text="一级分类"></asp:ListItem>
                                <asp:ListItem Value="2" Text="二级分类"></asp:ListItem>
                                <asp:ListItem Value="3" Text="三级分类"></asp:ListItem>
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            是否显示：</td>
                        <td style="padding-left: 10px; text-align: left;" colspan="2">
                            <asp:RadioButtonList ID="showinleft" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="1">显示</asp:ListItem>
                                <asp:ListItem Value="0">不显示</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" 
                            align="left" colspan="3">分类描述:
                                <textarea id="Editor1" cols="100" rows="8" style="width:700px;height:400px;visibility:hidden;" runat="server"></textarea>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td valign="top" 
                            align="left" colspan="3">英文介绍:
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
                <asp:Button ID="Button1" runat="server" Text="提交文章" CssClass="Button" OnClick="Button1_Click" ValidationGroup="aa"/></td>
                        <td style="width: 435px; text-align: left;">
                            &nbsp;
                </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
