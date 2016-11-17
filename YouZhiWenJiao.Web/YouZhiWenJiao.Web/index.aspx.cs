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
            //var path = System.Environment.CurrentDirectory;
            SQLiteConnection connection = new SQLiteConnection(@"Data Source=.\YouZhiWenJiao.Web\YouZhiWenJiao.Web\Database\sqlite.db;Version=3;");
            var sql = "select * from jaffer";
            var dt = SQLiteHelper.ExecuteDataSet(connection, sql, null);
        }
    }
}
