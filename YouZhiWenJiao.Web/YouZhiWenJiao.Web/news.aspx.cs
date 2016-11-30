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
	public partial class news : CommonPage
	{
		public int UniqueId = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			PageChanged(null, null);
		}

		protected void PageChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			sqlCmd.CommandText = @"
select 
id,
title,
content,
picture,
date(datetime) as datetime
from product
where (product.deleted <> 1 or product.deleted is null) and showinhomepage = 1 and categoryid = @CategoryId order by datetime desc";
			sqlCmd.Parameters.Add("@CategoryId", DbType.Int16);
			sqlCmd.Parameters["@CategoryId"].Value = (int)category.公司新闻;

			DataSet ds = new DataSet();
			SQLiteDataAdapter da = new SQLiteDataAdapter(sqlCmd);
			var dt = new DataTable();
			da.Fill(dt);

			for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
			{
				dt.Rows[rowIndex]["content"] = NoHtml(dt.Rows[rowIndex]["content"].ToString()).Substring(0, 100);
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
