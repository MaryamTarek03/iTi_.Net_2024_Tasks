using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTi_day_15_lab.Models
{
    public class NewsArchiveContext : DbContext 
    {
        public virtual DbSet<Author>? Author { get; set; }
        public virtual DbSet<Category>? Category { get; set; }
        public virtual DbSet<NewsPiece>? NewsPiece { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseNpgsql("Host=localhost;Username=postgres;Password=root;Database=NewsArchiveEFLab02");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsPiece>()
                .HasOne(news => news.Author)
                .WithMany(author => author.NewsPieces)
                .HasForeignKey(news => news.AuthorId);

            modelBuilder.Entity<NewsPiece>()
                .HasOne(news => news.Category)
                .WithMany(category => category.NewsPieces)
                .HasForeignKey(news => news.CategoryId);

            modelBuilder.Entity<Author>().Property(author => author.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<NewsPiece>().Property(news => news.Id).UseIdentityAlwaysColumn();
            // modelBuilder.Entity<NewsPiece>().Property(newsPiece => newsPiece.Date).HasColumnType("timestamp");
            // modelBuilder.Entity<NewsPiece>().Property(newsPiece => newsPiece.Time).HasColumnType("time");
        }
    }
}
