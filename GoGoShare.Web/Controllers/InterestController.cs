using GoGoShare.Web.Team2資料庫;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoGoShare.Web.Controllers;

public class InterestController(Team2Context context) : Controller
{
    [HttpGet("api/users/me/hashtags")]
    [RequireLogin(nameof(userId))]
    public async Task<IActionResult> GetUserHashtags(int userId)
    {
        var user = await context.用戶s
            .Include(x => x.HashtagFks)
            .FirstAsync(x => x.Id == userId);

        return Ok(user.HashtagFks.ToList());
    }

    [HttpPost("api/users/me/hashtags/{hashtagId:int}")]
    [RequireLogin(nameof(userId))]
    public async Task<IActionResult> AddUserHashtag(int userId, int hashtagId)
    {
        var user = await context.用戶s
            .Include(x => x.HashtagFks)
            .FirstAsync(x => x.Id == userId);

        var hashtag = await context.Hashtags.FirstAsync(x => x.Id == hashtagId);
        user.HashtagFks.Add(hashtag);
        await context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("api/users/me/hashtags/{hashtagId:int}")]
    [RequireLogin(nameof(userId))]
    public async Task<IActionResult> RemoveUserHashtag(int userId, int hashtagId)
    {
        var user = await context.用戶s
            .Include(x => x.HashtagFks)
            .FirstAsync(x => x.Id == userId);

        var hashtag = await context.Hashtags.FirstAsync(x => x.Id == hashtagId);
        user.HashtagFks.Remove(hashtag);
        await context.SaveChangesAsync();

        return Ok();
    }
}