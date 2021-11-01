using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 圖片 : Dictionary<string, object>
    {
        public int Id { get { return (int)this["Id"]; } set { this["Id"] = value; } }
        public int 上傳用戶_FK { get { return (int)this["上傳用戶_FK"]; } set { this["上傳用戶_FK"] = value; } }
        public string 路徑 { get { return (string)this["路徑"]; } set { this["路徑"] = value; } }


        public 用戶 Get上傳用戶()
        {
            return new 任務SelectById<用戶>(上傳用戶_FK).Get();
        }
    }
}