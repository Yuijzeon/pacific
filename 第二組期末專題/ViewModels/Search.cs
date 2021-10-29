using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 第二組期末專題.Models;

namespace 第二組期末專題.ViewModels
{
    public class Search
    {
        public List<文章> 輪播文章 { get; set; }
        public List<文章> 搜尋結果 { get; set; }
    }
}