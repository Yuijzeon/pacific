using System.Diagnostics;
using GoGoShare.Web.Models;
using GoGoShare.Web.Team2資料庫;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoGoShare.Web.Controllers;

public class HomeController(Team2Context sql任務) : Controller
{
    public async Task<IActionResult> Index()
    {
        var 精選文章 = await sql任務.文章s
            .Include(x => x.圖片FkNavigation)
            .OrderByDescending(x => x.Id)
            .Take(10)
            .ToListAsync();

        return View(精選文章);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}