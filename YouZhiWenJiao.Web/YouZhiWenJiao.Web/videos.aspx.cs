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

            DataTable newData = new DataTable();
            newData.Columns.Add("video1", typeof(string));
            newData.Columns.Add("title1", typeof(string));
            newData.Columns.Add("video2", typeof(string));
            newData.Columns.Add("title2", typeof(string));

            DataRow dr = null;
            for (int rowIndex = 1; rowIndex <= dt.Rows.Count; rowIndex++)
            {
                if ((rowIndex % 2) == 1)
                {
                    dr = newData.NewRow();
                    dr["video1"] = dt.Rows[rowIndex - 1]["video"];
                    dr["title1"] = dt.Rows[rowIndex - 1]["title"];
                }
                if ((rowIndex % 2) == 0)
                {
                    dr["video2"] = dt.Rows[rowIndex - 1]["video"];
                    dr["title2"] = dt.Rows[rowIndex - 1]["title"];
                    newData.Rows.Add(dr);
                }
                else
                {
                    if (rowIndex == dt.Rows.Count)
                    {
                        newData.Rows.Add(dr);
                    }
                }
            }

            rptDate.DataSource = newData.DefaultView;
            rptDate.DataBind();
            rptDate.ItemCount = dt.Rows.Count;
            if (newData.Rows.Count % rptDate.PageSize == 0)
                rptDate.PageCount = rptDate.ItemCount / 2 / rptDate.PageSize;
            else
                rptDate.PageCount = rptDate.ItemCount / 2 / rptDate.PageSize + 1;
		}
		protected void DataBindings(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			UniqueId++;
		}
	}
}
