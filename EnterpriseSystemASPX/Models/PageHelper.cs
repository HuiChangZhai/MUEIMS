using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseSystemASPX.Models
{
    public class PageHelper
    {
        public PageHelper()
        {
            this.PageSize = 8 ;
            this.IsFirstPage = true;
            this.IsLastPage = false;
            this.PageNext = 2;
            this.PagePre = 0;
        }
        /// <summary>
        /// 每页的条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 当前的页数
        /// </summary>
        public int PageCurrent { get; set; } 
        /// <summary>
        /// 当前的页数的下一页
        /// </summary>
        public int PageNext { get; set; }
        /// <summary>
        /// 当前的页数的上一页
        /// </summary>
        public int PagePre { get; set; }
        /// <summary>
        /// 当前的页数的开始索引
        /// </summary>
        public int IndexStart { get; set; }
        /// <summary>
        /// 当前的页数的结束索引
        /// </summary>
        public int IndexEnd { get; set; }
        /// <summary>
        /// 是否首页
        /// </summary>
        public bool IsFirstPage = false;
        /// <summary>
        /// 是否尾页
        /// </summary>
        public bool IsLastPage = false;
    }
}