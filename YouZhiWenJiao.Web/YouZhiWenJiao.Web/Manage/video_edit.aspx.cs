using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class video_edit : CommonPage
	{
		protected string productId = "";

		string user = @"";
		string imgUrl = @"";
		string imgPath = @"";
		string videoUrl = @"";
		string videoPath = @"";
		string href_string = @"../index.aspx";
		protected void Page_Load(object sender, EventArgs e)
		{
			#region Session User
			if (Session["user"] == null)
			{
				Response.Redirect("login.aspx");
			}
			user = Session["user"].ToString();
			#endregion

			productId = Request["id"] != null ? Request["id"].ToString() : "";

			if (productId != "")
			{
				sqlCmd.CommandText = "select title,datetime,picture,video from product where id='" + productId + "'";
				var dr = sqlCmd.ExecuteReader();
				if (dr.Read())
				{
					txtTitle.Text = dr[0].ToString();
					datetime.SelectedDate = DateTime.Parse(dr[1].ToString());
					imgPath = dr[2].ToString();
					videoPath = dr[3].ToString();
				}
				dr.Close();
			}
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			string uploadName = InputFile.Value;//获取待上传图片的完整路径，包括文件名  
			string pictureName = "";//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
			imgUrl = "";
			if (InputFile.Value != "")
			{
				int idx = uploadName.LastIndexOf(".");
				string suffix = uploadName.Substring(idx);//获得上传的图片的后缀名         

				pictureName = DateTime.Now.Ticks.ToString() + suffix;
				try
				{
					if (uploadName != "")
					{
						string AppUrl = "";
						if (Request.ApplicationPath == "/")
							AppUrl = Request.ApplicationPath;
						else
							AppUrl = Request.ApplicationPath + "/";
						string path = Server.MapPath(AppUrl + "img/" + pictureName);
						InputFile.PostedFile.SaveAs(path);
						imgUrl = AppUrl + "img/" + pictureName;
					}
				}
				catch (Exception ex)
				{
					Response.Write(ex);
				}
			}
			else
			{
				imgUrl = imgPath;
			}

			string uploadVideo = InputVideo.FileName;
			string videoName = "";

			videoUrl = "";
			if (InputVideo.FileName != "")
			{
				int idx = uploadVideo.LastIndexOf(".");
				string suffix = uploadVideo.Substring(idx);
				videoName = DateTime.Now.Ticks.ToString() + suffix;
				try
				{
					if (uploadVideo != "")
					{
						string AppUrl = "";
						if (Request.ApplicationPath == "/")
							AppUrl = Request.ApplicationPath;
						else
							AppUrl = Request.ApplicationPath + "/";
						string path = Server.MapPath(AppUrl + "video/" + videoName);
						InputVideo.PostedFile.SaveAs(path);
						videoUrl = AppUrl + "video/" + videoName;
					}
				}
				catch (Exception ex)
				{
					Response.Write(ex);
				}
			}
			else
			{
				videoUrl = videoPath;
			}

			if (productId != "")
			{
				sqlCmd.CommandText = @"
update product 
set 
title=@title,
datetime=@datetime,
picture=@picture,
video=@video,
updatedatetime=@updatedatetime,
updateuser=@updateuser
where id=@id;";
			}
			else
			{
				sqlCmd.CommandText = @"
insert into product(
id,
typeid,
categoryid,
title,
datetime,
picture,
video,
createdatetime,
createuser,
updatedatetime,
updateuser,
showinhomepage)
values(
@id,
@typeid,
@categoryid,
@title,
@datetime,
@picture,
@video,
@createdatetime,
@createuser,
@updatedatetime,
@updateuser,
1);";
			}

			productId = productId == "" ? Guid.NewGuid().ToString() : productId;
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@id", "'" + productId + "'");

			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@typeid", "'1'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@categoryid", "'" + ((int)category.首页视频).ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@title", "'" + txtTitle.Text + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@datetime", "'" + datetime.SelectedDate.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@picture", "'" + imgUrl.ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@video", "'" + videoUrl.ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@createdatetime", "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@createuser", "'" + user + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@updatedatetime", "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@updateuser", "'" + user + "'");
			sqlCmd.ExecuteNonQuery();

			Alert("保存成功!");
			Response.Redirect("video.aspx", false);
		}

		protected void btnPrewiew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(href_string, false);
		}

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("video.aspx", false);
		}
	}
}
