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
        public RequestResult<T> mgcSncAdd(T data) => dalRepositorySql.ActionSimple.mgcSncAdd<T>(data);

        public Task<RequestResult> mgcAsncAddRange(List<T> data) => dalRepositorySql.ActionSimple.mgcAsncAddRange<T>(data);
        public RequestResult mgcSncAddRange(List<T> data) => dalRepositorySql.ActionSimple.mgcSncAddRange<T>(data);

        public Task<RequestResult> mgcAsncUpdate(T data) => dalRepositorySql.ActionSimple.mgcAsncUpdate<T>(data);
        public RequestResult mgcSncUpdate(T data) => dalRepositorySql.ActionSimple.mgcSncUpdate<T>(data);

        public Task<RequestResult> mgcAsncUpdateRange(List<T> data) => dalRepositorySql.ActionSimple.mgcAsncUpdateRange<T>(data);
        public RequestResult mgcSncUpdateRange(List<T> data) => dalRepositorySql.ActionSimple.mgcSncUpdateRange<T>(data);

        public Task<RequestResult> mgcAsncDelete(T data) => dalRepositorySql.ActionSimple.mgcAsncDelete<T>(data);
        public RequestResult mgcSncDelete(T data) => dalRepositorySql.ActionSimple.mgcSncDelete<T>(data);

        public Task<RequestResult> mgcAsncDeleteRange(List<T> data) => dalRepositorySql.ActionSimple.mgcAsncDeleteRange<T>(data);
        public RequestResult mgcSncDeleteRange(List<T> data) => dalRepositorySql.ActionSimple.mgcSncDeleteRange<T>(data);

        public Task<RequestResult> mgcAsncDeleteById(int id) => dalRepositorySql.ActionSimple.mgcAsncDeleteById<T>(id);
        public RequestResult mgcSncDeleteById(int id) => dalRepositorySql.ActionSimple.mgcSncDeleteById<T>(id);

        public Task<RequestResult> mgcAsncDeleteByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcAsncDeleteByQuery<T>(predicate);
        public RequestResult mgcSncDeleteByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcSncDeleteByQuery<T>(predicate);

        public Task<RequestResult> mgcAsncDeleteAll() => dalRepositorySql.ActionSimple.mgcAsncDeleteAll<T>();
        public RequestResult mgcSncDeleteAll() => dalRepositorySql.ActionSimple.mgcSncDeleteAll<T>();

        public Task<RequestResult<List<T>>> mgcAsncGetAll() => dalRepositorySql.ActionSimple.mgcAsncGetAll<T>();
        public RequestResult<List<T>> mgcSncGetAll() => dalRepositorySql.ActionSimple.mgcSncGetAll<T>();

        public Task<RequestResult<Tuple<int>>> mgcAsncGetCount() => dalRepositorySql.ActionSimple.mgcAsncGetCount<T>();
        public RequestResult<Tuple<int>> mgcSncGetCount() => dalRepositorySql.ActionSimple.mgcSncGetCount<T>();

        public Task<RequestResult<List<T>>> mgcAsncGetByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcAsncGetByQuery<T>(predicate);
        public RequestResult<List<T>> mgcSncGetByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcSncGetByQuery<T>(predicate);

        public Task<RequestResult<T>> mgcAsncGetFirstByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcAsncGetFirstByQuery<T>(predicate);
        public RequestResult<T> mgcSncGetFirstByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcSncGetFirstByQuery<T>(predicate);

        public Task<RequestResult<Tuple<bool, T>>> mgcAsncGetFirstByQueryCheckValid(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcAsncGetFirstByQueryCheckValid<T>(predicate);
        public RequestResult<Tuple<bool, T>> mgcSncGetFirstByQueryCheckValid(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.mgcSncGetFirstByQueryCheckValid<T>(predicate);

        public Task<RequestResult<T>> mgcAsncGetById(int id) => dalRepositorySql.ActionSimple.mgcAsncGetById<T>(id);
        public RequestResult<T> mgcSncGetById(int id) => dalRepositorySql.ActionSimple.mgcSncGetById<T>(id);

        public Task<RequestResult<Tuple<bool, T>>> mgcAsncGetByIdCheckValid(int id) => dalRepositorySql.ActionSimple.mgcAsncGetByIdAndCheckValid<T>(id);
        public RequestResult<Tuple<bool, T>> mgcSncGetByIdCheckValid(int id) => dalRepositorySql.ActionSimple.mgcSncGetByIdAndCheckValid<T>(id);        
    }
}
