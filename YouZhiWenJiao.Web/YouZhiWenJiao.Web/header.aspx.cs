using System;

namespace YouZhiWenJiao.Web
{
	public partial class header : CommonPage
	{
		public string value = "";
		public static int meauIndex = 0;
		public string search = "";

		protected void onclick(object sender, EventArgs e)
		{
			//Response.Redirect("xxxx.aspx?search=" + input_value.Value.Trim());
		}
	}
}
