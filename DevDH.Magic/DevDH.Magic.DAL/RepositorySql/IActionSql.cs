using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dalDataObjects = DevDH.Magic.Abstractions.DataObjects;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.Common;

namespace DevDH.Magic.DAL.RepositorySql
{
    public interface IActionSql
    {
        
        Task<RequestResult<DbContext>> GetDbContextAsync();
        RequestResult<DbContext> GetDbContext();

        /// <summary>
        /// Читаем табличку в виде DataTable
        /// </summary>
        /// <param name="stringCmd"></param>
        /// <returns></returns>
        //Task<RequestResult<Tuple<bool, DataTable>>> GetDataTableByCmdAsync(string stringCmd, List<DbParameterCollection> dbParameterCollections = null);
        //RequestResult<Tuple<bool, DataTable>> GetDataTableByCmd(string stringCmd, List<DbParameterCollection> dbParameterCollections = null);

        /// <summary>
        /// Читаем табличку в виде DbDataReader
        /// </summary>
        /// <param name="stringCmd"></param>
        /// <returns></returns>
        //Task<RequestResult<Tuple<bool, DbDataReader>>> GetDbDataReaderByCmdAsync(string stringCmd, List<DbParameterCollection> dbParameterCollections = null);
        //RequestResult<Tuple<bool, DbDataReader>> GetDbDataReaderByCmd(string stringCmd, List<DbParameterCollection> dbParameterCollections = null);
    }
}
