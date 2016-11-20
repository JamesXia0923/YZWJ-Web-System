<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectpic.aspx.cs" Inherits="YouZhiWenJiao.Web.Manage.projectpic" %>

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
                <td bgcolor=#b1ceef height=1></td ></tr>
            <tr height=20>
                <td background=images/shadow_bg.jpg></td >
            </tr>
        </table>
                <table width='99%' cellpadding='1' cellspacing='1' align="center" style="margin-bottom:20px; background:#edf4fc; height:35px; border:1px solid #4293e6" border=0  >
                    <tr>
                     <td width='50px' align='center'  style=" white-space:normal">搜索条件：</td >    
                        <td style=' width:80px;'><input type='text' name='keyword' value='' id="txtserarch" runat="server" style='width:150px' /></td >                   
                        <td width="466" align="left"><input name="imageField" type="image" src="images/search.gif" width="45" height="20" border="0" class="np" /></td >
                       
                </tr>
              </table>
       <div style=" height:610px; overflow:auto;">
		 <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" id="table">
			<CONTROL:VIEWDATA id="rptDate" runat="Server" Select="false" Col="9" PageSize="10000" AllowPage="false"
				PageTrCss="PageTrCss" OnPageIndexChange="PageChanged" OnItemDataBound="DataBindings">
				<HEADERTEMPLATE>
                <tr>
                   <td colspan="6" style=" font-weight:bold;font-size:14px; text-align:left; color:#002779; height:37px;">&nbsp;&nbsp;动&nbsp;&nbsp;迁&nbsp;&nbsp;项&nbsp;&nbsp;目</td >
                 </tr>
                 <tr>
                    <th></th>
                   <th>序号</th>
                   <th>标题</th>                                    
                   <th>日期</th>
                                 
                 </tr>
				</HEADERTEMPLATE>
				<ITEMTEMPLATE>
					<tr align="center">
                    <td ><INPUT type=checkbox value='<%#DataBinder.Eval(Container.DataItem,"ID")%>' name=chkEleId></td >
						<td ><%# DataBinder.Eval(Container.DataItem,"Num")%></td >
						<td height="25" style=' text-align:center;'>
						<a  href='project_info.aspx?id=<%# DataBinder.Eval(Container.DataItem,"ID")%>'><%# DataBinder.Eval(Container.DataItem, "Name")%></a>
						</td >                     
						<td height="25"><%# DataBinder.Eval(Container.DataItem, "DateTime")%></td >						
					</tr>
				</ITEMTEMPLATE>
			</CONTROL:VIEWDATA>
		</table>
		</div>
        <table  border='0' cellpadding='1' cellspacing='1' align="center" style="margin-top:10px; width:99%; background:#edf4fc; height:35px;" >
                <tr>
                 <td colspan="6">&nbsp;&nbsp;     
                 <input type="button" value="删除" class="coolbg" runat="server" ID="BtnDel" NAME="BtnDel" onserverclick="SubDelClick">		                
                 <a target="_self" href='projectpic_info.aspx' class="coolbg" >新增</a>
                </tr>
              </table>


       	
    </form>
</body>
</html>
