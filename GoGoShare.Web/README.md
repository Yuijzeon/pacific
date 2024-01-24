* 如何反向工程資料庫
    * 在資料庫設計更新時也須手動更新
    * 進入 GoGoShare.Web 資料夾
    * 執行指令 `dotnet ef dbcontext scaffold "Name=ConnectionStrings:DefaultConnection" Microsoft.EntityFrameworkCore.SqlServer --output-dir Team2資料庫 -f`
    * ConnectionStrings:DefaultConnection 是資料庫連線字串
    * 資料庫連線字串在 GoGoShare.Web/appsettings.json 中