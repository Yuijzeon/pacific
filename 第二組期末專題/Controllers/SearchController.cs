﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;
using 第二組期末專題.ViewModels;

namespace 第二組期末專題.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(int? user, int? hashtag, int? favorite)
        {
            if (user != null)
            {
                var 選擇的用戶 = 資料庫.讀取<用戶>(user);

                var result = new Search()
                {
                    搜尋結果 = 選擇的用戶.Get創作文章清單()
                };

                return View(result);
            }

            if (favorite != null )
            {
                var 最愛收藏名單 = 資料庫.讀取<用戶>(favorite);

                var result = new Search()
                {
                    搜尋結果 = 最愛收藏名單.Get收藏文章清單()
                };

                return View(result);
            }

            if (hashtag != null)
            {
                var 選擇的hashtag = 資料庫.讀取<Hashtag>(hashtag);
                return View(new Search()
                {
                    搜尋結果 = 選擇的hashtag.Get文章List()
                });
            }

            return View(new Search() {
                搜尋結果 = 資料庫.讀取<文章>()
            });

            
        }

        public void By(FormCollection form)
        {
            var AAA = form["result"];
            var BBB = form["active"];
            var CCC = form["starttime"];
            var DDD = form["endtime"];
            var EEE = form["point"];
        }
    }
}