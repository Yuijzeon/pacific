using System;
using System.Collections.Generic;

namespace GoGoShare.Web.Team2資料庫;

public partial class Hashtag
{
    public int Id { get; set; }

    public string 名稱 { get; set; } = null!;

    public string 類別 { get; set; } = null!;

    public virtual ICollection<文章> 文章Fks { get; set; } = new List<文章>();

    public virtual ICollection<用戶> 用戶Fks { get; set; } = new List<用戶>();
}
