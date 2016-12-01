using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace YouZhiWenJiao.Web
{
	public partial class login : CommonPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Request.UrlReferrer != null)
				{
					ViewState["UrlReferrer"] = Request.CurrentExecutionFilePath;
				}
			}
		}

		protected void loginClick(object sender, EventArgs e)
		{
			if(txtLoginName.Value == "")
			{
				this.spanName.Visible = true;
				this.spanName.InnerText = "请输入用户名";
				return;
			}

			if(txtPassword.Value == "")
			{
				this.spanName.InnerText = "";
				this.spanPwd.Visible = true;
				this.spanPwd.InnerText = "请输入密码";
				return;
			}

			HttpCookie cookie = Request.Cookies["CheckCode"];
			if(cookie.Value != txtYzm.Value)
			{
				this.spanPwd.InnerText = "";
				this.spanYzm.Visible = true;
				this.spanYzm.InnerText = "验证码不正确";
				return;
			}

			sqlCmd.CommandText = @"select id from user where categoryid=@categoryId and name=@user and password=@password";
			sqlCmd.Parameters.Add("@categoryId", DbType.Int16);
			sqlCmd.Parameters.Add("@user", DbType.String);
			sqlCmd.Parameters.Add("@password", DbType.String);
			sqlCmd.Parameters["@categoryId"].Value = (int)category.系统用户;
			sqlCmd.Parameters["@user"].Value = txtLoginName.Value.ToString();
			sqlCmd.Parameters["@password"].Value = txtPassword.Value.ToString();
			int result = ToInt(sqlCmd.ExecuteScalar());

			if(result != 0)
			{
				Session["user"] = txtLoginName.Value;
			}
			else
			{
				//Alert("您好，您不属于本区域居民，没有权限访问。谢谢！");
				//return;
			}

			if (Session["UrlReferrer"] == null)
			{
				Response.Redirect("index.aspx");
			}
			else
			{
				Response.Redirect(Session["UrlReferrer"].ToString());
			}
		}
	}
}
