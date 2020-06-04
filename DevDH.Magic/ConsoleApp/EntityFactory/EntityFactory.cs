using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using constEnums = ConsoleApp.Abstractions.Constants.ConstantEnums;

namespace ConsoleApp.EntityFactory
{
    public class EntityFactory : DevDH.Magic.DAL.EntityFactory.IEntityContextFactory//, IDesignTimeDbContextFactory<EntityContextBase>
    {
        constEnums.TypeDbContext typeDbContext;
        string str_db_name;
        public EntityFactory(constEnums.TypeDbContext typeDbContext)
        {
            this.typeDbContext = typeDbContext;
            str_db_name = "DevDhMagicDB";
        }

        //public EntityContextBase CreateDbContext(string[] args)
        //{
        //    DbContextOptionsBuilder<EntityContextBase> optionsBuilder = new DbContextOptionsBuilder<EntityContextBase>();

        //    switch (typeDbContext)
        //    {
        //        case constEnums.TypeDbContext.typeSql:
        //            string string_connection = @$"Data Source=(localdb)\MSSQLLocalDB;Database={str_db_name};Trusted_Connection=True;";
        //            optionsBuilder.UseSqlServer(string_connection);
        //            break;
        //        case constEnums.TypeDbContext.typeSqlite:
        //            optionsBuilder.UseSqlite($"Data Source = {str_db_name}.db");
        //            break;
        //    }


        //    return new EntityContextBase(optionsBuilder.Options);
        //}

        public DbContext GetDbContext()
        {
            //DbContext dbContext = null;
            switch (typeDbContext)
            {
                case constEnums.TypeDbContext.typeSql:
                    return new EntityContextSql();                    
                    
                case constEnums.TypeDbContext.typeSqlite:
                    return new EntityContextSqlite();
                //dbContext.Database.Migrate();
                //break;
                default:
                    throw new ArgumentNullException();
            }
                        
            //return dbContext;
        }
    }
}
