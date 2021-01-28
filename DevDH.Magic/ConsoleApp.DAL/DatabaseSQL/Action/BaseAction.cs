using System;
using System.Collections.Generic;
using System.Text;
using dalDataObjects = ConsoleApp.Abstractions.DataObjects;
using ConstantBase = ConsoleApp.Abstractions.Constants.ConstantBase;
using System.Threading.Tasks;
using DevDH.Magic.Abstractions;
//using dalDatabaseSql = Example.DatabaseSQL.DatabaseSQL;
using dalRepositorySql = DevDH.Magic.DAL.RepositorySql.RepositorySql;
using System.Linq.Expressions;

namespace ConsoleApp.DAL.DatabaseSQL.Action
{
    public class BaseAction : ConstantBase
    { }


    public class BaseAction<T> : DevDH.Magic.DAL.RepositorySqlBaseAction.BaseAction<T>, IBaseAction<T> where T : class, dalDataObjects.IBaseObjectSql
    {        

    }

    
}
