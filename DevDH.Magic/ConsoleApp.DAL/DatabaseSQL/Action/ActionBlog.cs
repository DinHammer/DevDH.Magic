using System;
using System.Collections.Generic;
using System.Text;
using dalDataObjects = ConsoleApp.Abstractions.DataObjects;

namespace ConsoleApp.DAL.DatabaseSQL.Action
{
    public class ActionBlog : BaseAction<dalDataObjects.Blog>, IActionBlog
    {
    }
}
