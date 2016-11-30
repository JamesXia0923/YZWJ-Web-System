<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="YouZhiWenJiao.Web.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="[!--pagekey--]" />
    <meta name="description" content="[!--pagedes--]" />
    <link href="css/master.css" type="text/css" rel="stylesheet" />
    <link href="css/base.css" type="text/css" rel="stylesheet" />
    <base target="_parent">
</head>
<body>
    <form runat ="server" id="form1">
    <!--头部-->
    <div>
        <iframe frameborder="0" scrolling="no" width="100%" height="405px" src="header.aspx"></iframe>
    </div>
    <!--文字列表页主体-->
    <div class="block">
        <div style="overflow: hidden;">
            <div class="login fleft">
                <h1>
                    <img src="images/log_bg.jpg" /></h1>
                <table border="0" cellpadding="0" cellspacing="0" with="600px">
                    <tr>
                        <td>
                            用户名：
                        </td>
                        <td colspan="2">
                            <input type="text" class="log_inp" id="txtLoginName" runat="server" tabindex="1" onclick="checkform()" />
                            <span runat="server" id="spanName" style=" color:red"></span>
                        </td>
                        <td rowspan="3" align="center">
                            <input type="submit" class="log_btn1" value="登录" runat="server" id="loginBtn" onserverclick="loginClick"
                                tabindex="4" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密码：
                        </td>
                        <td colspan="2">
                            <input type="password" class="log_inp" id="txtPassword" runat="server" tabindex="2" onclick="checkform()" />
                            <span runat="server" id="spanPwd" style=" color:red"></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            验证码：
                        </td>
                        <td width="110">
                            <input type="text" class="log_inp1" id="txtYzm" runat="server" tabindex="3" onclick="checkform()" />
                            <span runat="server" id="spanYzm" style=" color:red"></span>
                        </td>
                        <td align="left">
                            <img style="width: 80px; height: 20px; cursor: pointer" id="image1" title="看不清楚?换一张"
                                alt="验证码" src="CheckCode.aspx" onclick="src='CheckCode.aspx?s='+Math.random()" />
                        </td>
                    </tr>
                </table>
                <script type="text/javascript">
                    function checkform() {
                        document.getElementById("spanName").style.display = "none";
                        document.getElementById("spanPwd").style.display="none";
                        document.getElementById("spanYzm").style.display="none";
                        }    
                </script>
            </div>
            <div class="fleft wor">
                <img src="images/log_3.jpg" /></div>
        </div>
    </div>
    <div>
        <iframe frameborder="0" scrolling="no" width="100%" class="h390" src="footer.aspx"></iframe>
    </div>

    <script src="js/all.js" type="text/javascript"></script>

    </form>
</body>
</html>
