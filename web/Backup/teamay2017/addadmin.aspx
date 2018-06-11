<%@ Page Language="C#" AutoEventWireup="True" EnableViewState="true" Inherits="bgbx_addadmin" Codebehind="addadmin.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="Images/style.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="include/jquery.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="1" class="a">
            <tr>
                <td colspan="4" class="f" align="center">
                    <asp:Label ID="Label6" runat="server" Text="添加管理员"></asp:Label>
                </td>
            </tr>
             <tr>
                <td width="80px" class="c">
                    用户名：
                </td>
                <td class="c">
                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="UserName" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                </td>
                  <td width="100px" class="c">
                显示名称：
                </td>
                <td class="c">
                    <asp:TextBox ID="RealName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="RealName" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td class="c">
                    密码：
                </td>
                <td class="c">
                    <asp:TextBox ID="pwd" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="pwd" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
              <td class="c">
                    配置：
                </td>
                <td class="c">
                    <asp:CheckBox ID="Youxiao" Checked="true" runat="server" Text="选中启用" />
                    <asp:CheckBox ID="Superman" runat="server" Text="选中具备超级管理员权限" />
                </td>
            </tr>
            <tr>
                <td class="c" colspan="2">添加管理员时，密码必须填写；修改管理员时，密码不填则不改原密码！
                    &nbsp;</td>
                <td class="c">
                    <asp:HiddenField ID="roles" runat="server" />
                    &nbsp;</td>
                <td class="c">
                    &nbsp;</td>
            </tr>
            
            <tr >
                <td class="c">
                    内容操作权限：
                </td>
                <td  class="c" colspan="3" align="left">
                <input id="chooseAll" type="checkbox" class="chooseAll" /> 全选/全不选切换
               <table id="allroles">
                <tr>
                    <asp:Repeater ID="outer" runat="server" onitemdatabound="outer_ItemDataBound">
                        <ItemTemplate>
                        <td valign="top">
                            <input id='outer_<%#Eval("id") %>' value='<%#Eval("id") %>' class="outer" type="checkbox" name='outer_<%#Eval("id") %>' /><label style="font-weight:bold"><%#Eval("cn_name") %></label><br />
                                <asp:Repeater ID="inner" runat="server">
                                    <ItemTemplate>
                                        <input id='inner_<%#Eval("id") %>' data='<%#Eval("myparent") %>' checked="checked" class='inner outer_<%#Eval("myparent") %>' type="checkbox" name='innerc' value='<%#Eval("id") %>' /><label for='inner_<%#Eval("id") %>'><%#Eval("cn_name")%></label><br />
                                    </ItemTemplate>
                                </asp:Repeater>
                        </td>
                        <%# (Container.ItemIndex + 1) % 7 == 0 ? "</tr><tr>" : ""%>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </tr>
               </table>
<script type="text/javascript">
    $(function () {
        $(".chooseAll").click(function () { $(".inner").attr("checked", $(this).attr('checked')) });
        $(".outer").click(function () {
            var _currentV = $(this).val();
            var _currentH = $(this).attr('checked');
            $(".outer_" + _currentV).attr('checked', _currentH);
        })
        $(".inner").click(function () {
            var _currentV = $(this).attr('data');
            var _currentH = $(this).attr('checked');
            //alert(_currentV);
            $("#outer_" + _currentV).attr("checked", $(".outer_" + _currentV + ":checked").size() == $(".outer_" + _currentV).size());
        })
        var roles = $("#roles").val();
        if (roles.val != "") {
            $(".inner").each(function () {
                var _currentV = $(this).val();

                if (roles.indexOf("," + _currentV + ",") >= 0) {
                    $(this).attr("checked", "true");
                }
            });
        }
    });
</script>
                  
                </td>
            </tr>
            <tr style="display:none">
                <td class="c">
                    内容操作权限：
                </td>
                <td  class="c" colspan="3" align="left">
                    <input id='inner_gl' class='inner outer_gl' type="checkbox" name='innerc' value='10' />是否具备管理首页浮动图片的权限
                </td>
            </tr>
            <tr>
                <td class="c" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="c" colspan="4">
                    <asp:Button ID="Button1" runat="server"
                        Text="提交" onclick="Button1_Click"  ValidationGroup="a" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
