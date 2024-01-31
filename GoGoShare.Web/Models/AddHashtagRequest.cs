using Microsoft.AspNetCore.Mvc;

namespace GoGoShare.Web.Models;

public class AddHashtagRequest
{
    [FromForm(Name = "名稱")]
    public required string HashtagName { get; set; }
    
    [FromForm(Name = "類別")]
    public required string HashtagCategory { get; set; }
}