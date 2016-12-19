﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Data;
using YouZhiWenJiao.Web.Common;

namespace YouZhiWenJiao.Web
{
	public partial class index : CommonPage
	{
		protected List<CommonModel> downloadList;
		protected CommonModel myVideo;
        protected string client;

		protected void Page_Load(object sender, EventArgs e)
		{
			Session["UrlReferrer"] = "index.aspx";
			var sql = "select * from product where showinhomepage = 1 and categoryid = " + ((int)category.资料下载).ToString() + " and (deleted <> 1 or deleted is null) and showinhomepage = 1 limit 0,10;";
			sqlCmd.CommandText = sql;
			IDataReader reader = sqlCmd.ExecuteReader();
			downloadList = new List<CommonModel>();
			while(reader.Read())
			{
				var Product = new CommonModel();
				Product.id = reader["id"].ToString();
				Product.categoryid = ToInt(reader["categoryid"]);
				Product.typeid = ToInt(reader["typeid"]);
				Product.title = reader["title"].ToString();
				if(Session["duser"] == null)
				{
					Product.video = "login.aspx";
                    client = "login.aspx";
				}
				else
				{
					Product.video = reader["video"].ToString();
                    client = "video/优智点读笔客户端.rar";
				}
				downloadList.Add(Product);
			}
			reader.Close();


			sql = "select * from product where showinhomepage = 1 and categoryid = " + ((int)category.首页视频).ToString() + " and (deleted <> 1 or deleted is null) and showinhomepage = 1 order by datetime desc limit 0,1;";
			sqlCmd.CommandText = sql;
			reader = sqlCmd.ExecuteReader();
			myVideo = new CommonModel();
			if(reader.Read())
			{
				myVideo.id = reader["id"].ToString();
				myVideo.categoryid = ToInt(reader["categoryid"]);
				myVideo.typeid = ToInt(reader["typeid"]);
				myVideo.title = reader["title"].ToString();
				myVideo.picture = reader["picture"].ToString();
				myVideo.video = reader["video"].ToString();
			}
			else
			{
				myVideo.picture = "images/xc_video.jpg";
			}
			reader.Close();
		}
	}
}
