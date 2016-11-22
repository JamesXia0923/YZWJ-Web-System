using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class about_info : CommonPage
	{
		protected int intID = 0;

		string imgURL = @"";
		string videoURL = @"";
		string href_string = @"../about.aspx?";
		protected string href_value = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null)
			{
				Response.Redirect("login.aspx");
			}

			intID = ToInt(Request["ID"]);

			href_value = href_string + "id=" + intID;

			if (!IsPostBack)
			{
				sqlCmd.CommandText = @"
		select type.id, type.description 
		from type 
		inner join category on category.id = type.categoryid
		where category.description = '公司简介';";
				var rd = sqlCmd.ExecuteReader();
				while (rd.Read())
				{
					ddlList.Items.Add(new ListItem(rd[1].ToString(), rd[0].ToString()));
				}
				rd.Close();

				if (intID > 0)
				{
					sqlCmd.CommandText = "select title,content,datetime,picture from product where Id=@id";
					sqlCmd.Parameters.Add("@id", DbType.Int16);
					sqlCmd.Parameters["@id"].Value = intID;
					var dr = sqlCmd.ExecuteReader();
					if (dr.Read())
					{
						txtName.Text = dr[0].ToString();
						ftbContent.Text = dr[1].ToString();
						datetime.DValue = dr[2];
						InputFile.Value = dr[3].ToString();
					}
					dr.Close();
				}
			}

			if (ToInt(ddlList.SelectedValue) == 1)
			{
				videoTr.Style.Add(HtmlTextWriterStyle.Display, "block");
			}
			else
			{
				videoTr.Style.Add(HtmlTextWriterStyle.Display, "none");
			}
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			string lx_id = ddlList.SelectedValue;

			string uploadName = InputFile.Value;//获取待上传图片的完整路径，包括文件名  
			//string uploadName = InputFile.PostedFile.FileName;         
			string pictureName = "";//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
			imgURL = "";
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
						imgURL = AppUrl + "img/" + pictureName;
					}
				}
				catch (Exception ex)
				{
					Response.Write(ex);
				}
			}

			//string uploadVideo = InputVideo.Value;
			//string videoName = "";

			//videoURL = "";
			//if (InputVideo.Value != "")
			//{
			//    int idx = uploadVideo.LastIndexOf(".");
			//    string suffix = uploadVideo.Substring(idx);
			//    videoName = DateTime.Now.Ticks.ToString() + suffix;
			//    try
			//    {
			//        if (uploadVideo != "")
			//        {
			//            string AppUrl = "";
			//            if (Request.ApplicationPath == "/")
			//                AppUrl = Request.ApplicationPath;
			//            else
			//                AppUrl = Request.ApplicationPath + "/";
			//            string path = Server.MapPath(AppUrl + "vedio/" + videoName);
			//            InputVideo.PostedFile.SaveAs(path);
			//            videoURL = AppUrl + "vedio/" + videoName;
			//        }
			//    }
			//    catch (Exception ex)
			//    {
			//        Response.Write(ex);
			//    }
			//}

			if (intID > 0)
			{
				sqlCmd.CommandText = @"
update product 
set 
title=@title,
content=@content,
datetime=@date,
picture=@picture,
updatedatetime=@updatedatetime
updateuser=@updateuser
where id=@id";
			}
			else
			{
				sqlCmd.CommandText =@"
insert into product (
typeid,
categoryid,
title,
datetime,
content,
picture
createdatetime,
createuser,
updatedatetime,
updateuser)
values(
@ypeid,
@categoryid,
@title,
@datetime,
@content,
@picture
@createdatetime,
@createuser,
@updatedatetime,
@updateuser)";
			}

			sqlCmd.Parameters.Add("@typeid", DbType.String);
			sqlCmd.Parameters["@typeid"].Value = ftbContent.Text;
			sqlCmd.Parameters.Add("@categoryid", DbType.DateTime);
			sqlCmd.Parameters["@categoryid"].Value = datetime.DValue;
			sqlCmd.Parameters.Add("@title", DbType.String);
			sqlCmd.Parameters["@title"].Value = txtName.Text;
			sqlCmd.Parameters.Add("@datetime", DbType.Int16);
			sqlCmd.Parameters["@datetime"].Value = intID;
			sqlCmd.Parameters.Add("@content", DbType.String);
			sqlCmd.Parameters["@content"].Value = ftbContent.Text;
			sqlCmd.Parameters.Add("@picture", DbType.DateTime);
			sqlCmd.Parameters["@picture"].Value = datetime.DValue;

			sqlCmd.Parameters.Add("@createdatetime", DbType.String);
			sqlCmd.Parameters["@createdatetime"].Value = txtName.Text;
			sqlCmd.Parameters.Add("@createuser", DbType.Int16);
			sqlCmd.Parameters["@createuser"].Value = intID;
			sqlCmd.Parameters.Add("@createdatetime", DbType.String);
			sqlCmd.Parameters["@createdatetime"].Value = txtName.Text;
			sqlCmd.Parameters.Add("@createuser", DbType.Int16);
			sqlCmd.Parameters["@createuser"].Value = intID;
			sqlCmd.ExecuteNonQuery();

			if (intID == 0)
			{
				sqlCmd.CommandText = "select @@IDENTITY";
				intID = ToInt(sqlCmd.ExecuteScalar());
			}
			href_value = href_string + "id=" + intID;
			Alert("保存成功!");
		}

		protected void btnPrewiew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("href_string", false);
		}

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("about.aspx", false);
		}
	}
}
