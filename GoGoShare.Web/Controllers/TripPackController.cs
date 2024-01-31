using GoGoShare.Web.Team2資料庫;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoGoShare.Web.Controllers;

public class TripPackController(Team2Context context) : Controller
{
    [HttpGet("api/users/me/trip-packs")]
    [RequireLogin(nameof(userId))]
    public async Task<IActionResult> GetUserTripPacks(int userId)
    {
        var user = await context.用戶s
            .Include(x => x.旅程包s)
            .ThenInclude(x => x.旅程包Links)
            .ThenInclude(x => x.文章FkNavigation)
            .FirstAsync(x => x.Id == userId);

        return Ok(user.旅程包s.ToList());
    }

    [HttpPost("api/trip-packs/{tripPackId:int}/articles/{articleId:int}")]
    [RequireLogin(nameof(userId))]
    public async Task<IActionResult> AddArticleToTripPack(int userId, int tripPackId, int articleId)
    {
        var tripPack = await context.旅程包s
            .Include(x => x.旅程包Links)
            .FirstAsync(x => x.Id == tripPackId);

        if (tripPack.作者用戶Fk != userId)
        {
            return Unauthorized();
        }

        var isTripPackExists = tripPack.旅程包Links.Contains(new 旅程包Link
        {
            文章Fk = articleId,
            旅程包Fk = tripPackId,
        });

        if (!isTripPackExists)
        {
            tripPack.旅程包Links.Add(new 旅程包Link
            {
                文章Fk = articleId,
                旅程包Fk = tripPackId,
            });

            await context.SaveChangesAsync();
        }

        return Ok();
    }

    [HttpDelete("api/trip-packs/{tripPackId:int}/articles/{articleId:int}")]
    [RequireLogin(nameof(userId))]
    public async Task<IActionResult> RemoveArticleFromTripPack(int userId, int tripPackId, int articleId)
    {
        var tripPack = await context.旅程包s
            .Include(x => x.旅程包Links)
            .FirstAsync(x => x.Id == tripPackId);

        if (tripPack.作者用戶Fk != userId)
        {
            return Unauthorized();
        }

        var isTripPackExists = tripPack.旅程包Links.Contains(new 旅程包Link
        {
            文章Fk = articleId,
            旅程包Fk = tripPackId,
        });

        if (isTripPackExists)
        {
            tripPack.旅程包Links.Remove(new 旅程包Link
            {
                文章Fk = articleId,
                旅程包Fk = tripPackId,
            });

            await context.SaveChangesAsync();
        }

        return Ok();
    }
}