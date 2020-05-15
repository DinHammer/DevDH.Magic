using System;
using System.Collections.Generic;
using System.Text;

namespace DevDH.Magic.Abstractions.DataObjects
{
    /// <summary>
    /// Обьект наследования для MsSql таблиц
    /// </summary>
    public class BaseObjectSql : IBaseObjectSql
    {
        public int id { get; set; }
    }
}
