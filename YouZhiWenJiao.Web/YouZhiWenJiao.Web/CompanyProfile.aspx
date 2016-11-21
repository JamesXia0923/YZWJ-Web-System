<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyProfile.aspx.cs" Inherits="YouZhiWenJiao.Web.CompanyProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>公司简介</title>
    <meta name="keywords" content="[!--pagekey--]" />
    <meta name="description" content="[!--pagedes--]" />
    <link href="css/master.css" type="text/css" rel="stylesheet" />
    <link href="css/base.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.SuperSlide.2.1.1.js"></script>
</head>
<body>
    <!--头部-->
    <div><iframe frameborder="0" scrolling="no" width="100%" height="165px" src="header.aspx"></iframe></div>
	<!--幻灯片-->
<div class="fullSlide">
		<div class="bd">
			<ul>
			<li style="background:url(images/banner.jpg) #FFF center 0 no-repeat;"><a target="_blank" href="#"></a></li>
			</ul>
		</div>
		<div class='db'>				
		</div>
</div>  
<div class="fullSlideBlockForCompany"></div>
<div class="fullSlideBlockForCompanyMark" id="mark"></div>
<!--文字列表页主体-->
<div class="newsbox yh">
    	<div class="block">
        	<div class="navmenu"><span>您现在的位置: <a href="#">公司简介</a> > 关于我们</span>公司简介</div>
            
            <div class="newsnr">
            	<div class="fleft leftmenu yh">
                	<ul>
                		<li><a href="Javascript:onclick('gsgs');" id = "agsgs" class="select">公司概述</a></li>
                		<li><a href="Javascript:onclick('gsln');" id = "agsln" class="">公司理念</a></li>
                		<li><a href="Javascript:onclick('czlc');" id = "aczlc" class="">成长历程</a></li>
                		<li><a href="Javascript:onclick('hzhb');" id = "ahzhb" class="">合作伙伴</a></li>
                		<li><a href="Javascript:onclick('lxwm');" id = "alxwm" class="">联系我们</a></li>
                	</ul>
                </div>
                <div id = "gsgs" class="content yh fright" style="width:850px;">
               	    <p>公司概述</p>
                	<p>优势</p>
                	<p>　　跨搜索引擎平台效果</p>
                	<p>        SEO优化是针对所有的搜索引擎来做的，只要SEO的方法是白帽的、专业的、面向用户体验的，那么你不仅仅能收获百度来的流量，谷歌，搜狗，360，雅虎，SOSO都会不同程度的认可你的网站，从而给你网站良好的展示位置。而SEM，不同的搜索引擎有不同的服务机制。</p>
                	<p>更多信息来自：<a href="http://www.haiis.com/"><strong>淮安网站建设</strong></a>，<a href="http://www.haiis.com/"><strong>淮安互联</strong></a></p>
                </div>
                <div id = "gsln" class="content yh fright" style="width:850px;">
               	    <p>公司理念</p>
                	<p>优势</p>
                	<p>　　跨搜索引擎平台效果</p>
                	<p>        SEO优化是针对所有的搜索引擎来做的，只要SEO的方法是白帽的、专业的、面向用户体验的，那么你不仅仅能收获百度来的流量，谷歌，搜狗，360，雅虎，SOSO都会不同程度的认可你的网站，从而给你网站良好的展示位置。而SEM，不同的搜索引擎有不同的服务机制。</p>
                	<p>更多信息来自：<a href="http://www.haiis.com/"><strong>淮安网站建设</strong></a>，<a href="http://www.haiis.com/"><strong>淮安互联</strong></a></p>
                </div>
                <div id = "czlc" class="content yh fright" style="width:850px;">
               	    <p>成长历程</p>
                	<p>优势</p>
                	<p>　　跨搜索引擎平台效果</p>
                	<p>        SEO优化是针对所有的搜索引擎来做的，只要SEO的方法是白帽的、专业的、面向用户体验的，那么你不仅仅能收获百度来的流量，谷歌，搜狗，360，雅虎，SOSO都会不同程度的认可你的网站，从而给你网站良好的展示位置。而SEM，不同的搜索引擎有不同的服务机制。</p>
                	<p>更多信息来自：<a href="http://www.haiis.com/"><strong>淮安网站建设</strong></a>，<a href="http://www.haiis.com/"><strong>淮安互联</strong></a></p>
                </div>
                <div id = "hzhb" class="content yh fright" style="width:850px;">
               	    <p>合作伙伴</p>
                	<p>优势</p>
                	<p>　　跨搜索引擎平台效果</p>
                	<p>        SEO优化是针对所有的搜索引擎来做的，只要SEO的方法是白帽的、专业的、面向用户体验的，那么你不仅仅能收获百度来的流量，谷歌，搜狗，360，雅虎，SOSO都会不同程度的认可你的网站，从而给你网站良好的展示位置。而SEM，不同的搜索引擎有不同的服务机制。</p>
                	<p>更多信息来自：<a href="http://www.haiis.com/"><strong>淮安网站建设</strong></a>，<a href="http://www.haiis.com/"><strong>淮安互联</strong></a></p>
                </div>
                <div id = "lxwm" class="content yh fright" style="width:850px;">
               	    <p>联系我们</p>
                	<p>优势</p>
                	<p>　　跨搜索引擎平台效果</p>
                	<p>        SEO优化是针对所有的搜索引擎来做的，只要SEO的方法是白帽的、专业的、面向用户体验的，那么你不仅仅能收获百度来的流量，谷歌，搜狗，360，雅虎，SOSO都会不同程度的认可你的网站，从而给你网站良好的展示位置。而SEM，不同的搜索引擎有不同的服务机制。</p>
                	<p>更多信息来自：<a href="http://www.haiis.com/"><strong>淮安网站建设</strong></a>，<a href="http://www.haiis.com/"><strong>淮安互联</strong></a></p>
                </div>                
                
<script type="text/javascript" id="bdshare_js" data="type=tools&amp;uid=375347" ></script>
<script type="text/javascript" id="bdshell_js"></script>
<script type="text/javascript">
document.getElementById("bdshell_js").src = "http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=" + Math.ceil(new Date()/3600000)
$(function() {
    window.location.hash = "#mark";
    $(".content").hide();
    $("#gsgs").show();
});
function onclick(obj) {
    $(".content").hide();
    $("#" + obj).show();
    $(".leftmenu>ul>li>a").removeClass();
    $("#a" + obj).addClass("select");
}
</script>
<!-- Baidu Button END -->
                    </div>
                </div>
                <div class="clearfix"></div>
          </div>
            

        </div>
    </div>	
    
	<div><iframe frameborder="0" scrolling="no" width="100%" src="footer.aspx"></iframe></div>

<script src="js/all.js" type="text/javascript"></script>
</body>
</html>
