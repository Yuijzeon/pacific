using Microsoft.AspNetCore.Mvc;

namespace GoGoShare.Web.Models;

public class 登入view
{
    [FromForm(Name = "帳號")]
    public required string Email { get; set; }

    [FromForm(Name = "密碼")]
    public required string Password { get; set; }
}