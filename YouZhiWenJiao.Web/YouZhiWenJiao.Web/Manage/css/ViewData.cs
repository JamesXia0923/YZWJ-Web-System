using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace YouZhiWenJiao.Web.Manage.css
{
    public class ViewData : Repeater, IPostBackEventHandler, IPostBackDataHandler
    {
        public event DataGridPageChangedEventHandler PageIndexChange;

        #region 变量
        private string BEGINTRTD = "<tr><td align=right class=styleItem colspan={1} height=28>";
        private string ENDTRTD = "</td></tr>";
        private string PAGEMES = "&nbsp;页次：{0}/{1}页&nbsp;|";
        private string PAGECOUNT = "&nbsp;共有{0}条记录&nbsp;";
        private string PAGEMES_Eng = "&nbsp;Page Num {0}/{1}&nbsp;|";
        private string PAGECOUNT_Eng = "&nbsp;Total Num {0}&nbsp;";
        private int intPageSize = 13;          // 每页显示行数
        private bool bolAllowPage = true;      // 是否在列表下面显示分页
        private string strPageType = "General";// 分页类型 Num 为数字分页 
        private bool bolHeadAllowPage = false; // 是否在列表上面显示分页
        private int intCol = 7;                // 分页<td></td>所跨行
        private int intCurrentPageIndex;       // 当前页
        private int intItemCount;              // 总记录数
        private IList IListDataSource;         // 数据
        private bool _Select = true;           //选择框分页
        private string _PageTrCss = "pageTr";  //分页 tr样式
        private string _Language = "chine";    //语言
        private bool _Del = false;
        public event EventHandler Click; //事件
        #endregion 变量

        #region 属性



        /// <summary>
        /// 数据棒定
        /// </summary>
        override public object DataSource
        {
            set
            {
                try
                {
                    IListDataSource = (IList)value;
                    ItemCount = IListDataSource.Count;
                }
                catch
                {
                    IListDataSource = null;
                    ItemCount = 0;
                }
            }
        }


        public bool Del
        {
            get { return _Del; }
            set { _Del = value; }
        }
        /// <summary>
        /// //语言
        /// </summary>
        public string Language
        {
            get { return _Language.ToLower(); }
            set { _Language = value; }
        }

        /// <summary>
        /// 是否在列表下面显示分页
        /// </summary>		
        public bool AllowPage
        {
            set { bolAllowPage = value; }
        }

        /// <summary>
        /// 分页tr的样式
        /// </summary>
        public string PageTrCss
        {
            get { return _PageTrCss; }
            set { _PageTrCss = value; }
        }

        /// <summary>
        /// 分页类型 Num数字
        /// </summary>	
        public string PageType
        {
            get { return strPageType.ToLower(); }
            set { strPageType = value; }
        }

        /// <summary>
        /// 是否在列表上面显示分页
        /// </summary>	
        public bool HeadAllowPage
        {
            set { bolHeadAllowPage = value; }
        }


        /// <summary>
        /// 分页<td></td>所跨行
        /// </summary>
        public int Col
        {
            get { return intCol; }
            set { intCol = value; }
        }


        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPageIndex
        {
            get { return intCurrentPageIndex; }
            set { intCurrentPageIndex = value; }
        }


        /// <summary>
        /// 跳转数字
        /// </summary>
        public int txtSize
        {
            get
            {
                int count = 1;
                if (ViewState["Count"] != null)
                    count = (int)ViewState["Count"];
                return count;
            }
            set
            {
                ViewState["Count"] = value;
            }
        }


        /// <summary>
        /// 每页显示个数
        /// </summary>
        public int PageSize
        {
            get { return intPageSize; }
            set { intPageSize = value; }
        }


        //选择框
        public bool Select
        {
            get { return _Select; }
            set { _Select = value; }
        }


        /// <summary>
        /// 总页数
        /// </summary>	
        public int PageCount
        {
            get
            {
                if (intItemCount % intPageSize == 0)
                    return (intItemCount) / intPageSize;
                else
                    return (intItemCount) / intPageSize + 1;
            }
        }


        /// <summary>
        /// 总记录数
        /// </summary>
        public int ItemCount
        {
            get { return intItemCount; }
            set { intItemCount = value; }
        }

        #endregion 属性

        #region 初始绑定数据
        override protected void OnLoad(EventArgs e)
        {
            OnPageIndexChanged(new DataGridPageChangedEventArgs(this, txtSize));
        }
        virtual protected void OnPageIndexChanged(DataGridPageChangedEventArgs e)
        {
            if (PageIndexChange != null)
                PageIndexChange(this, e);
        }


        virtual protected void OnClick(EventArgs e)
        {
            if (Click != null)
            {
                Click(null, e);
            }
        }
        override protected void OnDataBinding(EventArgs e)
        {
            if (CurrentPageIndex > PageCount)
                CurrentPageIndex = PageCount;

            if (CurrentPageIndex == 0)
                CurrentPageIndex = 1;

            int start = (CurrentPageIndex - 1) * PageSize;
            int size = Math.Min(PageSize, ItemCount - start);
            IList page = new ArrayList();
            for (int i = 0; i < size; i++)
                page.Add(IListDataSource[start + i]);
            base.DataSource = page;
            base.OnDataBinding(e);
        }

        #endregion 初始绑定数据

        #region   接口方法
        #region IPostBackEventHandler 成员

        public void RaisePostBackEvent(string eventArgument)
        {
            string aa = eventArgument.ToString();
            //判断是跳转还是分页
            if (eventArgument.ToString() != "txtSize" + this.UniqueID)
                CurrentPageIndex = int.Parse(eventArgument.ToString());
            txtSize = CurrentPageIndex;
            OnPageIndexChanged(new DataGridPageChangedEventArgs(this, CurrentPageIndex));
        }

        #endregion

        #region IPostBackDataHandler 成员

        public void RaisePostDataChangedEvent()
        {
            // TODO:  添加 MyList.RaisePostDataChangedEvent 实现
        }

        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            int temp = txtSize;
            try
            {
                CurrentPageIndex = Convert.ToInt32(postCollection["txtSize" + this.UniqueID]);
                txtSize = Convert.ToInt32(postCollection["txtSize" + this.UniqueID]);

                if (CurrentPageIndex < 1)
                {
                    CurrentPageIndex = 1;
                    txtSize = 1;
                }

            }
            catch (FormatException)
            {
                txtSize = temp;
                CurrentPageIndex = temp;
            }
            return false;
        }

        #endregion
        #endregion 接口方法

        /// <summary>
        /// 将此控件呈现给指定的输出参数。
        /// </summary>
        /// <param name="output"> 要写出到的 HTML 编写器 </param>
        protected override void Render(HtmlTextWriter output)
        {
            int temp = 0;
            #region 上面分页
            if (bolHeadAllowPage)
            {
                output.Write(string.Format(BEGINTRTD, PageTrCss, intCol));


                #region 上面分页 格式
                if (intCurrentPageIndex > 1)
                {
                    temp = intCurrentPageIndex - 1;
                    if (Language == "eng")
                    {
                        output.Write("&nbsp;<a id=prev" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, "0") + ">First</a>&nbsp;|");
                        output.Write("&nbsp;<a id=prev" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, temp.ToString()) + ">Previous</a>&nbsp;|");
                    }
                    else
                    {
                        output.Write("&nbsp;<a id=prev" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, "0") + ">首页</a>&nbsp;|");
                        output.Write("&nbsp;<a id=prev" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, temp.ToString()) + ">上一页</a>&nbsp;|");
                    }
                }
                else
                {
                    if (Language == "eng")
                    {
                        output.Write("<font color=#757D78>First</font>&nbsp;|");
                        output.Write("&nbsp;<font color=#757D78>Previous</font>&nbsp;|");
                    }
                    else
                    {
                        output.Write("<font color=#757D78>首页</font>&nbsp;|");
                        output.Write("&nbsp;<font color=#757D78>上一页</font>&nbsp;|");
                    }
                }
                if (intCurrentPageIndex < PageCount)
                {
                    temp = intCurrentPageIndex + 1;
                    if (Language == "eng")
                    {
                        output.Write("&nbsp;<a  id=next" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, temp.ToString()) + ">Next</a>&nbsp;|");
                        output.Write("&nbsp;<a  id=next" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, PageCount.ToString()) + ">Bottom</a>&nbsp;|");
                    }
                    else
                    {
                        output.Write("&nbsp;<a  id=next" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, temp.ToString()) + ">下一页</a>&nbsp;|");
                        output.Write("&nbsp;<a  id=next" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, PageCount.ToString()) + ">尾页</a>&nbsp;|");
                    }
                }
                else
                {
                    if (Language == "eng")
                    {
                        output.Write("&nbsp;<font color=#757d78>Next</font>&nbsp;|");
                        output.Write("&nbsp;<font color=#757D78>Bottom</font>&nbsp;|");
                    }
                    else
                    {
                        output.Write("&nbsp;<font color=#757d78>下一页</font>&nbsp;|");
                        output.Write("&nbsp;<font color=#757D78>尾页</font>&nbsp;|");
                    }

                }
                //总页数 总记录数 当前页
                if (Language == "eng")
                {
                    output.Write(string.Format(PAGEMES_Eng, intCurrentPageIndex, PageCount));
                    output.Write(string.Format(PAGECOUNT_Eng, intItemCount));
                }
                else
                {
                    output.Write(string.Format(PAGEMES, intCurrentPageIndex, PageCount));
                    output.Write(string.Format(PAGECOUNT, intItemCount));
                }
                //下拉列表分页
                if (Select)
                    output.Write(GetSelect());
                #endregion 上面分页 格式


                output.Write(ENDTRTD);
            }
            #endregion 上面分页

            base.Render(output);

            #region 下面分页
            if (bolAllowPage)
            {
                output.Write(string.Format(BEGINTRTD, PageTrCss, intCol));

                if (PageType != "num")
                {
                    #region (intCurrentPageIndex>1)
                    if (intCurrentPageIndex > 1)
                    {

                        temp = intCurrentPageIndex - 1;
                        if (Language == "eng")
                        {
                            output.Write("&nbsp;<a id=prev" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, "0") + ">First</a>&nbsp;|");
                            output.Write("&nbsp;<a id=prev" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, temp.ToString()) + ">Previous</a>&nbsp;|");
                        }
                        else
                        {
                            output.Write("&nbsp;<a id=prev" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, "0") + ">首页</a>&nbsp;|");
                            output.Write("&nbsp;<a id=prev" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, temp.ToString()) + ">上一页</a>&nbsp;|");
                        }

                    }
                    else
                    {

                        if (Language == "eng")
                        {
                            output.Write("<font color=#757D78>First</font>&nbsp;|");
                            output.Write("&nbsp;<font color=#757D78>Previous</font>&nbsp;|");
                        }
                        else
                        {
                            output.Write("<font color=#757D78>首页</font>&nbsp;|");
                            output.Write("&nbsp;<font color=#757D78>上一页</font>&nbsp;|");
                        }

                    }
                    #endregion
                    #region intCurrentPageIndex < PageCount)
                    if (intCurrentPageIndex < PageCount)
                    {

                        temp = intCurrentPageIndex + 1;
                        if (Language == "eng")
                        {
                            output.Write("&nbsp;<a  id=next" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, temp.ToString()) + ">Next</a>&nbsp;|");
                            output.Write("&nbsp;<a  id=next" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, PageCount.ToString()) + ">Bottom</a>&nbsp;|");
                        }
                        else
                        {
                            output.Write("&nbsp;<a  id=next" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, temp.ToString()) + ">下一页</a>&nbsp;|");
                            output.Write("&nbsp;<a  id=next" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, PageCount.ToString()) + ">尾页</a>&nbsp;|");
                        }
                    }
                    else
                    {
                        if (Language == "eng")
                        {
                            output.Write("&nbsp;<font color=#757d78>Next</font>&nbsp;|");
                            output.Write("&nbsp;<font color=#757D78>Bottom</font>&nbsp;|");
                        }
                        else
                        {
                            output.Write("&nbsp;<font color=#757d78>下一页</font>&nbsp;|");
                            output.Write("&nbsp;<font color=#757D78>尾页</font>&nbsp;|");
                        }

                    }
                    #endregion
                    #region 标志 第几页
                    if (Language == "eng")
                    {
                        output.Write(string.Format(PAGEMES_Eng, intCurrentPageIndex, PageCount));
                        output.Write(string.Format(PAGECOUNT_Eng, intItemCount));
                    }
                    else
                    {
                        output.Write(string.Format(PAGEMES, intCurrentPageIndex, PageCount));
                        output.Write(string.Format(PAGECOUNT, intItemCount));
                    }
                    #endregion
                    #region 下拉列表分页
                    if (Select)
                        output.Write(GetSelect());
                    #endregion
                    #region 删除
                    if (Del)
                    {

                        output.WriteBeginTag("input");
                        output.WriteAttribute("type", "submit");
                        output.WriteAttribute("Name", this.UniqueID);
                        output.WriteAttribute("class", "button");
                        output.WriteAttribute("ID", "btns" + this.UniqueID);
                        output.WriteAttribute("value", "删除");
                        output.WriteAttribute("class", "button");
                        output.WriteAttribute("onclick", "javascript:" + Page.GetPostBackEventReference(this, "DD"));
                        output.Write(HtmlTextWriter.TagRightChar);
                    }
                    #endregion
                }
                else
                {
                    #region 数字分页
                    output.Write(GetNum());
                    #region 跳转分页
                    //					output.WriteBeginTag("input");
                    //					output.WriteAttribute("type","text");
                    //					output.WriteAttribute("name","txtSize"+this.UniqueID);
                    //					if(ID!=null)
                    //						output.WriteAttribute("id",this.UniqueID);
                    //					output.WriteAttribute("size","2");
                    //					output.WriteAttribute("class","searchGo");
                    //					output.WriteAttribute("value",txtSize.ToString());
                    //					output.WriteAttribute("onkeydown","javascript:pageEvent('btn"+this.UniqueID+"')");
                    //				
                    //					output.Write(HtmlTextWriter.TagRightChar);
                    //					output.Write("   ");
                    //					output.WriteBeginTag ("input");
                    //					output.WriteAttribute ("type", "submit");
                    //					output.WriteAttribute ("Name", this.UniqueID);
                    //					output.WriteAttribute("class","button");
                    //					output.WriteAttribute("ID","btn"+this.UniqueID);
                    //					if(Language == "eng")
                    //						output.WriteAttribute ("value", "GO");
                    //					else
                    //						output.WriteAttribute ("value", "跳转");
                    //
                    //					output.WriteAttribute ("class", "button");					
                    //					output.WriteAttribute ("onclick","javascript:"+Page.GetPostBackEventReference(this,"txtSize"+this.UniqueID));
                    //					output.Write (HtmlTextWriter.TagRightChar);		
                    #endregion 跳转分页
                    #endregion
                }

                output.Write(ENDTRTD);
            }
            #endregion 下面分页

            Page.GetPostBackEventReference(this);
        }


        private string GetNum()
        {
            string strNum = "";
            int temp = 0;

            if (intCurrentPageIndex > 1)
            {
                temp = intCurrentPageIndex - 1;
                if (Language == "eng")
                    strNum += "&nbsp;<a id=prev" + this.UniqueID + " style='text-decoration: none;' href=javascript:" + Page.GetPostBackEventReference(this, temp.ToString()) + ">Previous page</a>&nbsp;|";
                else
                    strNum += "&nbsp;<a id=prev" + this.UniqueID + " style='text-decoration: none;' href=javascript:" + Page.GetPostBackEventReference(this, temp.ToString()) + ">上一页</a>&nbsp;|";

            }
            else
            {
                if (Language == "eng")
                    strNum += "&nbsp;<font color=#757D78>Previous page</font>&nbsp;|";
                else
                    strNum += "&nbsp;<font color=#757D78>上一页</font>&nbsp;|";

            }

            strNum += "";

            int intStart = 0;
            int intEnd = 0;

            if (CurrentPageIndex == 1)
                intStart = 1;
            else
                intStart = CurrentPageIndex - 1;


            if (CurrentPageIndex == 1)
            {
                if (intCurrentPageIndex + 4 <= PageCount)
                    intEnd = intCurrentPageIndex + 4;
                else
                    intEnd = PageCount;
            }
            else
            {
                if (intCurrentPageIndex + 3 <= PageCount)
                    intEnd = intCurrentPageIndex + 3;
                else
                    intEnd = PageCount;
            }
            for (int y = intStart; y <= intEnd; y++)
            {
                if (CurrentPageIndex != y)
                    strNum += "&nbsp;<a style='text-decoration: none;' id=next" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, y.ToString()) + ">" + y.ToString() + "</a>&nbsp;";
                else
                    strNum += "&nbsp;<a style='text-decoration: none;' id=next" + this.UniqueID + " href=javascript:" + Page.GetPostBackEventReference(this, y.ToString()) + "><font color=red>" + y.ToString() + "</font></a>&nbsp;";
            }
            if (intCurrentPageIndex < PageCount)
            {
                temp = intCurrentPageIndex + 1;
                if (Language == "eng")
                    strNum += "&nbsp;|&nbsp;<a id=next" + this.UniqueID + " style='text-decoration: none;' href=javascript:" + Page.GetPostBackEventReference(this, temp.ToString()) + ">Next Page</a>&nbsp;|&nbsp;";
                else
                    strNum += "&nbsp;|&nbsp;<a id=next" + this.UniqueID + " style='text-decoration: none;' href=javascript:" + Page.GetPostBackEventReference(this, temp.ToString()) + ">下一页</a>&nbsp;|&nbsp;";
            }
            else
            {
                if (Language == "eng")
                    strNum += "&nbsp;|&nbsp;<font color=#757d78>Next Page</font>&nbsp;|&nbsp;";
                else
                    strNum += "&nbsp;|&nbsp;<font color=#757d78>下一页</font>&nbsp;|&nbsp;";

            }
            return strNum;
        }
        private string GetSelect()
        {
            string CurrentPage = Context.Request.Path;
            string start = "&nbsp;&nbsp;<select name=\"PageCount\"  onchange=\"javascript:__doPostBack('" + this.UniqueID + "',this.value)\">";
            string content = null;
            for (int y = 1; y <= PageCount; y++)
            {
                if (CurrentPageIndex == y)
                    content += "<option value=" + y + " selected>" + y;
                else
                    content += "<option value=" + y + ">" + y;
            }
            return start + content + "</select>&nbsp;&nbsp;";

        }
        protected override void OnPreRender(EventArgs e)
        {
            Page.RegisterClientScriptBlock(
                "MessageButtonScript",
                "<script language=\"javascript\">\n" +
                "<!--\n" +
                "function pageEvent(btn)\n" +
                "{\n" +
                " if(event.keyCode == 13){document.getElementById(btn).focus();}\n" +
                "}\n" +
                "-->\n" +
                "</script>");
        }
    }
}
