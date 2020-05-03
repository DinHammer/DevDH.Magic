using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using dalDatabaseSql = ConsoleApp.DAL.DatabaseSQL.DatabaseSQL;
using dalRepositorySql = DevDH.Magic.DAL.RepositorySql.RepositorySql;
using entityFactory = ConsoleApp.EntityFactory;
using dalDataObjects = ConsoleApp.Abstractions.DataObjects;

namespace ConsoleApp.NUnit
{
    [TestFixture]
    public class TestDatabase : BaseTest
    {
        dalDataObjects.Blog blog1;
        dalDataObjects.Blog blog2;
        dalDataObjects.Blog blog3;

        dalDataObjects.Post post11;
        dalDataObjects.Post post12;
        dalDataObjects.Post post21;

        [OneTimeSetUp]
        public async Task Init()
        {
            dalRepositorySql.Init(new entityFactory.EntityFactory());
            dalDatabaseSql.Init();


            var var_blog1 = await dalDatabaseSql.Blog.AddDataAsync(new dalDataObjects.Blog { Url = "www.ololo.com" });
            SimpleAssert(var_blog1.IsValid);
            blog1 = var_blog1.Data;

            var var_blog2 = await dalDatabaseSql.Blog.AddDataAsync(new dalDataObjects.Blog { Url = "www.pishPish.com" });
            SimpleAssert(var_blog2.IsValid);
            blog2 = var_blog2.Data;

            var var_blog3 = await dalDatabaseSql.Blog.AddDataAsync(new dalDataObjects.Blog { Url = "www.ololoPishPish.com" });
            SimpleAssert(var_blog3.IsValid);
            blog3 = var_blog3.Data;


            var var_post11 = await dalDatabaseSql.Post.AddDataAsync(new dalDataObjects.Post { Content = "post11", IdBlog = blog1.Id });
            SimpleAssert(var_post11.IsValid);
            post11 = var_post11.Data;

            var var_post12 = await dalDatabaseSql.Post.AddDataAsync(new dalDataObjects.Post { Content = "post12", IdBlog = blog1.Id });
            SimpleAssert(var_post12.IsValid);
            post12 = var_post12.Data;

            var var_post21 = await dalDatabaseSql.Post.AddDataAsync(new dalDataObjects.Post { Content = "post21", IdBlog = blog2.Id });
            SimpleAssert(var_post21.IsValid);
            post21 = var_post21.Data;
        }

        [Test]        
        public async Task TestGetAllBlog()
        {
            var result = await dalDatabaseSql.Blog.GetDataAllAsunc();
            SimpleAssert(result.IsValid);
        }

        [OneTimeTearDown]
        public async Task CleanUp()
        {
            var var_blog1 = await dalDatabaseSql.Blog.DeleteByIdAsync(blog1.Id);
            SimpleAssert(var_blog1.IsValid);

            var var_blog2 = await dalDatabaseSql.Blog.DeleteByIdAsync(blog2.Id);
            SimpleAssert(var_blog2.IsValid);

            var var_blog3 = await dalDatabaseSql.Blog.DeleteByIdAsync(blog3.Id);
            SimpleAssert(var_blog3.IsValid);

            var var_post11 = await dalDatabaseSql.Post.DeleteByIdAsync(post11.Id);
            SimpleAssert(var_post11.IsValid);

            var var_post12 = await dalDatabaseSql.Post.DeleteByIdAsync(post12.Id);
            SimpleAssert(var_post12.IsValid);

            var var_post21 = await dalDatabaseSql.Post.DeleteByIdAsync(post21.Id);
            SimpleAssert(var_post21.IsValid);
        }
    }
}
