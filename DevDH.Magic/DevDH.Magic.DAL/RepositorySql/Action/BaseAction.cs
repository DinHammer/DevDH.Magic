using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ConstantBase = DevDH.Magic.DAL.Staff.ConstantBase;
using entityFactory = DevDH.Magic.DAL.EntityFactory;

namespace DevDH.Magic.DAL.RepositorySql.Action
{
    public class BaseAction : ConstantBase
    {
        readonly entityFactory.IEntityContextFactory contextFactory;

        public BaseAction(entityFactory.IEntityContextFactory contextFactory)
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

        protected string prtcGetIdentityInsertOn(string str_table_name) => $"SET IDENTITY_INSERT {str_table_name} ON";
        protected string prtcGetIdentityInsertOff(string str_table_name) => $"SET IDENTITY_INSERT {str_table_name} OFF";
    }
}
