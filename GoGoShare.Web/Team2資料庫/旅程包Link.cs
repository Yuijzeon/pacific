using System;
using System.Collections.Generic;

namespace GoGoShare.Web.Team2資料庫;

public partial class 旅程包Link
{
    public int 旅程包Fk { get; set; }

    public int 文章Fk { get; set; }

    public int 索引 { get; set; }
}
