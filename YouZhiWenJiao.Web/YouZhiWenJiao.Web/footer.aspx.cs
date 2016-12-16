using System;
using System.Collections.Generic;
using YouZhiWenJiao.Web.Common;
using System.Data;

namespace YouZhiWenJiao.Web
{
    public partial class footer : CommonPage
	{
        protected List<CommonModel> ProductCollection;

		protected void Page_Load(object sender, EventArgs e)
		{
            var typeid = Request["typeid"] != null ? ToInt(Request["typeid"]) : -1;
            var categoryid = Request["categoryid"] != null ? ToInt(Request["categoryid"]) : -1;
            var sql = "select * from product ";

            if (categoryid < 0)
            {
                sql = sql + "where picture is not null and picture != '' ";
            }
            else
            {
                if (typeid < 0)
                {
                    sql = sql + "where picture is not null and picture != '' and categoryid = " + categoryid.ToString() + " ";
                }
                else
                {
                    sql = sql + "where picture is not null and picture != '' and categoryid = " + categoryid.ToString() + " and typeid = " + typeid.ToString() + " ";
                }
            }
            sql = sql + " and categoryid not in (" + (int)category.优智文教 + "," + (int)category.公司新闻 + "," + (int)category.首页视频 + "," + (int)category.资料下载 + ")";
			sql = sql + " and (deleted <> 1 or deleted is null) and showinhomepage = 1 order by datetime desc limit 0,15;";

            sqlCmd.CommandText = sql;
            ProductCollection = new List<CommonModel>();
            IDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                var product = new CommonModel();
                product.id = reader["id"].ToString();
                product.categoryid = ToInt(reader["categoryid"]);
                product.typeid = ToInt(reader["typeid"]);
                product.title = reader["title"].ToString();
                product.content = reader["content"].ToString();
                product.picture = reader["picture"].ToString();
                ProductCollection.Add(product);
            }
		}
	}
}
