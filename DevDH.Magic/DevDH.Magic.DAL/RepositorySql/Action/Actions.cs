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

namespace DevDH.Magic.DAL.RepositorySql.Action
{    
    #region ActionSimple
    public class ActionSimple : BaseAction, IActionSimple
    {
        public ActionSimple(entityFactory.IEntityContextFactory contextFactory) : base(contextFactory)
        {

        }


        #region Add
        public Task<RequestResult<T>> mgcAsncAdd<T>(T data) where T : class, dalDataObjects.IBaseObjectId
        => Task.Run(() => { return mgcSncAdd<T>(data); });
        public RequestResult<T> mgcSncAdd<T>(T data) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {

                    context.Set<T>().Add(data);
                    context.SaveChanges();

                    return new RequestResult<T>(data, statusOk);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<T>(data, statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> mgcAsncAddRange<T>(List<T> data) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncAddRange<T>(data); });
        public RequestResult mgcSncAddRange<T>(List<T> data) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {
                    context.Set<T>().AddRange(data);
                    context.SaveChanges();

                    return new RequestResult(statusOk);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }
        #endregion

        #region Update
        public Task<RequestResult> mgcAsncUpdate<T>(T data) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncUpdate<T>(data); });
        public RequestResult mgcSncUpdate<T>(T data) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {
                    context.Set<T>().Update(data);
                    context.SaveChanges();

                    return new RequestResult(statusOk);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> mgcAsncUpdateRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncUpdateRange<T>(items); });
        public RequestResult mgcSncUpdateRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {
                    context.Set<T>().UpdateRange(items);
                    context.SaveChanges();

                    return new RequestResult(statusOk);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }
        #endregion

        #region Delete
        public Task<RequestResult> mgcAsncDelete<T>(T item) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncDelete<T>(item); });
        public RequestResult mgcSncDelete<T>(T item) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {
                    context.Set<T>().Remove(item);
                    context.SaveChanges();
                    return new RequestResult(statusOk);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> mgcAsncDeleteRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncDeleteRange<T>(items); });
        public RequestResult mgcSncDeleteRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {
                    context.Set<T>().RemoveRange(items);
                    context.SaveChanges();
                    return new RequestResult(statusOk);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> mgcAsncDeleteById<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncDeleteById<T>(id); });
        public RequestResult mgcSncDeleteById<T>(int id) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                var resultTmp = mgcSncGetById<T>(id);
                if (!resultTmp.IsValid)
                {
                    return new RequestResult(resultTmp.Status, resultTmp.Message);
                }

                return mgcSncDelete<T>(resultTmp.Data);
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> mgcAsncDeleteByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncDeleteByQuery<T>(predicate); });
        public RequestResult mgcSncDeleteByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {

                var resultTmp = mgcSncGetByQuery<T>(predicate);
                if (!resultTmp.IsValid)
                {
                    return new RequestResult(resultTmp.Status, resultTmp.Message);
                }

                return mgcSncDeleteRange<T>(resultTmp.Data);
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> mgcAsncDeleteAll<T>() where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncDeleteAll<T>(); });
        public RequestResult mgcSncDeleteAll<T>() where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                var tmpAll = mgcSncGetAll<T>();
                if (!tmpAll.IsValid)
                {
                    return new RequestResult(tmpAll.Status, tmpAll.Message);
                }

                return mgcSncDeleteRange<T>(tmpAll.Data);
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }

        #endregion

        #region Get

        public Task<RequestResult<List<T>>> mgcAsncGetAll<T>() where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncGetAll<T>(); });
        public RequestResult<List<T>> mgcSncGetAll<T>() where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {
                    List<T> result = context.Set<T>().ToList();
                    return new RequestResult<List<T>>(result, statusOk);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<List<T>>(null, statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult<Tuple<int>>> mgcAsncGetCount<T>() where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncGetCount<T>(); });
        public RequestResult<Tuple<int>> mgcSncGetCount<T>() where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {
                    int count = context.Set<T>().Count();

                    return new RequestResult<Tuple<int>>(Tuple.Create(count), statusOk);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<Tuple<int>>(null, statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult<List<T>>> mgcAsncGetByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncGetByQuery<T>(predicate); });
        public RequestResult<List<T>> mgcSncGetByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
        {
            List<T> result = new List<T>();
            try
            {
                using (var context = GetMyContext())
                {
                    IQueryable<T> query = context.Set<T>().Where(predicate);

                    result = query.ToList();
                    return new RequestResult<List<T>>(result, statusOk);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<List<T>>(result, statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult<T>> mgcAsncGetFirstByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncGetFirstByQuery<T>(predicate); });
        public RequestResult<T> mgcSncGetFirstByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
        {
            T result = default;
            try
            {
                using (var context = GetMyContext())
                {

                    var resultTmp = mgcSncGetByQuery<T>(predicate);
                    if (!resultTmp.IsValid)
                    {
                        return new RequestResult<T>(result, resultTmp.Status, resultTmp.Message, resultTmp.ExceptionList);
                    }

                    int count = resultTmp.Data.Count;

                    if (count == 1)
                    {
                        result = resultTmp.Data.First();
                        return new RequestResult<T>(result, statusOk);
                    }
                    else if (count == 0)
                    {
                        return new RequestResult<T>(result, statusNoContent);
                    }
                    else
                    {
                        return new RequestResult<T>(result, statusNotOneValue);
                    }

                }
            }
            catch (Exception ex)
            {
                return new RequestResult<T>(result, statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult<Tuple<bool, T>>> mgcAsncGetFirstByQueryCheckValid<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncGetFirstByQueryCheckValid<T>(predicate); });
        public RequestResult<Tuple<bool, T>> mgcSncGetFirstByQueryCheckValid<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {
                    var resultTmp = mgcSncGetFirstByQuery<T>(predicate);

                    switch (resultTmp.Status)
                    {
                        case RequestStatus.Ok:
                            return new RequestResult<Tuple<bool, T>>(Tuple.Create(true, resultTmp.Data), statusOk);
                        case RequestStatus.NoContent:
                            return new RequestResult<Tuple<bool, T>>(Tuple.Create(false, resultTmp.Data), statusOk);
                        default:
                            return new RequestResult<Tuple<bool, T>>(null, resultTmp.Status, resultTmp.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<Tuple<bool, T>>(Tuple.Create(false, default(T)), statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult<T>> mgcAsncGetById<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncGetById<T>(id); });
        public RequestResult<T> mgcSncGetById<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => mgcSncGetFirstByQuery<T>(x => x.id == id);


        public Task<RequestResult<Tuple<bool, T>>> mgcAsncGetByIdAndCheckValid<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcSncGetByIdAndCheckValid<T>(id); });
        public RequestResult<Tuple<bool, T>> mgcSncGetByIdAndCheckValid<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => mgcSncGetFirstByQueryCheckValid<T>(x => x.id == id);

        #endregion
    }
    #endregion

    #region ActionSql
    public class ActionSql : BaseAction, IActionSql
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
    #endregion
}
