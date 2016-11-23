using System;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using YouZhiWenJiao.Web.Manage.Entity;
using System.Web.UI.WebControls;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class about : CommonPage
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
where type.categoryid = " + (int)category.公司简介 + ";";
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
product.id,
product.title,
product.datetime,
newtype.description,
case when product.showpicture=1 
then '<INPUT type=checkbox id=showPic checked value='+ product.Id +' name=chkEleIdShowPic>' 
else '<INPUT type=checkbox id=showPic value='+ product.Id +' name=chkEleIdShowPic>' end as showpicture,
case when product.showinhomepage=1 
then '<INPUT type=checkbox id=showInHomePage checked value='+ product.Id +' name=chkEleIdShowInHomePage>' 
else '<INPUT type=checkbox id=showInHomePage value='+ product.Id +' name=chkEleIdShowInHomePage>' end as showinhomepage
from product
left join
(select * from type left join category on category.id = type.categoryid where category.id = @categotyid) 
newtype on newtype.id = product.typeid
where product.title like '@search' ";

			if (!sqlCmd.Parameters.Contains("@categotyid"))
			{
				sqlCmd.Parameters.Add("@categotyid", DbType.Int16);
			}
			sqlCmd.Parameters["@categotyid"].Value = (int)category.公司简介;

			if (!sqlCmd.Parameters.Contains("@search"))
			{
				sqlCmd.Parameters.Add("@search", DbType.String);
			}
			sqlCmd.Parameters["@search"].Value = "%" + txtserarch.Value + "%";

			if (ddlList.SelectedValue != "0")
			{
				sqlCmd.CommandText += " and type.id=" + ddlList.SelectedValue + "";
			}
			sqlCmd.CommandText += " order by product.updatedatetime desc;";

			DataSet ds = new DataSet();
			SQLiteDataAdapter da = new SQLiteDataAdapter(sqlCmd);
			da.Fill(ds);
			DataTable dt = ds.Tables[0];
			Information info = new Information();

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				info.Number = (i + 1).ToString();
				info.ID = dt.Rows[i]["id"].ToString();
				info.Title = dt.Rows[i]["title"].ToString();
				info.DateTime = DateTime.Parse(dt.Rows[i]["Datetime"].ToString()).ToShortDateString();
				info.Type = dt.Rows[i]["description"].ToString();
				info.ShowPic = DateTime.Parse(dt.Rows[i]["showpicture"].ToString()).ToShortDateString();
				info.ShowInHomePage = DateTime.Parse(dt.Rows[i]["showinhomepage"].ToString()).ToShortDateString();
				li.Add(info);
			}

			return li;
		}

		protected void SubDelClick(object sender, System.EventArgs e)
		{
			string strDocumentSortIds = Request.Form["chkEleId"];
			if (strDocumentSortIds != "" && strDocumentSortIds != null)
			{
				sqlCmd.CommandText = "update product set delect = 1 where id in(" + strDocumentSortIds + ")";
				sqlCmd.ExecuteNonQuery();
				Alert("删除成功!");
				PageChanged(null, null);
			}
		}

		protected void SubCreClick(object sender, System.EventArgs e)
		{
			Response.Redirect("about_edit.aspx", false); 
		}

		protected void SubSaveClick(object sender, System.EventArgs e)
		{
			string showPicIdList = Request.Form["chkEleIdShowPic"];
			string showInHomePageIdList = Request.Form["chkEleIdShowInHomePage"];

			sqlCmd.CommandText = @"
update product set showpicture=0 
from product
inner join category on category.id = product.categoryid
inner join type on type.id = product.typeid
where product.categoryid = " + (int)category.公司简介 + ";";
			sqlCmd.ExecuteNonQuery();
			sqlCmd.CommandText = @"
update product set showinhomepage=0 
from product
inner join category on category.id = product.categoryid
inner join type on type.id = product.typeid
where product.categoryid = " + (int)category.公司简介 + ";";
			sqlCmd.ExecuteNonQuery();

			if (showPicIdList != null)
			{
				sqlCmd.CommandText = "update product set showpicture=1 where id in(" + showPicIdList + ")";
				sqlCmd.ExecuteNonQuery();
			}

			if (showInHomePageIdList != null)
			{
				sqlCmd.CommandText = "update product set showinhomepage=1 where id in(" + showInHomePageIdList + ")";
				sqlCmd.ExecuteNonQuery();
			}
			Alert("保存成功!");
			PageChanged(null, null);
		}
	}
}
