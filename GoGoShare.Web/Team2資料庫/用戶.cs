using System;
using System.Collections.Generic;

namespace GoGoShare.Web.Team2資料庫;

public partial class 用戶
{
    public int Id { get; set; }

    public string 帳號 { get; set; } = null!;

    public string 密碼 { get; set; } = null!;

    public string 名字 { get; set; } = null!;

    public string 手機 { get; set; } = null!;

    public string 註冊日期 { get; set; } = null!;

    public string 大頭貼 { get; set; } = null!;

    public int 點數 { get; set; }
}
