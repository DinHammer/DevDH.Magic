using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Abstractions.DataObjects
{
    public class ObjectTest : BaseObjectSql
    {
        public string str_value { get; set; }
    }

    public class Blog : BaseObjectSql
    {
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
        public BlogImage BlogImage { get; set; }
    }

    public class BlogImage : BaseObjectSql
    {
        public byte[] Image { get; set; }
        public string Caption { get; set; }

        public int IdBlog { get; set; }
        public Blog Blog { get; set; }
    }

    public class Post : BaseObjectSql
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int IdBlog { get; set; }
        public Blog Blog { get; set; }
    }
}
