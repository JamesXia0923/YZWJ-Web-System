using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YouZhiWenJiao.Web
{
    public partial class CompanyProfile : CommonPage
    {
        protected List<CompanyProfileModel> CompanyProfileList;
        protected List<CompanyProfileTypeModel> CompanyProfileTypeList;

        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyProfileTypeList = new List<CompanyProfileTypeModel>();
            CompanyProfileTypeList.Add(new CompanyProfileTypeModel() { id = 1, categoryid = 1, description = "公司概述" });
            CompanyProfileTypeList.Add(new CompanyProfileTypeModel() { id = 2, categoryid = 1, description = "公司理念" });
            CompanyProfileTypeList.Add(new CompanyProfileTypeModel() { id = 3, categoryid = 1, description = "成长历程" });
            CompanyProfileTypeList.Add(new CompanyProfileTypeModel() { id = 4, categoryid = 1, description = "合作伙伴" });

            CompanyProfileList = new List<CompanyProfileModel>();
            CompanyProfileList.Add(new CompanyProfileModel() { id = 1, typeid = 1, title = "公司概述", content = "公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述公司概述" });
            CompanyProfileList.Add(new CompanyProfileModel() { id = 2, typeid = 2, title = "公司理念", content = "公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念公司理念" });
            CompanyProfileList.Add(new CompanyProfileModel() { id = 3, typeid = 3, title = "成长历程", content = "成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程成长历程" });
            CompanyProfileList.Add(new CompanyProfileModel() { id = 4, typeid = 4, title = "合作伙伴", content = "合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴合作伙伴" });
        }        
    }

    public class CompanyProfileTypeModel
    {
        public int id { get; set; }
        public int categoryid { get; set; }
        public string description { get; set; }
    }

    public class CompanyProfileModel
    {
        public int id{get;set;}
        public int typeid { get; set; }
        public int categoryid { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string picture { get; set; }
        public string contentpicture1 { get; set; }
        public string contentpicture2 { get; set; }
        public string contentpicture3 { get; set; }
        public bool showpicture { get; set; }
        public bool showinhomepage { get; set; }
    }
}
