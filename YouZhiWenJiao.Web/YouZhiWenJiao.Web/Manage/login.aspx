<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="YouZhiWenJiao.Web.Manage.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>管理中心登陆</title>
<link href="css/admin.css" type="text/css" rel="stylesheet" /></head>
<body style='BACKGROUND-COLOR:#002779;'>
    <form name="form1" method="post" runat="server" action="login.aspx" id="form1">

    
   <table width="100%" border=0 align="center" cellpadding=0 cellspacing=0 style="margin-top:220px;">
 <tr>
           <td align=middle>
             <table cellspacing=0 cellpadding=0 width=468 border=0>
                <tr>
                    <td><img height=23 src="images/login_1.jpg" width=468></td></tr>
                    <tr><td><img height=147 src="images/login_2.jpg" width=468></td></tr>
            </table>
            <table cellspacing=0 cellpadding=0 width=468 bgcolor=#ffffff border=0>
                <tr>
                    <td width=16><img height=122 src="images/login_3.jpg" width=16></td>
          <td align=middle>
            <table width=230 border=0 align="center" cellpadding=0 cellspacing=0>
             
              <tr height=5>
                <td></td>
                <td width=56></td>
                <td></td></tr>
              <tr height=36>
                <td></td>
                <td>用户名</td>
                <td><asp:TextBox ID="txtName" runat="server" Text="管理员"  style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid" ></asp:TextBox>
                </td></tr>
              <tr height=36>
                <td>&nbsp; </td>
                <td>口　令</td>
                <td><asp:TextBox ID="txtPass" runat="server" TextMode="Password"  style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid" ></asp:TextBox></td></tr>
              <tr height=5>
                <td colspan=3></td></tr>
              <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                <asp:Label ID="Prompt" runat="server"></asp:Label>
                    <asp:ImageButton  ID="btnLog" Width="70" Height="18" runat="server" 
                        ImageUrl="images/bt_login.gif" onclick="btnLog_Click" />
                    </td>
                </tr>
            </table></td>
          <td width=16><img height=122 src="images/login_4.jpg" 
            width=16></td></tr>
             </table>
             <table cellspacing=0 cellpadding=0 width=468 border=0>
                <tr>
                    <td><img height=16 src="images/login_5.jpg" width=468></td>
                </tr>
            </table>   
           <%--  <TABLE cellSpacing=0 cellPadding=0 width=468 border=0>
        <TR>
          <TD align=right><A href="../index.aspx" target=_blank><IMG 
            height=26 src="images/login_6.gif" width=165 
            border=0></A></TD></TR></TABLE></TD></TR></TABLE>   
          </td>
      </tr>
    </table>--%>
    
    </form>
</body>
</html>