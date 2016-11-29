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
    public partial class newsdetail : CommonPage
    {
        protected CommonModel CorporateNewsDetails;
        protected CommonTypeModel CorporateNewsType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["id"] = null;
            }
            CorporateNewsDetails = new CommonModel();
            CorporateNewsType = new CommonTypeModel();

            CorporateNewsDetails.id = Request["id"] != null ? Request["id"].ToString() : "";

            //根据id查询出新闻内容
            sqlCmd.CommandText = @"select * from product where id = @DetailId";
            sqlCmd.Parameters.Add("@DetailId", DbType.String);
            sqlCmd.Parameters["@DetailId"].Value = CorporateNewsDetails.id;
            IDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                CorporateNewsDetails = GenerateModel(reader)[0];
            }
            reader.Close();

            //查询出category
            sqlCmd.CommandText = @"select * from category where id = @CategoryId";
            sqlCmd.Parameters.Add("@CategoryId", DbType.Int16);
            sqlCmd.Parameters["@CategoryId"].Value = ToInt(CorporateNewsDetails.categoryid);
            reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                CorporateNewsType.description = reader["description"].ToString();
            }
            reader.Close();
        }
    }
}
