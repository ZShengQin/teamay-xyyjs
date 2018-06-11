<%@ Control Language="C#" AutoEventWireup="True" Inherits="Teamay_CBST.CN.parts.top" Codebehind="top.ascx.cs" %>
<div id="topWrapper">
	<div id="top">
        <div id="wight">
			<a href="/cn" class="A1" target="_blank"><img src="images/blank.gif" width="75px" height="16px" /></a>
			<a href="/en" class="A2" target="_blank"><img src="images/blank.gif" width="75px" height="16px" /></a>
		</div>
    </div>
	<div id="top_sec">
		<div class="topmenu">
            <ul id="UL_A">
				<li class="menu_top_li"><a href="index.aspx" class="topa">首页</a></li>
                <li class="menu_top_li"><a href="ShowPage.aspx?id=10" class="topa">公司概况</a></li>
				<li class="menu_top_li"><a href="ShowPage.aspx?id=90" class="topa">工程案例</a></li>
				<li class="menu_top_li"><a href="ShowPage.aspx?id=20" class="topa">行业/国家标准</a></li>
				<li class="menu_top_li"><a href="ShowPage.aspx?id=40" class="topa">人才招聘	</a></li>
				<li class="menu_top_li"><a href="ShowPage.aspx?id=30" class="topa">联系方式</a></li>
            </ul>
        </div>
	</div>
</div>
         <script type="text/javascript">
             $('li.menu_top_li').mousemove(function () {
                 //$(this).find('ul').slideDown(500);//you can give it a speed
                 $(this).find('ul').show();
                 $(this).addClass("moveon");
             });
             $('li.menu_top_li').mouseleave(function () {
                 //$(this).find('ul').slideUp("fast");
                 $(this).find('ul').hide();
                 $(this).removeClass("moveon");
             });
</script>
        
        
<div class="bigdiv">
        <div class="flexslider">
            <ul class="slides">
                <li style="background: url(images/bigimg.jpg) 50% 0 no-repeat;"><a href="javascript:void(0)">
                    &nbsp;</a></li>
            </ul>
        </div>
        <script type="text/javascript">
            $(document).ready(function () {
                $('.flexslider').flexslider({
                    directionNav: true,
                    pauseOnAction: false
                });
            });
        </script>
    </div>