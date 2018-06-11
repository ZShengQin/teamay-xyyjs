<%@ Control Language="C#" AutoEventWireup="True" Inherits="Teamay_CBST.CN.parts.top" CodeBehind="top.ascx.cs" %>

<!--header-->
<div class="title-bar">
  <div class="language-choice">
    <a href="/cn">中文</a> &nbsp;|&nbsp;
    <a href="/en">ENGLISH</a>
  </div>
</div>
<div id="top_sec">
  <div class="topmenu">
    <ul>
      <li class="menu_top_li"><a href="index.aspx">首页</a></li>
      <li class="menu_top_li"><a href="ShowPage.aspx?id=10">关于我们</a></li>
      <li class="menu_top_li"><a href="ShowPage.aspx?id=20">新闻中心</a></li>
      <li class="menu_top_li"><a href="ShowPage.aspx?id=30">人才团队</a></li>
      <li class="menu_top_li"><a href="ShowPage.aspx?id=40">教育教学</a></li>
      <li class="menu_top_li"><a href="ShowPage.aspx?id=50">科研平台</a></li>
      <li class="menu_top_li"><a href="ShowPage.aspx?id=60">诊疗中心</a></li>
      <li class="menu_top_li"><a href="ShowPage.aspx?id=70">研究成果</a></li>
      <li class="menu_top_li"><a href="ShowPage.aspx?id=80">联系我们</a></li>
    </ul>
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

<div class="swiper-container">
  <div class="swiper-wrapper">
    <img class="swiper-slide" src="images/bigpic.jpg" alt="" height="200px" width="100%" />
    <img class="swiper-slide" src="images/bigpic.jpg" alt="" height="200px" width="100%" />
    <img class="swiper-slide" src="images/bigpic.jpg" alt="" height="200px" width="100%" />
    <img class="swiper-slide" src="images/bigpic.jpg" alt="" height="200px" width="100%" />
    <img class="swiper-slide" src="images/bigpic.jpg" alt="" height="200px" width="100%" />
  </div>
  <div class="swiper-pagination"></div>
  <!-- 如果需要导航按钮 -->
   <div class="swiper-button-prev"></div>
   <div class="swiper-button-next"></div>
</div>
<script>
    var swiper = new Swiper('.swiper-container', {
    direction: 'horizontal',
      loop: true,
    autoplay: true,
    pagination: {
      el: '.swiper-pagination',
      clickable: true
    },
    // 如果需要前进后退按钮
    navigation: {
      nextEl: '.swiper-button-next',
      prevEl: '.swiper-button-prev',
    }
    })
</script>
