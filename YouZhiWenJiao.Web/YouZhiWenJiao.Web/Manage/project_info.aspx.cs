using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace YouZhiWenJiao.Web.Manage
{
    public partial class project_info : CommonPage
    {
        protected int IntID = 0;

        string imgURL = @"";
        string href_string = @"../project.aspx?";
        protected string href_value = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            IntID = ToInt(Request["ID"]);

            href_value = href_string + "id=" + IntID;

            if (!IsPostBack)
            {
                if (IntID > 0)
                {
                    sqlCmd.CommandText = @"select title,Datetime,基地概况,基本方案,基地概况图,项目进度 as TypeName from Project where Project.Id=@id";
                    sqlCmd.Parameters.Add("@id", SqlDbType.Int);
                    sqlCmd.Parameters["@id"].Value = IntID;
                    SqlDataReader dr = sqlCmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtName.Text = dr[0].ToString();
                        CreateDate.DValue = dr[1];
                        FreeTextBox1.Text = dr[2].ToString();
                        FreeTextBox2.Text = dr[3].ToString();
                        FreeTextBox3.Text = dr[4].ToString();
                        Progress.Text = dr[5].ToString();
                    }
                    dr.Close();
                }
            }
        }

        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            if (IntID > 0)
            {
                if (imgURL != "")
                    sqlCmd.CommandText = @"update ProjectIntro set 基地概况=@content1,基本信息=@content2,基地概况图=@content3,项目进度=@content4,Datetime=@date,Title=@title,Picture=@cs13 where Id=@id";
                else
                    sqlCmd.CommandText = "update ProjectIntro set 基地概况=@content1,基本信息=@content2,基地概况图=@content3,项目进度=@content4,Datetime=@date,Title=@title where Id=@id";
            }
            else
            {
                if (imgURL != "")
                    sqlCmd.CommandText = "insert into ProjectIntro (基地概况,基本信息,基地概况图,项目进度,Datetime,Title,Picture)values(@content1,@content2,@content3,@content4,@date,@title,@cs13)";
                else
                    sqlCmd.CommandText = "insert into ProjectIntro (基地概况,基本信息,基地概况图,项目进度,Datetime,Title)values(@content1,@content2,@content3,@content4,@date,@title)";
            }

            if (imgURL != "")
            {
                sqlCmd.Parameters.Add("@cs13", SqlDbType.NVarChar);
                sqlCmd.Parameters["@cs13"].Value = imgURL;
            }

            sqlCmd.Parameters.Add("@content1", SqlDbType.NText);
            sqlCmd.Parameters["@content1"].Value = FreeTextBox1.Text;
            sqlCmd.Parameters.Add("@content2", SqlDbType.NText);
            sqlCmd.Parameters["@content3"].Value = FreeTextBox2.Text;
            sqlCmd.Parameters.Add("@content3", SqlDbType.NVarChar);
            sqlCmd.Parameters["@content4"].Value = FreeTextBox3.Text;
            sqlCmd.Parameters.Add("@content4", SqlDbType.NVarChar);
            sqlCmd.Parameters["@content4"].Value = Progress.Text;
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
            href_value = href_string + "id=" + IntID;
            Alert("保存成功!");
        }
    }
}
