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
        public string 描述 { get; set; }
        public int 作者用戶_FK { get; set; }


        public 用戶 Get作者()
        {
            return new SelectById<用戶>(作者用戶_FK).Get();
        }
        
        public List<文章> Get文章清單()
        {
            string 查詢字串 = "SELECT * FROM [旅程包_link] WHERE 旅程包_FK=" + Id;
            return new SelectList<文章>(查詢字串).Get();
        }
        
    }
}