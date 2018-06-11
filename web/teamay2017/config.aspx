<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" Inherits="config" Codebehind="config.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="Images/style.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../xeditor/ckfinder/ckfinder.js"></script>
	<script type="text/javascript">

	    function BrowseServer() {
	        // You can use the "CKFinder" class to render CKFinder in a page:
	        var finder = new CKFinder();
	        finder.basePath = '/xeditor/ckfinder'; // The path for the installation of CKFinder (default = "/ckfinder/").
	        finder.selectActionFunction = SetFileField;
	        finder.popup();

	        // It can also be done in a single line, calling the "static"
	        // popup( basePath, width, height, selectFunction ) function:
	        // CKFinder.popup( '../', null, null, SetFileField ) ;
	        //
	        // The "popup" function can also accept an object as the only argument.
	        // CKFinder.popup( { basePath : '../', selectActionFunction : SetFileField } ) ;
	    }

	    // This is a sample function which is called when a file is selected in CKFinder.
	    function SetFileField(fileUrl) {
	        document.getElementById('filePath').value = fileUrl;
	    }

	</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="1" class="a">
            <tr>
                <td colspan="4" class="f" align="center">
                    <asp:Label ID="Label6" runat="server" Text="首页浮动图片管理"></asp:Label>
                </td>
            </tr>
             <tr>
                <td width="15%" class="c">
                    宽度：
                </td>
                <td width="35%" class="c">
                    <asp:TextBox ID="width" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="width" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td width="15%" class="c">
                    高度：
                </td>
                <td width="35%" class="c">
                    <asp:TextBox ID="height" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="height" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td  class="c">
                    图片：
                </td>
                <td class="c" colspan="3">
                    <asp:TextBox ID="filePath" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="filePath" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <input type="button" value="浏览服务器" onclick="BrowseServer();" />
                </td>
            </tr>
            <tr>
                <td  class="c">
                    链接地址：
                </td>
                <td class="c" colspan="3">
                    <asp:TextBox ID="link" runat="server" Width="400px"></asp:TextBox> * 需要包含http://
                </td>
            </tr>
             <tr>
                <td class="c">
                    是否启用：
                </td>
                <td  class="c" colspan="3">
                    <asp:DropDownList ID="mode" runat="server">
                        <asp:ListItem Value="0"  Text="首页不展示浮动图片（禁用）"></asp:ListItem>
                        <asp:ListItem Value="1" Text="在首页展示浮动图片（启用）"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="c" colspan="4">
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
