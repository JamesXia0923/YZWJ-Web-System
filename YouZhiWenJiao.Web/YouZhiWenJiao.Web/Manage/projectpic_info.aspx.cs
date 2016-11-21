using System;
using System.Data.SqlClient;
using System.Data;

namespace YouZhiWenJiao.Web.Manage
{
    public partial class projectpic_info : CommonPage
    {
        int IntID = 0;

        string imgURL = @"";
        string href_string = @"../infor.aspx?";
        protected string href_value = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            IntID = ToInt(Request["ID"]);

            href_value = href_string + "id=" + IntID + "05";

            if (!IsPostBack)
            {
                if (IntID > 0)
                {
                    sqlCmd.CommandText = @"select content,title,Datetime from ProjectPic where ProjectPic.id=@id";
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
            string uploadName = InputFile.Value;//获取待上传图片的完整路径，包括文件名  
            //string uploadName = InputFile.PostedFile.FileName;         
            string pictureName = "";//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
            imgURL = "";
            if (InputFile.Value != "")
            {
                int idx = uploadName.LastIndexOf(".");
                string suffix = uploadName.Substring(idx);//获得上传的图片的后缀名             
                pictureName = DateTime.Now.Ticks.ToString() + suffix;
                try
                {
                    if (uploadName != "")
                    {
                        string AppUrl = "";
                        if (Request.ApplicationPath == "/")
                            AppUrl = Request.ApplicationPath;
                        else
                            AppUrl = Request.ApplicationPath + "/";
                        string path = Server.MapPath(AppUrl + "img4/" + pictureName);
                        InputFile.PostedFile.SaveAs(path);
                        imgURL = AppUrl + "img4/" + pictureName;

                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }


            if (IntID > 0)
            {
                if (imgURL != "")
                    sqlCmd.CommandText = "update ProjectPic set Content=@content,Datetime=@date,title=@title,Picture=@cs13,ShowPic=@showpic where Id=@id";

                else
                    sqlCmd.CommandText = "update ProjectPic set Content=@content,Datetime=@date,title=@title where Id=@id";
            }
            else
            {
                if (imgURL != "")
                    sqlCmd.CommandText = "insert into ProjectPic (Content,Datetime,Title,Picture,ShowPic)values(@content,@date,@title,@cs13,@showpic)";
                else
                    sqlCmd.CommandText = "insert into ProjectPic (Content,Datetime,Title)values(@content,@date,@title)";
            }

            if (imgURL != "")
            {
                sqlCmd.Parameters.Add("@cs13", SqlDbType.NVarChar);
                sqlCmd.Parameters["@cs13"].Value = imgURL;
                sqlCmd.Parameters.Add("@showpic", SqlDbType.Int);
                sqlCmd.Parameters["@showpic"].Value = 1;
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
            href_value = href_string + "id=" + IntID + "05";
            Alert("保存成功!");
        }
    }
}
