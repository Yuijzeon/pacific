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

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=tcp:teamtwodb.database.windows.net,1433;Initial Catalog=teamdb2;Persist Security Info=False;User ID=teamtwo;Password=abcTwo22;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }
    }
}
