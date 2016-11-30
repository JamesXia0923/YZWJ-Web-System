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
	public partial class producttypelist : CommonPage
	{
        protected List<CommonTypeModel> ProductTypeCollection;
        protected CommonTypeModel ProductType;
   
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Session["categoryid"] = null;
            }
            ProductTypeCollection = new List<CommonTypeModel>();
            ProductType = new CommonTypeModel();
            //ProductType.categoryid = ToInt(Session["categoryid"]);
            ProductType.categoryid = Request["id"] != null ? ToInt(Request["id"]) : 3;

            sqlCmd.CommandText = @"select * from type where categoryid = @CategoryId";
            sqlCmd.Parameters.Add("@CategoryId",DbType.Int16);
            sqlCmd.Parameters["@CategoryId"].Value = ProductType.categoryid;
            IDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                ProductTypeCollection.Add(new CommonTypeModel()
                    {
                        id = ToInt(reader["id"]),
                        categoryid = ToInt(reader["categoryid"]),
                        description = reader["description"].ToString()
                    });
            }
            reader.Close();

            sqlCmd.CommandText = @"select * from category where id = @CategoryId";
            sqlCmd.Parameters.Add("@CategoryId", DbType.Int16);
            sqlCmd.Parameters["@CategoryId"].Value = ProductType.categoryid;
            reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                ProductType.description = reader["description"].ToString();
            }
            reader.Close();
		}
	}
}
