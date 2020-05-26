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
    public class ActionSimple : ActionBase, IActionSimple
    {
        public ActionSimple(entityFactory.IEntityContextFactory contextFactory) : base(contextFactory)
        {

        }


        #region Add
        public Task<RequestResult<T>> AddDataAsync<T>(T data) where T : class, dalDataObjects.IBaseObjectId
        => Task.Run(() => { return AddData<T>(data); });
        public RequestResult<T> AddData<T>(T data) where T : class, dalDataObjects.IBaseObjectId
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


        public Task<RequestResult> AddDataRangeAsync<T>(List<T> data) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return AddDataRange<T>(data); });
        public RequestResult AddDataRange<T>(List<T> data) where T : class, dalDataObjects.IBaseObjectId
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
        public Task<RequestResult> UpdateDataAsync<T>(T data) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return UpdateData<T>(data); });
        public RequestResult UpdateData<T>(T data) where T : class, dalDataObjects.IBaseObjectId
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


        public Task<RequestResult> UpdateDataRangeAsync<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return UpdateDataRange<T>(items); });
        public RequestResult UpdateDataRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
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
        public Task<RequestResult> DeleteAsync<T>(T item) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return Delete<T>(item); });
        public RequestResult Delete<T>(T item) where T : class, dalDataObjects.IBaseObjectId
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


        public Task<RequestResult> DeleteRangeAsync<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return DeleteRange<T>(items); });
        public RequestResult DeleteRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
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


        public Task<RequestResult> DeleteByIdAsync<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return DeleteById<T>(id); });
        public RequestResult DeleteById<T>(int id) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                var resultTmp = GetDataById<T>(id);
                if (!resultTmp.IsValid)
                {
                    return new RequestResult(resultTmp.Status, resultTmp.Message);
                }

                return Delete<T>(resultTmp.Data);
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> DeleteByQueryAsync<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return DeleteByQuery<T>(predicate); });
        public RequestResult DeleteByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {

                var resultTmp = GetDataByQuery<T>(predicate);
                if (!resultTmp.IsValid)
                {
                    return new RequestResult(resultTmp.Status, resultTmp.Message);
                }

                return DeleteRange<T>(resultTmp.Data);
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> DeleteAllAsync<T>() where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return DeleteAll<T>(); });
        public RequestResult DeleteAll<T>() where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                var tmpAll = GetDataAll<T>();
                if (!tmpAll.IsValid)
                {
                    return new RequestResult(tmpAll.Status, tmpAll.Message);
                }

                return DeleteRange<T>(tmpAll.Data);
            }
            catch (Exception ex)
            {
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }

        #endregion

        #region Get

        public Task<RequestResult<List<T>>> GetDataAllAsunc<T>() where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return GetDataAll<T>(); });
        public RequestResult<List<T>> GetDataAll<T>() where T : class, dalDataObjects.IBaseObjectId
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


        public Task<RequestResult<Tuple<int>>> GetCountAsync<T>() where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return GetCount<T>(); });
        public RequestResult<Tuple<int>> GetCount<T>() where T : class, dalDataObjects.IBaseObjectId
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


        public Task<RequestResult<List<T>>> GetDataByQueryAsync<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return GetDataByQuery<T>(predicate); });
        public RequestResult<List<T>> GetDataByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
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


        public Task<RequestResult<T>> GetDataFirstByQueryAsync<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return GetDataFirstByQuery<T>(predicate); });
        public RequestResult<T> GetDataFirstByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
        {
            T result = default;
            try
            {
                using (var context = GetMyContext())
                {

                    var resultTmp = GetDataByQuery<T>(predicate);
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


        public Task<RequestResult<Tuple<bool, T>>> GetDataFirstByQueryCheckValidAsync<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return GetDataFirstByQueryCheckValid<T>(predicate); });
        public RequestResult<Tuple<bool, T>> GetDataFirstByQueryCheckValid<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {
                    var resultTmp = GetDataFirstByQuery<T>(predicate);

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


        public Task<RequestResult<T>> GetDataByIdAsunc<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return GetDataById<T>(id); });
        public RequestResult<T> GetDataById<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => GetDataFirstByQuery<T>(x => x.id == id);


        public Task<RequestResult<Tuple<bool, T>>> GetDataByIdAndCheckValidAsunc<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return GetDataByIdAndCheckValid<T>(id); });
        public RequestResult<Tuple<bool, T>> GetDataByIdAndCheckValid<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => GetDataFirstByQueryCheckValid<T>(x => x.id == id);

        #endregion
    }
}
