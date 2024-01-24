using System;
using System.Collections.Generic;

namespace GoGoShare.Web.Team2資料庫;

public partial class 旅程包
{
    public int Id { get; set; }

    public string 標題 { get; set; } = null!;

    public string 描述 { get; set; } = null!;

    public int? 作者用戶Fk { get; set; }
}
