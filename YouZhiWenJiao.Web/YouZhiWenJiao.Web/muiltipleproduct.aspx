<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="muiltipleproduct.aspx.cs" Inherits="YouZhiWenJiao.Web.muiltipleproduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8">
<title>上海优智文教</title>
<link href="css/master.css" type="text/css" rel="stylesheet" />
<link href="css/base.css" type="text/css" rel="stylesheet" />
<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
<link href="css/flexslider.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/jquery.SuperSlide.2.1.1.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<script src="js/imagezoom.js" type="text/javascript"></script>
</head>

<body>
<!--头部-->
    <div><iframe frameborder="0" scrolling="no" width="100%" height="405px" src="header.aspx"></iframe></div>
    <div class="block">
	    <div>
	        <div class="navmenu"><span>您现在的位置: <a href="#">户外用品</a> > 产品1</span> 产品1</div>
	        <div class="container">
	            <div class="products">
                    <div class="products-grids">
		                <div class="col-md-8 products-single">
		                    <div class="col-md-5 grid-single">		
		                        <div class="flexslider">
		                            <ul class="slides">
			                            <li data-thumb="images/pic1.jpg">
				                            <div class="thumb-image"> <img src="images/pic1.jpg" data-imagezoom="true" class="img-responsive" alt=""/> </div>
			                            </li>
			                            <li data-thumb="images/pic2.jpg">
				                             <div class="thumb-image"> <img src="images/pic2.jpg" data-imagezoom="true" class="img-responsive" alt=""/> </div>
			                            </li>
			                            <li data-thumb="images/pic3.jpg">
			                               <div class="thumb-image"> <img src="images/pic3.jpg" data-imagezoom="true" class="img-responsive" alt=""/> </div>
			                            </li> 
		                            </ul>
				                </div>
				                <!-- FlexSlider -->
				                <script src="js/imagezoom.js"></script>
				                <script defer src="js/jquery.flexslider.js"></script>
				                <script>
				                    // Can also be used with $(document).ready()
				                    $(window).load(function() {
				                        $('.flexslider').flexslider({
				                            animation: "slide",
				                            controlNav: "thumbnails"
				                        });
				                    });
				                </script>
		                    </div>	
			                <div class="col-md-7 single-text">
					            <div class="details-left-info simpleCart_shelfItem">
						            <h3>Accessories Latest</h3>
						            <p class="availability">Availability: <span class="color">In stock</span></p>
			                    </div>
	                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
<!--底部-->    
	<div><iframe frameborder="0" scrolling="no" width="100%" class="h390" src="footer.aspx"></iframe></div>
</body>
</html>
