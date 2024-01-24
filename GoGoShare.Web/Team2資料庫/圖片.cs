using System;
using System.Collections.Generic;

namespace GoGoShare.Web.Team2資料庫;

public partial class 圖片
{
    public int Id { get; set; }

    public int? 上傳用戶Fk { get; set; }

    public string 路徑 { get; set; } = null!;
}
