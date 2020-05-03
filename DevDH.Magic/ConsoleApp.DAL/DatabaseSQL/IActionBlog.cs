using System;
using System.Collections.Generic;
using System.Text;
using dalDataObjects = ConsoleApp.Abstractions.DataObjects;

namespace ConsoleApp.DAL.DatabaseSQL
{
    public interface IActionBlog : IBaseAction<dalDataObjects.Blog>
    {
    }
}
