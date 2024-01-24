using System;
using System.Collections.Generic;

namespace GoGoShare.Web.Team2資料庫;

public partial class 評級
{
    public int Id { get; set; }

    public int 分數 { get; set; }

    public int? 評分用戶Fk { get; set; }

    public int? 文章Fk { get; set; }

    public string 評論 { get; set; } = null!;

    public virtual 文章? 文章FkNavigation { get; set; }

    public virtual 用戶? 評分用戶FkNavigation { get; set; }
}
