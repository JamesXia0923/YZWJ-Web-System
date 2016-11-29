using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using YouZhiWenJiao.Web.Manage.Entity;
using System.Web.UI.WebControls;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class news : CommonPage
	{
		public int UniqueId = 0;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null)
			{
				Response.Redirect("login.aspx");
			}

			if (!this.IsPostBack)
			{
				string oldvar = ddlList.SelectedValue;
				ddlList.Items.Clear();
				ddlList.Items.Add(new ListItem("所有", "0"));
				sqlCmd.CommandText = @"
select 
type.id, 
type.description 
from type 
inner join category on category.id = type.categoryid 
where type.categoryid = " + (int)category.公司新闻 + " order by type.id";
				var rd = sqlCmd.ExecuteReader();
				while (rd.Read())
				{
					ddlList.Items.Add(new ListItem(rd[1].ToString(), rd[0].ToString()));
				}
				rd.Close();
				if (oldvar != "")
				{
					ddlList.SelectedValue = oldvar;
				}
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
product.id as id,
product.title as title,
product.datetime as datetime,
newtype.description as description
from product
inner join
(select type.id,type.categoryid,type.description from type left join category on category.id = type.categoryid where category.id = @categotyid) 
newtype on newtype.id = product.typeid and newtype.categoryid = product.categoryid
where (product.deleted <> 1 or product.deleted is null) and product.title like '@search' ";

			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@categotyid", "'" + ((int)category.公司新闻).ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@search", "%" + txtserarch.Value + "%");

			if (ddlList.SelectedValue != "0")
			{
				sqlCmd.CommandText += " and newtype.id=" + ddlList.SelectedValue + "";
			}
            sqlCmd.CommandText += " order by product.datetime desc;";

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
				info.DateTime = DateTime.Parse(dt.Rows[i]["datetime"].ToString()).ToShortDateString();
				info.Type = dt.Rows[i]["description"].ToString();
				li.Add(info);
			}

			return li;
		}

		protected void SubDelClick(object sender, System.EventArgs e)
		{
			string strDocumentSortIds = null;
			strDocumentSortIds = Request.Form["chkEleId"];
			strDocumentSortIds = strDocumentSortIds.Replace(",", "','");
			if (strDocumentSortIds != "" && strDocumentSortIds != null)
			{
				sqlCmd.CommandText = "update product set deleted = 1 where id in('" + strDocumentSortIds + "')";
				sqlCmd.ExecuteNonQuery();
				Alert("删除成功!");
				PageChanged(null, null);
			}
		}

		protected void SubCreClick(object sender, System.EventArgs e)
		{
			Response.Redirect("news_edit.aspx", false);
		}

		protected void SubSaveClick(object sender, System.EventArgs e)
		{
			string showInHomePageIdList = Request.Form["chkEleIdShowInHomePage"];

			showInHomePageIdList = showInHomePageIdList.Replace(",", "','");

			sqlCmd.CommandText = @"
update product set showinhomepage=0 
from product
inner join category on category.id = product.categoryid
where product.categoryid = " + (int)category.公司新闻 + ";";
			sqlCmd.ExecuteNonQuery();

			if (showInHomePageIdList != null)
			{
				sqlCmd.CommandText = "update product set showinhomepage=1 where id in(" + "'" + showInHomePageIdList + "'" + ")";
				sqlCmd.ExecuteNonQuery();
			}
			Alert("保存成功!");
			PageChanged(null, null);
		}
	}
}
