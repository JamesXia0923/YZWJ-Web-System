<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorporateProductDetail.aspx.cs" Inherits="YouZhiWenJiao.Web.CorporateProductDetail"%>

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
<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/jquery.SuperSlide.2.1.1.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<script src="js/imagezoom.js" type="text/javascript"></script>
</head>


<body>

<!--头部-->
<div><iframe frameborder="0" scrolling="no" width="100%" height="405px" src="header.aspx"></iframe></div>
<!--产品信息-->    
    <!--单个产品-->
    <div class="block">
        <div class="navmenu"><span>您现在的位置: <a href="#"><%=ModuleType %>></a> > <%=ProductType %>></span> <%=ProductType %>></div>
	    <div class="container">
	        <div class="products">
		        <div class="products-grids">
		    	    <div class="col-md-8 products-single">
			            <div class="col-md-5 grid-single">		
				            <div class="flexslider3">
					          <ul class="slides">
						        <li>
							        <div> <img src=<%=Product.picture %> data-imagezoom="true" class="img-responsive" alt=""/> </div>
					          </ul>
					        </div>
				        </div>	
			            <div class="col-md-7 single-text">
				            <div class="details-left-info simpleCart_shelfItem">
					            <h3><%=Product.title %></h3>
					            <p class="availability"><span class="color"><%=Product.content %></span></p>
		                    </div>
	                    </div>
	                </div>
                </div>
            </div>
        </div>
    </div>

<!--底部--> 
	<div><iframe frameborder="0" scrolling="no" width="100%" class="h390" src="footer.aspx"></iframe></div>   

<script src="js/all.js" type="text/javascript"></script>
</body>
</html>