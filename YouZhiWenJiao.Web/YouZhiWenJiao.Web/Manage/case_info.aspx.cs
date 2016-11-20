using System;
using System.Data.SqlClient;
using System.Data;

namespace YouZhiWenJiao.Web.Manage
{
    public partial class case_info : CommonPage
    {
        int IntID = 0;

        string imgURL = @"";
        string href_string = @"../infor.aspx?";
        protected string href_value = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            IntID = ToInt(Request["ID"]);

            href_value = href_string + "id=" + IntID + "04";

            if (!IsPostBack)
            {
                sqlCmd.CommandText = "SELECT AnalysisType FROM dbo.AnalysisType";
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                    ddlList.AddItem(dr[0].ToString());
                dr.Close();

                if (IntID > 0)
                {
                    sqlCmd.CommandText = @"select content,title,Datetime,AnalysisType from Analysis
                                           inner join AnalysisType on AnalysisType.Id = isnull(TypeId,1) where Analysis.id=@id";
                    sqlCmd.Parameters.Add("@id", SqlDbType.Int);
                    sqlCmd.Parameters["@id"].Value = IntID;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.Read())
                    {
                        FreeTextBox1.Text = dr[0].ToString();
                        txtName.Text = dr[1].ToString();
                        CreateDate.DValue = dr[2];
                        ddlList.Value = dr["AnalysisType"].ToString();
                    }
                    dr.Close();
                }
            }
        }

        string get_id(string typeName)
        {
            sqlCmd.CommandText = @"select id  from AnalysisType where analysisType='" + typeName + "' ";
            SqlDataAdapter ad = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable ts = ds.Tables[0];

            if (ts.Rows.Count > 0)
            {
                return ts.Rows[0][0].ToString();
            }
            else
            {

                sqlCmd.Parameters.Add("@typeName", SqlDbType.NVarChar, 50);
                sqlCmd.Parameters["@typeName"].Value = typeName;
                sqlCmd.CommandText = @"insert into AnalysisType (AnalysisType) values(@typeName)";
                sqlCmd.ExecuteNonQuery();
                sqlCmd.CommandText = "select @@IDENTITY";
                return sqlCmd.ExecuteScalar().ToString();
            }
        }

        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            int lx_id = ToInt(get_id(ddlList.Value), 0);
            if (IntID > 0)
            {
                sqlCmd.CommandText = "update Analysis set content=@content,Datetime=@date,title=@title,TypeId=@type where id=@id";
            }
            else
            {
                sqlCmd.CommandText = "insert into Analysis (content,Datetime,title,Typeid)values(@content,@date,@title,@type)";
            }


            sqlCmd.Parameters.Add("@content", SqlDbType.NText);
            sqlCmd.Parameters["@content"].Value = FreeTextBox1.Text;
            sqlCmd.Parameters.Add("@date", SqlDbType.DateTime);
            sqlCmd.Parameters["@date"].Value = CreateDate.DValue;
            sqlCmd.Parameters.Add("@title", SqlDbType.NVarChar);
            sqlCmd.Parameters["@title"].Value = txtName.Text;
            sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar);
            sqlCmd.Parameters["@type"].Value = lx_id;

            sqlCmd.Parameters.Add("@id", SqlDbType.Int);
            sqlCmd.Parameters["@id"].Value = IntID;
            sqlCmd.ExecuteNonQuery();
            if (IntID == 0)
            {

                sqlCmd.CommandText = "select @@IDENTITY";
                IntID = ToInt(sqlCmd.ExecuteScalar());
            }
            href_value = href_string + "id=" + IntID + "04";
            Alert("保存成功!");
        }
    }
}
