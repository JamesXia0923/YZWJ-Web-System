﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;

namespace YouZhiWenJiao.Web
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SQLiteConnection connection = new SQLiteConnection(string.Format(@"Data Source={0}\Database\sqlite.db;Version=3;", System.AppDomain.CurrentDomain.BaseDirectory));
            //var sql = "select * from jaffer";
            //var dt = SQLiteHelper.ExecuteDataSet(connection, sql, null);
        }
    }
}
