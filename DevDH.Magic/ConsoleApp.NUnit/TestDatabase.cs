using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using dalDatabaseSql = ConsoleApp.DAL.DatabaseSQL.DatabaseSQL;
using dalRepositorySql = DevDH.Magic.DAL.RepositorySql.RepositorySql;
using entityFactory = ConsoleApp.DAL.EntityFactory;
using dalDataObjects = ConsoleApp.Abstractions.DataObjects;
using constEnums = ConsoleApp.Abstractions.Constants.ConstantEnums;

namespace ConsoleApp.NUnit
{
    [TestFixture]
    [TestFixtureSource(typeof(InitTestDatabase), nameof(InitTestDatabase.FixtureParams))]
    public class TestDatabase : BaseTest
    {
        constEnums.TypeDbContext typeDbContext;
        public TestDatabase(constEnums.TypeDbContext typeDbContext)
        {
            this.typeDbContext = typeDbContext;
        }

        dalDataObjects.Blog blog1;
        dalDataObjects.Blog blog2;
        dalDataObjects.Blog blog3;

        dalDataObjects.Post post11;
        dalDataObjects.Post post12;
        dalDataObjects.Post post21;

        [OneTimeSetUp]
        public async Task Init()
        {
            dalRepositorySql.Init(new entityFactory.EntityFactory(typeDbContext));
            dalDatabaseSql.Init();


            var var_blog1 = await dalDatabaseSql.Blog.mgcAddAsnc(new dalDataObjects.Blog { Url = "www.ololo.com" });
            SimpleAssertRequest(var_blog1);
            blog1 = var_blog1.Data;

            var var_blog2 = await dalDatabaseSql.Blog.mgcAddAsnc(new dalDataObjects.Blog { Url = "www.pishPish.com" });
            SimpleAssertRequest(var_blog2);
            blog2 = var_blog2.Data;

            var var_blog3 = await dalDatabaseSql.Blog.mgcAddAsnc(new dalDataObjects.Blog { Url = "www.ololoPishPish.com" });
            SimpleAssertRequest(var_blog3);
            blog3 = var_blog3.Data;


            var var_post11 = await dalDatabaseSql.Post.mgcAddAsnc(new dalDataObjects.Post { Content = "post11", IdBlog = blog1.id });
            SimpleAssertRequest(var_post11);
            post11 = var_post11.Data;

            var var_post12 = await dalDatabaseSql.Post.mgcAddAsnc(new dalDataObjects.Post { Content = "post12", IdBlog = blog1.id });
            SimpleAssertRequest(var_post12);
            post12 = var_post12.Data;

            var var_post21 = await dalDatabaseSql.Post.mgcAddAsnc(new dalDataObjects.Post { Content = "post21", IdBlog = blog2.id });
            SimpleAssertRequest(var_post21);
            post21 = var_post21.Data;
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void TestInsertData(int int_id)
        {
            var result = dalDatabaseSql.ObjectTest.InsetObject(new dalDataObjects.ObjectTest { id = int_id, str_value = $"int_value_{int_id}" });
            SimpleAssertRequest(result);
        }

        [Test]
        [TestCase(10)]        
        public void TestInsertDataRange(int int_count)
        {
            List<dalDataObjects.ObjectTest> list = new List<dalDataObjects.ObjectTest>();
            dalDataObjects.ObjectTest objectTest = null;
            for (int i = 1; i < int_count; i++)
            {
                objectTest = new dalDataObjects.ObjectTest { id = i, str_value = $"int_value_{i}" };
                list.Add(objectTest);
            }

            var result = dalDatabaseSql.ObjectTest.InsetObjectRange(list);
            SimpleAssertRequest(result);
        }

        [Test]
        [TestCase(10)]
        public void TestInsertOrUpdateDataRange(int int_count)
        {
            List<dalDataObjects.ObjectTest> list = new List<dalDataObjects.ObjectTest>();
            dalDataObjects.ObjectTest objectTest = null;
            for (int i = 1; i < int_count; i++)
            {
                objectTest = new dalDataObjects.ObjectTest { id = i, str_value = $"{i}_int_value_{i+1}" };
                list.Add(objectTest);
            }

            var result = dalDatabaseSql.ObjectTest.InsetOrUpdateObjectRange(list);
            SimpleAssertRequest(result);
        }

        [Test]        
        public async Task TestGetAllBlog()
        {
            var result = await dalDatabaseSql.Blog.mgcGetAllAsnc();
            SimpleAssertRequest(result);
        }

        [OneTimeTearDown]
        public async Task CleanUp()
        {
            var var_blog1 = await dalDatabaseSql.Blog.mgcDeleteByIdAsnc(blog1.id);
            SimpleAssert(var_blog1.IsValid);

            var var_blog2 = await dalDatabaseSql.Blog.mgcDeleteByIdAsnc(blog2.id);
            SimpleAssert(var_blog2.IsValid);

            var var_blog3 = await dalDatabaseSql.Blog.mgcDeleteByIdAsnc(blog3.id);
            SimpleAssert(var_blog3.IsValid);

            var var_post11 = await dalDatabaseSql.Post.mgcDeleteByIdAsnc(post11.id);
            SimpleAssert(var_post11.IsValid);

            var var_post12 = await dalDatabaseSql.Post.mgcDeleteByIdAsnc(post12.id);
            SimpleAssert(var_post12.IsValid);

            var var_post21 = await dalDatabaseSql.Post.mgcDeleteByIdAsnc(post21.id);
            SimpleAssert(var_post21.IsValid);
        }
    }
}
