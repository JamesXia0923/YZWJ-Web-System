<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product_edit.aspx.cs" Inherits="YouZhiWenJiao.Web.Manage.product_edit" %>
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
					园&nbsp;&nbsp;所&nbsp;&nbsp;装&nbsp;&nbsp;备</td>
				</tr>
				<tr>
					<td width="80" align="center" >标题：</td>
					<td height="45" style=" padding:10px;" align="left"><asp:TextBox id="txtTitle" runat="server" Width="332px"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="center">日期：</td>
					<td style=" padding:10px;"><asp:Calendar id="datetime" runat="server" Width="100px"></asp:Calendar></td>
				</tr>
				
				<tr>
					<td  width="80" align="center"  height="45">类型：</td>
					<td width='45' style=" padding:10px;" align="left">
					<asp:DropDownList Width="124px" ID="ddlListType" runat="server" onblur="ddlList_change()"></asp:DropDownList></td>
				</tr>
				
				<tr>
					<td height="45" align="center">展示图片1</td>
					<td height="45" style=" padding:10px;" align="left">
						<input id="InputFile1" style="width: 399px" type="file" runat="server" />
						<asp:Label ID="Lb_Info1" runat="server" ForeColor="Red"></asp:Label>
					</td>
				</tr>
				
				<tr>
					<td height="45" align="center">展示图片2</td>
					<td height="45" style=" padding:10px;" align="left">
						<input id="InputFile2" style="width: 399px" type="file" runat="server" />
						<asp:Label ID="Lb_Info2" runat="server" ForeColor="Red"></asp:Label>
					</td>
				</tr>
				
				<tr>
					<td height="45" align="center">展示图片3</td>
					<td height="45" style=" padding:10px;" align="left">
						<input id="InputFile3" style="width: 399px" type="file" runat="server" />
						<asp:Label ID="Lb_Info3" runat="server" ForeColor="Red"></asp:Label>
					</td>
				</tr>
				
				<tr>
					<td align="center">内容</td><td valign="top" style=" padding:10px;">
						<FTB:FreeTextBox ID="ftbContent" HelperFilesPath="CQEdit"  BackColor="224,224,224" ToolbarType="office2003" GutterBackColor="224,224,224" ImageGalleryPath="/CQEdit/privateimage" HelperFilesParameters='PublicImageGalleryPath=/CQEdit/publicImage'  runat="server" Width="650" height="400" ToolbarLayout="FontFacesMenu,save,FontSizesMenu, FontForeColorsMenu, FontBackColorsMenu,justifyleft,JustifyCenter,justifyfull,justifyright,InsertImageFromGallery,inserttable,Bold, Italic, Underline, Strikethrough, Center,Superscript, Subscript, CreateLink, Unlink, Remove" ></FTB:FreeTextBox>
					</td>
				</tr>
				
				<tr>
					<td height="60" colspan="2" align="left" valign="middle" style="border-bottom:none; padding-left:80px;">
						<asp:Button id="btnOK" OnClick="btnOK_Click" runat="server" text="确 定" class="coolbg"></asp:Button>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="btnPreview" OnClick="btnPrewiew_Click" runat="server" text="预 览" class="coolbg"></asp:Button>
						<%--<a href="<%=href_value%> " target="_blank" class="coolbg">预览</a>--%>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<%--<a href="about.aspx" class="coolbg" >返回列表</a>--%>
						<asp:Button id="btnBack" OnClick="btnBack_Click" runat="server" text="返回列表" class="coolbg"></asp:Button>
					</td>
				</tr>

			</table>

			<input id="txtcontent" type="hidden" name="txtcontent" runat="server">
		</form>
	</body>
</html>
