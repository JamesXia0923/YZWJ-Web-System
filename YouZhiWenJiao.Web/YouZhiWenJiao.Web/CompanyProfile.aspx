<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyProfile.aspx.cs"
    Inherits="YouZhiWenJiao.Web.CompanyProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>公司简介</title>
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
    <!--文字列表页主体-->
    <div class="newsbox yh">
        <div class="block">
            <div class="navmenu">
                <span>您现在的位置: <a href="#">公司简介</a> > 公司简介</span>公司简介</div>
            <div class="newsnr">
                <div class="fleft leftmenu yh">
                    <ul>
                        <% foreach(var CompanyProfileType in CompanyProfileTypeList) %>
                        <%{ %>
                        <li><a href="Javascript:onclick('<%=CompanyProfileType.id %>');" id="a<%=CompanyProfileType.id %>">
                            <%=CompanyProfileType.description%></a></li>
                        <%} %>
                    </ul>
                </div>
                <% foreach(var CompanyProfile in CompanyProfileList) %>
                <%{ %>
                <div id="<%=CompanyProfile.typeid %>" class="content yh fright" style="width: 850px;">
                    <p>
                        <%=CompanyProfile.title%></p>
                    <p>
                        <%=CompanyProfile.content%></p>
                </div>
                <%} %>

                <script type="text/javascript" id="bdshare_js" data="type=tools&amp;uid=375347"></script>

                <script type="text/javascript" id="bdshell_js"></script>

                <script type="text/javascript">
                    document.getElementById("bdshell_js").src = "http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=" + Math.ceil(new Date() / 3600000)
                    $(function() {
                        $(".content").hide();
                        $("#<%=CompanyProfileList[0].typeid %>").show();
                        $(".leftmenu>ul>li>:first").addClass("select");
                    });
                    function onclick(obj) {
                        $(".content").hide();
                        $("#" + obj).show();
                        $(".leftmenu>ul>li>a").removeClass();
                        $("#a" + obj).addClass("select");
                    }
                </script>

                <!-- Baidu Button END -->
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
    <div>
        <iframe frameborder="0" scrolling="no" width="100%" height="410px" src="footer.aspx"></iframe>
    </div>

    <script src="js/all.js" type="text/javascript"></script>

</body>
</html>
