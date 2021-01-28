using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dalDataObjects = ConsoleApp.Abstractions.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.DAL.DatabaseSQL.Action
{
    public class ActionDatabase : BaseAction, IActionDatabase
    {
        public RequestResult InsetTestObject(dalDataObjects.ObjectTest objectTest)
        {
            using (var var_context = DevDH.Magic.DAL.RepositorySql.RepositorySql.ActionSql.GetDbContext())
            {
                var var_my_context = var_context as ConsoleApp.DAL.EntityFactory.EntityContextSql;
                if (var_my_context == null)
                {
                    return new RequestResult(statusNotFound, message: "context not found");
                }
                var_context.Set<dalDataObjects.ObjectTest>().Add(objectTest);

                var_context.Database.OpenConnection();
                try
                {
                    var_context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT dbo.{nameof(var_my_context.ObjectTests)} ON");
                    var_context.SaveChanges();
                    var_context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT dbo.{nameof(var_my_context.ObjectTests)} OFF");
                    //transaction.Commit();
                }
                catch (Exception ex)
                {
                    return new RequestResult(statusDatabaseError, ex.Message, ex);
                }
                finally
                {
                    var_context.Database.CloseConnection();

                }

                return new RequestResult(statusOk);
            }
        }
    }

    public class ActionBlog : BaseAction<dalDataObjects.Blog>, IActionBlog
    {
    }

    public class ActionBlogImage : BaseAction<dalDataObjects.BlogImage>, IActionBlogImage
    {
    }

    public class ActionPost : BaseAction<dalDataObjects.Post>, IActionPost
    {
    }
}
