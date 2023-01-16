﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YoutubeShareData.Models
{
    public partial class YoutubeShareContext : DbContext
    {
        public static string ConnectionString { get; set; }
        public YoutubeShareContext()
        {
            Database.SetCommandTimeout(ConfigurationValues.DATABASE_TIMEOUT);
        }

        public YoutubeShareContext(DbContextOptions<YoutubeShareContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public virtual DbSet<YsUser> YsUser { get; set; }
        public virtual DbSet<YsVideo> YsVideo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YsUser>(entity =>
            {
                entity.ToTable("ys_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<YsVideo>(entity =>
            {
                entity.ToTable("ys_video");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.VideoLink)
                    .HasColumnType("text")
                    .HasColumnName("video_link");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}