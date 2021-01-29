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
        public Task<RequestResult<T>> mgcAddAsnc<T>(T data) where T : class, dalDataObjects.IBaseObjectId
        => Task.Run(() => { return mgcAdd<T>(data); });
        public RequestResult<T> mgcAdd<T>(T data) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult<T>(data, statusDatabaseError, ex.Message, ex);
            }
        }


        public Task<RequestResult> mgcAddRangeAsnc<T>(List<T> data) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcAddRange<T>(data); });
        public RequestResult mgcAddRange<T>(List<T> data) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, ex);
            }
        }
        #endregion

        #region Update
        public Task<RequestResult> mgcUpdateAsnc<T>(T data) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcUpdate<T>(data); });
        public RequestResult mgcUpdate<T>(T data) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, ex);
            }
        }


        public Task<RequestResult> mgcUpdateRangeAsnc<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcUpdateRange<T>(items); });
        public RequestResult mgcUpdateRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, ex);
            }
        }
        #endregion

        #region Delete
        public Task<RequestResult> mgcDeleteAsnc<T>(T item) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcDelete<T>(item); });
        public RequestResult mgcDelete<T>(T item) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, ex);
            }
        }


        public Task<RequestResult> mgcDeleteRangeAsnc<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcDeleteRange<T>(items); });
        public RequestResult mgcDeleteRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, ex);
            }
        }


        public Task<RequestResult> mgcDeleteByIdAsnc<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcDeleteById<T>(id); });
        public RequestResult mgcDeleteById<T>(int id) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                var resultTmp = mgcGetById<T>(id);
                if (!resultTmp.IsValid)
                {
                    return new RequestResult(resultTmp.Status, resultTmp.Message);
                }

                return mgcDelete<T>(resultTmp.Data);
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, ex);
            }
        }


        public Task<RequestResult> mgcDeleteByQueryAsnc<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcDeleteByQuery<T>(predicate); });
        public RequestResult mgcDeleteByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {

                var resultTmp = mgcGetByQuery<T>(predicate);
                if (!resultTmp.IsValid)
                {
                    return new RequestResult(resultTmp.Status, resultTmp.Message);
                }

                return mgcDeleteRange<T>(resultTmp.Data);
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, ex);
            }
        }


        public Task<RequestResult> mgcDeleteAllAsnc<T>() where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcDeleteAll<T>(); });
        public RequestResult mgcDeleteAll<T>() where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                var tmpAll = mgcGetAll<T>();
                if (!tmpAll.IsValid)
                {
                    return new RequestResult(tmpAll.Status, tmpAll.Message);
                }

                return mgcDeleteRange<T>(tmpAll.Data);
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, ex);
            }
        }

        #endregion

        #region Get

        public Task<RequestResult<List<T>>> mgcGetAllAsnc<T>() where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcGetAll<T>(); });
        public RequestResult<List<T>> mgcGetAll<T>() where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult<List<T>>(null, statusDatabaseError, ex.Message, ex);
            }
        }


        public Task<RequestResult<dalDataObjects.MgcInt>> mgcGetCountAsnc<T>() where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcGetCount<T>(); });
        public RequestResult<dalDataObjects.MgcInt> mgcGetCount<T>() where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {
                    int count = context.Set<T>().Count();

                    return new RequestResult<dalDataObjects.MgcInt>(new dalDataObjects.MgcInt(count), statusOk);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dalDataObjects.MgcInt>(null, statusDatabaseError, ex.Message, ex);
            }
        }


        public Task<RequestResult<List<T>>> mgcGetByQueryAsnc<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcGetByQuery<T>(predicate); });
        public RequestResult<List<T>> mgcGetByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult<List<T>>(result, statusDatabaseError, ex.Message, ex);
            }
        }


        public Task<RequestResult<T>> mgcGetFirstByQueryAsnc<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcGetFirstByQuery<T>(predicate); });
        public RequestResult<T> mgcGetFirstByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
        {
            T result = default;
            try
            {
                using (var context = GetMyContext())
                {

                    var resultTmp = mgcGetByQuery<T>(predicate);
                    if (!resultTmp.IsValid)
                    {
                        return new RequestResult<T>(result, resultTmp.Status, resultTmp.Message, resultTmp.exception);
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
                return new RequestResult<T>(result, statusDatabaseError, ex.Message, ex);
            }
        }


        public Task<RequestResult<dalDataObjects.MgcBoolData<T>>> mgcGetFirstByQueryCheckValidAsnc<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcGetFirstByQueryCheckValid<T>(predicate); });
        public RequestResult<dalDataObjects.MgcBoolData<T>> mgcGetFirstByQueryCheckValid<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {
                    var resultTmp = mgcGetFirstByQuery<T>(predicate);

                    switch (resultTmp.Status)
                    {
                        case RequestStatus.Ok:
                            return new RequestResult<dalDataObjects.MgcBoolData<T>>(new dalDataObjects.MgcBoolData<T>(true, resultTmp.Data), statusOk);
                        case RequestStatus.NoContent:
                            return new RequestResult<dalDataObjects.MgcBoolData<T>>(new dalDataObjects.MgcBoolData<T>(false, resultTmp.Data), statusOk);
                        default:
                            return new RequestResult<dalDataObjects.MgcBoolData<T>>(null, resultTmp.Status, resultTmp.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dalDataObjects.MgcBoolData<T>>(new dalDataObjects.MgcBoolData<T>(false, default(T)), statusDatabaseError, ex.Message, ex);
            }
        }


        public Task<RequestResult<T>> mgcGetByIdAsnc<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcGetById<T>(id); });
        public RequestResult<T> mgcGetById<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => mgcGetFirstByQuery<T>(x => x.id == id);


        public Task<RequestResult<dalDataObjects.MgcBoolData<T>>> mgcGetByIdAndCheckValidAsnc<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcGetByIdAndCheckValid<T>(id); });
        public RequestResult<dalDataObjects.MgcBoolData<T>> mgcGetByIdAndCheckValid<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => mgcGetFirstByQueryCheckValid<T>(x => x.id == id);

        #endregion
    }
    #endregion

    #region ActionSql
    public class ActionSql : BaseAction, IActionSql
    {
        public ActionSql(entityFactory.IEntityContextFactory contextFactory) : base(contextFactory)
        {

        }

        public Task<DbContext> mgcGetDbContextAsync()
            => Task.Run(() => { return mgcGetDbContext(); });
        public DbContext mgcGetDbContext() => GetMyContext();

        #region DeleteDatabase
        public RequestResult mgcDeleteDataAllInDatabase()
        {
            try
            {
                using (var var_context = mgcGetDbContext())
                {
                    var_context.Database.EnsureDeleted();
                }
            }
            catch (Exception ex)
            {
                return new RequestResult(statusOk, ex.Message, ex);
            }

            return new RequestResult(statusOk);
        }
        #endregion

        #region InsertOrUpdate
        public Task<RequestResult> mgcInsertOrUpdateAsnc<T>(T item, string str_table_name) where T : class, dalDataObjects.IBaseObjectId
            => mgcInsertOrUpdateRangeAsnc<T>(new List<T> { item }, str_table_name);
        public RequestResult mgcInsertOrUpdate<T>(T item, string str_table_name) where T : class, dalDataObjects.IBaseObjectId
            => mgcInsertOrUpdateRange<T>(new List<T> { item }, str_table_name);
        #endregion

        #region InsertOrUpdateRange
        public Task<RequestResult> mgcInsertOrUpdateRangeAsnc<T>(List<T> items, string str_table_name) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcInsertOrUpdateRange<T>(items, str_table_name); });
        public RequestResult mgcInsertOrUpdateRange<T>(List<T> items, string str_table_name) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var var_context = mgcGetDbContext())
                {
                    int int_count = items.Count;
                    for (int i = 0; i < int_count; i++)
                    {
                        var var_tmp = items[i];

                        var var_data = var_context.Set<T>().Where(x => x.id == var_tmp.id).FirstOrDefault();
                        if (var_data == null)
                        {
                            var_context.Set<T>().Add(var_tmp);
                        }
                        else
                        {
                            var_context.Entry<T>(var_tmp).State = EntityState.Deleted;
                            var_context.Set<T>().Update(var_tmp);
                            
                        }
                    }                    

                    var_context.Database.OpenConnection();
                    try
                    {
                        var_context.Database.ExecuteSqlRaw(prtcGetIdentityInsertOn(str_table_name));
                        var_context.SaveChanges();
                        var_context.Database.ExecuteSqlRaw(prtcGetIdentityInsertOff(str_table_name));
                    }
                    catch (Exception ex)
                    {
                        return new RequestResult(statusDatabaseError, ex.Message, ex);
                    }
                    finally
                    {
                        var_context.Database.CloseConnection();
                    }
                }
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, ex);
            }

            return new RequestResult(statusOk);
        }
        #endregion

        #region Insert
        public Task<RequestResult> mgcInsertAsnc<T>(T item, string str_table_name) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcInsert<T>(item, str_table_name); });
        public RequestResult mgcInsert<T>(T item, string str_table_name) where T : class, dalDataObjects.IBaseObjectId
            => mgcInsertRange<T>(new List<T> { item }, str_table_name);        
        #endregion

        #region InsertRange
        public Task<RequestResult> mgcInsertRangeAsnc<T>(List<T> items, string str_table_name) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcInsertRange<T>(items, str_table_name); });
        public RequestResult mgcInsertRange<T>(List<T> items, string str_table_name) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var var_context = mgcGetDbContext())
                {
                    foreach (var item in items)
                    {
                        var_context.Set<T>().Add(item);
                    }
                    
                    var_context.Database.OpenConnection();
                    try
                    {
                        var_context.Database.ExecuteSqlRaw(prtcGetIdentityInsertOn(str_table_name));
                        var_context.SaveChanges();
                        var_context.Database.ExecuteSqlRaw(prtcGetIdentityInsertOff(str_table_name));
                    }
                    catch (Exception ex)
                    {
                        return new RequestResult(statusDatabaseError, ex.Message, ex);
                    }
                    finally
                    {
                        var_context.Database.CloseConnection();
                    }
                }
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, ex);
            }

            return new RequestResult(statusOk);
        }
        #endregion


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
