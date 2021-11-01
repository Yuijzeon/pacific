using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 旅程包 : Dictionary<string, object>
    {
        public int Id { get { return (int)this["Id"]; } set { this["Id"] = value; } }
        public string 標題 { get { return (string)this["標題"]; } set { this["標題"] = value; } }
        public string 描述 { get { return (string)this["描述"]; } set { this["描述"] = value; } }
        public int 作者用戶_FK { get { return (int)this["作者用戶_FK"]; } set { this["作者用戶_FK"] = value; } }


        public 用戶 Get作者()
        {
            return new 任務SelectById<用戶>(this["作者用戶_FK"]).Get();
        }
        
        public List<文章> Get文章清單()
        {
            string 查詢字串 = "SELECT * FROM [旅程包_link] WHERE 旅程包_FK=" + this["Id"];
            return new 任務SelectList<文章>(查詢字串).Get();
        }
        
    }
}