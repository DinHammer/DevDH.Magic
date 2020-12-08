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
    public interface IBaseAction<T> where T : class, dalDataObjects.IBaseObjectId
    {
        Task<RequestResult<T>> mgcAsncAdd(T data);
        RequestResult<T> mgcAdd(T data);

        Task<RequestResult> mgcAsncAddRange(List<T> data);
        RequestResult mgcAddRange(List<T> data);

        Task<RequestResult> mgcAsncUpdate(T data);
        RequestResult mgcUpdate(T data);

        Task<RequestResult> mgcAsncUpdateRange(List<T> data);
        RequestResult mgcUpdateRange(List<T> data);

        Task<RequestResult> mgcAsncDelete(T data);
        RequestResult mgcDelete(T data);

        Task<RequestResult> mgcAsncDeleteRange(List<T> data);
        RequestResult mgcDeleteRange(List<T> data);

        Task<RequestResult> mgcAsncDeleteById(int id);
        RequestResult mgcDeleteById(int id);

        Task<RequestResult> mgcAsncDeleteByQuery(Expression<Func<T, bool>> predicate);
        RequestResult mgcDeleteByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult> mgcAsncDeleteAll();
        RequestResult mgcDeleteAll();

        Task<RequestResult<List<T>>> mgcAsncGetAll();
        RequestResult<List<T>> mgcGetAll();

        Task<RequestResult<Tuple<int>>> mgcAsncGetCount();
        RequestResult<Tuple<int>> mgcGetCount();

        Task<RequestResult<List<T>>> mgcAsncGetByQuery(Expression<Func<T, bool>> predicate);
        RequestResult<List<T>> mgcGetByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult<T>> mgcAsncGetFirstByQuery(Expression<Func<T, bool>> predicate);
        RequestResult<T> mgcGetFirstByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult<Tuple<bool, T>>> mgcAsncGetFirstByQueryCheckValid(Expression<Func<T, bool>> predicate);
        RequestResult<Tuple<bool, T>> mgcGetFirstByQueryCheckValid(Expression<Func<T, bool>> predicate);

        Task<RequestResult<T>> mgcAsncGetByIdAsync(int id);
        RequestResult<T> mgcGetById(int id);

        Task<RequestResult<Tuple<bool, T>>> mgcAsncGetByIdCheckValid(int id);
        RequestResult<Tuple<bool, T>> mgcGetByIdCheckValid(int id);
    }
}
