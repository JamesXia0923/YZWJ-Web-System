<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsdetail.aspx.cs" Inherits="YouZhiWenJiao.Web.newsdetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>公司新闻</title>
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
    <div class="newsbox">
    	<div class="block">
        	<div class="navmenu yh"><span>您现在的位置: <a href="CorporateNews.aspx?id=<%=CorporateNewsType.id %>"><%=CorporateNewsType.description %></a> > <%=CorporateNewsDetails.title%></span><%=CorporateNewsDetails.title%></div>
            <div class="newsnr">
           	  <h1 class="newstitle"><%=CorporateNewsDetails.title %></h1>
                <span class="newsxx">发布时间: <%=CorporateNewsDetails.datetime %>&nbsp;&nbsp;&nbsp;&nbsp;来源: 优智文教</span>
                <div class="content yh">
               	    <p><%=CorporateNewsDetails.content %></p>
                </div>
            </div>
        </div>
    </div>	
    
    <!--底部--> 
	<div><iframe frameborder="0" scrolling="no" width="100%" class="h390" src="footer.aspx"></iframe></div>
</form>
</body>
</html>
