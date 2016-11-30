using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Data;
using YouZhiWenJiao.Web.Common;

namespace YouZhiWenJiao.Web
{
	public partial class profile : CommonPage
	{
		protected List<CommonModel> CompanyProfileList;
		protected List<CommonTypeModel> CompanyProfileTypeList;

		protected void Page_Load(object sender, EventArgs e)
		{
			CompanyProfileTypeList = new List<CommonTypeModel>();
			var sql = "select * from type where categoryid = " + (int)category.公司简介 + " order by id";

			sqlCmd.CommandText = sql;
			IDataReader rdr = sqlCmd.ExecuteReader();

			while(rdr.Read())
			{
				CompanyProfileTypeList.Add(new CommonTypeModel() { id = ToInt(rdr["id"]), categoryid = ToInt(rdr["categoryid"]), description = rdr["description"].ToString() });
			}
			rdr.Close();

			CompanyProfileList = new List<CommonModel>();
			foreach(var cpt in CompanyProfileTypeList)
			{
				sql = "select * from product where categoryid = " + (int)category.公司简介 + " and typeid = " + cpt.id + " and (deleted <> 1 or deleted is null) and showinhomepage = 1 order by datetime desc limit 0,1;";
				sqlCmd.CommandText = sql;
				rdr = sqlCmd.ExecuteReader();

				while(rdr.Read())
				{
					CompanyProfileList.Add(new CommonModel() { id = rdr["id"].ToString(), typeid = ToInt(rdr["typeid"]), title = rdr["title"].ToString(), content = rdr["content"].ToString() });
				}
				rdr.Close();
			}
		}
	}
}
