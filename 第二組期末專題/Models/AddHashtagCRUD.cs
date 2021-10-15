using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class AddHashtagCRUD
    {
        //UserHashtag 新增
        public void Create(AddHashtag a)
        {
            string sql = "INSERT INTO User_Hashtag (UserId_FK, Hashtag_FK) VALUES (";
            sql += "N'" + a.UserId_FK + "',";
            sql += " N'" + a.Hashtag_FK + "')";

            new 資料庫任務(sql).Set更新();
        }
    }
}
