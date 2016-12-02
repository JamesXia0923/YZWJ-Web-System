using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class pass : CommonPage
	{
		string user = @"";
		protected void Page_Load(object sender, EventArgs e)
		{
			#region Session User
			if(Session["user"] == null)
			{
				Response.Redirect("login.aspx");
			}
			user = Session["user"].ToString();
			#endregion

			sqlCmd.Parameters.Add("@userid", DbType.String);
			sqlCmd.Parameters["@userid"].Value = Session["userid"];
			string script =
				@"<script type=""text/javascript"">
					function check() {
					if (document.getElementById(""" + NewPass.ClientID + @""").value != document.getElementById(""" + RetryPass.ClientID + @""").value) {
						alert(""确认密码和新密码不一致!"");
						return false;
					} else
						return true;
					}
				</script>";
			ClientScript.RegisterClientScriptBlock(GetType(), "check", script);
			BtnOK.OnClientClick = "javascript:return check();";
		}
		protected void Ok_Click(object sender, EventArgs e)
		{
			sqlCmd.CommandText = "select password from user where id=@userid";
			string oldpass = sqlCmd.ExecuteScalar().ToString();
			if(oldpass != OldPass.Text)
			{
				string script = @"<script type=""text/javascript"">alert(""输入的旧密码不正确!"");</script>";

				ClientScript.RegisterStartupScript(GetType(), "start", script);
			}
			else
			{
				if(NewPass.Text == RetryPass.Text)
				{
					sqlCmd.CommandText = 
@"update user
set 
password=@password,
updateuser=@updateuser,
updatedatetime='@updatedatetime'
where id=@userid";
					sqlCmd.Parameters.Add("@password", DbType.String, 20);
					sqlCmd.Parameters["@password"].Value = NewPass.Text;
					sqlCmd.Parameters.Add("@updateuser", DbType.String, 20);
					sqlCmd.Parameters["@updateuser"].Value = user;
					sqlCmd.CommandText = sqlCmd.CommandText.Replace("@datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"));

					sqlCmd.ExecuteNonQuery();
					Alert("修改成功");
				}
			}
		}
	}
}