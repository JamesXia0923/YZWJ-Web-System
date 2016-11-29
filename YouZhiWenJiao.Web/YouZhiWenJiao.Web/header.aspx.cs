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

        protected void btnSearch_Click(object sender, System.EventArgs e)
		{
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var searchTxt = "search.aspx?wd=" + txtSearch.Text;
                Response.Write("<script>window.open('" + searchTxt + "','_parent')</script>");
            }
		}
	}
}
