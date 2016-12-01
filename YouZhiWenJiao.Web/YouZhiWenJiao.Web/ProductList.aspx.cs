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
	public partial class productlist : CommonPage
	{
		public int UniqueId = 0;
		protected CommonModel Product;
		protected CommonTypeModel ProductType;

		protected void Page_Load(object sender, EventArgs e)
		{
			ProductType = new CommonTypeModel();
			ProductType.id = Request["id"] != null ? ToInt(Request["id"]) : 0; ;
			ProductType.categoryid = Request["cid"] != null ? ToInt(Request["cid"]) : 0;

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
where (deleted <> 1 or deleted is null) and showinhomepage = 1 and typeid=@TypeId and categoryid=@CategoryId order by datetime desc";
			sqlCmd.Parameters.Add("@TypeId", DbType.Int16);
			sqlCmd.Parameters.Add("@CategoryId", DbType.Int16);
			sqlCmd.Parameters["@TypeId"].Value = ToInt(ProductType.id);
			sqlCmd.Parameters["@CategoryId"].Value = ProductType.categoryid;

			DataSet ds = new DataSet();
			SQLiteDataAdapter da = new SQLiteDataAdapter(sqlCmd);
			var dt = new DataTable();
			da.Fill(dt);

			for(int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
			{
				dt.Rows[rowIndex]["content"] = NoHtml(dt.Rows[rowIndex]["content"].ToString()).Substring(0, 100);
			}

			DataTable newData = new DataTable();
			newData.Columns.Add("id1",typeof(string));
			newData.Columns.Add("title1",typeof(string));
			newData.Columns.Add("content1",typeof(string));
			newData.Columns.Add("picture1",typeof(string));
			newData.Columns.Add("datetime1", typeof(string));
			newData.Columns.Add("id2",typeof(string));
			newData.Columns.Add("title2",typeof(string));
			newData.Columns.Add("content2",typeof(string));
			newData.Columns.Add("picture2",typeof(string));
			newData.Columns.Add("datetime2", typeof(string));
			newData.Columns.Add("id3",typeof(string));
			newData.Columns.Add("title3",typeof(string));
			newData.Columns.Add("content3",typeof(string));
			newData.Columns.Add("picture3", typeof(string));
			newData.Columns.Add("datetime3", typeof(string));

			DataRow dr = null;
			for(int rowIndex = 1; rowIndex <= dt.Rows.Count; rowIndex++)
			{
				if((rowIndex % 3) == 1)
				{
					dr = newData.NewRow();
					dr["id1"] = dt.Rows[rowIndex - 1]["id"];
					dr["title1"] = dt.Rows[rowIndex - 1]["title"];
					dr["content1"] = dt.Rows[rowIndex - 1]["content"];
					dr["picture1"] = dt.Rows[rowIndex - 1]["picture"];
					dr["datetime1"] = dt.Rows[rowIndex - 1]["datetime"];
				}
				if((rowIndex % 3) == 2)
				{
					dr["id2"] = dt.Rows[rowIndex - 1]["id"];
					dr["title2"] = dt.Rows[rowIndex - 1]["title"];
					dr["content2"] = dt.Rows[rowIndex - 1]["content"];
					dr["picture2"] = dt.Rows[rowIndex - 1]["picture"];
					dr["datetime2"] = dt.Rows[rowIndex - 1]["datetime"];
				}
				if((rowIndex % 3) == 0)
				{
					dr["id3"] = dt.Rows[rowIndex - 1]["id"];
					dr["title3"] = dt.Rows[rowIndex - 1]["title"];
					dr["content3"] = dt.Rows[rowIndex - 1]["content"];
					dr["picture3"] = dt.Rows[rowIndex - 1]["picture"];
					dr["datetime3"] = dt.Rows[rowIndex - 1]["datetime"];
					newData.Rows.Add(dr);
				}
				else
				{
					if(rowIndex == dt.Rows.Count)
					{
						newData.Rows.Add(dr);
					}
				}
			}


			//int iAllCount = newData.Rows.Count;
			//int iPageSize = rptDate.PageSize;
			//int iNum = iAllCount * 3 % iPageSize;

			rptDate.DataSource = newData.DefaultView;
			rptDate.DataBind();
			rptDate.ItemCount = dt.Rows.Count;
			if(newData.Rows.Count % rptDate.PageSize == 0)
				rptDate.PageCount = rptDate.ItemCount / 3 / rptDate.PageSize;
			else
				rptDate.PageCount = rptDate.ItemCount / 3 / rptDate.PageSize + 1;
		}

		protected void DataBindings(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			UniqueId++;
		}
	}
}
