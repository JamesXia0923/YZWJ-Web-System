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
	public partial class news : CommonPage
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
            CorporateNewsType.categoryid = Request["id"] != null ? ToInt(Request["id"]) : 0;

            //根据categoryid查询出description
            sqlCmd.CommandText = @"select * from category where id = @CategoryId";
            sqlCmd.Parameters.Add("@CategoryId",DbType.Int16);
            sqlCmd.Parameters["@CategoryId"].Value = ToInt(CorporateNewsType.categoryid);
            IDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                CorporateNewsType.description = reader["description"].ToString();
            }
            reader.Close();

            //查询出新闻列表
            sqlCmd.CommandText = @"select * from product p                                   
                                   where p.categoryid = @CategoryId 
                                   order by datetime desc";
            sqlCmd.Parameters.Add("@CategoryId", DbType.Int16);
            sqlCmd.Parameters["@CategoryId"].Value = ToInt(CorporateNewsType.categoryid);
            reader = sqlCmd.ExecuteReader();
            while(reader.Read())
            {
                CorporateNewsList.AddRange(GenerateModel(reader));
            }
            reader.Close();
            foreach (var corporateNews in CorporateNewsList)
            {
                if (corporateNews.content.Length == 0)
                {
                    corporateNews.content = corporateNews.content.Substring(0, 100);
                }
            }
		}
	}
}
