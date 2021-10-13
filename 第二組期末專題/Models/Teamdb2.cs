using System;
using System.Collections.Generic;
using System.Data;
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

        public static 用戶 Get用戶ById(int id)
        {
            string 查詢字串 = "USE [teamdb2] SELECT * FROM [User]" +
                $" WHERE id={id}";
            DataRow 資料列 = new 資料庫任務(查詢字串).Get資料列();
            return new 用戶()
            {
                Id = (int)資料列["id"],
                名字 = (string)資料列["名字"]
            };
        }

        public static 貼文 Get貼文ById(int id)
        {
            string 查詢字串 = "USE [teamdb2] SELECT * FROM [Post]" +
                $" WHERE id={id}";
            DataRow 資料列 = new 資料庫任務(查詢字串).Get資料列();
            return new 貼文()
            {
                Id = (int)資料列["id"],
                文章title = (string)資料列["文章title"],
                文章內容 = (string)資料列["文章內容"],
                User = Get用戶ById((int)資料列["發文userId"])
            };
        }
    }
}