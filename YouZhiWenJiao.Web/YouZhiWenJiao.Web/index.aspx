<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="YouZhiWenJiao.Web.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta charset="utf-8">
<title>上海优智文教</title>
<link href="css/master.css" type="text/css" rel="stylesheet" />
<link href="css/base.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/jquery.SuperSlide.2.1.1.js"></script>
</head>

<body>
    <!--头部-->
    <div><iframe frameborder="0" scrolling="no" width="100%" height="405px" src="header.aspx"></iframe></div>
    <!--首页主体--> 
<%--    <div class="xc_pic ofHidden clearfix">
        <div class="block clearfix ofHidden">
            <b></b>
            <ul>
                <li><a href="producttypelist.aspx?id=3"><img src="images/case.png"></a></li>
			    <li><a href="producttypelist.aspx?id=4"><img src="images/kefu.png"></a></li>
			    <li><a href="producttypelist.aspx?id=5"><img src="images/dianzi.png"></a></li>
                <li><a href="videos.aspx"><img src="images/team.png"></a></li>
            </ul>
        </div>    
	</div> --%>
    <div class="clearfix ofHidden block yh pt20">
    	<div class="index_left fleft">
        	<div class="t1">产品展示 <span class="f14 c_666">Product List</span></div>            
            <!--九宫格-->
            <div class="ge ofHidden">
            	<div id="pro1" class="fleft ofHidden" style="width:540px;height:366px;"><a href="producttypelist.aspx?id=3" class="h280"><img src="productimages/product1.jpg" width="540" height="366"></a>
            	    <div id="pro1rsp" style="position:absolute;width: 540px;height: 366px;top: 464px;overflow: hidden;background-color:#000" ></div>
            	    <div id="pro1Btn" style="position:absolute;width: 540px;height: 366px;top: -564px;overflow: hidden;"><a href="producttypelist.aspx?id=3"><img src="images/case.png" style="margin-left:170px;width:200px;height:200px"></a></div>
            	</div>
                <div id="pro2" class="fright ofHidden" style="width:280px;height:175px"><a href="producttypelist.aspx?id=4" class="h140"><img src="productimages/product2.jpg" width="280" height="175"></a>
                    <div id="pro2rsp" style="position:absolute;width: 280px;height: 175px;top: 464px;overflow: hidden;background-color:#000" ></div>
            	    <div id="pro2Btn" style="position:absolute;width: 280px;height: 175px;top: -220px;overflow: hidden;"><a href="producttypelist.aspx?id=4"><img src="images/kefu.png" style="margin-left:70px"></a></div>
            	</div>
                <div id="pro3" class="fright ofHidden mt16" style="width:280px;height:175px"><a href="producttypelist.aspx?id=5" class="h140"><img src="productimages/product3.jpg" width="280" height="175"></a>
                    <div id="pro3rsp" style="position:absolute;width: 280px;height: 175px;top: 655px;overflow: hidden;background-color:#000" ></div>
            	    <div id="pro3Btn" style="position:absolute;width: 280px;height: 175px;top: -394px;overflow: hidden;"><a href="producttypelist.aspx?id=5"><img src="images/dianzi.png" style="margin-left:70px"></a></div>
            	</div>
            </div>
        </div>
        
        
    	<div class="index_right fright">
        	<div class="t1">下载中心 <span class="f14 c_666">Video Center</span></div>
        	<div style="margin-top:10px"><a href="<%=client %>" style="background:url(../images/linkImg.png) no-repeat 0 3px;padding-left:18px; font-size:14px; color:#666">优智点读笔客户端</a></div>
            <ul class="alzs clearfix ofHidden">
            <%int i = 0; %>
            <%foreach (var product in downloadList) %>
            <%{ %>
            	<li><div style="width:115px;overflow: hidden; text-overflow:ellipsis; white-space: nowrap;"><a href="<%=product.video %>"><%=product.title %></a></div></li>
            <%i++; %>
            <%} %>
            <%if (i < 11) %>
            <%{ %>
                <%for (int j = 0; j < 10 - i; j++) %>
                <%{ %>
                    <li><a>&nbsp;</a></li>
                <%} %>
            <%} %>
            </ul>
            
            <div class="t1 mt10">企业宣传片 <span class="f14 c_666">Trailer</span></div>
            <p class="mt10">
            <video src="<%=myVideo.video %>" controls="controls" poster="<%=myVideo.picture %>" style = "width:250px;height:143px;background-color:#000;">
            <embed src="<%=myVideo.video %>" width="270" height="168" /> 
            </object> 
            </video>
            
            </p>
        </div>
    </div>
    <!--底部--> 
	<div style="margin-top:20px"><iframe frameborder="0" scrolling="no" width="100%" class="h390" src="footer.aspx"></iframe></div>
	<script src="js/all.js" type="text/javascript"></script>
</body>
</html>
