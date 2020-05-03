using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Abstractions.DataObjects
{
    public class BlogImage : BaseObjectSql
    {        
        public byte[] Image { get; set; }
        public string Caption { get; set; }

        public int IdBlog { get; set; }
        public Blog Blog { get; set; }
    }
}
