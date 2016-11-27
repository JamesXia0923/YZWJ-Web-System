﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="type_edit.aspx.cs" Inherits="YouZhiWenJiao.Web.Manage.type_edit" ValidateRequest="false"%>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<link href="css/admin.css" type="text/css" rel="stylesheet" />
	</head>
	<body  style=" background-color:#fff">
		<form id="form1" runat="server">
			<table cellspacing=0 cellpadding=0 width="100%" align=center border=0>
				<tr height=28>
					<td align="left" background="images/title_bg1.jpg">&nbsp;</td>
				</tr>
				<tr>
					<td bgcolor=#b1ceef height=1></td>
				</tr>
				<tr height=20>
					<td background="images/shadow_bg.jpg"></td>
				</tr>
			</table>

			<table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="tab3">
				<tr>
					<td align="center" colspan="2" style="font-size:15px;font-weight: bold;height:35px;width:100%; background:#edf4fc; color:black; border-right:1px solid #edf4fc; border-bottom:1px solid #edf4fc;" >
					类&nbsp;&nbsp;型&nbsp;&nbsp;编&nbsp;&nbsp;辑</td>
				</tr>
				
				<tr>
					<td width="80" align="center"  height="45">模块：</td>
					<td height="45" style=" padding:10px;" align="left">
					<asp:DropDownList Width="124px" ID="ddlListCategory" Enabled="true" runat="server"></asp:DropDownList></td>
				</tr>
				
				<tr>
					<td width="80" align="center"  height="45">类型：</td>
					<td height="45" style=" padding:10px;" align="left"><asp:TextBox id="txtType" runat="server" Width="332px"></asp:TextBox></td>
				</tr>
				
				<tr>
					<td height="60" colspan="2" align="left" valign="middle" style="border-bottom:none; padding-left:80px;">
						<asp:Button id="btnOK" OnClick="btnOK_Click" runat="server" text="确 定" class="coolbg"></asp:Button>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="btnBack" OnClick="btnBack_Click" runat="server" text="返回列表" class="coolbg"></asp:Button>
					</td>
				</tr>

			</table>

			<input id="txtcontent" type="hidden" name="txtcontent" runat="server">
		</form>
	</body>
</html>
