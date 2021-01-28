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
        
    }

    public class ActionObjectTest : BaseAction<dalDataObjects.ObjectTest>, IActionObjectTest
    {
        public RequestResult InsetObject(dalDataObjects.ObjectTest objectTest)
            => DevDH.Magic.DAL.RepositorySql.RepositorySql.ActionSql.mgcInsert<dalDataObjects.ObjectTest>(objectTest, $"dbo.{nameof(ConsoleApp.DAL.EntityFactory.EntityContextSql.ObjectTests)}");

        public RequestResult InsetObjectRange(List<dalDataObjects.ObjectTest> items)
            => DevDH.Magic.DAL.RepositorySql.RepositorySql.ActionSql.mgcInsertRange<dalDataObjects.ObjectTest>(items, $"dbo.{nameof(ConsoleApp.DAL.EntityFactory.EntityContextSql.ObjectTests)}");
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
