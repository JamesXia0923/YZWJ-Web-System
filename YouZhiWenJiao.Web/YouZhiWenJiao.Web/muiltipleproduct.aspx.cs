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
    public partial class muiltipleproduct : CommonPage
    {
        protected List<CommonModel> ProductList;
        protected List<CommonTypeModel> ProductTypeList;

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductTypeList = new List<CommonTypeModel>();
            var sql = "select * from type where categoryid = 4 or 5";

            sqlCmd.CommandText = sql;
            IDataReader reader = sqlCmd.ExecuteReader();



        }
    }
}
