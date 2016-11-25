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
    public partial class CompanyProfile : CommonPage
    {
        protected List<CommonModel> CompanyProfileList;
        protected List<CommonTypeModel> CompanyProfileTypeList;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyProfileTypeList = new List<CommonTypeModel>();
            var sql = "select * from type where categoryid = 1";
            
            sqlCmd.CommandText = sql;
            IDataReader rdr = sqlCmd.ExecuteReader();

            while (rdr.Read())
            {
                CompanyProfileTypeList.Add(new CommonTypeModel() { id = ToInt(rdr["id"]), categoryid = ToInt(rdr["categoryid"]), description = rdr["description"].ToString() });
            }
            rdr.Close();

            CompanyProfileList = new List<CommonModel>();
            sql = "select * from product where categoryid = 1";
            sqlCmd.CommandText = sql;
            rdr = sqlCmd.ExecuteReader();

            while (rdr.Read())
            {
                CompanyProfileList.Add(new CommonModel() { id = rdr["id"].ToString(), typeid = ToInt(rdr["typeid"]), title = rdr["title"].ToString(), content = rdr["content"].ToString() });
            }
            rdr.Close();
        }        
    }
}
