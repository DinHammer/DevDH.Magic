using System;
using System.Collections.Generic;
using System.Text;
using dalDataObjects = DevDH.Magic.Abstractions.DataObjects;
//using coreDataObjects = DevDH.Magic.Abstractions.DataObjects;
using System.Threading.Tasks;
using DevDH.Magic.Abstractions;
using System.Linq.Expressions;

namespace DevDH.Magic.DAL.RepositorySqlBaseAction
{
    public interface IBaseAction<T> where T : class, dalDataObjects.IBaseObjectSql
    {
        Task<RequestResult<T>> AddDataAsync(T data);
        RequestResult<T> AddData(T data);

        Task<RequestResult> AddDataRangeAsync(List<T> data);
        RequestResult AddDataRange(List<T> data);

        Task<RequestResult> UpdateDataAsync(T data);
        RequestResult UpdateData(T data);

        Task<RequestResult> UpdateDataRangeAsync(List<T> data);
        RequestResult UpdateDataRange(List<T> data);

        Task<RequestResult> DeleteAsync(T data);
        RequestResult Delete(T data);

        Task<RequestResult> DeleteRangeAsync(List<T> data);
        RequestResult DeleteRange(List<T> data);

        Task<RequestResult> DeleteByIdAsync(int id);
        RequestResult DeleteById(int id);

        Task<RequestResult> DeleteByQueryAsync(Expression<Func<T, bool>> predicate);
        RequestResult DeleteByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult> DeleteAllAsync();
        RequestResult DeleteAll();

        Task<RequestResult<List<T>>> GetDataAllAsunc();
        RequestResult<List<T>> GetDataAll();

        Task<RequestResult<Tuple<int>>> GetCountAsunc();
        RequestResult<Tuple<int>> GetCount();

        Task<RequestResult<List<T>>> GetDataByQueryAsync(Expression<Func<T, bool>> predicate);
        RequestResult<List<T>> GetDataByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult<T>> GetDataFirstByQueryAsync(Expression<Func<T, bool>> predicate);
        RequestResult<T> GetDataFirstByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult<Tuple<bool, T>>> GetDataFirstByQueryCheckValidAsync(Expression<Func<T, bool>> predicate);
        RequestResult<Tuple<bool, T>> GetDataFirstByQueryCheckValid(Expression<Func<T, bool>> predicate);

        Task<RequestResult<T>> GetDataByIdAsync(int id);
        RequestResult<T> GetDataById(int id);

        Task<RequestResult<Tuple<bool, T>>> GetDataByIdCheckValidAsunc(int id);
        RequestResult<Tuple<bool, T>> GetDataByIdCheckValid(int id);
    }
}
