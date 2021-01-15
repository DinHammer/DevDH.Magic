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
        Task<RequestResult<T>> mgcAddAsnc(T data);
        RequestResult<T> mgcAdd(T data);

        Task<RequestResult> mgcAddRangeAsnc(List<T> data);
        RequestResult mgcAddRange(List<T> data);

        Task<RequestResult> mgcUpdateAsnc(T data);
        RequestResult mgcUpdate(T data);

        Task<RequestResult> mgcUpdateRangeAsnc(List<T> data);
        RequestResult mgcUpdateRange(List<T> data);

        Task<RequestResult> mgcDeleteAsnc(T data);
        RequestResult mgcDelete(T data);

        Task<RequestResult> mgcDeleteRangeAsnc(List<T> data);
        RequestResult mgcDeleteRange(List<T> data);

        Task<RequestResult> mgcDeleteByIdAsnc(int id);
        RequestResult mgcDeleteById(int id);

        Task<RequestResult> mgcDeleteByQueryAsnc(Expression<Func<T, bool>> predicate);
        RequestResult mgcDeleteByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult> mgcDeleteAllAsnc();
        RequestResult mgcDeleteAll();

        Task<RequestResult<List<T>>> mgcGetAllAsnc();
        RequestResult<List<T>> mgcGetAll();

        Task<RequestResult<Tuple<int>>> mgcGetCountAsnc();
        RequestResult<Tuple<int>> mgcSncGetCount();

        Task<RequestResult<List<T>>> mgcAsncGetByQuery(Expression<Func<T, bool>> predicate);
        RequestResult<List<T>> mgcSncGetByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult<T>> mgcAsncGetFirstByQuery(Expression<Func<T, bool>> predicate);
        RequestResult<T> mgcSncGetFirstByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult<Tuple<bool, T>>> mgcAsncGetFirstByQueryCheckValid(Expression<Func<T, bool>> predicate);
        RequestResult<Tuple<bool, T>> mgcSncGetFirstByQueryCheckValid(Expression<Func<T, bool>> predicate);

        Task<RequestResult<T>> mgcAsncGetById(int id);
        RequestResult<T> mgcSncGetById(int id);

        Task<RequestResult<Tuple<bool, T>>> mgcAsncGetByIdCheckValid(int id);
        RequestResult<Tuple<bool, T>> mgcSncGetByIdCheckValid(int id);
    }
}
