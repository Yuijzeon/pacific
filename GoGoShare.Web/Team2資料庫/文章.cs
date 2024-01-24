using System;
using System.Collections.Generic;

namespace GoGoShare.Web.Team2資料庫;

public partial class 文章
{
    public int Id { get; set; }

    public string 標題 { get; set; } = null!;

    public int? 作者用戶Fk { get; set; }

    public string 內容 { get; set; } = null!;

    public DateTime 日期起始 { get; set; }

    public DateTime 日期結束 { get; set; }

    public int? 圖片Fk { get; set; }

    public string 地點 { get; set; } = null!;

    public int 接待人數 { get; set; }

    public string? 類型 { get; set; }

    public int 點數 { get; set; }

    public DateTime? 文章註冊時間 { get; set; }
}
