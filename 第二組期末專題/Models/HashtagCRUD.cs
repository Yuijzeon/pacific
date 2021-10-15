using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class HashtagCRUD
    {
        //新增Hashtag類別方法
        public void Create(Hashtag p)
        {
            string sql = "INSERT INTO Hashtag (hashtag名稱, hashtag類別) VALUES (";
            sql += "N'" + p.hashtag名稱 + "',";
            sql += " N'" + p.hashtag類別 + "')";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=tcp:teamtwodb.database.windows.net,1433;Initial Catalog=teamdb2;Persist Security Info=False;User ID=teamtwo;Password=abcTwo22;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        //資料庫讀取字串
        private List<Hashtag> queryBySql(string sql)
        {
            List<Hashtag> list = new List<Hashtag>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=tcp:teamtwodb.database.windows.net,1433;Initial Catalog=teamdb2;Persist Security Info=False;User ID=teamtwo;Password=abcTwo22;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Hashtag()
                {
                    id = (int)reader["id"],
                    hashtag名稱 = reader["hashtag名稱"].ToString(),
                    hashtag類別 = reader["hashtag類別"].ToString()
                });
            }
            con.Close();
            return list;
        }

        //印出全部
        public List<Hashtag> queryAll()
        {
            return queryBySql("SELECT * FROM Hashtag");
        }
    }
}