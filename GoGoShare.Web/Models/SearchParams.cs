using Microsoft.AspNetCore.Mvc;

namespace GoGoShare.Web.Models;

public class SearchParams
{
    [FromQuery(Name = "pack")]
    public int? 旅程包Id { get; set; }
    
    [FromQuery(Name = "user")]
    public int? 用戶Id { get; set; }
    
    [FromQuery(Name = "hashtag")]
    public int? HashtagId { get; set; }
    
    [FromQuery(Name = "favorite")]
    public int? 收藏用戶Id { get; set; }
    
    [FromQuery(Name = "result")]
    public string? 關鍵字 { get; set; }
    
    [FromQuery(Name = "trip")]
    public string? 類型 { get; set; }
    
    [FromQuery(Name = "starttime")]
    public DateTime? 開始時間 { get; set; }
    
    [FromQuery(Name = "endtime")]
    public DateTime? 結束時間 { get; set; }
    
    [FromQuery(Name = "point")]
    public int? 點數 { get; set; }
    
    [FromQuery(Name = "page")]
    public int? 頁數 { get; set; }
}