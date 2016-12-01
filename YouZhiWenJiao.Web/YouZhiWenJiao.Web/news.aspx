<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="YouZhiWenJiao.Web.news" %>
<%@ Register TagPrefix="Control" Namespace="YouZhiWenJiao.Web.Manage.css" Assembly="YouZhiWenJiao.Web" %>

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
			<div class="navmenu"><span>您现在的位置: <a href="index.aspx">首页</a> > 公司新闻</span>公司新闻</div>
			<div class="text-list yh">
				<ul>
					<table class="talist">
						<CONTROL:VIEWDATA id="rptDate" runat="Server" Select="false" Col="12" PageSize="6" AllowPage="true" OnPageIndexChange="PageChanged"  OnItemDataBound="DataBindings">
							<ITEMTEMPLATE>
								<tr>
									<td style=" text-align:left;">
									<li class="clearfix"><div class="fleft"><img src="<%# DataBinder.Eval(Container.DataItem, "picture")%>" width="200" height="150" /></div>
										<div class="fright">
											<p class="bt"><a href="newsdetail.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id")%>" target="_parent"><%# DataBinder.Eval(Container.DataItem, "title")%></a></p>
											<p class="jj"><a href="newsdetail.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id")%>" target="_parent"><%# DataBinder.Eval(Container.DataItem, "Content")%></a></p>
											<p class="ck"><span class="time"><%# DataBinder.Eval(Container.DataItem, "datetime")%></span></p>
										</div>
									</li>
									</td>
								</tr>
							</ITEMTEMPLATE>
						</CONTROL:VIEWDATA>
					</table>
				</ul>
			</div>
		</div>
	</div>
	<!--底部--> 
	<div><iframe frameborder="0" scrolling="no" width="100%" class="h390" src="footer.aspx"></iframe></div>
</form>
</body>
</html>
