namespace GoGoShare.Web.Models;

public class 註冊Request
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string Phone { get; set; }
}