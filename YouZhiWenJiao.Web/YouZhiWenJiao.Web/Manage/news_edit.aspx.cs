using System;
using System.Data.SqlClient;
using System.Data;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class news_edit : CommonPage
	{
		protected int intID = 0;

		string imgURL = @"";
		string href_string = @"../news.aspx?";
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
				if (intID > 0)
				{
					sqlCmd.CommandText = "select title,content,datetime from product where Id=@id";
					sqlCmd.Parameters.Add("@id", DbType.Int16);
					sqlCmd.Parameters["@id"].Value = intID;
					var dr = sqlCmd.ExecuteReader();
					if (dr.Read())
					{
						txtName.Text = dr[0].ToString();
						ftbContent.Text = dr[1].ToString();
						datetime.DValue = dr[2];
					}
					dr.Close();
				}
			}
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			if (intID > 0)
			{
				sqlCmd.CommandText = "update AboutUS set Content=@content,Datetime=@date,title=@title where Id=@id";
			}
			else
			{
				sqlCmd.CommandText =
					"insert into product (typeid,categoryid,title,datetime,content,createdatetime,createuser,updatedatetime,updateuser)values(@ypeid,@categoryid,@title,@datetime,@content,@createdatetime,@createuser,@updatedatetime,@updateuser)";
			}

			sqlCmd.Parameters.Add("@content", DbType.String);
			sqlCmd.Parameters["@content"].Value = ftbContent.Text;
			sqlCmd.Parameters.Add("@date", DbType.DateTime);
			sqlCmd.Parameters["@date"].Value = datetime.DValue;
			sqlCmd.Parameters.Add("@title", DbType.String);
			sqlCmd.Parameters["@title"].Value = txtName.Text;
			sqlCmd.Parameters.Add("@id", DbType.Int16);
			sqlCmd.Parameters["@id"].Value = intID;
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
