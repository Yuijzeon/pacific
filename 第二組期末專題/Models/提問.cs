using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 提問 : Dictionary<string, object>
    {
        public int Id { get { return (int)this["Id"]; } set { this["Id"] = value; } }
        public string 問題 { get { return (string)this["問題"]; } set { this["問題"] = value; } }
        public string 回答 { get { return (string)this["回答"]; } set { this["回答"] = value; } }
        public int 提問用戶_FK { get { return (int)this["提問用戶_FK"]; } set { this["提問用戶_FK"] = value; } }


        public 用戶 Get提問用戶()
        {
            return new 任務SelectById<用戶>(提問用戶_FK).Get();
        }
    }
}