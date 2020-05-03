using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.DAL.DatabaseSQL
{
    public static class DatabaseSQL
    {
        public static void Init()
        {
            Database = new Action.ActionDatabase();
            Blog = new Action.ActionBlog();
            BlogImage = new Action.ActionBlogImage();
            Post = new Action.ActionPost();
        }

        public static IActionDatabase Database { get; private set; }
        public static IActionBlog Blog { get; private set; }
        public static IActionBlogImage BlogImage { get; private set; }
        public static IActionPost Post { get; private set; }
    }
}
