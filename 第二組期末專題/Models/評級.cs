using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 評級
    {
        public int Id { get; set; }
        public int 分數 { get; set; }
        public int 評分用戶_FK { get; set; }
        public int 文章_FK { get; set; }
        public string 評論 { get; set; }


        public 用戶 Get評分用戶()
        {
            return new 任務SelectById<用戶>(評分用戶_FK).Get();
        }
    }
}