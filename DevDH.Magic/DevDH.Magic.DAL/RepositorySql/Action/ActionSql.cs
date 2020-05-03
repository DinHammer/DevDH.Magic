using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using entityFactory = DevDH.Magic.DAL.EntityFactory;
using dalDataObjects = DevDH.Magic.Abstractions.DataObjects;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.Common;

namespace DevDH.Magic.DAL.RepositorySql.Action
{
    public class ActionSql : ActionBase, IActionSql
    {
        public ActionSql(entityFactory.IEntityContextFactory contextFactory) : base(contextFactory)
        {

        }

        public Task<RequestResult<DbContext>> GetDbContextAsync()
            => Task.Run(() => { return GetDbContext(); });
        public RequestResult<DbContext> GetDbContext()
        {
            var context = GetMyContext();
            return new RequestResult<DbContext>(context, statusOk);
        }
        //public Task<RequestResult<Tuple<bool, DataTable>>> GetDataTableByCmdAsync(string stringCmd, List<DbParameterCollection> dbParameterCollections = null)
        //    => Task.Run(() => { return GetDataTableByCmd(stringCmd, dbParameterCollections); });
        //public RequestResult<Tuple<bool, DataTable>> GetDataTableByCmd(string stringCmd, List<DbParameterCollection> dbParameterCollections = null)
        //{
        //    try
        //    {
        //        var resultTmp = GetDbDataReaderByCmd(stringCmd);
        //        DataTable dataTable = null;
        //        if (!resultTmp.IsValid)
        //        {
        //            return new RequestResult<Tuple<bool, DataTable>>(null, resultTmp.Status, resultTmp.ExceptionList);
        //        }

        //        bool hasRows = resultTmp.Data.Item1;

        //        if (hasRows)
        //        {
        //            dataTable = resultTmp.Data.Item2.GetSchemaTable();
        //            return new RequestResult<Tuple<bool, DataTable>>(Tuple.Create(true, dataTable), statusOk);
        //        }
        //        else
        //        {
        //            return new RequestResult<Tuple<bool, DataTable>>(Tuple.Create(false, dataTable), statusOk);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new RequestResult<Tuple<bool, DataTable>>(null, statusSomethingWrong, new List<Exception> { ex });
        //    }
        //}

        //public Task<RequestResult<Tuple<bool, DbDataReader>>> GetDbDataReaderByCmdAsync(string stringCmd, List<DbParameterCollection> dbParameterCollections = null)
        //    => Task.Run(() => { return GetDbDataReaderByCmd(stringCmd, dbParameterCollections); });
        //public RequestResult<Tuple<bool, DbDataReader>> GetDbDataReaderByCmd(string stringCmd, List<DbParameterCollection> dbParameterCollections = null)
        //{
        //    DbConnection connection = null;
        //    DbDataReader result = null;
        //    try
        //    {

        //        using (var context = GetMyContext())
        //        {
        //            connection = context.Database.GetDbConnection();
        //            using (var command = connection.CreateCommand())
        //            {

        //                command.CommandText = stringCmd;

        //                if (dbParameterCollections != null || dbParameterCollections?.Count > 0)
        //                {
        //                    foreach (var item in dbParameterCollections)
        //                    {
        //                        command.Parameters.Add(item);
        //                    }
        //                }

        //                //command.Parameters.Add(new SqlParameter("@data_value", System.Data.SqlDbType.NVarChar) { Value = data });

        //                if (connection.State.Equals(ConnectionState.Closed))
        //                {
        //                    connection.Open();
        //                }

        //                result = command.ExecuteReader();

        //                return new RequestResult<Tuple<bool, DbDataReader>>(Tuple.Create(result.HasRows, result), statusOk);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new RequestResult<Tuple<bool, DbDataReader>>(null, statusDatabaseError, new List<Exception> { ex });
        //    }
        //    finally
        //    {
        //        if (connection.State.Equals(ConnectionState.Open))
        //        {
        //            connection.Close();
        //        }
        //    }
        //}
    }
}
