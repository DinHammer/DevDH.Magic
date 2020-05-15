using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DevDH.Magic.Abstractions.DataObjects
{
    /// <summary>
    /// Обьект от которого должны наследоваться все Sql обьекты в MsSql датабасе
    /// </summary>
    public interface IObjectSqlBase
    {
        [Key]
        int id { get; set; }
    }
}
