using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using constEnums = ConsoleApp.Abstractions.Constants.ConstantEnums;

namespace ConsoleApp.NUnit
{
    public class InitTestDatabase
    {
        public static IEnumerable FixtureParams
        {
            get
            {
                yield return new TestFixtureData(constEnums.TypeDbContext.typeSql);
                yield return new TestFixtureData(constEnums.TypeDbContext.typeSqlite);
            }
        }
    }
}
