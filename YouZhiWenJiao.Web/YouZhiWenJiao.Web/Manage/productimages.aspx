<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productimages.aspx.cs" Inherits="YouZhiWenJiao.Web.Manage.productimages" %>
<%@ Register TagPrefix="Control" Namespace="YouZhiWenJiao.Web.Manage.css" Assembly="YouZhiWenJiao.Web" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<title></title>
		<link href="css/admin.css" rel="stylesheet" type="text/css" />
	</head>
	<body style=" background-color:#fff">
		<form id="form1" runat="server">
			<table cellspacing=0 cellpadding=0 width="100%" align=center border=0>
				<tr height=28>
					<td align="left" background=images/title_bg1.jpg>&nbsp;</td >
				</tr>
				<tr>
					<td bgcolor=#b1ceef height=1></td >
				</tr>
				<tr height=20>
					<td background=images/shadow_bg.jpg></td >
				</tr>
			</table>

			<div style=" height:610px; overflow:auto;">
				<table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" id="table">
					<tr>
						<td colspan="6" style=" font-weight:bold;font-size:14px; text-align:left; color:#002779; height:37px;">&nbsp;&nbsp;产&nbsp;&nbsp;品&nbsp;&nbsp;首&nbsp;&nbsp;页&nbsp;&nbsp;图</td >
					</tr>
					<tr>
						<th>产品类型</th>
						<th>展示图片</th>
						<th width="400">选择图片</th>
						<th width="200">替换</th>
					</tr>
					<tr align="center">
						<td>学前装备</td>
						<td><asp:Image ID="image" width="410" height="280" runat="server" AlternateText="Image text" ImageAlign="left" ImageUrl="../productimages/product1.jpg" /></td>
						<td><input id="InputFile1" style="width: 300px" type="file" runat="server" /><asp:Label ID="Lb_Info1" runat="server" ForeColor="Red"></asp:Label></td>
						<td><input type="button" value="替换" class="coolbg" runat="server" ID="BtnRep1" name="BtnDel" onserverclick="SubRepClick1" /></td>
					</tr>
					<tr align="center">
						<td>学习材料</td>
						<td><asp:Image ID="image1" width="410" height="140" runat="server" AlternateText="Image text" ImageAlign="left" ImageUrl="../productimages/product2.jpg"  /></td>
						<td><input id="InputFile2" style="width: 300px" type="file" runat="server" /><asp:Label ID="Lb_Info2" runat="server" ForeColor="Red"></asp:Label></td>
						<td><input type="button" value="替换" class="coolbg" runat="server" ID="BtnRep2" name="BtnDel" onserverclick="SubRepClick2" /></td>
					</tr>
					<tr align="center">
						<td>教学软件</td>
						<td><asp:Image ID="image2" width="200" height="130" runat="server" AlternateText="Image text" ImageAlign="left" ImageUrl="../productimages/product3.jpg"  /></td>
						<td><input id="InputFile3" style="width: 300px" type="file" runat="server" /><asp:Label ID="Lb_Info3" runat="server" ForeColor="Red"></asp:Label></td>
						<td><input type="button" value="替换" class="coolbg" runat="server" ID="BtnRep3" name="BtnDel" onserverclick="SubRepClick3" /></td>
					</tr>
					<tr align="center">
						<td>幼教书库</td>
						<td><asp:Image ID="image3" width="200" height="130" runat="server" AlternateText="Image text" ImageAlign="left" ImageUrl="../productimages/product4.jpg" /></td>
						<td><input id="InputFile4" style="width: 300px" type="file" runat="server" /><asp:Label ID="Lb_Info4" runat="server" ForeColor="Red"></asp:Label></td>
						<td><input type="button" value="替换" class="coolbg" runat="server" ID="BtnRep4" name="BtnDel" onserverclick="SubRepClick4" /></td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</html>
