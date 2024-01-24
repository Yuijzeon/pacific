using System;
using System.Collections.Generic;

namespace GoGoShare.Web.Team2資料庫;

public partial class 用戶favorite
{
    public int 收藏文章Fk { get; set; }

    public int 用戶Fk { get; set; }
}
