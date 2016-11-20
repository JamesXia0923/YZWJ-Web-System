using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class index : System.Web.UI.Page
	{
		protected string StrName = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null)
			{
				Response.Redirect("login.aspx");
			}
			else
			{
				StrName = Session["user"].ToString();
			}
		}
	}
}
