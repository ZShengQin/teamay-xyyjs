﻿<%@ Page Language="C#" AutoEventWireup="True" Inherits="Path_Man" Codebehind="Path_Man.aspx.cs" %>

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
            栏目【<asp:Label ID="leiType" runat="server" ForeColor="Red" Text="Label"></asp:Label>】管理

            <div style="float:right; font-size:12px; font-weight:normal">快速切换栏目到：<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            </div>
                </td>
        </tr>
        <tr>   
            <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; padding-left: 20px;width: 100%;" colspan="3">
                         <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; font-weight:bold " width="80px">序号</td>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; font-weight:bold " width="80px">栏目级别</td>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; font-weight:bold ">栏目名称</td>
                    
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left; font-weight:bold " width="80px">排序</td>
                    <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; font-weight:bold " width="260px">操作</td>
                </tr>
             <asp:Repeater ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">
                
                <ItemTemplate>
 
                            <tr>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; " >
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("id") %>'></asp:Label><asp:HiddenField ID="ntype" runat="server" Value='<%# Eval("ntype") %>' /></td>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: center; " >
                                    第 <asp:Label ID="Label4" runat="server" ForeColor="Red" Font-Bold="true" Text='<%# Eval("zlevel") %>'></asp:Label> 级</td>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left;" >
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("cn_name") %>'></asp:Label></td>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left;" ><%# Eval("sequence") %>
                                    </td>
                                <td style="border-bottom: #cadcea 1px solid; height: 35px; text-align: left;" >
                                    <asp:Button ID="Button2" runat="server" Visible='<%# Eval("realid").ToString()== "" && Eval("ntype").ToString() == "SinglePage"%>' Text="单页配置" CommandArgument='<%# Eval("id") %>' CommandName="edit" CausesValidation="False" CssClass="Button" />
                                    <asp:Button ID="Button3" runat="server" Visible='<%# Eval("realid").ToString()!= "" && Eval("ntype").ToString() != "SinglePage"%>' CommandArgument='<%#Eval("realid")%>' Text="添加新项" CausesValidation="False" CommandName="Delete" CssClass="Button"  />
                                    <asp:Button ID="Button6" runat="server" Visible='<%# Eval("realid").ToString()!= "" && Eval("ntype").ToString() != "SinglePage"%>' CommandArgument='<%#Eval("realid")%>' Text="管理文章" CommandName="Add" CssClass="Button" />
                                    </td>
                            </tr>

                     </ItemTemplate>
                    
                </asp:Repeater>
                </table>
                </td>
        </tr>
    </table>  


    </div>
    </form>
</body>
</html>
