<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="header.aspx.cs" Inherits="YouZhiWenJiao.Web.header" %>

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
		<div class="head">
		<div class="block yh f13">
			<p class="tright pt10"><a onclick="SetHome(window.location)" href="javascript:void(0)" class="pl10 pr10">设为首页</a> | <a onclick="AddFavorite(window.location,document.title)" href="javascript:void(0)" class="pl10 pr10">加入收藏</a></p>
			<div class="box position_a clearfix">
				<!--导航-->
				<div class="nav fleft ofHidden">
					<ul>
					<%ShowMenu(meauIndex); %>
					</ul>
				</div>
			
				<!--搜索-->
				<form name="searchform" method="post" action="/e/search/index.php" class="ss ofHidden">
					<input name='ecmsfrom' type='hidden' value='9'>
					<input type="hidden" name="show" value="title,newstext">
					<input class="index_srh" name="input_value" id="input_value" type="text" runat="server" placeholder="请输入关键字" >
					<input class="search" type="submit" name="submit" value="搜索">
				</form>
			</div>
		</div>
	</div>
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
</body>
</html>
