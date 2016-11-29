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
					//ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
					ViewState["UrlReferrer"] = Request.CurrentExecutionFilePath;
				}
			}
		}

		protected void loginClick(object sender, EventArgs e)
		{
			HttpCookie cookie = Request.Cookies["CheckCode"];
			if (cookie.Value != txtYzm.Value)
			{
				Alert("验证码填写不正确");
				return;
			}

			if (true)
			{
				Session["user"] = txtLoginName.Value;
			}
			else
			{
				Alert("您好，您不属于本区域居民，没有权限访问。谢谢！");
				return;
			}

			if (ViewState["UrlReferrer"] == null)
			{
				Response.Redirect("index.aspx");
			}
			else
			{
				Response.Redirect(Page.Session["UrlReferrer"].ToString());
			}
		}
	}
}
