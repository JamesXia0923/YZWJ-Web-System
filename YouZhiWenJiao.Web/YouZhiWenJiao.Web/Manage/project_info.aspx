<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="project_info.aspx.cs"   validateRequest="false"  Inherits="YouZhiWenJiao.Web.Manage.project_info" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<%@ Register TagPrefix="cc1" Namespace="SailingWebControl" Assembly="SailingWebControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="css/admin.css" type="text/css" rel="stylesheet" />
    <script>
        /*第一种形式 第二种形式 更换显示样式*/
        function setTab(name, cursel, n) {
            for (i = 1; i <= n; i++) {
                var menu = document.getElementById(name + i);
                var con = document.getElementById("con_" + name + "_" + i);
                menu.className = i == cursel ? "hover" : "";
                con.style.display = i == cursel ? "block" : "none";
            }
        }
//-->
</script>
<style>
    a{ cursor:pointer;}
   .tab{ border-left:1px solid #bbb; width:814px;}
   .tab th{ border-bottom:1px solid #bbb;border-right:1px solid #bbb;border-top:1px solid #bbb;background:#f1f1f1; color:#999; height:30px; line-height:30px; font-size:12px;border-left:1px solid #bbb}
   .tab th.hover{ background:#fff;color:#43a0ff;font-weight:bold;border-bottom:1px solid #fff;border-right:1px solid #bbb;border-top:1px solid #bbb;border-left:1px solid #bbb}
   .tab th.cur{ background:#fff;color:#43a0ff;font-weight:bold;border-bottom:1px solid #fff;border-right:1px solid #bbb;border-top:1px solid #bbb;border-left:1px solid #bbb}
   .tab td { border-bottom:1px solid #bbb; border-right:1px solid #bbb;}
    .style1
    {
        height: 32px;
    }
</style>
</head>
<body  style=" background-color:#fff">
    <form id="form1" runat="server">
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
					<td align="center" colspan="2" style="font-size:15px;font-weight: bold;height:35px;width:100%; background:#edf4fc; color:black; border-right:1px solid #edf4fc; border-bottom:1px solid #edf4fc;" >添&nbsp;&nbsp;加&nbsp;&nbsp;项&nbsp;&nbsp;目&nbsp;&nbsp;信&nbsp;&nbsp;息</td>
				</tr>
				  
                <tr>
	                <td  width="80" height="45" align="center" >标题：</td>
	                <td height="45" style=" padding:10px;" align="left"><asp:TextBox id="txtName" runat="server" Width="332px"></asp:TextBox></td>
                </tr>
                <tr >
	                <td height="45" align="center">日期：</td>
	                <td height="45" style=" padding:10px;"><cc1:tq_calendar id="CreateDate" runat="server" Width="90px"></cc1:tq_calendar></td>
                </tr>
                
                <tr>
                <td align="center">项目信息：</td>
                <td>
                <table width="300px" cellpadding="0px" cellspacing="0" style="border:0; padding-left:10px" class="tab" id="Tab2">
                    <tr>
                    <th id="two1" class="cur" onclick="setTab('two',1,5)" style="height: 32px;"><a>基地概况</a></th>
                    <th id="two2" onclick="setTab('two',2,5)" class="style1"> <a>项目方案</a></th>
                    <th id="two3" onclick="setTab('two',3,5)" class="style1"> <a>基地概况图</a></th>
                    <th id="two4" onclick="setTab('two',4,5)" class="style1"> <a>项目进度</a></th>
                    <th id="two5" onclick="setTab('two',5,5)" class="style1"> <a>动迁项目</a></th>
                    <th  style=" background:#fff; border:0" class="style1">&nbsp;&nbsp;</th>
                    </tr>
                    <tr>
                    <td colspan="5" style="border:0">
                    <div>
                    <div id="con_two_1" style="padding-top:10px">
                        <FTB:FreeTextBox ID="FreeTextBox1" HelperFilesPath="CQEdit"  BackColor="224,224,224" ToolbarType="office2003" GutterBackColor="224,224,224" ImageGalleryPath="/CQEdit/privateimage" HelperFilesParameters='PublicImageGalleryPath=/CQEdit/publicImage'  runat="server" Width="650" height="400" ToolbarLayout="FontFacesMenu,save,FontSizesMenu, FontForeColorsMenu, FontBackColorsMenu,justifyleft,JustifyCenter,justifyfull,justifyright,InsertImageFromGallery,inserttable,Bold, Italic, Underline, Strikethrough, Center,Superscript, Subscript, CreateLink, Unlink, Remove" ></FTB:FreeTextBox>
                    </div>
                    <div id="con_two_2" style="padding-top:10px;display:none">
                        <FTB:FreeTextBox ID="FreeTextBox2" HelperFilesPath="CQEdit"  BackColor="224,224,224" ToolbarType="office2003" GutterBackColor="224,224,224" ImageGalleryPath="/CQEdit/privateimage" HelperFilesParameters='PublicImageGalleryPath=/CQEdit/publicImage'  runat="server" Width="650" height="400" ToolbarLayout="FontFacesMenu,save,FontSizesMenu, FontForeColorsMenu, FontBackColorsMenu,justifyleft,JustifyCenter,justifyfull,justifyright,InsertImageFromGallery,inserttable,Bold, Italic, Underline, Strikethrough, Center,Superscript, Subscript, CreateLink, Unlink, Remove" ></FTB:FreeTextBox>                    
                    </div>
                    <div id="con_two_3" style="padding-top:10px;display:none">
                        <FTB:FreeTextBox ID="FreeTextBox3" HelperFilesPath="CQEdit"  BackColor="224,224,224" ToolbarType="office2003" GutterBackColor="224,224,224" ImageGalleryPath="/CQEdit/privateimage" HelperFilesParameters='PublicImageGalleryPath=/CQEdit/publicImage'  runat="server" Width="650" height="400" ToolbarLayout="FontFacesMenu,save,FontSizesMenu, FontForeColorsMenu, FontBackColorsMenu,justifyleft,JustifyCenter,justifyfull,justifyright,InsertImageFromGallery,inserttable,Bold, Italic, Underline, Strikethrough, Center,Superscript, Subscript, CreateLink, Unlink, Remove" ></FTB:FreeTextBox>
                    </div>
                    <div id="con_two_4" style="padding-top:10px;display:none">
                        <asp:TextBox id="Progress" runat="server" Width="100px"></asp:TextBox>
                    </div>
                    <div id="con_two_5" style="padding-top:10px;display:none">
                        <a href="projectpic.aspx?id=<%=IntID %>" class="coolbg">编辑动迁项目</a>
                    </div>
                    </div>
                    </td>

                    </tr>
                </table>
                </td>
                </tr>
             
                <tr>
                  <td height="60" colspan="2" align="left" valign="middle" style="border-bottom:none; padding-left:80px;">
                  <asp:Button id="btnOK" OnClick="btnOK_Click" runat="server" Text="确 定" CssClass="coolbg"></asp:Button>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <a href="<%=href_value%> "  target="_blank" class="coolbg" >预览</a>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <a href="project.aspx" class="coolbg" >返回列表</a></td>
                </tr>

              </table>

        <input id="txtcontent" type="hidden" name="txtcontent" runat="server"/>
    </form>
</body>
</html>
