using System;
using System.Collections.Generic;

namespace GoGoShare.Web.Team2資料庫;

public partial class Hashtag
{
    public int Id { get; set; }

    public string 名稱 { get; set; } = null!;

    public string 類別 { get; set; } = null!;
}
