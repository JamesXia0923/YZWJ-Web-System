using System;
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
	public partial class videos : CommonPage
	{
		public int UniqueId = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["duser"] == null)
			{
				Session["UrlReferrer"] = "videos.aspx";
				Response.Redirect("login.aspx");
			}

			PageChanged(null, null);
		}

		protected void PageChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			sqlCmd.CommandText = @"
select 
id,
title,
content,
video,
date(datetime) as datetime
from product
where (deleted <> 1 or deleted is null) and showinhomepage = 1 and categoryid = @CategoryId order by datetime desc";
			sqlCmd.Parameters.Add("@CategoryId", DbType.Int16);
			sqlCmd.Parameters["@CategoryId"].Value = (int)category.资料下载;

			DataSet ds = new DataSet();
			SQLiteDataAdapter da = new SQLiteDataAdapter(sqlCmd);
			var dt = new DataTable();
			da.Fill(dt);
			for(int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
			{
				var strContent = NoHtml(dt.Rows[rowIndex]["content"].ToString());
				dt.Rows[rowIndex]["content"] = strContent.Length > 200 ? strContent.Substring(0, 200) : strContent;
			}
			int iAllCount = dt.Rows.Count;
			int iPageSize = rptDate.PageSize;
			int iNum = iAllCount % iPageSize;
			rptDate.DataSource = dt.DefaultView;
			rptDate.DataBind();
		}
		protected void DataBindings(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			UniqueId++;
		}
	}
}
