using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;

using System.Collections;
using System.Configuration;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace YouZhiWenJiao.Web.Manage
{
    public partial class news_info : CommonPage
    {
        int IntID = 0;
      
        string imgURL = @"";
        string videoURL = @"";
        string href_string = @"../infor.aspx?";
        protected string href_value = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            IntID = ToInt(Request["ID"]);

            href_value = href_string + "id=" + IntID;

            if (!IsPostBack)
            {
                sqlCmd.CommandText = "SELECT newsType FROM dbo.NewsType";
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                    ddlList.AddItem(dr[0].ToString());
                dr.Close();

                if (IntID > 0)
                {
                    sqlCmd.CommandText = @"select content,title,Datetime,newsType from News
                                           inner join newsType on NewsType.Id = isnull(TypeId,1) where News.id=@id";
                    sqlCmd.Parameters.Add("@id", SqlDbType.Int);
                    sqlCmd.Parameters["@id"].Value = IntID;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.Read())
                    {
                        FreeTextBox1.Text = dr[0].ToString();
                        txtName.Text = dr[1].ToString();
                        CreateDate.DValue = dr[2];
                        ddlList.Value = dr["newsType"].ToString();
                    }
                    dr.Close();
                }
            }

            if (ddlList.Value == "视频新闻")
            {
                videoTr.Style.Add(HtmlTextWriterStyle.Display,"block");
            }
            else
            {
                videoTr.Style.Add(HtmlTextWriterStyle.Display,"none");
            }
        }

        string get_id(string typeName)
        {
            sqlCmd.CommandText = @"select id from NewsType where newsType='" + typeName + "' ";
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
                sqlCmd.CommandText = @"insert into NewsType (newsType) values(@typeName)";
                sqlCmd.ExecuteNonQuery();
                sqlCmd.CommandText = "select @@IDENTITY";
                return sqlCmd.ExecuteScalar().ToString();
            }
        }

        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            int lx_id = ToInt(get_id(ddlList.Value), 0);

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


            //string uploadVideo = InputVideo.Value;
            //string videoName = "";

            //videoURL = "";
            //if (InputVideo.Value != "")
            //{
            //    int idx = uploadVideo.LastIndexOf(".");
            //    string suffix = uploadVideo.Substring(idx);
            //    videoName = DateTime.Now.Ticks.ToString() + suffix;
            //    try
            //    {
            //        if (uploadVideo != "")
            //        {
            //            string AppUrl = "";
            //            if (Request.ApplicationPath == "/")
            //                AppUrl = Request.ApplicationPath;
            //            else
            //                AppUrl = Request.ApplicationPath + "/";
            //            string path = Server.MapPath(AppUrl + "vedio/" + videoName);
            //            InputVideo.PostedFile.SaveAs(path);
            //            videoURL = AppUrl + "vedio/" + videoName;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write(ex);
            //    }
            //}

            if (IntID > 0)
            {
                if (imgURL != "")
                    sqlCmd.CommandText = "update News set Content=@content,Datetime=@date,title=@title,Picture=@cs13,ShowPic=@showpic,TypeId=@type,Video=@video where Id=@id";
                else
                    sqlCmd.CommandText = "update News set Content=@content,Datetime=@date,title=@title,TypeId=@type,Video=@video where Id=@id";
            }
            else
            {
                if (imgURL != "")
                    sqlCmd.CommandText = "insert into News (Content,Datetime,Title,Picture,ShowPic,TypeId,Video)values(@content,@date,@title,@cs13,@showpic,@type,@video)";
                else
                    sqlCmd.CommandText = "insert into News (Content,Datetime,Title,TypeId,Video)values(@content,@date,@title,@type,@video)";
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
            sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar);
            sqlCmd.Parameters["@type"].Value = lx_id;
            sqlCmd.Parameters.Add("@video", SqlDbType.NVarChar);
            sqlCmd.Parameters["@video"].Value = videoURL;

            sqlCmd.Parameters.Add("@id", SqlDbType.Int);
            sqlCmd.Parameters["@id"].Value = IntID;

            sqlCmd.ExecuteNonQuery();
            if (IntID == 0)
            {

                sqlCmd.CommandText = "select @@IDENTITY";
                IntID = ToInt(sqlCmd.ExecuteScalar());
            }
            href_value = href_string + "id=" + IntID + "00";
            Alert("保存成功!");
        }

    }
}