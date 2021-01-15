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

        Task<RequestResult<dalDataObjects.MgcInt>> mgcGetCountAsnc();
        RequestResult<dalDataObjects.MgcInt> mgcGetCount();

        Task<RequestResult<List<T>>> mgcGetByQueryAsnc(Expression<Func<T, bool>> predicate);
        RequestResult<List<T>> mgcGetByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult<T>> mgcGetFirstByQueryAsnc(Expression<Func<T, bool>> predicate);
        RequestResult<T> mgcGetFirstByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult<dalDataObjects.MgcBoolData<T>>> mgcGetFirstByQueryCheckValidAsnc(Expression<Func<T, bool>> predicate);
        RequestResult<dalDataObjects.MgcBoolData<T>> mgcGetFirstByQueryCheckValid(Expression<Func<T, bool>> predicate);

        Task<RequestResult<T>> mgcGetByIdAsnc(int id);
        RequestResult<T> mgcGetById(int id);

        Task<RequestResult<dalDataObjects.MgcBoolData<T>>> mgcGetByIdCheckValidAsnc(int id);
        RequestResult<dalDataObjects.MgcBoolData<T>> mgcGetByIdCheckValid(int id);
    }
}
