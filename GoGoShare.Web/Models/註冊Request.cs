using Microsoft.AspNetCore.Mvc;

namespace GoGoShare.Web.Models;

public class 註冊Request
{
    [FromForm(Name = "Email")]
    public required string Email { get; set; }

    [FromForm(Name = "Password")]
    public required string Password { get; set; }

    [FromForm(Name = "Name")]
    public required string Name { get; set; }

    [FromForm(Name = "Phone")]
    public required string Phone { get; set; }
}