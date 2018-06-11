<%@ Page Language="C#" AutoEventWireup="True" Inherits="Teamay_CBST.CN.ErrorHandle" Codebehind="ErrorHandle.aspx.cs" %>

<%@ Register src="parts/top.ascx" tagname="top" tagprefix="uc1" %>

<%@ Register src="parts/foot.ascx" tagname="foot" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>苏州大学“两学一做”学习教育专题网站</title>
<meta name="keywords" content="苏州大学“两学一做”学习教育专题网站">
<link rel="stylesheet" href="index.css" type="text/css" />
<script src="common/jquery.js" type="text/javascript"></script>
</head>

<body>
<form id="form1" runat="server">

<uc1:top ID="top2" runat="server" />
<asp:HiddenField ID="nowText" runat="server" />


<div id="secondContentWrapper">
	<div id="secondContent" style="background:url(/images/404.jpg) no-repeat center center; height:650px;" >
        
    </div>
</div>
<uc2:foot ID="foot2" runat="server" />


</form>




</body>

</html>
