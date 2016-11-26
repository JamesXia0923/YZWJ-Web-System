using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class about_edit : CommonPage
	{
		protected string productId = "";

		string user = @"";
		string imgUrl= @"";
		string imgPath = @"";
		string href_string = @"../about.aspx?";
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

				sqlCmd.CommandText = sqlCmd.CommandText.Replace("@categotyid", "'" + ((int)category.公司简介).ToString() + "'");
				var rd = sqlCmd.ExecuteReader();
				while (rd.Read())
				{
					ddlListType.Items.Add(new ListItem(rd[1].ToString(), rd[0].ToString()));
				}
				rd.Close();

				if (productId != "")
				{
					sqlCmd.CommandText = "select title,content,datetime,picture,typeid from product where id='" + productId + "'";
					var dr = sqlCmd.ExecuteReader();
					if (dr.Read())
					{
						txtTitle.Text = dr[0].ToString();
						ftbContent.Text = dr[1].ToString();
						datetime.SelectedDate = DateTime.Parse(dr[2].ToString());
						imgPath = dr[3].ToString();
						ddlListType.SelectedValue = dr[4].ToString();
					}
					dr.Close();
				}
			}
			#endregion
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

			if (productId != "")
			{
				sqlCmd.CommandText = @"
update product 
set 
typeid=@typeid, 
title=@title,
content=@content,
datetime=@datetime,
picture=@picture,
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
content,
picture,
createdatetime,
createuser,
updatedatetime,
updateuser)
values(
@id,
@typeid,
@categoryid,
@title,
@datetime,
@content,
@picture,
@createdatetime,
@createuser,
@updatedatetime,
@updateuser);";
			}

			productId = productId == "" ? Guid.NewGuid().ToString() : productId;
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@id", "'" + productId + "'");

			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@typeid", "'" + ddlListType.SelectedIndex.ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@categoryid", "'" + ((int)category.公司简介).ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@title", "'" + txtTitle.Text + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@datetime", "'" + datetime.SelectedDate.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@content", "'" + ftbContent.Text + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@picture", "'" + imgUrl.ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@createdatetime", "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@createuser", "'" + user + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@updatedatetime", "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@updateuser", "'" + user + "'");
			sqlCmd.ExecuteNonQuery();

			href_value = href_string + "id=" + productId;
			Alert("保存成功!");
			Response.Redirect("about.aspx", false);
		}

		protected void btnPrewiew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(href_value, false);
		}

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("about.aspx", false);
		}
	}
}
