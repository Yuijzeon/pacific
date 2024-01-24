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

    public virtual ICollection<旅程包Link> 旅程包Links { get; set; } = new List<旅程包Link>();

    public virtual ICollection<評級> 評級s { get; set; } = new List<評級>();

    public virtual ICollection<Hashtag> HashtagFks { get; set; } = new List<Hashtag>();

    public virtual ICollection<用戶> 用戶Fks { get; set; } = new List<用戶>();
}
