using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Abstractions.DataObjects
{
    public class Blog : BaseObjectSql
    {
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
        public BlogImage BlogImage { get; set; }        
    }
}
