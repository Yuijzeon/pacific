using System;
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
        public ActionResult Index(int? user)
        {
            if (user != null)
            {
                var 選擇的用戶 = new 任務SelectById<用戶>((int)user).Get();

                return View(new Search()
                {
                    搜尋結果 = 選擇的用戶.Get創作文章清單()
                });
            }

            List<文章> 搜尋結果文章列表 = new 任務SelectList<文章>("SELECT * FROM [文章]").Get();

            return View(new Search() {
                搜尋結果 = 搜尋結果文章列表
            });
        }
    }
}