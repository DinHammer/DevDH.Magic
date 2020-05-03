using System;
using System.Collections.Generic;
using System.Text;
using entityFactory = DevDH.Magic.DAL.EntityFactory;

namespace DevDH.Magic.DAL.RepositorySql
{
    public static class RepositorySql
    {
        public static void Init(entityFactory.IEntityContextFactory contextFactory)
        {
            ActionSimple = new Action.ActionSimple(contextFactory);
            ActionSql = new Action.ActionSql(contextFactory);
        }

        public static IActionSimple ActionSimple { get; private set; }
        public static IActionSql ActionSql { get; private set; }
    }
}
