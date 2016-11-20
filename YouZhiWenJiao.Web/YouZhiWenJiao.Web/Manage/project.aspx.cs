﻿using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace YouZhiWenJiao.Web.Manage
{
    public partial class project : CommonPage
    {
        public int UniqueId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
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


            sqlCmd.CommandText = @"select id,title,Datetime from Project where Title like @search ";

            if (!sqlCmd.Parameters.Contains("@search"))
            {
                sqlCmd.Parameters.Add("@search", SqlDbType.NVarChar);
            }
            sqlCmd.Parameters["@search"].Value = "%" + txtserarch.Value + "%";

            sqlCmd.CommandText += "order by Datetime desc";

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
                info.DateTime = DateTime.Parse(dt.Rows[i]["Datetime"].ToString()).ToShortDateString();
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
                sqlCmd.CommandText = "delete Project where id in(" + strDocumentSortIds + ")";
                sqlCmd.ExecuteNonQuery();
                Alert("删除成功!");
                PageChanged(null, null);
            }
        }
    }
}