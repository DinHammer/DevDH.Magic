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
        public Task<RequestResult<T>> mgcAsncAdd(T data) => dalRepositorySql.ActionSimple.mgcAsncAdd<T>(data);
        public RequestResult<T> mgcAdd(T data) => dalRepositorySql.ActionSimple.mgcAdd<T>(data);

        public Task<RequestResult> mgcAsncAddRange(List<T> data) => dalRepositorySql.ActionSimple.mgcAsncAddRange<T>(data);
        public RequestResult mgcAddRange(List<T> data) => dalRepositorySql.ActionSimple.mgcAddRange<T>(data);

        public Task<RequestResult> mgcAsncUpdate(T data) => dalRepositorySql.ActionSimple.mgcAsncUpdate<T>(data);
        public RequestResult mgcUpdate(T data) => dalRepositorySql.ActionSimple.mgcUpdate<T>(data);

        public Task<RequestResult> mgcAsncUpdateRange(List<T> data) => dalRepositorySql.ActionSimple.mgcAsncUpdateRange<T>(data);
        public RequestResult mgcUpdateRange(List<T> data) => dalRepositorySql.ActionSimple.mgcUpdateRange<T>(data);

        public Task<RequestResult> mgcAsncDelete(T data) => dalRepositorySql.ActionSimple.mgcAsncDelete<T>(data);
        public RequestResult mgcDelete(T data) => dalRepositorySql.ActionSimple.mgcDelete<T>(data);

        public Task<RequestResult> mgcAsncDeleteRange(List<T> data) => dalRepositorySql.ActionSimple.mgcAsncDeleteRange<T>(data);
        public RequestResult mgcDeleteRange(List<T> data) => dalRepositorySql.ActionSimple.mgcDeleteRange<T>(data);

        public Task<RequestResult> mgcAsncDeleteById(int id) => dalRepositorySql.ActionSimple.mgcAsncDeleteById<T>(id);
        public RequestResult mgcDeleteById(int id) => dalRepositorySql.ActionSimple.mgcDeleteById<T>(id);

        public Task<RequestResult> mgcAsncDeleteByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcAsncDeleteByQuery<T>(predicate);
        public RequestResult mgcDeleteByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcDeleteByQuery<T>(predicate);

        public Task<RequestResult> mgcAsncDeleteAll() => dalRepositorySql.ActionSimple.mgcAsncDeleteAll<T>();
        public RequestResult mgcDeleteAll() => dalRepositorySql.ActionSimple.mgcDeleteAll<T>();

        public Task<RequestResult<List<T>>> mgcAsncGetAll() => dalRepositorySql.ActionSimple.mgcAsncGetAll<T>();
        public RequestResult<List<T>> mgcGetAll() => dalRepositorySql.ActionSimple.mgcGetAll<T>();

        public Task<RequestResult<Tuple<int>>> mgcAsncGetCount() => dalRepositorySql.ActionSimple.mgcAsncGetCount<T>();
        public RequestResult<Tuple<int>> mgcGetCount() => dalRepositorySql.ActionSimple.mgcGetCount<T>();

        public Task<RequestResult<List<T>>> mgcAsncGetByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcAsncGetByQuery<T>(predicate);
        public RequestResult<List<T>> mgcGetByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcGetByQuery<T>(predicate);

        public Task<RequestResult<T>> mgcAsncGetFirstByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcAsncGetFirstByQuery<T>(predicate);
        public RequestResult<T> mgcGetFirstByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcGetFirstByQuery<T>(predicate);

        public Task<RequestResult<Tuple<bool, T>>> mgcAsncGetFirstByQueryCheckValid(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcAsncGetFirstByQueryCheckValid<T>(predicate);
        public RequestResult<Tuple<bool, T>> mgcGetFirstByQueryCheckValid(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcGetDataFirstByQueryCheckValid<T>(predicate);

        public Task<RequestResult<T>> mgcAsncGetByIdAsync(int id) => dalRepositorySql.ActionSimple.mgcAsncGetById<T>(id);
        public RequestResult<T> mgcGetById(int id) => dalRepositorySql.ActionSimple.mgcGetById<T>(id);

        public Task<RequestResult<Tuple<bool, T>>> mgcAsncGetByIdCheckValid(int id) => dalRepositorySql.ActionSimple.mgcAsncGetByIdAndCheckValid<T>(id);
        public RequestResult<Tuple<bool, T>> mgcGetByIdCheckValid(int id) => dalRepositorySql.ActionSimple.mgcGetByIdAndCheckValid<T>(id);        
    }
}
