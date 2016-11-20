using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class login : CommonPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Session["userid"] = null;
				Session["user"] = null;
			}
		}

		protected void btnLog_Click(object sender, ImageClickEventArgs e)
		{
			Session["user"] = txtName.Text;
			sqlCmd.CommandText = "select id from user where name=@name and password=@password";
			sqlCmd.Parameters.Add("@name", DbType.String, 20);
			sqlCmd.Parameters.Add("@password", DbType.String, 50);
			sqlCmd.Parameters["@name"].Value = Session["user"];
			sqlCmd.Parameters["@password"].Value = txtPass.Text;
			
			object Id = sqlCmd.ExecuteScalar();
			if (Id == null)
			{
				Prompt.Text = "用户名或密码不正确!";
				return;
			}
			Session["userid"] = Id.ToString();
			Response.Redirect("index.aspx");
		}
	}
}
