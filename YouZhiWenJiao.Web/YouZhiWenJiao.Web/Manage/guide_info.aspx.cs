using System;
using System.Data.SqlClient;
using System.Data;

namespace YouZhiWenJiao.Web.Manage
{
    public partial class guide_info : CommonPage
    {
        int IntID = 0;

        string imgURL = @"";
        string href_string = @"../infor.aspx?";
        protected string href_value = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            IntID = ToInt(Request["ID"]);

            href_value = href_string + "id=" + IntID + "02";

            if (!IsPostBack)
            {
                if (IntID > 0)
                {
                    sqlCmd.CommandText = @"select content,title,Datetime from Guide where Guide.id=@id";
                    sqlCmd.Parameters.Add("@id", SqlDbType.Int);
                    sqlCmd.Parameters["@id"].Value = IntID;
                    SqlDataReader dr = sqlCmd.ExecuteReader();
                    if (dr.Read())
                    {
                        FreeTextBox1.Text = dr[0].ToString();
                        txtName.Text = dr[1].ToString();
                        CreateDate.DValue = dr[2];
                    }
                    dr.Close();
                }
            }
        }

        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            if (IntID > 0)
            {
                sqlCmd.CommandText = "update Guide set content=@content,Datetime=@date,title=@title where id=@id";
            }
            else
            {
                sqlCmd.CommandText = "insert into Guide (content,Datetime,title)values(@content,@date,@title)";
            }


            sqlCmd.Parameters.Add("@content", SqlDbType.NText);
            sqlCmd.Parameters["@content"].Value = FreeTextBox1.Text;
            sqlCmd.Parameters.Add("@date", SqlDbType.DateTime);
            sqlCmd.Parameters["@date"].Value = CreateDate.DValue;
            sqlCmd.Parameters.Add("@title", SqlDbType.NVarChar);
            sqlCmd.Parameters["@title"].Value = txtName.Text;

            sqlCmd.Parameters.Add("@id", SqlDbType.Int);
            sqlCmd.Parameters["@id"].Value = IntID;
            sqlCmd.ExecuteNonQuery();
            if (IntID == 0)
            {
                sqlCmd.CommandText = "select @@IDENTITY";
                IntID = ToInt(sqlCmd.ExecuteScalar());
            }
            href_value = href_string + "id=" + IntID + "02";
            Alert("保存成功!");
        }
    }
}
