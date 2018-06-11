<%@ Page Language="C#" AutoEventWireup="true"  validateRequest="false"  Inherits="bgbx_Article_add" Codefile="Article_add.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
        <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link rel="stylesheet" href="../kindeditor/themes/default/default.css" />
	<link rel="stylesheet" href="../kindeditor/plugins/code/prettify.css" />
	<script charset="utf-8" src="../kindeditor/kindeditor-all.js"></script>
	<script charset="utf-8" src="../kindeditor/lang/zh-CN.js"></script>
	<script charset="utf-8" src="../kindeditor/plugins/code/prettify.js"></script>
    <link href="include/StyleSheet.css" rel="stylesheet" type="text/css" />
           <script type="text/javascript" src="include/jquery.js"></script>
<script type="text/javascript" src="js/jquery-ui.js"></script>
<script type="text/javascript" src="js/jquery-ui-slide.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-timepicker-addon.js"></script>
<link rel="stylesheet" type="text/css" href="css/jquery-ui.css" />
<script type="text/javascript">
    $(function () {
        $('.date-pick').datetimepicker();
    });

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
        prettyPrint();
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:left; margin-left:15px;">
    <table border="0" cellpadding="0" cellspacing="0" style="border-right: #a2d0e5 1px solid;
        border-top: #a2d0e5 1px solid; margin-top: 15px; border-left: #a2d0e5 1px solid;
        border-bottom: #a2d0e5 1px solid; background-color: #f6fbff;" >
        <tr>
            <td style="background-image: url(include/images/back-1.gif); width:100%; border-bottom-width: 1px; border-bottom-color: #cadcea; border-top-width: 1px; border-top-color: #cadcea;  height: 28px; font-weight:bold; font-size:14px;" colspan="3">
            文章添加<asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="border-bottom: #cadcea 1px solid; text-align: left; padding-left: 20px;" colspan="3" align="left">
                <table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td style="width: 85px; text-align: right; height: 31px;">
                            分类：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="TextBox">
                            </asp:DropDownList>&nbsp;&nbsp;请务必选择正确的类别！</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 31px;">
                            标题：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBox" Width="570px" ValidationGroup="aa"></asp:TextBox>
                            </td>
                    </tr>
                    <tr style="display:none">
                        <td  align="right">
                            标题(en)：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="TextBox1_en" runat="server" CssClass="TextBox" Width="570px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 31px;">
                            配图：</td>
                        <td style="padding-left: 10px; text-align: left; height: 31px;  position:relative;">
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="TextBox" Width="155px" />
                            <asp:Button ID="Button2" runat="server" CssClass="Button" Text="上传图片" OnClick="Button2_Click" ValidationGroup="bb" />
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload1"
                                ErrorMessage="请选择图片！" ValidationGroup="bb"></asp:RequiredFieldValidator>
                            <div style=" position:absolute; right:20px; top :5px"><asp:Image ID="Image1" runat="server" ImageUrl="include/images/nonebig.gif" Height="50px" Width="50px" /></div></td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 31px;">
                            配置：</td>
                        <td style="padding-left: 10px; text-align: left; ">
                            
                            点击数 <asp:TextBox ID="ClickTimes" runat="server" Text="1" CssClass="TextBox" Width="80px"></asp:TextBox>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" Visible="false" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="0">不置顶</asp:ListItem>
                                <asp:ListItem Value="1">置顶</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 31px;">
                            链接：</td>
                        <td style="padding-left: 10px; text-align: left; ">
                            <asp:TextBox ID="KeyTxt" runat="server" CssClass="TextBox" Width="450px" ValidationGroup="aa"></asp:TextBox> 不为空启用,以http://开头</td>
                    </tr>
                    <tr>
                        <td  style=" text-align: right; height: 31px;">
                            排序时间：</td>
                        <td style="padding-left: 10px; text-align: left; position:relative ">
                            <asp:TextBox ID="PXTime" runat="server" CssClass="TextBox" Width="270px" Text="" ></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td  style=" text-align: right; height: 31px;">
                            发布时间：</td>
                        <td style="padding-left: 10px; text-align: left; position:relative ">
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="TextBox" Width="270px" Text="" ></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;发布人： <asp:Label ID="Author" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div style=" position:absolute; right:20px; top :5px"><asp:Button ID="Button3" runat="server" Text="快速发布" CssClass="Button" OnClick="Button1_Click" ValidationGroup="aa"/></div>
                            </td>
                    </tr>
                    <tr>
                        <td valign="top" 
                            align="left" colspan="3">
                                <textarea id="Editor1" cols="100" rows="8" style="width:700px;height:400px;visibility:hidden;" runat="server"></textarea>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td valign="top" 
                            align="left" colspan="3">en:
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
                <asp:Button ID="Button1" runat="server" Text="发布文章" CssClass="Button" OnClick="Button1_Click" ValidationGroup="aa"/></td>
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
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            Date.format = 'yyyy-mm-dd';

            $('.date-pick').datePicker({ startDate: '2014-1-1', clickInput: true });

        });
            
    </script>
</body>
</html>
