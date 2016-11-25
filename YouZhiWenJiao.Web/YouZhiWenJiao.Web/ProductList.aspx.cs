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
	public partial class ProductList : CommonPage
	{
        protected List<CommonModel> ProductCollection;
        protected CommonModel Product;
        protected CommonTypeModel ProductType;

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Session["id"] = null;
            }
            ProductCollection = new List<CommonModel>();
            ProductType = new CommonTypeModel();
            //ProductType.id = ToInt(Session["id"]);
            ProductType.id = 1;
            ProductType.categoryid = 3;

            //查询出该type下的所有产品
            sqlCmd.CommandText = @"select * from product where typeid=@TypeId and categoryid=@CategoryId";
            sqlCmd.Parameters.Add("@TypeId", DbType.Int16);
            sqlCmd.Parameters.Add("@CategoryId", DbType.Int16); 
            sqlCmd.Parameters["@TypeId"].Value = ToInt(ProductType.id);
            sqlCmd.Parameters["@CategoryId"].Value = ProductType.categoryid;
            IDataReader reader = sqlCmd.ExecuteReader();
            while(reader.Read())
            {
                ProductCollection.AddRange(GenerateModel(reader));
            }
            reader.Close();
            foreach (CommonModel product in ProductCollection)
            {
                product.content = product.content.Substring(0, 20);
            }
		}
	}
}
