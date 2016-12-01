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
    public partial class productdetail : CommonPage
    {
        protected List<CommonModel> ProductList;
        protected CommonModel Product;
        protected string ProductType;
        protected string ModuleType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["id"] = null;
            }

            Product = new CommonModel();
            ProductList = new List<CommonModel>();
            Product.id = Request["id"] != null ? Request["id"].ToString() : "";

            //根据id查询出产品信息
            var queryProduct = "select * from product where id = @productId";
            sqlCmd.CommandText = queryProduct;
            sqlCmd.Parameters.Add("@productId", DbType.String);
            sqlCmd.Parameters["@productId"].Value = Product.id;
            IDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                Product.id = reader["id"].ToString();
                Product.categoryid = ToInt(reader["categoryid"]);
                Product.typeid = ToInt(reader["typeid"]);
                Product.title = reader["title"].ToString();
                Product.content = reader["content"].ToString();
                Product.picture = reader["picture"].ToString();
                Product.datetime = Convert.ToDateTime(reader["datetime"]).ToString("yyyy-MM-dd");
            }
            reader.Close();

            //根据此页面的产品，得到该类型下的所有产品
            var queryProductList = "select * from product where typeid = @typeId";
            sqlCmd.CommandText = queryProductList;
            sqlCmd.Parameters.Add("@typeId", DbType.Int16);
            sqlCmd.Parameters["@typeId"].Value = Product.typeid;
            reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                ProductList.AddRange(GenerateModel(reader));
            }
            reader.Close();

            //根据typeid 和 categoryid 得到类型的description
            var queryDescription = @"select t.description as productType, c.description as moduleType from type t, category c 
                                    where t.categoryid = c.id 
                                    and t.id=@typeId and t.categoryid = @categoryId";
            sqlCmd.CommandText = queryDescription;
            sqlCmd.Parameters.Add("@typeId", DbType.Int16);
            sqlCmd.Parameters.Add("@categoryId", DbType.Int16);
            sqlCmd.Parameters["@typeId"].Value = Product.typeid;
            sqlCmd.Parameters["@categoryId"].Value = Product.categoryid;
            reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                ProductType = reader["productType"].ToString();
                ModuleType = reader["moduleType"].ToString();
            }
            reader.Close();

        }
    }
}
