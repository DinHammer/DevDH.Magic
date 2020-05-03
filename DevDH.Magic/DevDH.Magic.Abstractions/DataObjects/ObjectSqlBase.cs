using System;
using System.Collections.Generic;
using System.Text;

namespace DevDH.Magic.Abstractions.DataObjects
{
    /// <summary>
    /// Обьект наследования для MsSql таблиц
    /// </summary>
    public class ObjectSqlBase : IObjectSqlBase
    {
        public int Id { get; set; }
    }
}
