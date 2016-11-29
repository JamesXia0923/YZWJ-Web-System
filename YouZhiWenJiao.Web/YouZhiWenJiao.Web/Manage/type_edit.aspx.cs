using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class type_edit : CommonPage
	{
		protected string productId = "";
		protected string[] ids = null;
		private string categorylist = ((int)category.公司简介).ToString() + ',' + ((int)category.公司新闻).ToString() + ',' + ((int)category.教师书库).ToString() + ',' + ((int)category.园所装备).ToString() + ',' + ((int)category.园长书库).ToString() + ',' + ((int)category.资料下载).ToString();

		string user = @"";
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
			ids = productId.Split('|');

			if (!IsPostBack)
			{
				sqlCmd.CommandText = @"
select id, description 
from category 
where id in (" + categorylist + ");";
				var rd = sqlCmd.ExecuteReader();
				while (rd.Read())
				{
					ddlListCategory.Items.Add(new ListItem(rd[1].ToString(), rd[0].ToString()));
				}
				rd.Close();

				if (productId != "")
				{
					ddlListCategory.Enabled = false;

					sqlCmd.CommandText = @"
select 
categoryid,
type.description as typedescription
from
type
left join category on categoryid = category.id
where type.id = " + ids[0] + " and categoryid = " + ids[1] + ";";
					var dr = sqlCmd.ExecuteReader();
					if (dr.Read())
					{
						ddlListCategory.SelectedValue = dr[0].ToString();
						txtType.Text = dr[1].ToString();
					}
					dr.Close();
				}
			}
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			if (productId != "")
			{
				sqlCmd.CommandText = @"
update type 
set 
description=@description,
updatedatetime=@updatedatetime,
updateuser=@updateuser
where type.id = " + ids[0] + " and categoryid = " + ids[1] + ";";
			}
			else
			{
				sqlCmd.CommandText = "select max(id) from type where categoryid = " + "'" + ddlListCategory.SelectedValue + "';";
				productId = (ToInt(sqlCmd.ExecuteScalar()) + 1).ToString();

				sqlCmd.CommandText = @"
insert into type(
id,
categoryid,
description,
createdatetime,
createuser,
updatedatetime,
updateuser)
values(
@id,
@categoryid,
@description,
@createdatetime,
@createuser,
@updatedatetime,
@updateuser);";
			}

			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@id", "'" + productId + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@categoryid", "'" + ddlListCategory.SelectedValue + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@description", "'" + txtType.Text + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@createdatetime", "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@createuser", "'" + user + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@updatedatetime", "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@updateuser", "'" + user + "'");
			sqlCmd.ExecuteNonQuery();
			Alert("保存成功!");
			Response.Redirect("type.aspx", false);
		}

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("type.aspx", false);
		}
	}
}
