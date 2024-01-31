using Microsoft.AspNetCore.Mvc;

namespace GoGoShare.Web.Models;

public class NewCommentRequest
{
    [FromForm(Name = "分數")]
    public required int Score { get; set; }
    
    [FromForm(Name = "評論")]
    public required string Content { get; set; }
}