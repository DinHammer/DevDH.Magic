/*
 * dir .\ConsoleApp
 * dotnet ef migrations add 20200604_sqlite_init --project ConsoleApp --context EntityContextSqlite  --output-dir ./EntityFactory/Migrations/Sqlite
 * dotnet ef migrations add 20200604_sql_init --project ConsoleApp --context EntityContextSql  --output-dir ./EntityFactory/Migrations/Sql 
 * 
 * dotnet ef migrations add 20200604_sqlite_init --project ConsoleApp --context EntityContextSql  --output-dir ./EntityFactory/Migrations/ 
 * 
 * dotnet ef database update
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using dalDataObjects = ConsoleApp.Abstractions.DataObjects;

namespace ConsoleApp.EntityFactory
{
    public class EntityContextSql : EntityContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string string_connection = @"Data Source=(localdb)\MSSQLLocalDB;Database=DevDhMagicDB;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(string_connection);
            //optionsBuilder.UseSqlServer(string_connection,x=>x.MigrationsAssembly("ConsoleApp.EntityFactory.Migrations.Sql"));
        }
    }

    public class EntityContextSqlite : EntityContext
    {
        public EntityContextSqlite()
        {
            Database.Migrate();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DevDhMagicDB.db");
            //optionsBuilder.UseSqlite($"Data Source = DevDhMagicDB.db", x => x.MigrationsAssembly("ConsoleApp.EntityFactory.Migrations.Sqlite"));
            optionsBuilder.UseSqlite($"Data Source = {dbPath}");
        }        
    }


    public class EntityContext : DbContext
    {        
        public DbSet<dalDataObjects.Blog> Blogs { get; set; }
        public DbSet<dalDataObjects.BlogImage> BlogImages { get; set; }
        public DbSet<dalDataObjects.Post> Posts { get; set; }

        //public EntityContextBase(DbContextOptions<EntityContextBase> options) : base(options)
        //{ }
        
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
