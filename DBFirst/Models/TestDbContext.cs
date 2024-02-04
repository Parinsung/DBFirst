using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirst.Models;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BlogHistory> BlogHistorys { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TestDB;Integrated Security=True;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.Property(e => e.Test)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("test");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasIndex(e => e.BlogId, "IX_Posts_BlogId");

            entity.Property(e => e.Test)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("test");

            entity.HasOne(d => d.Blog).WithMany(p => p.Posts).HasForeignKey(d => d.BlogId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
