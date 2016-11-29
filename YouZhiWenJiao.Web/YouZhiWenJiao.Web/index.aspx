<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="YouZhiWenJiao.Web.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta charset="utf-8">
<!--<title>[!--pagetitle--] - [!--class.name--] - <?=$public_r[sitename]?></title>-->
<title>上海优智文教</title>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<meta name="keywords" content="[!--pagekey--]" />
<meta name="description" content="[!--pagedes--]" />
<link href="css/master.css" type="text/css" rel="stylesheet" />
<link href="css/base.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/jquery.SuperSlide.2.1.1.js"></script>
</head>

<body>
    <!--头部-->
    <div><iframe frameborder="0" scrolling="no" width="100%" height="405px" src="header.aspx"></iframe></div>
    <!--首页主体--> 
    <div class="xc_pic ofHidden clearfix">
        <div class="block clearfix ofHidden">
            <b></b>
            <ul>
                <li><a href="producttypelist.aspx?id=3"><img src="images/case.png"></a></li>
			    <li><a href="producttypelist.aspx?id=4"><img src="images/kefu.png"></a></li>
			    <li><a href="producttypelist.aspx?id=5"><img src="images/dianzi.png"></a></li>
                <li><a href=""><img src="images/team.png"></a></li>
            </ul>
        </div>    
	</div> 
    <div class="clearfix ofHidden block yh pt20">
    	<div class="index_left fleft">
        	<div class="t1">产品展示 <span class="f14 c_666">Product</span></div>            
            <!--九宫格-->
            <div class="ge ofHidden">
            	<div class="w410 fleft h280 ofHidden"><a href="" class="h280"><img src="productimages/product1.jpg" width="410" height="280"><p class="f16">户外用品</p><b class="h45"></b></a></div>
                <div class="w410 fright h140 ofHidden"><a href="" class="h140"><img src="productimages/product2.jpg" width="410" height="140"><p class="f14">室内用品</p><b class="h30"></b></a></div>
                <div class="w410 fright mt10">
                	<span class="w200 fleft h130 ofHidden"><a href="" class="h130"><img src="productimages/product3.jpg" width="200" height="130"><p class="f14">学习用品</p><b class="h30"></b></a></span>
                    <span class="w200 fright h130 ofHidden"><a href="" class="h130"><img src="productimages/product4.jpg" width="200" height="130"><p class="f14">寓教于乐</p><b class="h30"></b></a></span>
                </div>
            </div>
            
            <div class="index_pic1"><img src="images/product_index.jpg"></div>
        </div>
        
        
    	<div class="index_right fright">
        	<div class="t1">音频中心 <span class="f14 c_666">Video Center</span></div>
            <ul class="alzs clearfix ofHidden">
            <%int i = 0; %>
            <%foreach (var product in downloadList) %>
            <%{ %>
            	<li><a href="<%=product.picture %>"><%=product.title %></a></li>
            <%i++; %>
            <%} %>
            <%if (i < 18) %>
            <%{ %>
                <%for (int j = 0; j < 18 - i; j++) %>
                <%{ %>
                    <li><a></a></li>
                <%} %>
            <%} %>
            </ul>
            
            <div class="t1 mt20">企业宣传片 <span class="f14 c_666">Trailer</span></div>
            <p class="mt20"><img src="images/xc_video.jpg" width="270" height="168"></p>
        </div>
    </div>
    <!--底部--> 
	<div style="margin-top:10px"><iframe frameborder="0" scrolling="no" width="100%" class="h390" src="footer.aspx"></iframe></div>
	<script src="js/all.js" type="text/javascript"></script>
</body>
</html>
