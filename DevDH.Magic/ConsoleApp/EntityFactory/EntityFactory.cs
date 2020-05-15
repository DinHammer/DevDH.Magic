using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EntityFactory
{
    public class EntityFactory : DevDH.Magic.DAL.EntityFactory.IEntityContextFactory
    {
        public DbContext GetDbContext()
        {            
            var context = new EntityContext();
            return context;
        }
    }
}
