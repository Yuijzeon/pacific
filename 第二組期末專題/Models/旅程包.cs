using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 旅程包
    {
        public int Id { get; set; }
        public string 標題 { get; set; }
        public string 內容 { get; set; }
        public 用戶 作者 { get; set; }
    }
}