using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Abstractions.DataObjects
{
    public class Post : BaseObjectSql
    {        
        public string Title { get; set; }
        public string Content { get; set; }

        public int IdBlog { get; set; }
        public Blog Blog { get; set; }        
    }
}
