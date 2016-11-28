﻿using System;
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
    public partial class index : CommonPage
    {
        protected List<CommonModel> downloadList;
        protected void Page_Load(object sender, EventArgs e)
        {
            var sql = "select * from product where showinhomepage = 1 and categoryid = " + ((int)category.资料下载).ToString() + "  limit 0,18;";
            sqlCmd.CommandText = sql;
            IDataReader reader = sqlCmd.ExecuteReader();
            downloadList = new List<CommonModel>();
            if (reader.Read())
            {
                var Product = new CommonModel();
                Product.id = reader["id"].ToString();
                Product.categoryid = ToInt(reader["categoryid"]);
                Product.typeid = ToInt(reader["typeid"]);
                Product.title = reader["title"].ToString();
                Product.picture = reader["video"].ToString();
                downloadList.Add(Product);
            }
            reader.Close();
        }
    }
}
