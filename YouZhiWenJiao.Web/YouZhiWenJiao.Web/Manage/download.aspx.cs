using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using YouZhiWenJiao.Web.Manage.Entity;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class download : CommonPage
	{
		public int UniqueId = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null)
			{
				Response.Redirect("login.aspx");
			}
		}

		protected void PageChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			rptDate.DataSource = GetNewList();
			rptDate.DataBind();
		}

		protected void DataBindings(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			UniqueId++;
		}
		public IList GetNewList()
		{
			IList li = new ArrayList();

			sqlCmd.CommandText = @"
select 
id,
title,
datetime,
case when product.showinhomepage=1 
then '<INPUT type=checkbox id=showInHomePage checked value='+ product.Id +' name=chkEleIdShowInHomePage>' 
else '<INPUT type=checkbox id=showInHomePage value='+ product.Id +' name=chkEleIdShowInHomePage>' end as showinhomepage
from product 
where categoryid = @category and title like '@search' order by updatedatetime desc";

			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@category", "'" + ((int)category.资料下载).ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@search", "%" + txtserarch.Value + "%");

			DataSet ds = new DataSet();
			SQLiteDataAdapter da = new SQLiteDataAdapter(sqlCmd);
			da.Fill(ds);
			DataTable dt = ds.Tables[0];
			Information info = null;

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				info = new Information();
				info.Number = (i + 1).ToString();
				info.ID = dt.Rows[i]["id"].ToString();
				info.Title = dt.Rows[i]["title"].ToString();
				info.DateTime = DateTime.Parse(dt.Rows[i]["Datetime"].ToString()).ToShortDateString();
				info.ShowInHomePage = dt.Rows[i]["showinhomepage"].ToString();
				li.Add(info);
			}

			return li;
		}

		protected void SubDelClick(object sender, System.EventArgs e)
		{
			string showInHomePageIdList = Request.Form["chkEleIdShowInHomePage"];
			showInHomePageIdList = showInHomePageIdList.Replace(",", "','");

			sqlCmd.CommandText = @"
update product set showinhomepage=0 
from product
inner join category on category.id = product.categoryid
where product.categoryid = " + (int)category.资料下载 + ";";
			sqlCmd.ExecuteNonQuery();

			if (showInHomePageIdList != null)
			{
				sqlCmd.CommandText = "update product set showinhomepage=1 where id in(" + "'" + showInHomePageIdList + "'" + ")";
				sqlCmd.ExecuteNonQuery();
			}
			Alert("保存成功!");
			PageChanged(null, null);
		}

		protected void SubCreClick(object sender, System.EventArgs e)
		{
			Response.Redirect("download_edit.aspx", false);
		}
	}
}