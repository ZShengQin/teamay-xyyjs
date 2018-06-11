<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" Inherits="bgbx_addDownload" Codebehind="addDownload.aspx.cs" %>

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
                    <asp:Label ID="Label6" runat="server" Text="添加组图"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="15%" class="c">
                    组图文本：
                </td>
                <td width="35%" class="c" align="left" colspan="3">
                     <asp:TextBox ID="downloadTitle" runat="server" width="300px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td width="15%" class="c">
                    选择图片：
                </td>
                <td width="35%" class="c" align="left">
                     <asp:TextBox ID="filePath" runat="server"></asp:TextBox>
    
                     <asp:FileUpload ID="FileUpload1" runat="server" CssClass="TextBox" Width="155px" />
                            <asp:Button ID="Button2" runat="server" CssClass="Button" Text="上传图片" OnClick="Button2_Click"  /><asp:Label ID="Label1" ForeColor="Red" runat="server"></asp:Label>
                </td>
                <td width="15%" class="c">
                    顺序:
                </td>
                <td width="35%" class="c" align="left">
                    <asp:TextBox ID="orderIndex" runat="server" Text="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="orderIndex" ErrorMessage="*"></asp:RequiredFieldValidator> 排序越大越靠前

                </td>
            </tr>
            <tr>
                <td  class="c">
                    链接地址：
                </td>
                <td class="c" colspan="3" align="left">
                    <asp:TextBox ID="downloadLink" runat="server" Width="500px"></asp:TextBox> * 需要包含http://
                </td>
            </tr>
             <tr style="display:none">
                <td class="c">
                    语言版本：
                </td>
                <td  class="c">
                    <asp:DropDownList ID="language" runat="server">
                        <asp:ListItem Value="中文友情链接"  Text="中文友情链接"></asp:ListItem>
                        <asp:ListItem Value="英文友情链接" Text="英文友情链接"></asp:ListItem>
                        <asp:ListItem Value="中文首页大图"  Text="中文首页大图"></asp:ListItem>
                        <asp:ListItem Value="英文首页大图" Text="英文首页大图"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="c">
                   
                </td>
                <td class="c">
                    
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
