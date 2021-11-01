using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 評級 : Dictionary<string, object>
    {
        public int Id { get { return (int)this["Id"]; } set { this["Id"] = value; } }
        public int 分數 { get { return (int)this["分數"]; } set { this["分數"] = value; } }
        public int 評分用戶_FK { get { return (int)this["評分用戶_FK"]; } set { this["評分用戶_FK"] = value; } }
        public int 文章_FK { get { return (int)this["文章_FK"]; } set { this["文章_FK"] = value; } }
        public string 評論 { get { return (string)this["評論"]; } set { this["評論"] = value; } }


        public 用戶 Get評分用戶()
        {
            return new 任務SelectById<用戶>(this["評分用戶_FK"]).Get();
        }
    }
}