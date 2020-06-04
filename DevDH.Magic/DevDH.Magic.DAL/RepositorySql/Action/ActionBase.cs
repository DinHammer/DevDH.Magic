using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
//using System.Data.SqlClient;
using System.Text;
using ConstantBase = DevDH.Magic.DAL.Staff.ConstantBase;
using entityFactory = DevDH.Magic.DAL.EntityFactory;

namespace DevDH.Magic.DAL.RepositorySql.Action
{
    public class ActionBase : ConstantBase
    {
        readonly entityFactory.IEntityContextFactory contextFactory;

        public ActionBase(entityFactory.IEntityContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        protected DbContext GetMyContext()
        {
            //if (dbContext == null)
            //{
            //    var myContext = contextFactory.CreateDbContext();
            //    dbContext = myContext as DbContext;
            //}

            //return dbContext;
            var myContext = contextFactory.GetDbContext();            
            return myContext;
        }


    }
}
