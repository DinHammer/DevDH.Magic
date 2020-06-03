using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EntityFactory
{
    public class EntityFactory : DevDH.Magic.DAL.EntityFactory.IEntityContextFactory, IDesignTimeDbContextFactory<EntityContext>
    {
        public EntityContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<EntityContext> optionsBuilder = new DbContextOptionsBuilder<EntityContext>();

            string string_connection = @"Data Source=(localdb)\MSSQLLocalDB;Database=DevDhMagicDB;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(string_connection);

            return new EntityContext(optionsBuilder.Options);
        }

        public DbContext GetDbContext()
        {
            DbContext dbContext = CreateDbContext(new string[] { });            
            dbContext.Database.Migrate();
            return dbContext;
        }
    }
}
