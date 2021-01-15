using System;
using System.Collections.Generic;
using System.Text;
using dalDataObjects = DevDH.Magic.Abstractions.DataObjects;
using System.Threading.Tasks;
using DevDH.Magic.Abstractions;
//using dalDatabaseSql = Example.DatabaseSQL.DatabaseSQL;
using dalRepositorySql = DevDH.Magic.DAL.RepositorySql.RepositorySql;
using System.Linq.Expressions;
using ConstantBase = DevDH.Magic.Abstractions.Constants.ConstantBase;

namespace DevDH.Magic.DAL.RepositorySqlBaseAction
{
    public class BaseAction : ConstantBase
    { }

    public class BaseAction<T> : BaseAction, IBaseAction<T> where T : class, dalDataObjects.IBaseObjectId
    {
        public Task<RequestResult<T>> mgcAddAsnc(T data) => dalRepositorySql.ActionSimple.mgcAddAsnc<T>(data);
        public RequestResult<T> mgcAdd(T data) => dalRepositorySql.ActionSimple.mgcAdd<T>(data);

        public Task<RequestResult> mgcAddRangeAsnc(List<T> data) => dalRepositorySql.ActionSimple.mgcAddRangeAsnc<T>(data);
        public RequestResult mgcAddRange(List<T> data) => dalRepositorySql.ActionSimple.mgcAddRange<T>(data);

        public Task<RequestResult> mgcUpdateAsnc(T data) => dalRepositorySql.ActionSimple.mgcUpdateAsnc<T>(data);
        public RequestResult mgcUpdate(T data) => dalRepositorySql.ActionSimple.mgcUpdate<T>(data);

        public Task<RequestResult> mgcUpdateRangeAsnc(List<T> data) => dalRepositorySql.ActionSimple.mgcUpdateRangeAsnc<T>(data);
        public RequestResult mgcUpdateRange(List<T> data) => dalRepositorySql.ActionSimple.mgcUpdateRange<T>(data);

        public Task<RequestResult> mgcDeleteAsnc(T data) => dalRepositorySql.ActionSimple.mgcDeleteAsnc<T>(data);
        public RequestResult mgcDelete(T data) => dalRepositorySql.ActionSimple.mgcDelete<T>(data);

        public Task<RequestResult> mgcDeleteRangeAsnc(List<T> data) => dalRepositorySql.ActionSimple.mgcDeleteRangeAsnc<T>(data);
        public RequestResult mgcDeleteRange(List<T> data) => dalRepositorySql.ActionSimple.mgcDeleteRange<T>(data);

        public Task<RequestResult> mgcDeleteByIdAsnc(int id) => dalRepositorySql.ActionSimple.mgcDeleteByIdAsnc<T>(id);
        public RequestResult mgcDeleteById(int id) => dalRepositorySql.ActionSimple.mgcDeleteById<T>(id);

        public Task<RequestResult> mgcDeleteByQueryAsnc(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcDeleteByQueryAsnc<T>(predicate);
        public RequestResult mgcDeleteByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcDeleteByQuery<T>(predicate);

        public Task<RequestResult> mgcDeleteAllAsnc() => dalRepositorySql.ActionSimple.mgcDeleteAllAsnc<T>();
        public RequestResult mgcDeleteAll() => dalRepositorySql.ActionSimple.mgcDeleteAll<T>();

        public Task<RequestResult<List<T>>> mgcGetAllAsnc() => dalRepositorySql.ActionSimple.mgcGetAllAsnc<T>();
        public RequestResult<List<T>> mgcGetAll() => dalRepositorySql.ActionSimple.mgcGetAll<T>();

        public Task<RequestResult<dalDataObjects.MgcInt>> mgcGetCountAsnc() => dalRepositorySql.ActionSimple.mgcGetCountAsnc<T>();
        public RequestResult<dalDataObjects.MgcInt> mgcGetCount() => dalRepositorySql.ActionSimple.mgcGetCount<T>();

        public Task<RequestResult<List<T>>> mgcGetByQueryAsnc(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcGetByQueryAsnc<T>(predicate);
        public RequestResult<List<T>> mgcGetByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcGetByQuery<T>(predicate);

        public Task<RequestResult<T>> mgcGetFirstByQueryAsnc(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcGetFirstByQueryAsnc<T>(predicate);
        public RequestResult<T> mgcGetFirstByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcGetFirstByQuery<T>(predicate);

        public Task<RequestResult<dalDataObjects.MgcBoolData<T>>> mgcGetFirstByQueryCheckValidAsnc(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcGetFirstByQueryCheckValidAsnc<T>(predicate);
        public RequestResult<dalDataObjects.MgcBoolData<T>> mgcGetFirstByQueryCheckValid(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcGetFirstByQueryCheckValid<T>(predicate);

        public Task<RequestResult<T>> mgcGetByIdAsnc(int id) => dalRepositorySql.ActionSimple.mgcGetByIdAsnc<T>(id);
        public RequestResult<T> mgcGetById(int id) => dalRepositorySql.ActionSimple.mgcGetById<T>(id);

        public Task<RequestResult<dalDataObjects.MgcBoolData<T>>> mgcGetByIdCheckValidAsnc(int id) => dalRepositorySql.ActionSimple.mgcGetByIdAndCheckValidAsnc<T>(id);
        public RequestResult<dalDataObjects.MgcBoolData<T>> mgcGetByIdCheckValid(int id) => dalRepositorySql.ActionSimple.mgcGetByIdAndCheckValid<T>(id);        
    }
}
