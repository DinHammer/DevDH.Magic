using System;
using System.Collections.Generic;
using System.Text;

namespace DevDH.Magic.Abstractions.DataObjects
{
    /// <summary>
    /// Обьект от которого должны наследоваться все Sql обьекты в MsSql датабасе
    /// </summary>
    public interface IObjectSqlBase
    {
        int Id { get; set; }
    }
}
