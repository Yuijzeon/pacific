using System;
using System.Collections.Generic;

namespace GoGoShare.Web.Team2資料庫;

public partial class 提問
{
    public int Id { get; set; }

    public string 問題 { get; set; } = null!;

    public string 回答 { get; set; } = null!;

    public int? 提問用戶Fk { get; set; }
}
