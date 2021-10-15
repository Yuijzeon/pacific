using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public static class Teamdb2
    {
        public static string 連線字串 = "Server=tcp:teamtwodb.database.windows.net,1433;" +
                                       "Initial Catalog=teamdb2;" +
                                       "Persist Security Info=False;" +
                                       "User ID=teamtwo;" +
                                       "Password=abcTwo22;" +
                                       "MultipleActiveResultSets=False;" +
                                       "Encrypt=True;" +
                                       "TrustServerCertificate=False;" +
                                       "Connection Timeout=30;";

        public static Hashtag GetHashtagById(int id)
        {
            string 查詢字串 = "USE [teamdb2] SELECT * FROM [Hashtag]" +
                " WHERE id=" + id;

            DataRow 資料列 = new 資料庫任務(查詢字串).Get資料列();

            return new Hashtag()
            {
                id = (int)資料列["id"],
                hashtag名稱 = (string)資料列["hashtag名稱"],
                hashtag類別 = (string)資料列["hashtag類別"]
            };
        }

        public static List<Hashtag> GetHashtag集ById(string 資料表名稱, int id)
        {
            List<Hashtag> hashtag集 = new List<Hashtag>();

            string 查詢字串 = "USE [teamdb2] SELECT * FROM " + 資料表名稱 +
                " WHERE PostId_FK=" + id;

            new 資料庫任務(查詢字串)
            {
                When擷取到一筆資料 = delegate (SqlDataReader 資料擷取器)
                {
                    hashtag集.Add(GetHashtagById((int)資料擷取器["Hashtag_FK"]));
                }
            }.擷取();

            return hashtag集;
        }

        public static 用戶 Get用戶ById(int id)
        {
            string 查詢字串 = "USE [teamdb2] SELECT * FROM [User]" +
                " WHERE id=" + id;

            DataRow 資料列 = new 資料庫任務(查詢字串).Get資料列();

            return new 用戶()
            {
                Id = (int)資料列["id"],
                帳號 = (string)資料列["帳號"],
                密碼 = (string)資料列["密碼"],
                名字 = (string)資料列["名字"],
                手機 = (string)資料列["手機"],
                註冊日期 = (DateTime)資料列["註冊日期"],
                大頭貼 = (string)資料列["大頭貼"],
                點數 = (int)資料列["點數"],
                Hashtag集 = GetHashtag集ById("User_Hashtag", (int)資料列["id"])
            };
        }

        public static 貼文 Get貼文ById(int id)
        {
            string 查詢字串 = "USE [teamdb2] SELECT * FROM [Post]" +
                " WHERE id=" + id;

            DataRow 資料列 = new 資料庫任務(查詢字串).Get資料列();

            return new 貼文()
            {
                Id = (int)資料列["id"],
                標題 = (string)資料列["文章title"],
                作者 = Get用戶ById((int)資料列["發文userId"]),
                內容 = (string)資料列["文章內容"],
                日期起始 = (DateTime)資料列["日期起始"],
                日期結束 = (DateTime)資料列["日期結束"],
                時段起始 = (string)資料列["時段起始"],
                時段 = (string)資料列["時段"],
                地點 = (string)資料列["地點"],
                接待人數 = (int)資料列["接待人數"],
                類型 = (string)資料列["類型"],
                Hashtag集 = GetHashtag集ById("Journey_Hashtag", (int)資料列["id"])
            };
        }
    }
}