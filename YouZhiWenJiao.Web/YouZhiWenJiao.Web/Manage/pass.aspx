<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pass.aspx.cs" Inherits="YouZhiWenJiao.Web.Manage.pass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <link href="css/admin.css" type="text/css" rel="stylesheet" />
</head>
<body  style=" background-color:#fff">
    <form id="form1" runat="server">
    <div>

     <table cellspacing=0 cellpadding=0 width="100%" align=center border=0>
                  <tr height=28>
                       <td align="left" background=images/title_bg1.jpg>&nbsp;</td>
                  </tr>
                  <tr>
                       <td bgcolor=#b1ceef height=1></td></tr>
                  <tr height=20>
                       <td background=images/shadow_bg.jpg></td>
                 </tr>
              </table>

       <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="tab3">
              
               
<tr>
<td height="45" style=" padding:10px; width:80px;" align="left">旧口令:</td>
	<td align="left"><asp:TextBox id="OldPass" runat="server" Width="120px" TextMode="Password"></asp:TextBox></td>
</tr>
<tr><td height="45" style=" padding:10px;" align="left">新 口 令:</td>
	<td align="left"><asp:TextBox id="NewPass" runat="server" Width="120px" TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
	<td height="45" style=" padding:10px;" align="left">确认口令:</td>
	<td align="left"><asp:TextBox id="RetryPass" runat="server" Width="120px" TextMode="Password"></asp:TextBox></td>
</tr>
<tr><td colspan="2"></td></tr>

             
                <tr>
                  <td height="60" colspan="2" align="left" valign="middle" style="border-bottom:none; padding-left:80px;">
                  <asp:Button ID="BtnOK" runat="server" Text="修改"  CssClass="coolbg" OnClick="Ok_Click" />
                </tr>

              </table>




    </div>
    </form>
</body>
</html>
