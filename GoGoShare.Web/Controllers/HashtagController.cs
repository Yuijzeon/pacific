using GoGoShare.Web.Models;
using GoGoShare.Web.Team2資料庫;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoGoShare.Web.Controllers;

public class HashtagController(Team2Context context) : Controller
{
    [HttpPost("api/hashtags")]
    public async Task<IActionResult> CreateHashtag([FromForm] NewHashtagRequest request)
    {
        var hashtag = await context.Hashtags
            .Where(x => x.名稱 == request.HashtagName)
            .Where(x => x.類別 == request.HashtagCategory)
            .FirstOrDefaultAsync();

        if (hashtag != null)
        {
            return Ok(hashtag.Id);
        }

        var newHashtag = new Hashtag
        {
            名稱 = request.HashtagName,
            類別 = request.HashtagCategory,
        };

        await context.Hashtags.AddAsync(newHashtag);
        await context.SaveChangesAsync();

        return Ok(newHashtag.Id);
    }
}