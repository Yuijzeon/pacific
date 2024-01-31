using GoGoShare.Web.Models;
using GoGoShare.Web.Team2資料庫;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoGoShare.Web.Controllers;

public class CommentController(Team2Context context) : Controller
{
    [HttpPost("api/articles/{articleId:int}/comments")]
    [RequireLogin(nameof(commenterId))]
    public async Task<IActionResult> AddComment(int commenterId, int articleId, NewCommentRequest request)
    {
        var article = await context.文章s
            .Include(x => x.作者用戶FkNavigation)
            .FirstAsync(x => x.Id == articleId);

        article.評級s.Add(new 評級
        {
            分數 = request.Score,
            評分用戶Fk = commenterId,
            文章Fk = articleId,
            評論 = request.Content,
        });

        article.點數 += request.Score;

        var author = await context.用戶s
            .FirstAsync(x => x.Id == article.作者用戶Fk);

        var commenter = await context.用戶s
            .FirstAsync(x => x.Id == commenterId);

        author.點數 += request.Score;
        commenter.點數 -= request.Score;

        await context.SaveChangesAsync();

        return Ok();
    }
}