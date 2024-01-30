using GoGoShare.Web.Team2資料庫;

namespace GoGoShare.Web.Models;

public class Search
{
    public List<文章> 輪播文章 { get; set; }
    public List<文章> 收藏文章 { get; set; }
    public List<文章> 搜尋結果 { get; set; }
    public string 標題 { get; set; }
}