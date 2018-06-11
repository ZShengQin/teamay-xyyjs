<%@ Page Language="C#" AutoEventWireup="True" EnableViewState="false" Inherits="Teamay_CBST.CN.Index"
  CodeBehind="Index.aspx.cs" %>

<%@ Register Src="parts/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="parts/foot.ascx" TagName="foot" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <meta name="keywords" content="江苏省血液研究所" />
  <title>江苏省血液研究所</title>
  <link rel="stylesheet" href="common/css/index.css" />
  <link rel="stylesheet" href="common/css/swiper-4.2.2.min.css" />
  <script src="common/js/jquery.js"></script>
  <script src="common/js/swiper-4.2.2.min.js"></script>
</head>

<body>
  <form id="form1" runat="server">
    <!--header-->
    <uc1:top ID="top1" runat="server" />

    <!--内容区 可鼠标滚动-->
    <div class="content">
      <!--动态 成果 讲座-->
      <div class="main-info">
        <div class="main-info-1">
          <!--新闻动态-->
          <div class="news">
            <div class="header-title">
              <span class="header-cn">新闻动态</span><span class="header-en">/NEWS</span><a class="header-more" href="#">MORE</a>
            </div>
            <div class="news-item">
              <img src="images/news1.jpg" alt="" />
              <div class="news-content">
                <div>2018年2月, 朱力教授团队在动脉粥样硬化调控机制研究上取得重要进展</div>
                <p>
                  最近，朱力教授团队发现血管内皮细胞的导向分子Sema7A介导扰动流引起的动脉粥样硬化斑块形成，具有重要的临床意义和应用价值。研究成果以“Vascular Semaphorin 7A upregul ation by
                disturbed flow promotes atherosclerosi......<a href="#">more</a>
                </p>
              </div>
            </div>
            <div class="news-item">
              <img src="images/news1.jpg" alt="" />
              <div class="news-content">
                <div>2018年2月, 朱力教授团队在动脉粥样硬化调控机制研究上取得重要进展</div>
                <p>
                  最近，朱力教授团队发现血管内皮细胞的导向分子Sema7A介导扰动流引起的动脉粥样硬化斑块形成，具有重要的临床意义和应用价值。研究成果以“Vascular Semaphorin 7A upregul ation by
                disturbed flow promotes atherosclerosi......<a href="#">more</a>
                </p>
              </div>
            </div>
          </div>

          <!--学术讲座-->
          <div class="academic">
            <div class="header-title">
              <span class="header-cn">学术讲座</span><span class="header-en">/ACADEMIC</span><a class="header-more" href="#">MORE</a>
            </div>
            <img src="images/academic.jpg" alt="" />
            <div class="academic-title">吴毅教授所肩负的看风景的萨克分解机</div>
            <p class="academic-content">发圣诞节疯狂就送阿范德萨放使劲地沟第三方叫发动机搜安抚就是发决赛福建省发沙发</p>
            <div class="academic-links">
              <ul>
                <li><a href="#">医学装备质量控制中心举办安徽省第二期内镜...</a><span>03-24</span></li>
                <li><a href="#">省长李国英来我院调研智慧医院建设工作</a><span>03-24</span></li>
                <li><a href="#">合肥市疾控中心赴南区进行消毒质量监测</a><span>03-24</span></li>
                <li><a href="#">我院介入科受邀加入中国静脉联盟</a><span>03-24</span></li>
              </ul>
            </div>
          </div>
        </div>

        <div class="main-info-2">
          <!--科研成果-->
          <div class="research">
            <div class="header-title">
              <span class="header-cn">研究成果</span>
              <span class="header-en">/NEWS</span>
              <a class="header-more" href="#">MORE</a>
            </div>
            <div class="research-links">
              <ul>
                <li>2018年2月，主力教授爱动脉粥样硬化调控机制研究上取得重要进展<span>03-24</span></li>
                <li>2017年11月29日心血管小型专题讨论会<span>03-24</span></li>
                <li>2017年迎新大会暨新生入学教育活动顺利进行<span>03-24</span></li>
                <li>2017年10月25日The Wistar Institute Dr. Dmitry Gabrilovich学术报告<span>03-24</span></li>
                <li>2018年1月5日，上海市公共卫生临床中心刘保池教授学术报告<span>03-24</span></li>
              </ul>
            </div>
          </div>

          <!--guidance-->
          <div class="guide">
            <img class="guide-img" src="images/guide.jpg" alt="" />
            <div class="qrcode">
              <img src="images/qrcode.jpg" alt="" />
              <p align="center">微信平台</p>
            </div>
          </div>

        </div>
      </div>
    </div>

    <!--科研平台导航-->
    <div class="science-plat">
      <div class="plat-content">
        <div class="platform">
          <div>科研平台</div>
        </div>
        <div class="platforms">
          <div class="plat-href plat-href-margin">
            <a href="ShowPage.aspx?id=51">血液科</a>
          </div>
          <div class="plat-href plat-href-margin">
            <a href="ShowPage.aspx?id=52">卫生部血栓与止血实验室</a>
          </div>
          <div class="plat-href plat-href-margin">
            <a href="ShowPage.aspx?id=53">教育部工程中心</a>
          </div>
          <div class="plat-href">
            <a href="ShowPage.aspx?id=54">唐仲英血液学研究中心</a>
          </div>
        </div>
        <div class="platforms">
          <div class="plat-href plat-href-margin">
            <a href="ShowPage.aspx?id=55">血液学协同创新中心</a>
          </div>
          <div class="plat-href plat-href-margin">
            <a href="ShowPage.aspx?id=56">造血干细胞移植研究所</a>
          </div>
          <div class="plat-href plat-href-margin">
            <a href="ShowPage.aspx?id=57">儿童血液病研究中心</a>
          </div>
          <div class="plat-href">
            <a href="ShowPage.aspx?id=58">样本/资源库</a>
          </div>
        </div>
      </div>
    </div>

    <!--footer-->
    <uc2:foot ID="foot1" runat="server" />

  </form>
</body>

</html>
