using GoGoShare.Web.Models;
using GoGoShare.Web.Team2資料庫;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoGoShare.Web.Controllers;

public class SearchController(Team2Context sql任務) : Controller
{
    // GET: Search
    public async Task<IActionResult> Index(SearchParams request)
    {
        var memberId = HttpContext.Session.GetInt32("ID");

        var search = new Search
        {
            輪播文章 = await sql任務.文章s.Where(x => x.Id == 1 || x.Id == 6 || x.Id == 7).ToListAsync(),
            收藏文章 = request.收藏用戶Id == null
                ? []
                : await sql任務.用戶s
                    .Where(x => x.Id == memberId)
                    .SelectMany(x => x.文章s)
                    .ToListAsync(),
            搜尋結果 = await sql任務.文章s
                .Include(x => x.旅程包Links)
                .Include(x => x.HashtagFks)
                .Include(x => x.用戶Fks)
                .Where(x => request.旅程包Id == null || x.旅程包Links.Any(p => p.旅程包Fk == request.旅程包Id))
                .Where(x => request.用戶Id == null || x.作者用戶Fk == request.用戶Id)
                .Where(x => request.HashtagId == null || x.HashtagFks.Any(h => h.Id == request.HashtagId))
                .Where(x => request.收藏用戶Id == null || x.用戶Fks.Any(u => u.Id == request.收藏用戶Id))
                .Where(x => request.關鍵字 == null || x.標題.Contains(request.關鍵字) || x.內容.Contains(request.關鍵字))
                .Where(x => request.開始時間 == null || x.日期起始 >= request.開始時間)
                .Where(x => request.結束時間 == null || x.日期結束 <= request.結束時間)
                .Where(x => request.點數 == null || x.點數 >= request.點數)
                .ToListAsync(),
            標題 = await Get標題(request),
        };

        return View(search);
    }

    private async Task<string> Get標題(SearchParams request)
    {
        if (request.用戶Id != null)
        {
            var 作者 = await sql任務.用戶s.FirstOrDefaultAsync(x => x.Id == request.用戶Id);

            if (作者 != null)
            {
                return $"\"{作者.名字}\" 創作的文章";
            }
        }

        if (request.HashtagId != null)
        {
            var hashtag = await sql任務.Hashtags.FirstOrDefaultAsync(x => x.Id == request.HashtagId);

            if (hashtag != null)
            {
                return $"包含Hashtag: \"{hashtag.名稱}\" 的文章";
            }
        }

        if (request.收藏用戶Id != null)
        {
            var 用戶 = await sql任務.用戶s.FirstOrDefaultAsync(x => x.Id == request.收藏用戶Id);

            if (用戶 != null)
            {
                return $"\"{用戶.名字}\" 收藏的文章";
            }
        }

        return request.類型 switch
        {
            "room" => "出租房間",
            "food" => "共享美食",
            "trip" => "分享旅程",
            _ => "主題旅遊"
        };
    }

    //用戶新增收藏
    [RequireLogin]
    public async Task 加入收藏(int memberId, [FromQuery(Name = "id")] int articleId)
    {
        var 用戶Favorite = await sql任務.文章s.FirstAsync(x => x.Id == articleId);
        var 用戶 = await sql任務.用戶s.FirstAsync(x => x.Id == memberId);

        if (用戶.文章s.Contains(用戶Favorite))
        {
            用戶.文章s.Remove(用戶Favorite);
        }
        else
        {
            用戶.文章s.Add(用戶Favorite);
        }

        await sql任務.SaveChangesAsync();
    }
}