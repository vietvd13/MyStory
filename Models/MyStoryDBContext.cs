using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyStory.Models
{
    public partial class MyStoryDBContext : DbContext
    {
        public MyStoryDBContext()
        {
        }

        public MyStoryDBContext(DbContextOptions<MyStoryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Story> Stories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Database=MyStoryDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Story>(entity =>
            {
                entity.ToTable("Story");

                entity.Property(e => e.StoryId).HasColumnName("story_id");

                entity.Property(e => e.Picture).HasColumnName("picture");

                entity.Property(e => e.TheDescription).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
