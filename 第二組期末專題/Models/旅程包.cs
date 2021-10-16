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


        /*
        public List<文章> Get所屬文章()
        {
            string 查詢字串 = "SELECT * FROM [旅程包_link] WHERE 旅程包_FK=" + Id;
            return new Select文章清單(查詢字串).Get();
        }
        */

        public 用戶 Get作者()
        {
            return new Select用戶ById(作者用戶_FK).Get();
        }
    }
}