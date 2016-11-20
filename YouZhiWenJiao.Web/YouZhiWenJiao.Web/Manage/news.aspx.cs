using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace YouZhiWenJiao.Web.Manage
{
    public partial class news : CommonPage
    {
       
        public int UniqueId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string oldvar = ddlList.SelectedValue;
                ddlList.Items.Clear();
                ddlList.Items.Add(new ListItem("所有", "0"));
                sqlCmd.CommandText = "SELECT id,newstype FROM NewsType";
                SqlDataReader rd = sqlCmd.ExecuteReader();
                while (rd.Read())
                    ddlList.Items.Add(new ListItem(rd[1].ToString(), rd[0].ToString()));
                rd.Close();
                if (oldvar != "") ddlList.SelectedValue = oldvar;
            }
        }
        protected void PageChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            rptDate.DataSource = GetNewList();
            rptDate.DataBind();
        }

        protected void DataBindings(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            UniqueId++;
        }
        public IList GetNewList()
        {
            IList li = new ArrayList();

            sqlCmd.CommandText = @"select News.Id,Title,Content,Datetime,newsType,
case when ShowPic=1 then '<INPUT type=checkbox id=XSPic
 checked  value='+convert(nvarchar(10),News.Id)+' name=chkEleIdXSPic>' else 
'<INPUT type=checkbox id=XSPic    value='+convert(nvarchar(10),News.Id)+' name=chkEleIdXSPic>' end as 是否显示图片
from News inner join NewsType on NewsType.id = isnull(typeid,0) where Title like @search order by Datetime desc";

            if (!sqlCmd.Parameters.Contains("@search"))
            {
                sqlCmd.Parameters.Add("@search", SqlDbType.NVarChar);
            }
            sqlCmd.Parameters["@search"].Value = "%" + txtserarch.Value + "%";

            if (ddlList.SelectedValue != "0")
                sqlCmd.CommandText += " and Type=" + ddlList.SelectedValue + "";

            System.Data.SqlClient.SqlDataAdapter ad;
            System.Data.DataSet ds;
            ad = new SqlDataAdapter(sqlCmd);
            ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            Info info = null;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                info = new Info();
                info.Num = (i + 1).ToString();
                info.ID = dt.Rows[i]["id"].ToString();
                info.Name = dt.Rows[i]["title"].ToString();
                info.Content = dt.Rows[i]["content"].ToString();
                info.Type = dt.Rows[i]["newsType"].ToString();
                info.XSPic = dt.Rows[i]["是否显示图片"].ToString();
                info.DateTime = dt.Rows[i]["Datetime"] != System.DBNull.Value ? DateTime.Parse(dt.Rows[i]["Datetime"].ToString()).ToShortDateString() : "";
                li.Add(info);
            }

            return li;
        }

        protected void SubDelClick(object sender, System.EventArgs e)
        {
            string strDocumentSortIds = null;
            strDocumentSortIds = Request.Form["chkEleId"];
            if (strDocumentSortIds != null)
            {
                sqlCmd.CommandText = "delete News where id in(" + strDocumentSortIds + ")";
                sqlCmd.ExecuteNonQuery();
                Alert("删除成功!");
                PageChanged(null, null);
            }
        }


        protected void SubSaveClick(object sender, System.EventArgs e)
        {
            string strPictureShowIds = null;
            strPictureShowIds = Request.Form["chkEleIdXSPic"];
            sqlCmd.CommandText = "update News set ShowPic = 0";
            sqlCmd.ExecuteNonQuery();

            if (strPictureShowIds != null)
            {
                sqlCmd.CommandText = "update News set ShowPic=1 where id in(" + strPictureShowIds + ")";
                sqlCmd.ExecuteNonQuery();
            }
            Alert("保存成功!");
            PageChanged(null, null);
        }
    }
}