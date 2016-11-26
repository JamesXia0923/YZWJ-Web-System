<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="YouZhiWenJiao.Web.Manage.index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<title>管理中心 v1.0</title>
		<link href="css/admin.css" type="text/css" rel="stylesheet" />
	</head>
	<body >
		<form id="form1" runat="server">
			<table style="width:100%; height:100%;" border=0 cellpadding=0 cellspacing=0>
				<tr>
					<td id='top' valign="top">
						<table cellspacing=0 cellpadding=0  style=" height:100%; width:100%" background="images/header_bg.jpg" border=0>
							<tr height=56>
								<td width=260><img height=56 src="images/header_left.jpg" width="260"></td>
								<td style="font-weight: bold; color: #fff; padding-top: 20px" align="center">当前用户：<%=StrName %>&nbsp;&nbsp;<a style="color: #fff" href="pass.aspx" target=main>修改口令</a> &nbsp;&nbsp;<a style="color: #fff"  href="login.aspx" target=_top>退出系统</a>&nbsp;&nbsp;<a style="color: #fff"  href="../index.aspx" target="_blank" >首页</a> </td>
								<td align=right width=268 valign="top"><img height=56 src="images/header_right.jpg" width="268"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td style=" text-align:center; height:100%;" id='tdu' valign="top">
						<table style=" width:100%" cellpadding="0" cellspacing="0" border="0">
							<tr>
								<td align="center" valign="top" style="background:url(images/menu_bg.jpg) repeat; width:170px; height:100%; border-right:1px solid #aecff1;">
									<table width="150" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top:10px;" >
										<tr>
											<td style="text-align:center; background:url(images/menu_bt.jpg) no-repeat; height:32px;" >
											<a target="main" href="about.aspx">公司简介</a></td>
										</tr>
										<tr><td height="5"></td></tr>
										<tr>
											<td style="text-align:center; background:url(images/menu_bt.jpg) no-repeat; height:32px;">
											<a target="main" href="news.aspx">公司新闻</a></td>
										</tr>
										<tr><td height="5"></td></tr>
										<tr>
											<td style="text-align:center; background:url(images/menu_bt.jpg) no-repeat; height:32px;">
											<a target="main" href="product.aspx">园所装备</a></td>
										</tr>
										<tr><td height="5"></td></tr>
										<tr>
											<td style="text-align:center; background:url(images/menu_bt.jpg) no-repeat; height:32px;">
											<a target="main" href="principalBS.aspx">园长书库</a></td>
										</tr>
										<tr><td height="5"></td></tr>
										<tr>
											<td style="text-align:center; background:url(images/menu_bt.jpg) no-repeat; height:32px;">
											<a target="main" href="teacherBS.aspx">教师书库</a></td>
										</tr>
										<tr><td height="5"></td></tr>
										<tr>
											<td style="text-align:center; background:url(images/menu_bt.jpg) no-repeat; height:32px;">
											<a target="main" href="download.aspx">资料下载</a></td>
										</tr>
										<tr><td height="5"></td></tr>
										<tr>
											<td style="text-align:center; background:url(images/menu_bt.jpg) no-repeat; height:32px;">
											<a target="main" href="video.aspx">首页视频</a></td>
										</tr>
										<tr><td height="5"></td></tr>
										<tr>
											<td style="text-align:center; background:url(images/menu_bt.jpg) no-repeat; height:32px;">
											<a target="main" href="type.aspx">类型编辑</a></td>
										</tr>
									</table>
								</td>
								<td height="800" valign="top" style="background:#fff;">
									<iframe id="framemain" name='main' frameborder="0" src="about.aspx" style=" width:100%; height:100%;"></iframe>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
