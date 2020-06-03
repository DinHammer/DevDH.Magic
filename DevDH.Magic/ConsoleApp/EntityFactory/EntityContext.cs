/*
 * dir .\ConsoleApp
 * dotnet ef migrations add 20200603_local_init --project ConsoleApp --context EntityContext  --output-dir ./EntityFactory/Migrations
 * dotnet ef database update
 */
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using dalDataObjects = ConsoleApp.Abstractions.DataObjects;

namespace ConsoleApp.EntityFactory
{
    public class EntityContext : DbContext
    {        

        public DbSet<dalDataObjects.Blog> Blogs { get; set; }
        public DbSet<dalDataObjects.BlogImage> BlogImages { get; set; }
        public DbSet<dalDataObjects.Post> Posts { get; set; }

        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string string_connection = @"Data Source=(localdb)\MSSQLLocalDB;Database=DevDhMagicDB;Trusted_Connection=True;";
        //    optionsBuilder.UseSqlServer(string_connection);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dalDataObjects.Post>()
               .HasOne(x => x.Blog)
               .WithMany(y => y.Posts)
               .HasForeignKey(x => x.IdBlog);

            modelBuilder.Entity<dalDataObjects.Blog>()
                .HasOne(x => x.BlogImage)
                .WithOne(y => y.Blog)
                .HasForeignKey<dalDataObjects.BlogImage>(x => x.IdBlog);
        }
    }
}
