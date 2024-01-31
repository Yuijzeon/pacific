using GoGoShare.Web.Models;
using GoGoShare.Web.Team2資料庫;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoGoShare.Web.Controllers;

public class SignUpController(Team2Context sql任務) : Controller
{
    // GET: SignUp
    public IActionResult Index()
    {
        return View();
    }

    //SHOW出所有標籤
    [RequireLogin(nameof(memberId))]
    public async Task<IActionResult> SelectInterest(int memberId)
    {
        var data = new SelectInterest
        {
            已選Hashtags = await sql任務.用戶s
                .Where(x => x.Id == memberId)
                .SelectMany(x => x.HashtagFks)
                .ToListAsync(),
            全部Hashtags = await sql任務.Hashtags.ToListAsync(),
        };

        return View(data);
    }

    //用戶註冊
    public async Task<IActionResult> 註冊([FromForm] 註冊Request request)
    {
        var x = new 用戶
        {
            帳號 = request.Email,
            密碼 = request.Password,
            名字 = request.Name,
            手機 = request.Phone,
            註冊日期 = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
            大頭貼 = "初始照片.jpg",
            點數 = 1,
        };

        await sql任務.用戶s.AddAsync(x);
        return RedirectToAction("Index");
    }

    //新增用戶標籤
    [RequireLogin(nameof(memberId))]
    public async Task<IActionResult> AddUserHashtag(int memberId, [FromForm] int id)
    {
        var 用戶 = await sql任務.用戶s.FirstAsync(x => x.Id == memberId);
        var hashtag = await sql任務.Hashtags.FirstAsync(x => x.Id == id);
        用戶.HashtagFks.Add(hashtag);
        await sql任務.SaveChangesAsync();

        return RedirectToAction("SelectInterest");
    }

    //刪除用戶標籤
    [RequireLogin(nameof(memberId))]
    public async Task<IActionResult> 刪除用戶標籤(int memberId, [FromForm] int id)
    {
        var 用戶 = await sql任務.用戶s.SingleAsync(x => x.Id == memberId);
        var hashtag = await sql任務.Hashtags.SingleAsync(x => x.Id == id);
        用戶.HashtagFks.Remove(hashtag);
        await sql任務.SaveChangesAsync();

        return RedirectToAction("SelectInterest");
    }

    // //返回主頁
    // public IActionResult back()
    // {
    //     return RedirectToAction("Index", "Member");
    // }

    //登入
    [HttpPost("api/login")]
    public async Task<IActionResult> Login([FromForm] 登入view request)
    {
        var 用戶 = await sql任務.用戶s
            .Where(x => x.帳號 == request.Email)
            .Where(x => x.密碼 == request.Password)
            .SingleOrDefaultAsync();

        if (用戶 is null)
        {
            return BadRequest();
        }

        HttpContext.Session.SetInt32("ID", 用戶.Id);
        HttpContext.Session.SetString("Name", 用戶.名字);

        return Ok();
    }
}