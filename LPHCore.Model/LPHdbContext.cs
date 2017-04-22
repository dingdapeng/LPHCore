using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LPHCore.Model
{
    public partial class LPHdbContext : DbContext
    {
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsCategory> NewsCategory { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysPermissin> SysPermissin { get; set; }
        public virtual DbSet<SysPermissinSysMenu> SysPermissinSysMenu { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysRoleSysPermissin> SysRoleSysPermissin { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserSysRole> SysUserSysRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=LPHdb;uid=sa;pwd=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Click).HasDefaultValueSql("0");

                entity.Property(e => e.Contents).HasColumnType("ntext");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ImgUrl).HasMaxLength(100);

                entity.Property(e => e.Seq).HasDefaultValueSql("0");

                entity.Property(e => e.Status).HasDefaultValueSql("0");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_News_News_Category");
            });

            modelBuilder.Entity<NewsCategory>(entity =>
            {
                entity.ToTable("News_Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Seq).HasDefaultValueSql("0");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasColumnType("varchar(500)");
            });

            modelBuilder.Entity<SysPermissin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Types)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<SysPermissinSysMenu>(entity =>
            {
                entity.ToTable("SysPermissin_SysMenu");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysMenuId).HasColumnName("SysMenuID");

                entity.Property(e => e.SysPermissinId).HasColumnName("SysPermissinID");

                entity.HasOne(d => d.SysMenu)
                    .WithMany(p => p.SysPermissinSysMenu)
                    .HasForeignKey(d => d.SysMenuId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SysPermissin_SysMenu_SysMenu");

                entity.HasOne(d => d.SysPermissin)
                    .WithMany(p => p.SysPermissinSysMenu)
                    .HasForeignKey(d => d.SysPermissinId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SysPermissin_SysMenu_SysPermissin");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SysRoleSysPermissin>(entity =>
            {
                entity.ToTable("SysRole_SysPermissin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysPermissinId).HasColumnName("SysPermissinID");

                entity.Property(e => e.SysRoleId).HasColumnName("SysRoleID");

                entity.HasOne(d => d.SysPermissin)
                    .WithMany(p => p.SysRoleSysPermissin)
                    .HasForeignKey(d => d.SysPermissinId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SysRole_SysPermissin_SysPermissin");

                entity.HasOne(d => d.SysRole)
                    .WithMany(p => p.SysRoleSysPermissin)
                    .HasForeignKey(d => d.SysRoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SysRole_SysPermissin_SysRole");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Status).HasDefaultValueSql("1");

                entity.Property(e => e.TrueName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SysUserSysRole>(entity =>
            {
                entity.ToTable("SysUser_SysRole");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SysRoleId).HasColumnName("SysRoleID");

                entity.Property(e => e.SysUserId).HasColumnName("SysUserID");

                entity.HasOne(d => d.SysRole)
                    .WithMany(p => p.SysUserSysRole)
                    .HasForeignKey(d => d.SysRoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SysUser_SysRole_SysRole");

                entity.HasOne(d => d.SysUser)
                    .WithMany(p => p.SysUserSysRole)
                    .HasForeignKey(d => d.SysUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SysUser_SysRole_SysUser");
            });
        }
    }
}