<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorporateNews.aspx.cs" Inherits="YouZhiWenJiao.Web.CorporateNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta charset="utf-8">
<!--<title>[!--pagetitle--] - [!--class.name--] - <?=$public_r[sitename]?></title>-->
<title>公司新闻列表</title>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<link href="css/master.css" type="text/css" rel="stylesheet" />
<link href="css/base.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/jquery.SuperSlide.2.1.1.js"></script>
</head>
<body>
    <!--头部-->
    <div><iframe frameborder="0" scrolling="no" width="100%" height="405px" src="header.aspx"></iframe></div>
    <!--文字列表页主体-->
    <div class="newsbox yh">
    	<div class="block">
        	<div class="navmenu"><span>您现在的位置: <a href="#">首页</a> > <%=CorporateNewsType.description %></span><%=CorporateNewsType.description %></div>
            
            <div class="text-list yh">
				<ul>
				    <% foreach (var corporateNews in CorporateNewsList){%>
				        <li class="clearfix">
				            <div class="fleft"><img src="<%=corporateNews.picture %>" width="200" height="150" /></div>
				            <div class="fright">
				                <p class="bt"><a href="CorporateNewsDetail.aspx?id=<%=corporateNews.id %>" target="_parent"><%=corporateNews.title %></a></p>
				                <p class="jj"><a href="CorporateNewsDetail.aspx?id=<%=corporateNews.id %>" target="_parent"><%=corporateNews.content %></a></p>
				                <p class="ck"><span class="eye">10</span><span class="time"><%=corporateNews.datetime %></span></p>
				            </div>
				        </li>
				    <%} %>
				</ul>
				
			</div>
            
            <div class="page clearfix"><a href="" class="on">1</a><a href="">2</a><a href="">3</a><a href="">>></a></div>
        </div>
    </div>	
    <!--底部--> 
	<div><iframe frameborder="0" scrolling="no" width="100%" class="h390" src="footer.aspx"></iframe></div>
</body>
</html>
