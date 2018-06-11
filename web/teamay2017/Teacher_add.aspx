<%@ Page Language="C#" AutoEventWireup="true" Inherits="Teacher_add" Codefile="Teacher_add.aspx.cs" %>
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
    <div style="text-align:left; margin-left:15px;">
    <table border="0" cellpadding="0" cellspacing="0" style="border-right: #a2d0e5 1px solid;
        border-top: #a2d0e5 1px solid; margin-top: 15px; border-left: #a2d0e5 1px solid;
        border-bottom: #a2d0e5 1px solid; background-color: #f6fbff; width:850px;" >
        <tr>
            <td style="background-image: url(include/images/back-1.gif); width:100%; border-bottom-width: 1px; border-bottom-color: #cadcea; border-top-width: 1px; border-top-color: #cadcea;  height: 28px; font-weight:bold; font-size:14px;" colspan="3">
            导师添加<asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="border-bottom: #cadcea 1px solid; text-align: left; padding-left: 20px;" colspan="3" align="left">
                <table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td style="width: 105px; text-align: right; height: 31px;">
                            分类：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="TextBox">
                            </asp:DropDownList>&nbsp;&nbsp;请务必选择正确的类别！</td>
                    </tr>
                    <tr style="display:none">
                        <td style="text-align: right; height: 31px;">
                            用户名：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="User_name" runat="server" CssClass="TextBox" Width="200px" ></asp:TextBox>
                            密码：<asp:TextBox ID="Password" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 31px;">
                            导师姓名：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="Name_Cn" runat="server" CssClass="TextBox" Width="200px" ></asp:TextBox>
                            头衔：<asp:TextBox ID="Title_cn" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr style="display:none">
                        <td  align="right">
                            导师姓名(en)：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="Name_En" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                            头衔：<asp:TextBox ID="Title_en" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 31px;">
                            照片：</td>
                        <td style="padding-left: 10px; text-align: left; height: 31px;  position:relative;">
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="TextBox" Width="155px" />
                            <asp:Button ID="Button2" runat="server" CssClass="Button" Text="上传图片" OnClick="Button2_Click" ValidationGroup="bb" />
                            <asp:TextBox ID="Photo" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload1"
                                ErrorMessage="请选择图片！" ValidationGroup="bb"></asp:RequiredFieldValidator>
                            <div style=" position:absolute; right:20px; top :5px"><asp:Image ID="Image1" runat="server" ImageUrl="include/images/nonebig.gif" Height="50px" Width="50px" /></div></td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 31px;">
                            联系方式：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="Zy_Cn" runat="server" CssClass="TextBox" TextMode="MultiLine" Height="50px" Width="440px" ></asp:TextBox>
                            </td>
                    </tr>
                    <tr style="display:none">
                        <td  align="right">
                            联系方式(en)：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="Zy_en" runat="server" CssClass="TextBox"  TextMode="MultiLine" Height="50px" Width="440px" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 31px;">
                            研究方向：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="Research_cn" runat="server" CssClass="TextBox" TextMode="MultiLine" Height="50px" Width="440px" ></asp:TextBox>
                            </td>
                    </tr>
                    <tr style="display:none">
                        <td  align="right">
                            研究方向(en)：</td>
                        <td style="padding-left: 10px; text-align: left" colspan="2">
                            <asp:TextBox ID="Research_en" runat="server" CssClass="TextBox"  TextMode="MultiLine" Height="50px" Width="440px" ></asp:TextBox></td>
                    </tr>
                    
                    <tr>
                        <td style="text-align: right; height: 31px;">
                            排序标识：</td>
                        <td style="padding-left: 10px; text-align: left; position:relative"><asp:TextBox ID="Sequence" runat="server" Text="1" CssClass="TextBox" Width="200px"></asp:TextBox>
                        数字越大越靠前排<div style=" position:absolute; right:20px; top :5px"><asp:Button ID="Button3" runat="server" Text="快速保存" CssClass="Button" OnClick="Button1_Click" ValidationGroup="aa"/></div>
                        </td>
                    </tr>
                    <tr>
                       <td style="text-align: right; height: 31px;">
                            正文：</td><td style="padding-left: 10px; text-align: left; ">
                                <textarea id="Editor1" cols="100" rows="8" style="width:700px;height:400px;visibility:hidden;" runat="server"></textarea>
                        </td>
                    </tr>
                    <tr  style="display:none">
                        <td valign="top" 
                            align="left" colspan="2">en:
                                <textarea id="Editor2" cols="100" rows="8" style="width:700px;height:400px;visibility:hidden;" runat="server"></textarea> 
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left; padding-left: 20px; height: 35px;">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 120px">
                </td>
                        <td style="width: 73px">
                <asp:Button ID="Button1" runat="server" Text="发布文章" CssClass="Button" OnClick="Button1_Click" ValidationGroup="aa"/></td>

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
