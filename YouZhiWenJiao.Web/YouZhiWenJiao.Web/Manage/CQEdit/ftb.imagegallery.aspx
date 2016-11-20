<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ftb.imagegallery.aspx.cs" Inherits="FreeTextBox1.CQEdit.ftbimagegallery" %>
<!doctype html public "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html>
<head>
   <META HTTP-EQUIV="Expires" CONTENT="0">
<title>插入图片</title>
<link rel="stylesheet" type="text/css" href="ImageGallery.css" />
<script language="javascript">
    lastDiv = null;

    //theDiv 当前对象  w 宽度  h 高度  m当前照片名称
    //filename[p] 表示点击的是向上  [d] 表示点击的是文件夹  其他表示的是服务器上照片名称
    //filePath 照片路径
    function divClick(theDiv, filename,filePath,w,h,m) {
        if (lastDiv) {
            lastDiv.style.border = "1 solid #CCCCCC";
        }
        lastDiv = theDiv;
        theDiv.style.border = "2 solid #316AC5";

        document.getElementById("FileToDelete").value = filename;
       
        ShowImg(filename,filePath,w,h,m);

    }

// 图片目录 公共目录 新的目录
    function gotoFolder(ImageGalleryPath,PublicImageGalleryPath, newfolder) {
      
    window.navigate("ftb.imagegallery.aspx?frame=1&rif=" + ImageGalleryPath + "&PublicImageGalleryPath=" + PublicImageGalleryPath + "&UpPath=" + newfolder);
}		
    
    //选择图片的返回事件
    function returnImage(imagename, width, height) {
        var arr = new Array();
       
        arr["filename"] = imagename;
        arr["width"] = width;
        arr["height"] = height;
        window.parent.returnValue = arr;
        window.parent.close();
    }


    function CheckFilename() {
        var fileName = document.getElementById("UploadFile").value;
      
        if (fileName == "") {

            alert("请选择上传图片!");
            return false;
           
        }
        if (!CheckFileExtension(fileName)) {
          
            alert("请选择正确的图片格式!");
            return false;
        }
       
        return true;
    }
    function CheckFileExtension(theValue) {
        var arrFileExtension = new Array("jpg", "jpeg", "dib", "bmp", "gif", "swf");
        var arrFile, strExtension, Pos;
        arrFile = theValue.split("\\");
        strExtension = arrFile[arrFile.length - 1];
        Pos = strExtension.indexOf(".");
        strExtension = strExtension.substring(Pos + 1, strExtension.length);
        for (var i = 0; i < arrFileExtension.length; i++) {
            if (strExtension.toLowerCase() == arrFileExtension[i])
                return true;
        }
        return false;
    }
    function ShowImg(obj, path,w,h,m) {
        
        if (obj == 'p') {
            document.getElementById("PreImg").src = '/images/ftb/folder.up.gif';
            document.getElementById('Message').innerHTML = "当前选择的是: 向上";
            document.getElementById("PreImg").alt = "向上";
        }
        else if (obj == 'd') {
        document.getElementById("PreImg").src = '/images/ftb/folder.big.gif';
        document.getElementById('Message').innerHTML = "当前选择的是: " + path
        document.getElementById("PreImg").alt = path;
        }
        else {
            document.getElementById("PreImg").src = path;
            document.getElementById('Message').innerHTML = "当前选择的是: " + m;
            document.getElementById("PreImg").alt = m;
        }
        document.getElementById("PreImg").width = w;
        document.getElementById("PreImg").height = h;
    }



    function ShowImg1(src) {
      //  document.getElementById("imgDiv").innerHTML = "<img id='imgObj' onerror='javascript:GetError();' onload='javascript:GetSize();' src='file:///" + src + "'>"; //onerror='javascript:GetError()'
        //alert(document.getElementById("imgObj").src);
        //document.getElementById("PreImg").src= src;
    }
    function GetSize() {
        var width, height;
        var imgObj = document.getElementById("imgObj");
        width = imgObj.width;
        height = imgObj.height;
        document.getElementById("err_msg").innerHTML = "图片大小(宽×高):<font color=red>" + width + "×" + height + "</font>";
        
        if (width > 94) {
            imgObj.width = 94;
            imgObj.height = imgObj.height * 94 / imgObj.width;
        } 
         
        if (height > 94) {
            imgObj.height = 94;
            imgObj.width = imgObj.width * 94 / imgObj.height;
        }
    }
    function GetError() {
       // document.getElementById("err_msg").innerHTML = "图片大小(宽×高):<font color=red>NaN</font>";
        document.getElementById("imgDiv").innerHTML = "";
       // document.getElementById("err_msg").innerHTML = "图片文件不存在或格式错误！"
    } 
</script>	
</head>

<body>

<form id="FORM1" enctype="multipart/form-data" runat="server">
<asp:panel id="MainPage" runat="server" visible="false">
    <table width="100%" height="100%" cellpadding=0 cellspacing=0 border=0>
        <tr>
            <td>
	            <div id="galleryarea" style="width:100%; height:100%; overflow: auto;">
		            <asp:label id="gallerymessage" runat="server"></asp:label>
		            <asp:panel id="GalleryPanel" runat="server"></asp:panel>
	            </div>
             </td>
        </tr>
        <asp:Panel id="UploadPanel" runat="server">
            <tr>
                <td height="80" style="padding-left:10px;border-top: 1 solid #999999; background-color:#99ccff;">
        	
	                <table>	                  
	                    <tr>
	                        <td style="width:180px; height:80px" align="center" valign="middle" class="imageholder"><img  src="/images/ftb/tmp.jpg" id="PreImg"  class="imagespacer" alt="preview" /></td>
		                    <td valign="top" align="right">
		                        <table>
		                            <tr>
		                                <td><input id="UploadFile" onpropertychange="CheckFilename(this.value);" type="file" name="UploadFile" runat="server"  style="width:300;"/></td>
		                            </tr>
		                             <tr>
		                                <td valign="top" align="left">		
		                                                       
		                                     上传<input type="checkbox" style=" background:#99ccff;" id="CkbSC" runat="server" />
			                                 <asp:button id="UploadImage" Text="上传" runat="server" onclick="UploadImage_OnClick" />
			                                 <asp:button id="DeleteImage" Text="删除" runat="server" onclick="DeleteImage_OnClick" />	
		                                </td>		
	                                 </tr>
	                                 <tr>
		                                 <td>			                   
			                                 <div id="Message"><asp:literal id="ResultsMessage" runat="server" /></div>
		                                 </td>		
	                                 </tr>
		                        </table>
		                    </td>
		                    <td style=" width:5px"/>		
	                    </tr>
	                   
	                    
	                </table>	
	                <input type="hidden" id="FileToDelete" value="" runat="server" />
	                <input type="hidden" id="RootImagesFolder" value="images" runat="server" />
	                <input type="hidden" id="CurrentImagesFolder" value="images" runat="server" />
                </td>
            </tr>
        </asp:Panel>
    </table>
    </asp:panel>
    <asp:panel id="iframePanel" runat="server" >
    	<iframe style="width:100%;height:100%;border:0;" border=0 frameborder=0 src="ftb.imagegallery.aspx?frame=1&<%=Request.QueryString%>"></iframe>
    </asp:panel>

    
</form>
</body>
</HTML>

