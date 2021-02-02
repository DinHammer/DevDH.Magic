using System;
using System.Collections.Generic;
using System.Text;
using dalDataObjects = ConsoleApp.Abstractions.DataObjects;
using coreDataObjects = DevDH.Magic.Abstractions.DataObjects;
using System.Threading.Tasks;
using DevDH.Magic.Abstractions;
using System.Linq.Expressions;

namespace ConsoleApp.DAL.DatabaseSQL
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <see cref="ConsoleApp.DAL.DatabaseSQL.Action.BaseAction">
    public interface IBaseAction<T> : DevDH.Magic.DAL.RepositorySqlBaseAction.IBaseAction<T> where T : class, dalDataObjects.IBaseObjectSql
    { }
    public interface IActionDatabase
    {
        RequestResult DeleteDatabase();
    }

    public interface IActionObjectTest : IBaseAction<dalDataObjects.ObjectTest>
    {
        RequestResult InsetObject(dalDataObjects.ObjectTest objectTest);
        RequestResult InsetObjectRange(List<dalDataObjects.ObjectTest> items);
        //RequestResult InsetOrUpdateObjectRange(List<dalDataObjects.ObjectTest> items);
    }

    public interface IActionBlog : IBaseAction<dalDataObjects.Blog>
    {
    }

    public interface IActionBlogImage : IBaseAction<dalDataObjects.BlogImage>
    {
    }

    public interface IActionPost : IBaseAction<dalDataObjects.Post>
    {
    }
}
