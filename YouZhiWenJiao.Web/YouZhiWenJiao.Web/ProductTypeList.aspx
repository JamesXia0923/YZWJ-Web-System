<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductTypeList.aspx.cs"
    Inherits="YouZhiWenJiao.Web.ProductTypeList" %>

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
    <!--头部-->
    <div>
        <iframe frameborder="0" scrolling="no" width="100%" height="405px" src="header.aspx">
        </iframe>
    </div>
    <!--产品类型列表（左边框）-->
    <div class="block">
        <div class="navmenu" id="navMenu">
            <span>您现在的位置: <a href="#">首页</a> >
                <%=ProductType.description %></span><%=ProductType.description %></div>
        <div>
            <% if (ProductTypeCollection.Count != 0) %>
            <%{ %>
                <div class="fleft leftmenu yh" id="leftMenu">
                    <ul>
                        <% foreach (var productType in ProductTypeCollection) %>
                        <%{ %>
                        <li><a href="Javascript:onclick('<%=productType.id %>')" id="a<%=productType.id %>">
                            <%=productType.description%></a></li>
                        <%} %>
                    </ul>
                </div>
                <% foreach (var productType in ProductTypeCollection) %>
                <%{ %>
                <div class="content yh fright" id="<%=productType.id %>" style="width: 850px;">
                    <iframe src="ProductList.aspx?id=<%=productType.id %>&cid=<%=productType.categoryid %>" width="100%" height="1275px"
                        frameborder="0" scrolling="no"></iframe>
                </div>
                <%} %>

                <script type="text/javascript" id="bdshare_js" data="type=tools&amp;uid=375347"></script>

                <script type="text/javascript" id="bdshell_js"></script>

                <script type="text/javascript">
                    document.getElementById("bdshell_js").src = "http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=" + Math.ceil(new Date() / 3600000)
                    $(function() {
                        $(".content").hide();
                        $("#<%=ProductTypeCollection[0].id %>").show();
                        $(".leftmenu>ul>li>:first").addClass("select");

                        var h3_height = 405;
                        $(window).scroll(function() {
                            var this_scrollTop = $(this).scrollTop();
                            if (this_scrollTop > h3_height) {
                                $("#leftMenu").attr("style", "z-index: -1; transform: translateZ(0px); position: fixed; transition: margin-top 0.3s ease; will-change: margin-top, top; top: 46px;");
                                $("#navMenu").attr("style", "background-color:#fff;z-index: 10;position: fixed; top: 0px;width:1135px;");
                            }
                            else {
                                $("#leftMenu").attr("style", "");
                                $("#navMenu").attr("style", "");
                            }
                        });
                    });
                    function onclick(obj) {
                        $(".content").hide();
                        $("#" + obj).show();
                        $(".leftmenu>ul>li>a").removeClass();
                        $("#a" + obj).addClass("select");
                    }
                </script>
            <%} %>
        </div>
    </div>
    <!--底部-->
    <div>
        <iframe frameborder="0" scrolling="no" width="100%" class="h390" src="footer.aspx">
        </iframe>
    </div>
</body>
</html>
