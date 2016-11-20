﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorporateProductDetail.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8">
<!--<title>[!--pagetitle--] - [!--class.name--] - <?=$public_r[sitename]?></title>-->
<title>上海优智文教</title>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<meta name="keywords" content="[!--pagekey--]" />
<meta name="description" content="[!--pagedes--]" />
<link href="css/master.css" type="text/css" rel="stylesheet" />
<link href="css/base.css" type="text/css" rel="stylesheet" />
<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/jquery.SuperSlide.2.1.1.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<script src="js/imagezoom.js" type="text/javascript"></script>
</head>


<body>

<!--头部-->
<div class="head">
	<div class="block yh f13">
		<p class="tright pt10"><a onclick="SetHome(window.location)" href="javascript:void(0)" class="pl10 pr10">设为首页</a> | <a onclick="AddFavorite(window.location,document.title)" href="javascript:void(0)" class="pl10 pr10">加入收藏</a></p>
		<div class="box position_a clearfix">     
			<!--导航-->
			<div class="nav fleft ofHidden">
				<ul>
				   <li><a href="index.html">首页</a></li>
				   <li><a href="gsjj.html">公司简介</a></li>
				   <li><a href="xwzx.html">公司新闻</a></li>
				   <li><a href="cpzs.html">园所装备</a></li>
				   <li><a href="xwzx.html">园长书库</a></li>
				   <li><a href="">教师书库</a></li>
				   <li><a href="">资料下载</a></li>
				   <li><a href="zxly.htmll">在线留言</a></li>
				   <li><a href="">联系我们</a></li>
				</ul>
			</div>
		
			<!--搜索-->
			<form name="searchform" method="post" action="/e/search/index.php" class="ss ofHidden">
				<input name='ecmsfrom' type='hidden' value='9'>
				<input type="hidden" name="show" value="title,newstext">
				<input class="index_srh" name="keyboard" placeholder="请输入关键字" >
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
<div class="fullSlideBlock"></div>
<!--产品信息-->    
    <!--单个产品-->
    <div class="block">
        <div class="navmenu"><span>您现在的位置: <a href="#">户外用品</a> > 产品1</span> 产品1</div>
	    <div class="container">
	        <div class="products">
		        <div class="products-grids">
		    	    <div class="col-md-2 products-single"></div>
			        <div class="col-md-4 grid-single">		
				        <div class="flexslider3">
					      <ul class="slides">
						    <li>
							    <div class="thumb-image"> <img src="images/pic1.jpg" data-imagezoom="true" class="img-responsive" alt=""/> </div>
					      </ul>
					    </div>
				    </div>	
			        <div class="col-md-6 single-text">
				        <div class="details-left-info simpleCart_shelfItem">
					        <h3>Accessories Latest</h3>
					        <p class="availability">Availability: <span class="color">In stock</span></p>
		                </div>
	                </div>
                </div>
            </div>
        </div>
    </div>

	<div class="team clearfix yh mt20">
		<div class="block">
			<div class="t1">产品欣赏 <span class="f14 c_666">Product</span></div>			
			<div class="bd">
				<ul class="picList">
					<li>
						<div class="pic"><a href="#" target="_blank"><img src="images/pic7.jpg" /></a></div>
						<div class="title"><a href="#" target="_blank">产品1</a></div>
					</li>
					<li>
						<div class="pic"><a href="#" target="_blank"><img src="images/pic8.jpg" /></a></div>
						<div class="title"><a href="#" target="_blank">产品2</a></div>
					</li>
					<li>
						<div class="pic"><a href="#" target="_blank"><img src="images/pic3.jpg" /></a></div>
						<div class="title"><a href="#" target="_blank">产品3</a></div>
					</li>
					<li>
						<div class="pic"><a href="#" target="_blank"><img src="images/pic4.jpg" /></a></div>
						<div class="title"><a href="#" target="_blank">产品4</a></div>
					</li>
					<li>
						<div class="pic"><a href="#" target="_blank"><img src="images/pic5.jpg" /></a></div>
						<div class="title"><a href="#" target="_blank">产品5</a></div>
					</li>
					<li>
						<div class="pic"><a href="#" target="_blank"><img src="images/pic6.jpg" /></a></div>
						<div class="title"><a href="#" target="_blank">产品6</a></div>
					</li>
				</ul>
			</div>
		</div>
	</div>
        
        
	<div class="foot clearfix">
		<div class="block">
			<div class="fleft">
				<p><a href="" class="a1">联系我们</a>|<a href="" class="a2">公司诚聘</a>|<a href="" class="a3">合作伙伴</a>|<a href="" class="a4">网站地图</a></p>
				<p>Copyright © 2016 www.shqxh.com,All Rights Reserved</p>
				<p>版权所有  上海优智文教用品有限公司</p>
			</div>
			
			<div class="fright">
				<p class="p1">联系电话：021-36362870    56402571</p>
				<p class="p2">邮编：200442</p>
				<p class="p3">公司地址：宝山区新沪路689号3号楼516室</p>
			</div>
		</div>
	</div>    

<script src="js/all.js" type="text/javascript"></script>
</body>
</html>