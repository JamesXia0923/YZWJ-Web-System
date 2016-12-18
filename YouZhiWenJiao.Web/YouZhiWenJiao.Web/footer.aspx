<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="footer.aspx.cs" Inherits="YouZhiWenJiao.Web.footer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta charset="utf-8">
<link href="css/master.css" type="text/css" rel="stylesheet" />
<link href="css/base.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/jquery.SuperSlide.2.1.1.js"></script>
</head>
<body>
<div class="team clearfix yh">
		<div class="block">
			<div class="t1">产品欣赏 <span class="f14 c_666">Product</span></div>			
			<div class="bd">
				<ul class="picList">
				    <%foreach (var product in ProductCollection) %>
				    <%{ %>
					<li>
						<div class="pic"><a href="productdetail.aspx?id=<%=product.id %>" target="_blank"><img src="<%=product.picture %>" /></a></div>
						<div class="title"><a href="productdetail.aspx?id=<%=product.id %>" target="_blank"><%=product.title%></a></div>
					</li>
					<%} %>
				</ul>
			</div>
		</div>
	</div>
	<div class="foot clearfix">
		<div class="block">
			<div class="fleft">
				<p><a href="aboutMe.html" class="a1" target="_parent">联系我们</a>|<a href="index.aspx" class="a2" target="_parent">公司首页</a>|<a href="profile.aspx" class="a3" target="_parent">公司介绍</a>|<a href="news.aspx" class="a4" target="_parent">活动公告</a></p>
				<p>Copyright © 2016 www.shqxh.com,All Rights Reserved</p>
				<p>版权所有  上海优智文教用品有限公司</p>
			</div>
			
			<div class="fright">
				<p class="p1">联系电话：021-36362870    56402571</p>
				<p class="p2">邮编：200442</p>
				<p class="p3">公司地址：上海市宝山区新沪路689号3号楼202室</p>
			</div>
		</div>
	</div>
	<script src="js/all.js" type="text/javascript"></script>
</body>
</html>
