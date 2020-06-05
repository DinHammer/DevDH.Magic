using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using constEnums = ConsoleApp.Abstractions.Constants.ConstantEnums;

namespace ConsoleApp.EntityFactory
{
    public class EntityFactory : DevDH.Magic.DAL.EntityFactory.IEntityContextFactory
    {
        constEnums.TypeDbContext typeDbContext;
        
        public EntityFactory(constEnums.TypeDbContext typeDbContext)
        {
            this.typeDbContext = typeDbContext;            
        }        

        public DbContext GetDbContext()
        {            
            switch (typeDbContext)
            {
                case constEnums.TypeDbContext.typeSql:
                    return new EntityContextSql();                                        
                case constEnums.TypeDbContext.typeSqlite:
                    return new EntityContextSqlite();                
                default:
                    throw new ArgumentNullException();
            }                                    
        }
    }
}
