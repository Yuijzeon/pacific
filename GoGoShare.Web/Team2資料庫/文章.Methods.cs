namespace GoGoShare.Web.Team2資料庫;

public partial class 文章
{
    public string Get圖片路徑()
    {
        return this.圖片FkNavigation?.路徑 ?? "bg_3.jpg";
    }
}
