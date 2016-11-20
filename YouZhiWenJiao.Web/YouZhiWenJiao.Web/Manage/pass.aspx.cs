using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace YouZhiWenJiao.Web.Manage
{
    public partial class pass : CommonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            sqlCmd.Parameters.Add("@userid", SqlDbType.NVarChar);
            sqlCmd.Parameters["@userid"].Value = Session["userid"];
            string script =
           @"<script type=""text/javascript"">
            function check() {
            if (document.getElementById(""" + NewPass.ClientID + @""").value != document.getElementById(""" + RetryPass.ClientID + @""").value) {
                alert(""重复口令和新口令不一致!"");
                return false;
            } else
                return true;
            }
            </script>";
            ClientScript.RegisterClientScriptBlock(GetType(), "check", script);
            BtnOK.OnClientClick = "javascript:return check();";
        }
        protected void Ok_Click(object sender, EventArgs e)
        {
            sqlCmd.CommandText = "SELECT Password from Manager WHERE ID=@userid";
            string oldpass = sqlCmd.ExecuteScalar().ToString();
            if (oldpass != OldPass.Text)
            {
                string script =
@"<script type=""text/javascript"">
alert(""输入的旧密码不正确!"");
</script>";
                ClientScript.RegisterStartupScript(GetType(), "start", script);
            }
            else
            {
                if (NewPass.Text != RetryPass.Text)

                    Alert("重复输入不正确");
                else
                {
                    sqlCmd.CommandText = "UPDATE Manager SET Password=@password WHERE ID=@userid";
                    sqlCmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 50);
                    sqlCmd.Parameters["@password"].Value = NewPass.Text;
                    sqlCmd.ExecuteNonQuery();
                    Alert("修改成功");
                    //  Response.Redirect("content.aspx");
                }
            }
        }
    }
}