/*
 * dir .\ConsoleApp
 * Создать миграцию для SqLite в свою папку(в PackageManagerConsole в качестые Default Project выбрать: ConsoleApp.Dal(но это не точно))
 * Add-Migration mgr_init_sqlite  -Context EntityContextSqlite  -OutputDir ./EntityFactory/Migrations/Sqlite
 * 
 * Создать миграцию для контекста SQL в свою папку
 * dotnet ef migrations add mgr_init_sql --project ConsoleApp --context EntityContextSql  --output-dir ./EntityFactory/Migrations/Sql 
 * Применить миграцию для SQL из папки
 * dotnet ef database update --project ConsoleApp --context EntityContextSql
 * 
 * dotnet ef migrations add 20200604_sqlite_init --project ConsoleApp --context EntityContextSql  --output-dir ./EntityFactory/Migrations/ 
 * 
 * dotnet ef database update
 */
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using dalDataObjects = ConsoleApp.Abstractions.DataObjects;
using constString = ConsoleApp.Abstractions.Constants.ConstantStrings;
using System.IO;

namespace ConsoleApp.DAL.EntityFactory
{
    public class EntityContextSql : EntityContext
    {
        public EntityContextSql()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string name_database = constString.name_database;
            string string_connection = $@"Data Source=(localdb)\MSSQLLocalDB;Database={name_database};Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(string_connection);
            //optionsBuilder.UseSqlServer(string_connection, x => x.MigrationsAssembly("ConsoleApp.EntityFactory.Migrations.Sql"));
        }
    }

    public class EntityContextSqlite : EntityContext
    {
        public EntityContextSqlite()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string name_database = constString.name_database;
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{name_database}.db");
            //optionsBuilder.UseSqlite($"Data Source = DevDhMagicDB.db", x => x.MigrationsAssembly("ConsoleApp.EntityFactory.Migrations.Sqlite"));
            optionsBuilder.UseSqlite($"Filename={dbPath}");
            //optionsBuilder.UseSqlite($"Data Source = {dbPath}", x => x.MigrationsAssembly("ConsoleApp.EntityFactory.Migrations.Sqlite"));
        }
    }


    public class EntityContext : DbContext
    {
        public DbSet<dalDataObjects.Blog> Blogs { get; set; }
        public DbSet<dalDataObjects.BlogImage> BlogImages { get; set; }
        public DbSet<dalDataObjects.Post> Posts { get; set; }
        public DbSet<dalDataObjects.ObjectTest> ObjectTests { get; set; }

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
