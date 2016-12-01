<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="YouZhiWenJiao.Web.search" %>

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
<form id="form1" runat="server">
    <!--头部-->
    <div><iframe frameborder="0" scrolling="no" width="100%" height="405px" src="header.aspx"></iframe></div>
    <!--文字列表页主体-->
    <div class="newsbox yh">
    	<div class="block">
        	<div class="navmenu"><span>您现在的位置: <a href="index.aspx">首页</a> > 搜索结果</span><%=SearchWD %></div>
            
            <div class="text-list yh">
				<ul>
				    <% foreach (var corporateNews in CorporateNewsList){%>
				        <li class="clearfix">
				                <%if (corporateNews.categoryid == 1) %>
				                <%{ %>
				            <div class="fleft"><img src="<%=corporateNews.picture %>" width="200" height="150" /></div>
				            <div class="fright">
				                    <p class="bt"><a href="profile.aspx" target="_parent"><%=corporateNews.title%></a></p>
				                    <p class="jj"><a href="profile.aspx" target="_parent"><%=corporateNews.content%></a></p>
				                    <p class="ck"><span>分类 : 公司简介</span><span class="time"><%=corporateNews.datetime%></span></p>
				                <%} %>
				                <%if (corporateNews.categoryid == 2) %>
				                <%{ %>
				            <div class="fleft"><img src="<%=corporateNews.picture %>" width="200" height="150" /></div>
				            <div class="fright">
				                    <p class="bt"><a href="newsdetail.aspx?id=<%=corporateNews.id %>" target="_parent"><%=corporateNews.title%></a></p>
				                    <p class="jj"><a href="newsdetail.aspx?id=<%=corporateNews.id %>" target="_parent"><%=corporateNews.content%></a></p>
				                    <p class="ck"><span>分类 : 公司新闻</span><span class="time"><%=corporateNews.datetime%></span></p>
				                <%} %>
				                <%if (corporateNews.categoryid == 3) %>
				                <%{ %>
				            <div class="fleft"><img src="<%=corporateNews.picture %>" width="200" height="150" /></div>
				            <div class="fright">
				                    <p class="bt"><a href="productdetail.aspx?id=<%=corporateNews.id %>" target="_parent"><%=corporateNews.title%></a></p>
				                    <p class="jj"><a href="productdetail.aspx?id=<%=corporateNews.id %>" target="_parent"><%=corporateNews.content%></a></p>
				                    <p class="ck"><span>分类 : 园所装备</span><span class="time"><%=corporateNews.datetime%></span></p>
				                <%} %>
				                <%if (corporateNews.categoryid == 4) %>
				                <%{ %>
				            <div class="fleft"><img src="<%=corporateNews.picture %>" width="200" height="150" /></div>
				            <div class="fright">
				                    <p class="bt"><a href="productdetail.aspx?id=<%=corporateNews.id %>" target="_parent"><%=corporateNews.title%></a></p>
				                    <p class="jj"><a href="productdetail.aspx?id=<%=corporateNews.id %>" target="_parent"><%=corporateNews.content%></a></p>
				                    <p class="ck"><span>分类 : 园长书库</span><span class="time"><%=corporateNews.datetime%></span></p>
				                <%} %>
				                <%if (corporateNews.categoryid == 5) %>
				                <%{ %>
				            <div class="fleft"><img src="<%=corporateNews.picture %>" width="200" height="150" /></div>
				            <div class="fright">
				                    <p class="bt"><a href="productdetail.aspx?id=<%=corporateNews.id %>" target="_parent"><%=corporateNews.title%></a></p>
				                    <p class="jj"><a href="productdetail.aspx?id=<%=corporateNews.id %>" target="_parent"><%=corporateNews.content%></a></p>
				                    <p class="ck"><span>分类 : 教师书库</span><span class="time"><%=corporateNews.datetime%></span></p>
				                <%} %>
				                <%if (corporateNews.categoryid == 6) %>
				                <%{ %>
				            <div></div>
				            <div class="fright">
				                    <p class="bt"><a href="<%=corporateNews.video %>" target="_parent"><%=corporateNews.title%></a></p>
				                    <p class="jj"><a href="<%=corporateNews.video %>" target="_parent"><%=corporateNews.content%></a></p>
				                    <p class="ck"><span>分类 : 资料下载</span><span class="time"><%=corporateNews.datetime%></span></p>
				                <%} %>
				            </div>
				        </li>
				    <%} %>
				</ul>
				
			</div>
        </div>
    </div>	
    <!--底部--> 
	<div><iframe frameborder="0" scrolling="no" width="100%" class="h390" src="footer.aspx"></iframe></div>
</form>
</body>
</html>
