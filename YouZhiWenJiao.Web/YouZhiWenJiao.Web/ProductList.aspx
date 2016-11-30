<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productlist.aspx.cs" Inherits="YouZhiWenJiao.Web.productlist" %>
<%@ Register TagPrefix="Control" Namespace="YouZhiWenJiao.Web.Manage.css" Assembly="YouZhiWenJiao.Web" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <!--<title>[!--pagetitle--] - [!--class.name--] - <?=$public_r[sitename]?></title>-->
    <title>上海优智文教</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta name="keywords" content="[!--pagekey--]" />
    <meta name="description" content="[!--pagedes--]" />
    <link href="css/master.css" type="text/css" rel="stylesheet" />
    <link href="css/base.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.SuperSlide.2.1.1.js"></script>

</head>
<body>
<form id="form1" runat="server">
    <!--图片列表页主体-->
    <div class="newsbox yh">
        <div class="block">
            <div class="pic_list">
                <ul class="clearfix">
                    <table class="talist_1">
						<CONTROL:VIEWDATA id="rptDate" runat="Server" Select="false" Col="3" PageSize="3" AllowPage="true" OnPageIndexChange="PageChanged"  OnItemDataBound="DataBindings">
							<ITEMTEMPLATE>
								<tr>
									<td style=" text-align:left;">
										<li class="clearfix">
											<div class="photo yh"><img src="<%# DataBinder.Eval(Container.DataItem, "picture")%>" style="height: 100%; width: 100%;" /><p><%# DataBinder.Eval(Container.DataItem, "title")%></p></div>
											<div class="rsp"></div>
											<div class="text">
												<a href="productdetail.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id")%>" target="_parent">
													<h3><%# DataBinder.Eval(Container.DataItem, "title")%></h3>
												<p style="overflow: hidden; text-overflow:ellipsis; white-space: nowrap;"><%# DataBinder.Eval(Container.DataItem, "content")%></p>
												<div>TIME :<%# DataBinder.Eval(Container.DataItem, "datetime")%></div>
												</a>
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
    <script src="js/all.js" type="text/javascript"></script>
</form>
</body>
</html>
