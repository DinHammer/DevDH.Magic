using System;
using System.Collections.Generic;
using System.Text;
using dalDataObjects = ConsoleApp.Abstractions.DataObjects;
using ConstantBase = ConsoleApp.Abstractions.Constants.ConstantBase;
using System.Threading.Tasks;
using DevDH.Magic.Abstractions;
//using dalDatabaseSql = Example.DatabaseSQL.DatabaseSQL;
using dalRepositorySql = DevDH.Magic.DAL.RepositorySql.RepositorySql;
using System.Linq.Expressions;

namespace ConsoleApp.DAL.DatabaseSQL.Action
{
    public class BaseAction : ConstantBase
    { }


    public class BaseAction<T> : DevDH.Magic.DAL.RepositorySqlBaseAction.BaseAction<T>, IBaseAction<T> where T : class, dalDataObjects.IBaseObjectSql
    {
        //public Task<RequestResult<T>> AddDataAsync(T data) => dalRepositorySql.ActionSimple.AddDataAsync<T>(data);
        //public RequestResult<T> AddData(T data) => dalRepositorySql.ActionSimple.AddData<T>(data);

        //public Task<RequestResult> AddDataRangeAsync(List<T> data) => dalRepositorySql.ActionSimple.AddDataRangeAsync<T>(data);
        //public RequestResult AddDataRange(List<T> data) => dalRepositorySql.ActionSimple.AddDataRange<T>(data);

        //public Task<RequestResult> UpdateDataAsync(T data) => dalRepositorySql.ActionSimple.UpdateDataAsync<T>(data);
        //public RequestResult UpdateData(T data) => dalRepositorySql.ActionSimple.UpdateData<T>(data);

        //public Task<RequestResult> UpdateDataRangeAsync(List<T> data) => dalRepositorySql.ActionSimple.UpdateDataRangeAsync<T>(data);
        //public RequestResult UpdateDataRange(List<T> data) => dalRepositorySql.ActionSimple.UpdateDataRange<T>(data);

        //public Task<RequestResult> DeleteAsync(T data) => dalRepositorySql.ActionSimple.DeleteAsync<T>(data);
        //public RequestResult Delete(T data) => dalRepositorySql.ActionSimple.Delete<T>(data);

        //public Task<RequestResult> DeleteRangeAsync(List<T> data) => dalRepositorySql.ActionSimple.DeleteRangeAsync<T>(data);
        //public RequestResult DeleteRange(List<T> data) => dalRepositorySql.ActionSimple.DeleteRange<T>(data);

        //public Task<RequestResult> DeleteByIdAsync(int id) => dalRepositorySql.ActionSimple.DeleteByIdAsync<T>(id);
        //public RequestResult DeleteById(int id) => dalRepositorySql.ActionSimple.DeleteById<T>(id);

        //public Task<RequestResult> DeleteByQueryAsync(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.DeleteByQueryAsync<T>(predicate);
        //public RequestResult DeleteByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.DeleteByQuery<T>(predicate);

        //public Task<RequestResult> DeleteAllAsync() => dalRepositorySql.ActionSimple.DeleteAllAsync<T>();
        //public RequestResult DeleteAll() => dalRepositorySql.ActionSimple.DeleteAll<T>();

        //public Task<RequestResult<List<T>>> GetDataAllAsunc() => dalRepositorySql.ActionSimple.GetDataAllAsunc<T>();
        //public RequestResult<List<T>> GetDataAll() => dalRepositorySql.ActionSimple.GetDataAll<T>();

        //public Task<RequestResult<Tuple<int>>> GetCountAsunc() => dalRepositorySql.ActionSimple.GetCountAsync<T>();
        //public RequestResult<Tuple<int>> GetCount() => dalRepositorySql.ActionSimple.GetCount<T>();

        //public Task<RequestResult<List<T>>> GetDataByQueryAsync(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.GetDataByQueryAsync<T>(predicate);
        //public RequestResult<List<T>> GetDataByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.GetDataByQuery<T>(predicate);

        //public Task<RequestResult<T>> GetDataFirstByQueryAsync(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.GetDataFirstByQueryAsync<T>(predicate);
        //public RequestResult<T> GetDataFirstByQuery(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.GetDataFirstByQuery<T>(predicate);

        //public Task<RequestResult<Tuple<bool, T>>> GetDataFirstByQueryCheckValidAsync(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.GetDataFirstByQueryCheckValidAsync<T>(predicate);
        //public RequestResult<Tuple<bool, T>> GetDataFirstByQueryCheckValid(Expression<Func<T, bool>> predicate) => dalRepositorySql.ActionSimple.GetDataFirstByQueryCheckValid<T>(predicate);

        //public Task<RequestResult<T>> GetDataByIdAsync(int id) => dalRepositorySql.ActionSimple.GetDataByIdAsunc<T>(id);
        //public RequestResult<T> GetDataById(int id) => dalRepositorySql.ActionSimple.GetDataById<T>(id);

        //public Task<RequestResult<Tuple<bool, T>>> GetDataByIdCheckValidAsunc(int id) => dalRepositorySql.ActionSimple.GetDataByIdCheckValidAsunc<T>(id);
        //public RequestResult<Tuple<bool, T>> GetDataByIdCheckValid(int id) => dalRepositorySql.ActionSimple.GetDataByIdCheckValid<T>(id);

        //public Task<RequestResult<T>> AddDataAsync(T data) => dalRepositorySql.Action.AddDataAsync<T>(data);
    }

    
}
