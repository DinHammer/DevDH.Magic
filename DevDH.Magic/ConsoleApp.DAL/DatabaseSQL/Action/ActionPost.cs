using System;
using System.Collections.Generic;
using System.Text;
using dalDataObjects = ConsoleApp.Abstractions.DataObjects;

namespace ConsoleApp.DAL.DatabaseSQL.Action
{
    public class ActionPost : BaseAction<dalDataObjects.Post>, IActionPost
    {
    }
}
