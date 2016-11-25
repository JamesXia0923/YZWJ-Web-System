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
        <iframe frameborder="0" scrolling="no" width="100%" height="405px" src="header.aspx"></iframe>
    </div>
    <!--产品类型列表（左边框）-->
    <div class="block">
        <div class="navmenu">
            <span>您现在的位置: <a href="#">设计工程</a> > 园所装备</span>园所装备</div>
        <div>
            <div class="fleft leftmenu yh">
                <ul>
                    <li><a href="">关于我们</a> </li>
                    <li><a href="Javascript:onclick('bb');" id="abb">bbbbb</a></li>
                    <li><a href="">ccccc</a></li>
                </ul>
            </div>
            <div class="content yh fright" id="bb" style="width: 850px;">
                <iframe id="iframe" src="ProductList.aspx" width="100%" height="1275px" frameborder="0" scrolling="no">dddddd</iframe>
            </div>

            <script type="text/javascript" id="bdshare_js" data="type=tools&amp;uid=375347"></script>

            <script type="text/javascript" id="bdshell_js"></script>

            <script type="text/javascript">
                document.getElementById("bdshell_js").src = "http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=" + Math.ceil(new Date() / 3600000)
                $(function() {
                    $(".content").hide();
                    $(".leftmenu>ul>li>:first").addClass("select");
                });
                function onclick(obj) {
                    $(".content").hide();
                    $("#" + obj).show();
                    $(".leftmenu>ul>li>a").removeClass();
                    $("#a" + obj).addClass("select");
                }
            </script>

        </div>
    </div>
    <!--底部-->
    <div>
        <iframe frameborder="0" scrolling="no" width="100%" height="410px" src="footer.aspx"></iframe>
    </div>
</body>
</html>
