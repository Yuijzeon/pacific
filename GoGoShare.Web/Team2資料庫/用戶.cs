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

    public virtual ICollection<圖片> 圖片s { get; set; } = new List<圖片>();

    public virtual ICollection<提問> 提問s { get; set; } = new List<提問>();

    public virtual ICollection<旅程包> 旅程包s { get; set; } = new List<旅程包>();

    public virtual ICollection<評級> 評級s { get; set; } = new List<評級>();

    public virtual ICollection<Hashtag> HashtagFks { get; set; } = new List<Hashtag>();

    public virtual ICollection<文章> 收藏文章Fks { get; set; } = new List<文章>();
}
