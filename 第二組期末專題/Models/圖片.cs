using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 圖片
    {
        public int Id { get; set; }
        public int 上傳用戶_FK { get; set; }
        public int 路徑 { get; set; }


        public 用戶 Get上傳用戶()
        {
            return new SelectById<用戶>(上傳用戶_FK).Get();
        }
    }
}