<%@ Page Language="C#" AutoEventWireup="True" Inherits="Teamay_CBST.EN.ShowPage"
    CodeBehind="ShowPage.aspx.cs" %>

<%@ Register Src="parts/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="parts/foot.ascx" TagName="foot" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>苏州西西环保科技有限公司</title>
    <link rel="stylesheet" href="index.css" type="text/css" />
    <meta name="keywords" content="苏州西西环保科技有限公司">
    <script src="common/jquery.js" type="text/javascript"></script>
    <script src="common/jquery.flexslider-min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var nowtext = $("#nowText").val();
            $("#s_colsA li").each(function (i, e) {

                var curr = $(this).text();
                if (curr.indexOf(nowtext) >= 0) {
                    $(this).addClass("selected");
                }

            });



            //$("#secondContentWrapper").height($("#s_colsB").height() > 600 ? $("#s_colsB").height() : 600);
			if($("#singleNews").attr("id") == "singleNews"){
				$("#s_colsB").height(($("#singleNews").height() < 400 ? 450 : $("#singleNews").height()) + 80);
			}else{
				$("#s_colsB").height(($("#trip").height() < 400 ? 450 : $("#trip").height()) + 80);
			}
            $(".menus").height($("#s_colsA ul").height() + 100);

        }); 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:top ID="top2" runat="server" />
    <asp:HiddenField ID="nowText" runat="server" />
    <div id="secondContentWrapper">
        <div id="secondContent">
            <div id="s_colsA">
                <h1>
                    <asp:Literal ID="LeftTitle" runat="server"></asp:Literal></h1>
                <div class="menus">
                    <ul>
                        <asp:Repeater ID="LeftMenu" runat="server">
                            <ItemTemplate>
                                <li class="level<%#Eval("zlevel") %> parent_<%#Eval("myParent") %>" id="s<%#Eval("id") %>">
                                    <a href="ShowPage.aspx?id=<%#Eval("id") %>" target="_self">
                                        <%#Eval("cn_name")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div id="s_colsB">
                <div id="bar">
                    <h5>
                        当前位置：首页 >
                        <asp:Literal ID="DaoArticle" runat="server"></asp:Literal></h5>
                </div>
                <div id="trip">
                    <div id="innerContent">
                        <div id="ms">
                            <asp:Literal ID="ContentFromDB" runat="server"></asp:Literal></div>
                        <div id="TextList_time" runat="server" visible="false">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="4%" height="10">
                                    </td>
                                    <td width="84%">
                                    </td>
                                    <td width="12%">
                                    </td>
                                </tr>
                                <asp:Repeater ID="Repeater_news" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td height="28" align="center" valign="baseline">
                                                <span>
                                                    <img src="images/dot.gif" /></span>
                                            </td>
                                            <td height="28" align="left">
                                                <a title="<%#Eval("title")%>" style="white-space: nowrap; text-overflow: ellipsis;
                                                    overflow: hidden; display: block; width: 530px;" target="_blank" href="ShowPage.aspx?type=<%#Eval("id")%>">
                                                    <%#Eval("title")%></a>
                                            </td>
                                            <td height="28" align="center">
                                                <%#Eval("timenew") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="1" colspan="3" background="images/diana.jpg">
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <table style="margin: 10px auto 0;">
                                <tr>
                                    <td colspan="7">
                                        <asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click">页首</asp:LinkButton>
                                        &nbsp;&nbsp;
                                        <asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页 </asp:LinkButton>
                                        &nbsp;&nbsp;
                                        <asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页 </asp:LinkButton>
                                        &nbsp;&nbsp;
                                        <asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">页尾</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td colspan="4">
                                        第<asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>页/共<asp:Label ID="LabCountPage"
                                            runat="server" Text="Label"></asp:Label>页
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="singleNews" runat="server" visible="false">
                            <asp:Literal ID="ArticleTitle" Visible="false" runat="server"></asp:Literal>
                            <h1 class="header">
                                <asp:Literal ID="SingleTitle" runat="server"></asp:Literal></h1>
                            <h2 class="header" style="display:none">
                                发布日期：<asp:Literal ID="SingleDate" runat="server"></asp:Literal><asp:Literal ID="SingleTimes"
                                    runat="server" Visible="false"></asp:Literal>
                            </h2>
                            <asp:Literal ID="SingleContent" runat="server"></asp:Literal>
                        </div>
                        <div id="faculty" runat="server" visible="false" class="facultyview">
                            <asp:Literal ID="facultyviewContent" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc2:foot ID="foot2" runat="server" />
    </form>
</body>
</html>
