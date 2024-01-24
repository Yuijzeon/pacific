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

    public virtual DbSet<旅程包> 旅程包s { get; set; }

    public virtual DbSet<旅程包Link> 旅程包Links { get; set; }

    public virtual DbSet<用戶> 用戶s { get; set; }

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

            entity.HasOne(d => d.上傳用戶FkNavigation).WithMany(p => p.圖片s)
                .HasForeignKey(d => d.上傳用戶Fk)
                .HasConstraintName("FK_圖片_圖片");
        });

        modelBuilder.Entity<提問>(entity =>
        {
            entity.ToTable("提問");

            entity.Property(e => e.提問用戶Fk).HasColumnName("提問用戶_FK");

            entity.HasOne(d => d.提問用戶FkNavigation).WithMany(p => p.提問s)
                .HasForeignKey(d => d.提問用戶Fk)
                .HasConstraintName("FK_提問_用戶");
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

            entity.HasMany(d => d.HashtagFks).WithMany(p => p.文章Fks)
                .UsingEntity<Dictionary<string, object>>(
                    "文章hashtag",
                    r => r.HasOne<Hashtag>().WithMany()
                        .HasForeignKey("HashtagFk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_文章Hashtag_Hashtag"),
                    l => l.HasOne<文章>().WithMany()
                        .HasForeignKey("文章Fk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_文章Hashtag_文章"),
                    j =>
                    {
                        j.HasKey("文章Fk", "HashtagFk");
                        j.ToTable("文章Hashtag");
                        j.IndexerProperty<int>("文章Fk").HasColumnName("文章_FK");
                        j.IndexerProperty<int>("HashtagFk").HasColumnName("Hashtag_FK");
                    });

            entity.HasMany(d => d.用戶Fks).WithMany(p => p.收藏文章Fks)
                .UsingEntity<Dictionary<string, object>>(
                    "用戶favorite",
                    r => r.HasOne<用戶>().WithMany()
                        .HasForeignKey("用戶Fk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_用戶Favorite_用戶"),
                    l => l.HasOne<文章>().WithMany()
                        .HasForeignKey("收藏文章Fk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_用戶Favorite_文章"),
                    j =>
                    {
                        j.HasKey("收藏文章Fk", "用戶Fk");
                        j.ToTable("用戶Favorite");
                        j.IndexerProperty<int>("收藏文章Fk").HasColumnName("收藏文章_FK");
                        j.IndexerProperty<int>("用戶Fk").HasColumnName("用戶_FK");
                    });
        });

        modelBuilder.Entity<旅程包>(entity =>
        {
            entity.ToTable("旅程包");

            entity.Property(e => e.作者用戶Fk).HasColumnName("作者用戶_FK");
            entity.Property(e => e.標題).HasMaxLength(50);

            entity.HasOne(d => d.作者用戶FkNavigation).WithMany(p => p.旅程包s)
                .HasForeignKey(d => d.作者用戶Fk)
                .HasConstraintName("FK_旅程包_用戶");
        });

        modelBuilder.Entity<旅程包Link>(entity =>
        {
            entity.HasKey(e => new { e.旅程包Fk, e.索引 }).HasName("PK_旅程包_link_1");

            entity.ToTable("旅程包_link");

            entity.Property(e => e.旅程包Fk).HasColumnName("旅程包_FK");
            entity.Property(e => e.文章Fk).HasColumnName("文章_FK");

            entity.HasOne(d => d.文章FkNavigation).WithMany(p => p.旅程包Links)
                .HasForeignKey(d => d.文章Fk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_旅程包_link_文章");

            entity.HasOne(d => d.旅程包FkNavigation).WithMany(p => p.旅程包Links)
                .HasForeignKey(d => d.旅程包Fk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_旅程包_link_旅程包");
        });

        modelBuilder.Entity<用戶>(entity =>
        {
            entity.ToTable("用戶");

            entity.Property(e => e.名字).HasMaxLength(50);
            entity.Property(e => e.大頭貼).HasDefaultValue("初始照片.jpg");
            entity.Property(e => e.密碼).HasMaxLength(50);
            entity.Property(e => e.帳號).HasMaxLength(50);
            entity.Property(e => e.手機).HasMaxLength(50);
            entity.Property(e => e.註冊日期)
                .HasMaxLength(50)
                .HasDefaultValueSql("(getdate())");

            entity.HasMany(d => d.HashtagFks).WithMany(p => p.用戶Fks)
                .UsingEntity<Dictionary<string, object>>(
                    "用戶hashtag",
                    r => r.HasOne<Hashtag>().WithMany()
                        .HasForeignKey("HashtagFk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_用戶Hashtag_Hashtag"),
                    l => l.HasOne<用戶>().WithMany()
                        .HasForeignKey("用戶Fk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_用戶Hashtag_用戶"),
                    j =>
                    {
                        j.HasKey("用戶Fk", "HashtagFk");
                        j.ToTable("用戶Hashtag");
                        j.IndexerProperty<int>("用戶Fk").HasColumnName("用戶_FK");
                        j.IndexerProperty<int>("HashtagFk").HasColumnName("Hashtag_FK");
                    });
        });

        modelBuilder.Entity<評級>(entity =>
        {
            entity.ToTable("評級");

            entity.Property(e => e.文章Fk).HasColumnName("文章_FK");
            entity.Property(e => e.評分用戶Fk).HasColumnName("評分用戶_FK");
            entity.Property(e => e.評論).HasDefaultValue("");

            entity.HasOne(d => d.文章FkNavigation).WithMany(p => p.評級s)
                .HasForeignKey(d => d.文章Fk)
                .HasConstraintName("FK_評級_文章");

            entity.HasOne(d => d.評分用戶FkNavigation).WithMany(p => p.評級s)
                .HasForeignKey(d => d.評分用戶Fk)
                .HasConstraintName("FK_評級_用戶");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
