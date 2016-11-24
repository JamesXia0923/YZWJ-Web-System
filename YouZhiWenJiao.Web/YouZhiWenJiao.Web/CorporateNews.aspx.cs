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
	public partial class CorporateNews : CommonPage
	{
        protected List<CommonModel> CorporateNewsList;
        protected CommonTypeModel CorporateNewsType;
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Session["id"] = null;
            }
            CorporateNewsType = new CommonTypeModel();
            CorporateNewsList = new List<CommonModel>();
            CorporateNewsType.categoryid = ToInt(Session["id"]);

            //根据categoryid查询出description
            sqlCmd.CommandText = @"select * from category where id = @CategoryId";
            sqlCmd.Parameters["@CategoryId"].Value = ToInt(CorporateNewsType.categoryid);
            IDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                CorporateNewsType.description = reader["description"].ToString();
            }
            reader.Close();

            //查询出新闻列表
            sqlCmd.CommandText = @"select p.* from product p 
                                   inner join type t on t.id = p.typeid
                                   where p.categoryid = @CategoryId 
                                   order by datetime desc";
            sqlCmd.Parameters["@CategoryId"].Value = ToInt(CorporateNewsType.categoryid);
            reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                CorporateNewsList.Add(new CommonModel() { 
                    id = ToInt(reader["id"]),
                    typeid = ToInt(reader["typeid"]),
                    categoryid = ToInt(reader["categoryid"]),
                    title = reader["title"].ToString(),
                    content = reader["content"].ToString().Substring(0,100),
                    picture = reader["picture"].ToString(),
                    datetime = Convert.ToDateTime(reader["datetime"])
                });
            }
            reader.Close();
		}
	}
}
