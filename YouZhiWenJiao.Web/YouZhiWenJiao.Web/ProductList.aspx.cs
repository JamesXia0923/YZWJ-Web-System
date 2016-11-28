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
	public partial class productlist : CommonPage
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
            ProductType.id = Request["id"] != null ? ToInt(Request["id"]) : 0; ;
            ProductType.categoryid = Request["cid"] != null ? ToInt(Request["cid"]) : 0;

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
		}

        protected void ViewProductDetail(object sender, EventArgs e)
        {
            Response.Redirect("http://www.baidu.com");
        }
	}
}
