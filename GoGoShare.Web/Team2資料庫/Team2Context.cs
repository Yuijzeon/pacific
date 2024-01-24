using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GoGoShare.Web.Team2資料庫;

public partial class Team2Context : DbContext
{
    public Team2Context()
    {
    }

    public Team2Context(DbContextOptions<Team2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Hashtag> Hashtags { get; set; }

    public virtual DbSet<圖片> 圖片s { get; set; }

    public virtual DbSet<提問> 提問s { get; set; }

    public virtual DbSet<文章> 文章s { get; set; }

    public virtual DbSet<文章hashtag> 文章hashtags { get; set; }

    public virtual DbSet<旅程包> 旅程包s { get; set; }

    public virtual DbSet<旅程包Link> 旅程包Links { get; set; }

    public virtual DbSet<用戶> 用戶s { get; set; }

    public virtual DbSet<用戶favorite> 用戶favorites { get; set; }

    public virtual DbSet<用戶hashtag> 用戶hashtags { get; set; }

    public virtual DbSet<評級> 評級s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Hashtag>(entity =>
        {
            entity.ToTable("Hashtag");

            entity.Property(e => e.名稱).HasMaxLength(50);
            entity.Property(e => e.類別).HasMaxLength(50);
        });

        modelBuilder.Entity<圖片>(entity =>
        {
            entity.ToTable("圖片");

            entity.Property(e => e.上傳用戶Fk).HasColumnName("上傳用戶_FK");
        });

        modelBuilder.Entity<提問>(entity =>
        {
            entity.ToTable("提問");

            entity.Property(e => e.提問用戶Fk).HasColumnName("提問用戶_FK");
        });

        modelBuilder.Entity<文章>(entity =>
        {
            entity.ToTable("文章");

            entity.Property(e => e.作者用戶Fk).HasColumnName("作者用戶_FK");
            entity.Property(e => e.圖片Fk).HasColumnName("圖片_FK");
            entity.Property(e => e.文章註冊時間).HasColumnType("smalldatetime");
            entity.Property(e => e.日期結束).HasColumnType("datetime");
            entity.Property(e => e.日期起始).HasColumnType("datetime");
            entity.Property(e => e.標題).HasMaxLength(50);
            entity.Property(e => e.類型).HasMaxLength(50);
        });

        modelBuilder.Entity<文章hashtag>(entity =>
        {
            entity.HasKey(e => new { e.文章Fk, e.HashtagFk });

            entity.ToTable("文章Hashtag");

            entity.Property(e => e.文章Fk).HasColumnName("文章_FK");
            entity.Property(e => e.HashtagFk).HasColumnName("Hashtag_FK");
        });

        modelBuilder.Entity<旅程包>(entity =>
        {
            entity.ToTable("旅程包");

            entity.Property(e => e.作者用戶Fk).HasColumnName("作者用戶_FK");
            entity.Property(e => e.標題).HasMaxLength(50);
        });

        modelBuilder.Entity<旅程包Link>(entity =>
        {
            entity.HasKey(e => new { e.旅程包Fk, e.索引 }).HasName("PK_旅程包_link_1");

            entity.ToTable("旅程包_link");

            entity.Property(e => e.旅程包Fk).HasColumnName("旅程包_FK");
            entity.Property(e => e.文章Fk).HasColumnName("文章_FK");
        });

        modelBuilder.Entity<用戶>(entity =>
        {
            entity.ToTable("用戶");

            entity.Property(e => e.名字).HasMaxLength(50);
            entity.Property(e => e.密碼).HasMaxLength(50);
            entity.Property(e => e.帳號).HasMaxLength(50);
            entity.Property(e => e.手機).HasMaxLength(50);
            entity.Property(e => e.註冊日期).HasMaxLength(50);
        });

        modelBuilder.Entity<用戶favorite>(entity =>
        {
            entity.HasKey(e => new { e.收藏文章Fk, e.用戶Fk });

            entity.ToTable("用戶Favorite");

            entity.Property(e => e.收藏文章Fk).HasColumnName("收藏文章_FK");
            entity.Property(e => e.用戶Fk).HasColumnName("用戶_FK");
        });

        modelBuilder.Entity<用戶hashtag>(entity =>
        {
            entity.HasKey(e => new { e.用戶Fk, e.HashtagFk });

            entity.ToTable("用戶Hashtag");

            entity.Property(e => e.用戶Fk).HasColumnName("用戶_FK");
            entity.Property(e => e.HashtagFk).HasColumnName("Hashtag_FK");
        });

        modelBuilder.Entity<評級>(entity =>
        {
            entity.ToTable("評級");

            entity.Property(e => e.文章Fk).HasColumnName("文章_FK");
            entity.Property(e => e.評分用戶Fk).HasColumnName("評分用戶_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
