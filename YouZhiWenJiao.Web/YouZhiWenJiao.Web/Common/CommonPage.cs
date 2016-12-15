using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Collections.Generic;
using YouZhiWenJiao.Web.Common;
using System.Text.RegularExpressions;

namespace YouZhiWenJiao.Web
{
	public class CommonPage : System.Web.UI.Page
	{
		protected SQLiteConnection sqlConn = null;
		protected SQLiteCommand sqlCmd = null;

		protected CommonPage()
		{
		}

		#region Web Form Designer generated code
		override protected void OnLoad(EventArgs e)
		{
			Response.CacheControl = "No-cache";
			sqlConn = new SQLiteConnection();
			sqlCmd = new SQLiteCommand();
			sqlConn = new SQLiteConnection(string.Format(@"Data Source={0}\Database\sqlite.db;Version=3;", System.AppDomain.CurrentDomain.BaseDirectory));
			sqlConn.Open();
			sqlCmd.Connection = this.sqlConn;
			base.OnLoad(e);
		}

		protected void ShowMenu(int iMenu)
		{
			Response.Write(@"
				<li><a href=""index.aspx""  " + (iMenu == 1 ? " class='cur' " : "") + @"target=""_parent"">首&nbsp;页</a></li>
				<li><a href=""profile.aspx""  " + (iMenu == 2 ? " class='cur' " : " ") + @"target=""_parent"">优智文教</a></li>
				<li><a href=""news.aspx""  " + (iMenu == 3 ? " class='cur' " : "  ") + @"target=""_parent"">新闻中心</a></li>
				<li><a href=""producttypelist.aspx?id=3"" " + (iMenu == 4 ? " class='cur' " : " ") + @" target=""_parent"">学前装备</a></li>
				<li><a href=""producttypelist.aspx?id=4""  " + (iMenu == 5 ? " class='cur' " : "  ") + @"target=""_parent"">学习材料</a></li>
				<li><a href=""producttypelist.aspx?id=5""  " + (iMenu == 6 ? " class='cur' " : "  ") + @"target=""_parent"">教学软件</a></li>
				<li><a href=""producttypelist.aspx?id=11""  " + (iMenu == 7 ? " class='cur' " : "  ") + @"target=""_parent"">幼教书库</a></li>
				<li><a href=""videos.aspx""  " + (iMenu == 8 ? " class='cur' " : "  ") + @"target=""_parent"">下载中心</a></li>
				<li><a href=""aboutMe.html""  " + (iMenu == 9 ? " class='cur' " : "  ") + @"target=""_parent"">联系我们</a></li>");
		}

		override protected void OnUnload(EventArgs e)
		{
			if (sqlConn != null)
				sqlConn.Close();
			base.OnUnload(e);
		}

		#endregion

		public bool IsInt(string number)
		{
			if (number == null)
				return false;
			if (number.Length == 0)
				return false;
			for (int i = 0; i < number.Length; i++)
			{
				char n = number[i];
				if (n > '9' || n < '0')
					return false;
			}
			return true;
		}

		protected void Alert(string prompt)
		{
			string script = "<script type=\"text/javascript\">alert(\"" + prompt + "\");</script>";
			ClientScript.RegisterStartupScript(GetType(), "_STARTALERT", script);
		}

		static public int ToInt(object obj)
		{
			return ToInt(obj, 0);
		}

		static public int ToInt(object obj, int def)
		{
			try
			{
				return Int32.Parse(obj.ToString());
			}
			catch
			{
				return def;
			}
		}
		static public double ToDouble(object obj, double def)
		{
			try
			{
				return double.Parse(obj.ToString());
			}
			catch
			{
				return def;
			}
		}
		public static string ConvertToAlertSaveString(string strSource)
		{
			string strRet = strSource.Replace("'", "\"");

			strRet = strRet.Replace("<script>", "");
			strRet = strRet.Replace("</script>", "");
			strRet = strRet.Replace("&", "&");
			strRet = strRet.Replace("'", "''");
			strRet = strRet.Replace("*", "");
			strRet = strRet.Replace("\n", "<br/>");
			strRet = strRet.Replace("\r\n", "<br/>");
			strRet = strRet.Replace("select", "");
			strRet = strRet.Replace("insert", "");
			strRet = strRet.Replace("update", "");
			strRet = strRet.Replace("delete", "");
			strRet = strRet.Replace("create", "");
			strRet = strRet.Replace("drop", "");
			strRet = strRet.Replace("delcare", "");
			return strRet;
		}

		public static String javaScriptEscape(String input)
		{
			if (input == null)
			{
				return input;
			}
			System.Text.StringBuilder filtered = new System.Text.StringBuilder(input.Length);
			char prevChar = '\u0000';
			char c;
			for (int i = 0; i < input.Length; i++)
			{
				c = input[i];
				if (c == '"')
				{
					filtered.Append("\\\"");
				}
				else if (c == '\'')
				{
					filtered.Append("\\'");
				}
				else if (c == '\\')
				{
					filtered.Append("\\\\");
				}
				else if (c == '\t')
				{
					filtered.Append("\\t");
				}
				else if (c == '\n')
				{
					if (prevChar != '\r')
					{
						filtered.Append("\\n");
					}
				}
				else if (c == '\r')
				{
					filtered.Append("\\n");
				}
				else if (c == '\f')
				{
					filtered.Append("\\f");
				}
				else if (c == '/')
				{
					filtered.Append("\\/");
				}
				else
				{
					filtered.Append(c);
				}
				prevChar = c;
			}
			return filtered.ToString();
		}

		public List<CommonModel> GenerateModel(IDataReader reader)
		{
			List<CommonModel> results = new List<CommonModel>();
			results.Add(new CommonModel()
			{
				id = reader["id"].ToString(),
				typeid = ToInt(reader["typeid"]),
				categoryid = ToInt(reader["categoryid"]),
				title = reader["title"].ToString(),
				content = reader["content"].ToString(),
				picture = reader["picture"].ToString(),
				contentpicture1 = reader["contentpicture1"].ToString(),
				contentpicture2 = reader["contentpicture2"].ToString(),
				contentpicture3 = reader["contentpicture3"].ToString(),
                datetime = Convert.ToDateTime(reader["datetime"]).ToString("yyyy-MM-dd"),
                video = reader["video"].ToString()
			});
			return results;
		}

		public enum category
		{
			公司简介 = 1,
			公司新闻 = 2,
			园所装备 = 3,
			园长书库 = 4,
			教师书库 = 5,
			资料下载 = 6,
			在线留言 = 7,
			联系我们 = 8,
			系统用户 = 9,
			首页视频 = 10
		}

        public string NoHtml(string withHtml)
        {
            var result = Regex.Replace(withHtml, "<[^>]*>", " ");
            return result;
        }
	}
}
