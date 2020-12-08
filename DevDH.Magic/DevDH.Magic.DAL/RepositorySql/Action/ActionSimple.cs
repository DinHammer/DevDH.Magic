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
        public Task<RequestResult<T>> mgcAsncAdd<T>(T data) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult<T>(data, statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> mgcAsncAddRange<T>(List<T> data) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }
        #endregion

        #region Update
        public Task<RequestResult> mgcAsncUpdate<T>(T data) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> mgcAsncUpdateRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }
        #endregion

        #region Delete
        public Task<RequestResult> mgcAsncDelete<T>(T item) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> mgcAsncDeleteRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> mgcAsncDeleteById<T>(int id) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> mgcAsncDeleteByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult> mgcAsncDeleteAll<T>() where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult(statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }

        #endregion

        #region Get

        public Task<RequestResult<List<T>>> mgcAsncGetAll<T>() where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult<List<T>>(null, statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult<Tuple<int>>> mgcAsncGetCount<T>() where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcGetCount<T>(); });
        public RequestResult<Tuple<int>> mgcGetCount<T>() where T : class, dalDataObjects.IBaseObjectId
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
                return new RequestResult<List<T>>(result, statusDatabaseError, ex.Message, new List<Exception> { ex });
            }
        }


        public Task<RequestResult<T>> mgcAsncGetFirstByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
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
            => Task.Run(() => { return mgcGetDataFirstByQueryCheckValid<T>(predicate); });
        public RequestResult<Tuple<bool, T>> mgcGetDataFirstByQueryCheckValid<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId
        {
            try
            {
                using (var context = GetMyContext())
                {
                    var resultTmp = mgcGetFirstByQuery<T>(predicate);

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
            => Task.Run(() => { return mgcGetById<T>(id); });
        public RequestResult<T> mgcGetById<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => mgcGetFirstByQuery<T>(x => x.id == id);


        public Task<RequestResult<Tuple<bool, T>>> mgcAsncGetByIdAndCheckValid<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => Task.Run(() => { return mgcGetByIdAndCheckValid<T>(id); });
        public RequestResult<Tuple<bool, T>> mgcGetByIdAndCheckValid<T>(int id) where T : class, dalDataObjects.IBaseObjectId
            => mgcGetDataFirstByQueryCheckValid<T>(x => x.id == id);

        #endregion
    }
}
