<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="YouZhiWenJiao.Web.ProductList" %>

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

    <script type="text/javascript" src="js/jquery.min.js"></script>

    <script type="text/javascript" src="js/jquery.SuperSlide.2.1.1.js"></script>

</head>
<body>
    <!--图片列表页主体-->
    <div class="newsbox yh">
        <div class="block">
            <div class="pic_list">
                <ul class="clearfix">
                    <% foreach(var product in ProductCollection)%>
                    <%{%>
                    <li>
                        <div class="photo yh">
                            <img src="<%=product.picture %>" />
                            <p><%=product.title %></p>
                        </div>
                        <div class="rsp">
                        </div>
                        <div class="text">
                            <a href="CorporateProductDetail.aspx?id=<%=product.id %>" target="_parent">
                                <h3><%=product.title %></h3>
                                <p><%=product.content %>...</p>
                                <div>TIME :<%=product.datetime %></div>
                            </a>
                        </div>
                    </li>
                    <%} %>
                </ul>
                <div class="page clearfix">
                    <a href="" class="on">1</a><a href="">2</a><a href="">3</a><a href="">>></a></div>
            </div>
        </div>
    </div>

    <script src="js/all.js" type="text/javascript"></script>

</body>
</html>
