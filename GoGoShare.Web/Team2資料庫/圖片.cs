using System;
using System.Collections.Generic;

namespace GoGoShare.Web.Team2資料庫;

public partial class 圖片
{
    public int Id { get; set; }

    public int? 上傳用戶Fk { get; set; }

    public string 路徑 { get; set; } = null!;

    public virtual 用戶? 上傳用戶FkNavigation { get; set; }

    public virtual ICollection<文章> 文章s { get; set; } = new List<文章>();
}
