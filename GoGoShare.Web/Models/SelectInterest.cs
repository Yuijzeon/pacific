using GoGoShare.Web.Team2資料庫;

namespace GoGoShare.Web.Models;

public class SelectInterest
{
    public List<Hashtag> 已選Hashtags { get; set; }
    public List<Hashtag> 全部Hashtags { get; set; }
}