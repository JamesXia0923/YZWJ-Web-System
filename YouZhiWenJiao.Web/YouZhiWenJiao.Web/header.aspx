<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="header.aspx.cs" Inherits="YouZhiWenJiao.Web.header" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<meta charset="utf-8">
	<!--<title>[!--pagetitle--] - [!--class.name--] - <?=$public_r[sitename]?></title>-->
	<title>�Ϻ������Ľ�</title>
	<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
	<meta name="keywords" content="[!--pagekey--]" />
	<meta name="description" content="[!--pagedes--]" />
	<link href="css/master.css" type="text/css" rel="stylesheet" />
	<link href="css/base.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
	<script type="text/javascript" src="js/jquery.SuperSlide.2.1.1.js"></script>
</head>
<body>
	<form runat="server">
		<div class="head">
		<div class="block yh f13">
			<p class="tright pt10"><a onclick="SetHome(window.location)" href="javascript:void(0)" class="pl10 pr10">��Ϊ��ҳ</a> | <a onclick="AddFavorite(window.location,document.title)" href="javascript:void(0)" class="pl10 pr10">�����ղ�</a></p>
			<div class="box position_a clearfix">
				<!--����-->
				<div class="nav fleft ofHidden">
					<ul>
					<%ShowMenu(meauIndex); %>
					</ul>
				</div>
			
				<!--����-->
				<form name="searchform" method="post" action="/e/search/index.php" class="ss ofHidden">
					<input name='ecmsfrom' type='hidden' value='9'>
					<input type="hidden" name="show" value="title,newstext">
					<input class="index_srh" name="input_value" id="input_value" type="text" runat="server" placeholder="������ؼ���" >
					<input class="search" type="submit" name="submit" value="����">
				</form>
			</div>
		</div>
	</div>
<%--    <div class="header">
      <div class="clearfix">
        <h1 class="fl logo"><a href="index.aspx"><img src="images/logo.png" /></a></h1>
        <div class="fr topbar">
          <div><a onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.zs3s.sh.cn/');" href="#">��Ϊ��ҳ</a>&nbsp;|&nbsp;<a href="#" onclick="javascript:window.external.AddFavorite('http://www.zs3s.sh.cn/','�Ϻ��л��ֵ����������շ���������')" >�ղر�վ</a>&nbsp;|&nbsp;<a href="http://weibo.com" target="_blank" class="weibo">����΢��</a></div>
          <div class="search">
            <input name="textfield" id="textfield" type="text" runat="server"/>
            <input name="button" id="btnsearch" type="button" onserverclick="onclick" runat="server"/>
          </div>
        </div>
      </div>
      <div class="menu">
        <ul>
        <%ShowMenu(meauIndex); %>
        </ul>
      </div>
     </div>--%>
	</form>
</body>
</html>
