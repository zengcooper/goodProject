﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Titan.Blog.Model.DataModel
{
    public partial class ModelBaseContext : DbContext
    {
        public ModelBaseContext()
        {
        }

        public ModelBaseContext(DbContextOptions<ModelBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysButton> SysButton { get; set; }
        public virtual DbSet<SysModule> SysModule { get; set; }
        public virtual DbSet<SysOperateLog> SysOperateLog { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysRoleModuleButton> SysRoleModuleButton { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserRole> SysUserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=TestDB;User ID=sa;Password=1q2w3e4r;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<SysButton>(entity =>
            {
                entity.HasKey(e => e.SysButtonId)
                    .HasName("PK_SYSBUTTON")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.SysButtonId).ValueGeneratedNever();

                entity.Property(e => e.ButtonName)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysModule>(entity =>
            {
                entity.HasKey(e => e.SysModuleId)
                    .HasName("PK_SYSMODULE")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.SysModuleId).ValueGeneratedNever();

                entity.Property(e => e.Action)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Controller)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LinkUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyByName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyTime).HasColumnType("datetime");

                entity.Property(e => e.ModuleDesc)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleIcon)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysOperateLog>(entity =>
            {
                entity.HasKey(e => e.SysOperateLogId)
                    .HasName("PK_SYSOPERATELOG")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.SysOperateLogId).ValueGeneratedNever();

                entity.Property(e => e.Action)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Controller)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LinkUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OperateDesc)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasKey(e => e.SysRoleId)
                    .HasName("PK_SYSROLE")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.SysRoleId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ModifyByName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyTime).HasColumnType("datetime");

                entity.Property(e => e.RoleDesc)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysRoleModuleButton>(entity =>
            {
                entity.HasKey(e => e.SysRoleModuleButtonId)
                    .HasName("PK_SYSROLEMODULEBUTTON")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.SysRoleModuleButtonId).ValueGeneratedNever();

                entity.Property(e => e.AvailableButtonJson)
                    .HasMaxLength(4000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasKey(e => e.SysUserId)
                    .HasName("PK_SYSUSER")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.SysUserId).ValueGeneratedNever();

                entity.Property(e => e.Telphone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserPwd)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysUserRole>(entity =>
            {
                entity.HasKey(e => e.SysUserRoleId)
                    .HasName("PK_SYSUSERROLE")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.SysUserRoleId).ValueGeneratedNever();
            });
        }
    }
}
