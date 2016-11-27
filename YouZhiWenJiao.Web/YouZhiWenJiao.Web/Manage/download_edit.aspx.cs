using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class download_edit : CommonPage
	{
		protected string productId = @"";

		string user = @"";
		string videoUrl = @"";
		string videoPath = @"";
		string href_string = @"../download.aspx?";
		protected string href_value = "";
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
			href_value = href_string + "id=" + productId;

			#region Page refresh
			if (!IsPostBack)
			{
				sqlCmd.CommandText = @"
select type.id, type.description 
from type 
inner join category on category.id = type.categoryid
where categoryid = @categotyid";

				sqlCmd.CommandText = sqlCmd.CommandText.Replace("@categotyid", "'" + ((int)category.资料下载).ToString() + "'");
				var rd = sqlCmd.ExecuteReader();
				while (rd.Read())
				{
					ddlListType.Items.Add(new ListItem(rd[1].ToString(), rd[0].ToString()));
				}
				rd.Close();

				if (productId != "")
				{
					sqlCmd.CommandText = "select title,datetime,video,typeid from product where id=" + "'" + productId + "'";
					var dr = sqlCmd.ExecuteReader();
					if (dr.Read())
					{
						txtTitle.Text = dr[0].ToString();
						datetime.SelectedDate = DateTime.Parse(dr[1].ToString());
						videoPath = dr[2].ToString();
						ddlListType.SelectedValue = dr[3].ToString();
					}
					dr.Close();
				}
			}
			#endregion
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
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

			if (productId !="")
			{
				sqlCmd.CommandText = @"
update product 
set 
typeid=@typeid,
title=@title,
datetime=@datetime,
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
video,
createdatetime,
createuser,
updatedatetime,
updateuser,
showinhomepage
)
values(
@id,
@typeid,
@categoryid,
@title,
@datetime,
@video,
@createdatetime,
@createuser,
@updatedatetime,
@updateuser,
1);";
			}

			productId = productId == "" ? Guid.NewGuid().ToString() : productId;
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@id", "'" + productId + "'");

			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@typeid", "'" + ddlListType.SelectedValue.ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@categoryid", "'" + ((int)category.资料下载).ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@title", "'" + txtTitle.Text + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@datetime", "'" + datetime.SelectedDate.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@video", "'" + videoUrl + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@createdatetime", "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@createuser", "'" + user + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@updatedatetime", "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@updateuser", "'" + user + "'");
			sqlCmd.ExecuteNonQuery();

			href_value = href_string + "id=" + productId;
			Alert("保存成功!");
			Response.Redirect("download.aspx", false);
		}

		protected void btnPrewiew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(href_string, false);
		}

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("download.aspx", false);
		}
	}
}
